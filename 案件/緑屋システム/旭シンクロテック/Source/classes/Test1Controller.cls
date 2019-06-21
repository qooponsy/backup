public class Test1Controller {
    public Map<String,String> a {get;set;}

    //コンストラクタ
    public Test1Controller(){
        System.debug('★★★初期化');
        Test1();

        // Date a = MB_DateTimeUtil.Datetime2Str('2019/02/08', 'yyyy/MM/dd');//希望納期
        Date a = Date.parse('2019/02/08');
        
        System.debug('time::' + a);
        CheckMapOrder();
    }

    // 値の取得試すだけならこの関数の中に
    public void Test1() {
        String a = CommonItems.RECORDE_TYPE_MATERIAL.get(CommonItems.MATERIAL_LIST_SMALL);
        System.debug('★★★a：' + a);

        // Map<String, FixedValueList__c> mcs = FixedValueList__c.getAll();
        // FixedValueList__c mc = FixedValueList__c.getValues('ErrorURL__c');
        // FixedValueList__c mc = FixedValueList__c.getAll().values();
        // List<FixedValueList__c> mcs = FixedValueList__c.getAll().values();
        // System.debug('★★★mcs：' + mc);

        FixedValueList__c mc = FixedValueList__c.getInstance();
        System.debug('★★★mcs：' + mc);
        System.debug('★★★ErrorURL：' +  mc.ErrorURL__c);

    }

    public void CheckInitData() {
        System.debug('★★★初期処理：' + CommonItems.RECORDE_TYPE_MATERIAL);

        String bSamll = CommonItems.RECORDE_TYPE_MATERIAL.get(CommonItems.MATERIAL_LIST_SMALL);
        String bBig = CommonItems.RECORDE_TYPE_MATERIAL.get(CommonItems.MATERIAL_LIST_BIG); 

         System.debug('★★★big：' + bBig);
         System.debug('★★★small：' + bSamll);
    }

    public void getKeta() {
        System.debug('★★★getKeta呼ばれた');
    }

    public void getRecodeType() {

        ID recodeType = MB_SobjectUtil.getRecordType('ProcurementRequest__c', 'B_Material_Big');

        System.debug('★★★RecodeType：' + recodeType);
    }

    public void UpdateTest() {
        System.debug('★★★更新処理を始めるゾ☆');

        ProcurementRequest__c item = new ProcurementRequest__c();
        item.Id= 'a0H0k000004bVNJEA2';
        // item.Quantity__c = 2222;
        item.ProcurementRequestRemarks__c = '備考更新2';
        
        ProcurementRequest__c item2 = new ProcurementRequest__c();
        item2.Id= 'a0H0k000004bVNEEA2';
        item2.Quantity__c = 2222;

        List<ProcurementRequest__c> itemList = new List<ProcurementRequest__c>();
        itemList.add(item);
        itemList.add(item2);

        DaoProcurementRequest.Edit(itemList);
    }

    public void DeleteTest() {
        System.debug('★★★今日も削除処理を頑張るぞい☆');

        ID id1 = ID.valueOf('a0H0k000004bVGmEAM'); // 687
        ID id2 = ID.valueOf('a0H0k000004bVMuEAM'); // 688

        List<ID> idList = new List<ID>();
        idList.add(id1);
        idList.add(id2);

        DaoProcurementRequest.Remove(idList);
    }

    public void GetAccountList() {
        String a = 'a040k000008Sdv8AAC'; // 工事番号
        String b = 'a000k0000054nGpAAI'; // 資材名

        // 資材を取り扱っている取引先リスト取得
        List<AggregateResult> vendorList = new List<AggregateResult>();
        vendorList = DaoUnitPrice.getItemVendorList(b);

        System.debug('★★★list：' + vendorList);

        // 検索用リスト作成
        List<String> searchList = new List<String>();
        for(AggregateResult up : vendorList) {
            String sId = String.valueOf(up.get('Vendor__c'));
            searchList.add(sId);
        }

        System.debug('★★★list2：' + searchList);

        // 仕入れ先リスト取得
        List<AggregateResult> accountList = DaoConstructionAccount.getAccountList(a, searchList);

        System.debug('★★★accountList：' + accountList);
    }

    private void CheckMapOrder() {
        a = new Map<String,String>();
        a.put('01','01');
        a.put('100','100');
        a.put('05','05');
        a.put('2','2');

        for(String key : a.values()){
            System.debug('◇◇◇Map出力:' + key);
        }
    }


}