public with sharing class InvoiceVerificationController {

    /**
     * 初期処理（コンストラクタ）
     */
    public InvoiceVerificationController(){

    }

    @RemoteAction
    public static Map<String,String> getInvoiceInfo (String qrCode){
        MB_GenericDao dao = new MB_GenericDao('InvoiceInfo__c');

        Set<String> fields = new Set<String>{};
        fields.add('Id'); // Id
        fields.add('Name'); // 請求書情報
        fields.add('AccountName__c'); // 仕入先(参照)
        fields.add('AccountName__r.Name'); // 仕入先名
        fields.add('InvoiceMonth__c'); //請求月
        fields.add('TotalAmountTaxIn__c'); //請求書金額(税込)
        fields.add('ConstructionNumber__c'); // 工事番号
        fields.add('ConstructionNumber__r.Name'); // 工事番号名

        String query = dao.getSelectStr(fields);
        query += ' ';
        query += 'Where QRInfo__c = :qrCode	 ';

        System.debug('★★★qrCode：' + qrCode);
        System.debug('★★★query：' + query);

        List<InvoiceInfo__c> InvoiceInfoList = Database.query(query);

        System.debug('★★★List：' + InvoiceInfoList);

        Map<String,String> results = null;
        if(InvoiceInfoList.size() != 0) {
            results = new Map<String,String>();
            InvoiceInfo__c temp = InvoiceInfoList[0];

            results.put('id', temp.Id);
            results.put('name', temp.Name);
            results.put('account', temp.AccountName__c);
            results.put('accountName', temp.AccountName__r.Name);
            results.put('invoiceMonth', DateStrFormat(temp.InvoiceMonth__c));
            results.put('totalAmountTaxIn', temp.TotalAmountTaxIn__c.format());
            results.put('constructionNumber', temp.ConstructionNumber__c);
            results.put('constructionNumberName', temp.ConstructionNumber__r.Name);

            System.debug('★★★results：' + results);

        }

        return results;
    }

    @RemoteAction
    public static String invoiceVerification (String invoiceId, String invoiceAmountStr){
        boolean success = true;

        System.debug('★★★invoiceAmountStr：' + invoiceAmountStr);

        // 入力値を通貨型に変換
        String invoiceAmountIntStr = invoiceAmountStr.replace(',','');
        Decimal invoiceAmount = Decimal.valueOf(invoiceAmountIntStr);

        System.debug('★★★invoiceAmount：' + invoiceAmount);
        
        // 請求書情報取得
        MB_GenericDao dao = new MB_GenericDao('InvoiceInfo__c');
        Set<String> fields = new Set<String>{};
        fields.add('Name'); // 請求書情報
        fields.add('TotalAmountTaxIn__c'); // 請求書金額
        fields.add('AccountName__r.AccountID__c');

        String query = dao.getSelectStr(fields);
        query += ' ';
        query += 'Where Id = :invoiceId ';

        System.debug('★★★query：' + query);
        System.debug('★★★invoiceId：' + invoiceId);
        
        List<InvoiceInfo__c> InvoiceInfoList = Database.query(query);
        System.debug('★★★InvoiceInfoList：' + InvoiceInfoList);

        InvoiceInfo__c item = null;
        if(InvoiceInfoList == null) {
            // 取得できなければエラー
            success = false;
        } else {
            System.debug('nullでない');
            // 請求書金額とマスタ金額を比較
            item = InvoiceInfoList[0];
            if (invoiceAmount != item.TotalAmountTaxIn__c) {
                // 一致しなければエラー
                System.debug('★★★invoiceAmount：' + invoiceAmount);
                System.debug('★★★item => TotalAmountTaxIn__c：' + item.TotalAmountTaxIn__c);
                System.debug('一致せず');
                success = false;
            } else {
                // 明細の保存金額と自動金額の比較
                String header = item.Id;
                Set<String> dFields = new Set<String>{};
                dFields.add('Name'); // 請求書情報
                dFields.add('UnitPriceAuto__c'); // 単価(自動)
                dFields.add('UnitPriceSave__c'); // 単価(保存)
                dFields.add('QuantityAuto__c'); // 数量（自動）
                dFields.add('QuantitySave__c'); // 数量（保存）
                dFields.add('MoneyIncludTaxAuto__c'); // 税込金額（自動）
                dFields.add('MoneyIncludTaxSave__c'); // 税込金額（保存）

                query = dao.getSelectStr(dFields);
                query += ' ';
                query += 'Where InvoiceInfoHeader__c = :header ';

                System.debug('★★★query：' + query);
                System.debug('★★★header：' + header);

                List<InvoiceInfo__c> detailList = Database.query(query);

                System.debug('★★★detailList：' + detailList);

                for(InvoiceInfo__c d : detailList) {
                    // 単価比較
                    if(d.UnitPriceAuto__c != d.UnitPriceSave__c) {
                        success = false;
                    }

                    // 数量比較
                    if(d.QuantityAuto__c != d.QuantitySave__c) {
                        success = false;
                    }

                    // 税込金額比較
                    if(d.MoneyIncludTaxAuto__c != d.MoneyIncludTaxSave__c) {
                        success = false;
                    }

                    if(success == false) {
                        System.debug('★★★detail：' + d);
                        break;
                    }
                }

            }
        }

        String ret = '';
        if (!success) {
            // 一致しなければエラーリンクを返却

            // URLを動的生成
            FixedValueList__c cosnt = FixedValueList__c.getInstance();
            String url = cosnt.ErrorURL__c + '?accountid=' + item.AccountName__r.AccountID__c;
            System.debug('★★★url：' + url);

            ret = url;
        } else {
            // 完全一致していればステータス更新
            item.InvoiceCheck__c = true;
            Database.update(item);
        }

        return ret;
    }

    @RemoteAction
    public static String registOBICData (String invoiceId){
        String errorMsg = '';

        try{
            // 請求書情報取得
            MB_GenericDao dao = new MB_GenericDao('InvoiceInfo__c');

            Set<String> fields = new Set<String>{};
            fields.add('Id'); // Id
            fields.add('Name'); // 請求書情報
            fields.add('InvoiceMonth__c'); // 請求月
            fields.add('AccountName__r.Name'); // 仕入先名
            fields.add('AccountName__r.TermsOfPayment__c'); // 支払サイト(月区分)
            fields.add('AccountName__r.TermsOfPaymentDay__c'); // 支払サイト(日区分)

            String query = dao.getSelectStr(fields);
            query += ' ';
            query += 'Where Id = :invoiceId ';

            System.debug('★★★query：' + query);
            System.debug('★★★invoiceId：' + invoiceId);
            
            List<InvoiceInfo__c> InvoiceInfoList = Database.query(query);

            if(InvoiceInfoList == null) {
                // 取得できなければエラー
                errorMsg = '対象のデータが見つかりませんでした。';
            } else {
                System.debug('nullでない');
                
                InvoiceInfo__c ii  = InvoiceInfoList[0];
                System.debug('★★★ii：' + ii);

                // 明細情報取得
                String header = ii.Id;
                Set<String> dFields = new Set<String>{};
                dFields.add('Name'); // 請求書情報
                dFields.add('ItemCode__c'); // 資材コード
                dFields.add('MoneySave__c'); // 勢抜き金額（保存）

                query = dao.getSelectStr(dFields);
                query += ' ';
                query += 'Where InvoiceInfoHeader__c = :header ';

                List<InvoiceInfo__c> detailList = Database.query(query);
                System.debug('★★★detailList：' + detailList);

                // 登録データ作成
                OBIC_Confirmation__c item = new OBIC_Confirmation__c();

                // 請求書情報
                item.InvoiceHeader__c = ii.Id;

                // 請求月
                // String invoiceMonth = invoiceMonthStr.deleteWhitespace();
                item.PaymentDueDate__c = MB_AccUtil.getBillingDate(ii.InvoiceMonth__c, ii.AccountName__r.TermsOfPayment__c, ii.AccountName__r.TermsOfPaymentDay__c);
                System.debug(item.PaymentDueDate__c);

                // 商品コードごとに税抜き金額をサマリー
                Map<String, OBIC_Confirmation__c> regMap = new Map<String, OBIC_Confirmation__c>();
                for (InvoiceInfo__c d : detailList) {
                    if(regMap.containsKey(d.ItemCode__c)) {
                        OBIC_Confirmation__c reg = regMap.get(d.ItemCode__c);
                        reg.Amount__c += d.MoneySave__c;

                        regMap.remove(d.ItemCode__c);
                        regMap.put(d.ItemCode__c, reg);
                    } else {
                        // key がない場合新規登録
                        OBIC_Confirmation__c reg = item.clone(false,true,false,false );
                        reg.ItemCode__c = d.ItemCode__c;
                        reg.Amount__c = d.MoneySave__c;

                        regMap.put(d.ItemCode__c, reg);
                    }
                }

                // 登録用リストに明細行番号付与して作成
                List<OBIC_Confirmation__c> regList = new List<OBIC_Confirmation__c>();
                Integer cnt = 1;
                for(String key : regMap.keySet()) {
                    OBIC_Confirmation__c reg = regMap.get(key);
                    reg.DetailNo__c = String.valueOf(cnt);
                    regList.add(reg);
                    cnt += 1;
                }

                Database.Insert(regList);
            }

        } catch(Exception e) {
            System.debug('!!!!エラー：' + e.getMessage() + '\n' + e.getStackTraceString());
            // errMsg = '登録処理に失敗しました。';
            errorMsg = e.getMessage() + '\n' + e.getStackTraceString();
        }

        return errorMsg;
    }

    public static String DateStrFormat(Date d) {
        DateTime dt = Datetime.newInstance(d.year(), d.month(), d.day());
        String dt_str = dt.format('yyyy / MM');

        return dt_str;
    }

}