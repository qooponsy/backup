public with sharing class MaterialController {
    //オブジェクト参照用
    public List<Construction__c> ConstructionList {get; set;}
    public List<Category__c> CategoryItemList {get; set;}

    //画面表示用
    public String errorMes {get;set;} //エラー表示用
    public List<Map<String,String>> ConstructionDisplay {get;set;} //選択画面1
    public String divisionSmall {get;set;} //選択画面1 B材・小口
    public String divisionBig {get;set;} //選択画面1 B材・大口
    public Map<String,Map<String, List<List<String>>>> Selection2Display {get; set;} // 選択画面2
    // public List<Category__c> Selection3Display {get;set;} //選択画面3
    public Map<String,List<String>> Selection3Display {get;set;} //選択画面3
    public String Selection4Label {get;set;} //選択画面4 資材名
    public List<Item__c> Selection4Size {get;set;} //選択画面4 サイズ
    public List<SelectOption> Selection4SizeList {get;set;} //選択画面4 サイズ表示用
    public List<ProcurementRequest__c> List1InputList {get;set;} //一覧画面1 レコード表示用・入力中
    public List<ProcurementRequest__c> List1ConfirmationList {get;set;} //一覧画面1 レコード表示用・決裁者確認中
    public List<ProcurementRequest__c> List1ApprivalList {get;set;} //一覧画面1 レコード表示用・承認
    public List<ProcurementRequest__c> List1RejectionList {get;set;} //一覧画面1 レコード表示用・却下
    // public List<ProcurementRequest__c> List1ProcurementList {get;set;} //一覧画面1 レコード表示用・調達依頼中
    // public MAP<String,List<ProcurementRequest__c>> List1TempList {get;set;} //一覧画面1 復元用
    public MAP<String,Map<String, Map<String, String>>> List1TempList {get;set;} //一覧画面1 復元用
    public Item__c List1EditList {get;set;} //一覧画面1 編集遷移時のデータ取得用
    public List<SelectOption> List1AmPmList {get;set;} //一覧画面1 AM/PM選択用
    public List<Map<String,String>> UpdateList {get;set;} //一覧画面2 更新対象データ表示｜テーブル更新用
    public List<Map<String,String>> List2InputList {get;set;} //一覧画面2 更新対象データ表示,入力中
    public List<Map<String,String>> List2RejectionList {get;set;} //一覧画面2 更新対象データ表示,却下

    public Map<String, Map<String, String>> List1InputMap {get;set;}
    public Map<String, Map<String, String>> List1RejectionMap {get;set;}

    //入力値格納用
    public static String ConstructionNumber {get;set;} //工事番号
    public static String Procurementnumber {get;set;} //調達番号
    public static String division {get;set;} //B材選択値 => division
    public static String classification {get;set;} //分類
    public static String material {get;set;} //材質
    public static String item {get;set;} //品名
    public static String standard1 {get;set;} //規格1
    public static String standard2 {get;set;} //規格2
    public static String size {get;set;} //サイズ
    public static String volume {get;set;} //数量
    public static String note {get;set;} //備考
    public static String unit {get;set;} //単位
    public static String PRId {get;set;} //調達依頼オブジェクトID
    public static String ConstructionName {get;set;} //工事名
    public static String ConstructionRecordTypeId {get;set;} //工事番号レコードタイプ
    

    //init
    public void init(){
        // マスタデータ
        ConstructionList = new List<Construction__c>();
        CategoryItemList = new List<Category__c>();

        // 画面表示用
        ConstructionDisplay = new List<Map<String,String>>();
        Selection2Display = new Map<String,Map<String, List<List<String>>>>();
        // Selection3Display = new List<Category__c>();
        Selection3Display = new Map<String, List<String>>();
        Selection4SizeList = new List<SelectOption>();
        List1InputList = new List<ProcurementRequest__c>();
        List1ConfirmationList = new List<ProcurementRequest__c>();
        List1ApprivalList = new List<ProcurementRequest__c>();
        List1RejectionList = new List<ProcurementRequest__c>();
        // List1ProcurementList = new List<ProcurementRequest__c>();
        List1EditList = new Item__c();
        List1AmPmList = new List<SelectOption>();
        List1TempList = null; // 初期値null
        // bbbMap = new Map<String,String>();
        // bbbMap.put('1','');
        UpdateList = new List<Map<String,String>>();
        List2InputList = new List<Map<String,String>>();
        List2RejectionList = new List<Map<String,String>>();  

    }

    //コンストラクタ
    public MaterialController(){
        //初期化処理(必ず呼ぶこと！！)
        init();

        // 工事番号マスタの取得
        this.ConstructionList = DaoConstruction.getConstructionList();
        if(ConstructionList.isEmpty()){
            //マスタが存在しなかった時の処理
        }

        // カテゴリマスタの取得
        this.CategoryItemList = DaoCategory.getItemList();
        if(CategoryItemList.isEmpty()){
            //マスタが存在しなかった時の処理
        }
        //B材定数取得
        divisionSmall = CommonItems.MATERIAL_LIST_SMALL;
        divisionBig = CommonItems.MATERIAL_LIST_BIG;

        // 選択①画面の表示用データ作成
        System.debug('マスタ取得件数:' + ConstructionList.size());
        //repeatタグ用変数の生成
        for (Construction__c value : this.ConstructionList) {
            //用意しておいた画面表示用配列に入れていく
            ConstructionDisplay.add(new Map<String,String>{'value' => value.Name, 'label' => value.ConstructionName__c, 'record_type' => ID.valueOf(value.RecordTypeId)});
        }

        // 選択②画面の表示用データ作成
        CreateSelection2View();

    }

    //リダイレクト処理
    //資材選択2画面
    public PageReference checkRedirect(){
        //工事番号と区分をチェック
        PageReference ret = null;
        System.debug('★★★：' + ConstructionNumber);
        System.debug('★★★division：' + division);
        //工事番号
        if(ConstructionNumber == null){
            ret = Page.MaterialSelection1;
            System.debug('★★★：工事番号ifを通った');
        }
        //区分
        if(division == null){
            ret = Page.MaterialSelection1;
            System.debug('★★★：区分ifを通った');
        }
        System.debug('★★★ret：' + ret);
        return ret;
    }

    //ページ遷移
    //資材選択1から2
    public PageReference transition1Next(){
        return Page.MaterialSelection2;
    }
    //資材選択2から3
    public PageReference transition2Next(){
        PageReference ret = null;

        System.debug('★★★classification:' + classification);
        System.debug('★★★material:' + material);
        System.debug('★★★item:' + item);
        //規格マスタの取得
        Selection3Display.clear();
        List<Category__c> StandardList = DaoCategory.getStandardList(classification,material,item);
        // Selection3Display = DaoCategory.getStandardList(classification,material,item);
        
        //ページ遷移の判定(1行であれば[規格1]を確認 複数行であればSelection3に遷移)
        if(StandardList.size() == 1){
            String tgt = (StandardList[0].Standard1__c == null) ? '' : StandardList[0].Standard1__c;
            //null,空文字,半角空白のチェック
            if(String.isBlank(tgt)){
                ret = Page.MaterialSelection4;
                Selection4Label = item + '_' + material;
                //選択4画面の準備
                Category__c category = new Category__c();
                category.Classification__c = classification;
                category.Material__c = material;
                category.Item__c = item;
                // category.Standard1__c = standard1;
                // category.Standard2__c = standard2;
                System.debug('★★★category:' + category);
                Selection4Size = DaoItem.getStandardList(category);
                System.debug('★★★Selection4Size:' + Selection4Size);

                Selection4SizeList.clear();
                for (Item__c size : Selection4Size) {
                    String tmpOption =  size.Size__c;
                    System.debug('★★★tmpOption:' + tmpOption);
                    System.debug('★★★Selection4SizeList:' + Selection4SizeList);
                    Selection4SizeList.add(new SelectOption(tmpOption, tmpOption));
                }

                System.debug('★★★size1,isBlank => Selection4');
            }else{
                List<String> standard2List = new List<String>();
                standard2List.add(StandardList[0].Standard2__c);
                Selection3Display.put(tgt, standard2List);
                ret = Page.MaterialSelection3;
                System.debug('★★★size1,notBlank => Selection3');
                System.debug('★★★Selection3Display:' + Selection3Display);
            }
        }else if(StandardList.size() > 1){
            for(Category__c c : StandardList) {
                String key = (c.Standard1__c == null) ? '' : c.Standard1__c;
                if(!Selection3Display.containsKey(key)) {
                    // 未登録の場合
                    // List<String> standard2List = null;
                    List<String> standard2List = new List<String>();
                    String s2 = '';
                    if (c.Standard2__c != null) {
                        s2 = c.Standard2__c;
                        // standard2List = new List<String>();
                        standard2List.add(s2);
                    }else {
                        standard2List.add('nullデータ');
                    }
                    Selection3Display.put(key, standard2List);
                } else {
                    // 登録済みの場合
                    List<String> standard2List = Selection3Display.get(key);
                    if (standard2List == null) {
                        standard2List = new List<String>();
                        standard2List.add('');
                    }
                    String s2 = '';
                    if (c.Standard2__c != null) {
                        s2 = c.Standard2__c;
                    }else{
                        s2 = 'nullデータ';
                    }
                    standard2List.add(s2);
                    Selection3Display.remove(key);
                    Selection3Display.put(key, standard2List);
                }
            }

            System.debug('★★★Selection3Display:' + Selection3Display);
            
            ret = Page.MaterialSelection3;
            System.debug('★★★size>1 => Selection3');
        }

        return ret;
    }
    //資材選択3から4
    public PageReference transition3Next(){
        classification = System.currentPageReference().getParameters().get('classification');
        material = System.currentPageReference().getParameters().get('material');
        item = System.currentPageReference().getParameters().get('item');
        standard1 = System.currentPageReference().getParameters().get('standard1');
        standard2 = System.currentPageReference().getParameters().get('standard2');
        System.debug('★★★classification:' + classification);
        System.debug('★★★material:' + material);
        System.debug('★★★item:' + item);
        System.debug('★★★standard1:' + standard1);
        System.debug('★★★standard2:' + standard2);

        //サイズ取得
        Category__c category = new Category__c();
        category.Classification__c = classification;
        category.Material__c = material;
        category.Item__c = item;
        category.Standard1__c = standard1;
        category.Standard2__c = standard2;
        System.debug('★★★category:' + category);
        Selection4Size = DaoItem.getStandardList(category);
        System.debug('★★★Selection4Size:' + Selection4Size);
        //サイズコンボボックス成型
        Selection4SizeList.clear();
        for (Item__c tgt : Selection4Size) {
            String tmpOption =  tgt.Size__c;
            System.debug('★★★tmpOption:' + tmpOption);
            System.debug('★★★Selection4SizeList:' + Selection4SizeList);
            Selection4SizeList.add(new SelectOption(tmpOption, tmpOption));
        }
        System.debug('★★★Selection4SizeList:' + Selection4SizeList);

        //資材名ラベル連結
        String tmpLabelString = material + '_' + item;
        System.debug('String,isNotBlank(standard1):' + String.isNotBlank(standard1));
        if(String.isNotBlank(standard1)){
            tmpLabelString = tmpLabelString + '_' + standard1;
            System.debug('規格1のifに入った');
            System.debug('String,isNotBlank(standard2):' + String.isNotBlank(standard2));
            if(String.isNotBlank(standard2)){
                tmpLabelString = tmpLabelString + '×' + standard2;
                System.debug('規格2のifに入った');
            }
        }
        Selection4Label = tmpLabelString;
        System.debug('★★★Selection4Label:' + Selection4Label);

        return Page.MaterialSelection4;
    }
    public PageReference transitionList1Next(){
 
        //UpdateListの初期化
        UpdateList.clear();
        List2InputList.clear();
        List2RejectionList.clear();
        System.debug('☆☆☆');
        System.debug('☆☆☆List1InputList:' + List1InputList);
        System.debug('☆☆☆List1InputMap:' + List1InputMap);
        Integer count = 0;
        //チェックボックスのtrue項目のみ抜き出す
        for(Map<String,String> inputtgt : List1InputMap.values()){ //Inputのfor
            if(inputtgt.get('AmPm') == null){
                    inputtgt.put('AmPm', '');
            }
            if(inputtgt.get('Check') == 'true'){
                UpdateList.add(inputtgt); //テーブル更新用リスト
                List2InputList.add(inputtgt); //表示用リスト
            }
            count++;
        }
        for(Map<String,String> rejectiontgt : List1RejectionMap.values()){ //rejectionのfor
            if(rejectiontgt.get('AmPm') == null){
                    rejectiontgt.put('AmPm', '');
            }
            if(rejectiontgt.get('Check') == 'true'){
                UpdateList.add(rejectiontgt); //テーブル更新用リスト
                List2RejectionList.add(rejectiontgt); //表示用リスト
            }
            count++;
        }
        System.debug('☆☆Loopcount:' + count);
        System.debug('☆☆UpdateList:' + UpdateList);
        System.debug('☆☆UpdateList Count:' + UpdateList.size());

        // 戻る動作用の復元データリストの作成
        List1TempList = null;
        List1TempList = new Map<String, Map<String, Map<String, String>>>();
        List1TempList.put('Input', List1InputMap.clone());
        List1TempList.put('Rejection', List1RejectionMap.clone());

        return Page.MaterialList2;
    }
    //選択2画面検索機能からの遷移
    public PageReference transition2SearchNext(){
        System.debug('★★★classification:' + classification);
        System.debug('★★★material:' + material);
        System.debug('★★★item:' + item);
        System.debug('★★★standard1:' + standard1);
        System.debug('★★★standard2:' + standard2);
        //サイズ取得
        Category__c category = new Category__c();
        category.Classification__c = classification;
        category.Material__c = material;
        category.Item__c = item;
        category.Standard1__c = standard1;
        category.Standard2__c = standard2;
        System.debug('★★★category:' + category);
        Selection4Size = DaoItem.getStandardList(category);
        System.debug('★★★Selection4Size:' + Selection4Size);
        //サイズコンボボックス成型
        Selection4SizeList.clear();
        for (Item__c tgt : Selection4Size) {
            String tmpOption =  tgt.Size__c;
            System.debug('★★★tmpOption:' + tmpOption);
            System.debug('★★★Selection4SizeList:' + Selection4SizeList);
            Selection4SizeList.add(new SelectOption(tmpOption, tmpOption));
        }
        System.debug('★★★Selection4SizeList:' + Selection4SizeList);

        //資材名ラベル連結
        String tmpLabelString = item + '_' + material;
        System.debug('String,isNotBlank(standard1):' + String.isNotBlank(standard1));
        if(String.isNotBlank(standard1)){
            tmpLabelString = tmpLabelString + '_' + standard1;
            System.debug('規格1のifに入った');
            System.debug('String,isNotBlank(standard2):' + String.isNotBlank(standard2));
            if(String.isNotBlank(standard2)){
                tmpLabelString = tmpLabelString + '_' + standard2;
                System.debug('規格2のifに入った');
            }
        }
        Selection4Label = tmpLabelString;
        System.debug('★★★Selection4Label:' + Selection4Label);

        return Page.MaterialSelection4;
    }

    //戻る処理
    //資材選択2
    public PageReference transition2Back(){
        return Page.MaterialSelection1;
    }
    //資材選択3
    public PageReference transition3Back(){
        classification = System.currentPageReference().getParameters().get('classification');
        material = System.currentPageReference().getParameters().get('material');
        item = System.currentPageReference().getParameters().get('item');

        return Page.MaterialSelection2;
    }
    //資材選択4
    public PageReference transition4Back(){
        PageReference ret = null;
        classification = System.currentPageReference().getParameters().get('classification');
        material = System.currentPageReference().getParameters().get('material');
        item = System.currentPageReference().getParameters().get('item');
        standard1 = System.currentPageReference().getParameters().get('standard1');
        standard2 = System.currentPageReference().getParameters().get('standard2');

        if(standard1 == '' ) {
            ret = transition1Next();
        } else {
            ret = transition2Next();
        }

        return ret;
    }
    //資材一覧1への遷移
    //---!! 一覧1画面への遷移元は複数あるため命名規則を分離 !!---
    public PageReference transitionToList1(){
        PageReference ret = null;
        //SOQLにて調達依頼オブジェクトの取得 -> 各ステータスごとにListを生成(入力中・決裁者確認中・承認・却下)
        Integer limitation = 100;

        // 復元リストがあれば復元リストの中身を表示
        if(List1TempList != null) {
            // List1InputList = List1TempList.get('Input');
            // List1ConfirmationList = List1TempList.get('Confirmation');
            // List1ApprivalList = List1TempList.get('Apprival');
            // List1RejectionList = List1TempList.get('Rejection');
            // List1ProcurementList = List1TempList.get('Procurement');

            // List1InputMap = convertList1(List1InputList);
            // List1RejectionMap = convertList1(List1RejectionList);

            List1InputMap = List1TempList.get('Input');
            List1RejectionMap = List1TempList.get('Rejection');
            System.debug('★★★List1TempList：' + List1TempList);
            System.debug('★★★List1InputMap：' + List1InputMap);
        } else {

            // 入力中
            List1InputList = DaoProcurementRequest.getInputList(ConstructionNumber, division, CommonItems.PROCUREMENTS_STATUS_INPUT, limitation);
            // Map<String, Map<String,String>> a = new Map<String, ProcurementRequest__c>();
            // for(ProcurementRequest__c aList : List1InputList){
            //     a.put(aList.ProcurementRequestNumber__c, {bbb => ''});
            // }
            List1InputMap = convertList1(List1InputList); //
            System.debug('☆List1InputMap:' + List1InputMap);
            
            limitation -= List1InputList.size();
            System.debug('★★★:limitation' + limitation);
            
            //調達依頼中
            // if (limitation > 0) {
            //     List1ProcurementList = DaoProcurementRequest.getInputList(ConstructionNumber, division, CommonItems.PROCUREMENTS_STATUS_PROCUREMENT, limitation);
            //     limitation -= List1ProcurementList.size();
            //     System.debug('★★★:limitation' + limitation);
            // }
            
            // 決裁者確認中
            if (limitation > 0) {
                List1ConfirmationList = DaoProcurementRequest.getInputList(ConstructionNumber, division, CommonItems.PROCUREMENTS_STATUS_CHECK, limitation);
                limitation -= List1ConfirmationList.size();
                System.debug('★★★:limitation' + limitation);
            }
            
            // 却下
            if (limitation > 0) {
                List1RejectionList = DaoProcurementRequest.getInputList(ConstructionNumber, division, CommonItems.PROCUREMENTS_STATUS_REJECTION, limitation);
                List1RejectionMap = convertList1(List1RejectionList);
                System.debug('☆List1RejectionMap:' + List1RejectionMap);
                limitation -= List1RejectionList.size();
                System.debug('★★★:limitation' + limitation);
            }
        }

        

        // PROCUREMENTS_STATUS_PROCUREMENT
        

        System.debug('★★★List1InputList:' + List1InputList);
        System.debug('★★★List1ConfirmationList:' + List1ConfirmationList);
        // System.debug('★★★List1ApprivalList:' + List1ApprivalList);
        System.debug('★★★List1RejectionList:' + List1RejectionList);
        //System.debug('★★★List1ProcurementList:' + List1ProcurementList);

        //調達依頼番号の初期化
        Procurementnumber = '';

        //AM/PM用selectOptionの用意
        List1AmPmList.clear();
        System.debug('ampm::::::' + CommonItems.AMPM_LIST);
        List1AmPmList.add(new selectOption('','なし'));
        for(String tgt : CommonItems.AMPM_LIST){
            List1AmPmList.add(new selectOption(tgt, tgt));
        }

        ret = Page.MaterialList1;

        return ret;
    }
    //資材一覧1画面・「編集」ボタン
    public PageReference transitionList1Edit(){
        // 不要リストクリア
        List1TempList = null;

        PageReference ret = null;
        String materialId;
        //資材選択4画面への遷移に必要なパラメータの取得 -> 分類、材質、品名、規格1、規格2、サイズ、備考|区分、数量
        // classification = System.currentPageReference().getParameters().get('classification');
        // material = System.currentPageReference().getParameters().get('material');
        // item = System.currentPageReference().getParameters().get('item');
        // division = System.currentPageReference().getParameters().get('division');
        // standard1 = System.currentPageReference().getParameters().get('standard1');
        // standard2 = System.currentPageReference().getParameters().get('standard2');
        // size = System.currentPageReference().getParameters().get('size');
        volume = System.currentPageReference().getParameters().get('volume');
        note = System.currentPageReference().getParameters().get('note');
        MaterialId = System.currentPageReference().getParameters().get('MaterialId');
        Procurementnumber = System.currentPageReference().getParameters().get('ProcurementRequestNumber');
        PRId = System.currentPageReference().getParameters().get('Id'); //調達依頼オブジェクトのID
        System.debug('★★★MaterialId:' + MaterialId);

        // System.debug('★★★bbbMap:' + bbbMap);

        //取得した資材マスタのIDから資材選択4画面への遷移に必要なパラメータを取得
        List1EditList = DaoItem.getItemObject(MaterialId);
        //取得したマスタから情報の参照
        classification = List1EditList.Classification__c;
        material = List1EditList.Material__c;
        item = List1EditList.Item__c;
        standard1 = List1EditList.Standard1__c;
        standard2 = List1EditList.Standard2__c;
        size = List1EditList.Size__c;
        unit = List1EditList.Unit__c;
        System.debug('★★★classification:' + classification);
        System.debug('★★★material:' + material);
        System.debug('★★★item:' + item);
        System.debug('★★★division:' + division);
        System.debug('★★★standard1:' + standard1);
        System.debug('★★★standard2:' + standard2);
        System.debug('★★★size:' + size);
        System.debug('★★★unit:' + unit);
        System.debug('★★★note:' + note);
        //サイズ取得
        Category__c category = new Category__c();
        category.Classification__c = classification;
        category.Material__c = material;
        category.Item__c = item;
        category.Standard1__c = standard1;
        category.Standard2__c = standard2;
        System.debug('★★★category:' + category);
        Selection4Size = DaoItem.getStandardList(category);
        System.debug('★★★Selection4Size:' + Selection4Size);
        //サイズコンボボックス成型
        Selection4SizeList.clear();
        for (Item__c tgt : Selection4Size) {
            String tmpOption =  tgt.Size__c;
            System.debug('★★★tmpOption:' + tmpOption);
            System.debug('★★★Selection4SizeList:' + Selection4SizeList);
            Selection4SizeList.add(new SelectOption(tmpOption, tmpOption));
        }
        System.debug('★★★Selection4SizeList:' + Selection4SizeList);
        //資材名ラベル連結
        String tmpLabelString = material + '_' + item;
        if(String.isNotBlank(standard1)){
            tmpLabelString = tmpLabelString + '_' + standard1;
            System.debug('規格1のifに入った');
            System.debug('String,isNotBlank(standard2):' + String.isNotBlank(standard2));
            if(String.isNotBlank(standard2)){
                tmpLabelString = tmpLabelString + '×' + standard2;
                System.debug('規格2のifに入った');
            }
        }
        Selection4Label = tmpLabelString;
        System.debug('★★★Selection4Label:' + Selection4Label);

        //サイズと単位に必要な資材マスタのList

        ret = Page.MaterialSelection4;
        return ret;
    }

    //資材一覧2｜「承認申請」ボタン
    public PageReference appUpdateList2(){
        // 不要リストのクリア
        List1TempList = null;
        
        PageReference ret = null;
        // TODO:調達依頼オブジェクトのListに再加工
        List<ProcurementRequest__c> updItemList = new List<ProcurementRequest__c>();
        System.debug('☆一覧1で使っていたList::' + UpdateList);
        for(Map<String,String> tgt : UpdateList){
            System.debug('☆一覧1で使っていたListの中身::' + tgt);
            ProcurementRequest__c tgtItem = new ProcurementRequest__c();
            tgtItem.Id = tgt.get('Id');                                                   //更新対象のID
            tgtItem.AmPm__c = tgt.get('AmPm');                                            //AM/PM区分
            if(division==CommonItems.MATERIAL_LIST_SMALL || (division==CommonItems.MATERIAL_LIST_BIG && tgt.get('DeliveryPlaceC')!='')){
                tgtItem.DeliveryPlace__c = tgt.get('DeliveryPlaceC');                         //納品先
            }
            if(division==CommonItems.MATERIAL_LIST_SMALL || (division==CommonItems.MATERIAL_LIST_BIG && tgt.get('DesiredDeliveryDateC')!='')){
                tgtItem.DesiredDeliveryDate__c = Date.parse(tgt.get('DesiredDeliveryDateC')); //希望納期
            }
            if(division!=CommonItems.MATERIAL_LIST_BIG){
                tgtItem.Vendor__c = tgt.get('VendorC');                                   //仕入先(小口のみ)
            }
            if(division!=CommonItems.MATERIAL_LIST_BIG){
                tgtItem.TransactionStatus__c = CommonItems.PROCUREMENTS_STATUS_CHECK;     //取引ステータス(小口のみ)
            }
            tgtItem.RequestMailSend__c = false; //承認依頼メール送信済フラグ(必ずfalseにする)
            updItemList.add(tgtItem);
        }
        //更新カラム：AmPm__c(AM/PM区分), DeliveryPlace__c(納品先), DesiredDeliveryDate__c(希望納期), Vendor__c(仕入先)
        System.debug('☆マスタ登録用のList::' + updItemList);
        Boolean editRet = DaoProcurementRequest.Edit(updItemList); //データ更新関数
        // if(editRet){
            // 資材○○に遷移
            // ret = Page.MaterialList1;
            List1TempList = null;
            ret = transitionToList1();
        // }else{
            //元のページ？(POSTバックになってしまう？)
        // }

        return ret;
    }

    public PageReference transition1(){
        // 不要データ初期化
        List1TempList = null;
        return Page.MaterialSelection1;
    }
    /*public PageReference transition2(){
        PageReference pageRef = Page.MaterialSelection2;
        pageRef.getParameters().put('ConstructionNumber', ConstructionNumber);

        return pageRef;
    }*/
    public PageReference transition3(){
        return Page.MaterialSelection3;
    }
    public PageReference transition4(){
        //サイズ、数量、備考欄の初期化
        size = '';
        volume = '';
        note = '';

        return Page.MaterialSelection4;
    }
    public PageReference transitionList1(){
        return Page.MaterialList1;
    }

    public void CreateSelection2View(){
        for (Category__c value : this.CategoryItemList) {
            
            // 分類が格納してあるか確認
            String classification =  value.SortClassification__c + '_' + value.Classification__c ;
            // String sortClassification = value.SortClassification__c ;
            if ( Selection2Display.containsKey(classification) ) {
                // 分類格納済み
                // 　なにもしない
            }else {
                // 分類未格納
                Map<String, List<List<String>>> MaterialList = new Map<String, List<List<String>>>();
                Selection2Display.put(classification, MaterialList);
            }

            //  材質が格納してあるか確認
            String Material = value.SortMaterial__c + '_' + value.Material__c;
            Map<String, List<List<String>>> MaterialList = Selection2Display.get(Classification);
            if (MaterialList.containsKey(Material)) {
                // 材質格納済み
                // 　なにもしない
            }else {
                // 材質未格納
                List<List<String>>  ItemList = new List<List<String>>();
                MaterialList.put(Material, ItemList);
            }

            // 品名を格納
            String item = value.SortItem__c + '_' + value.Item__c;
            List<List<String>> ItemList = Selection2Display.get(Classification).get(Material);
            if (ItemList.isEmpty()) {
                // 1レコード分の品名リストを作成
                List<String> ItemRow = new List<String>();
                ItemRow.add(item);
                ItemList.add(ItemRow);
            }else {
                // 1レコード3件ずつのリストを作成
                List<String> ItemRow = ItemList.get(ItemList.size()-1);
                if (ItemRow.size() < 3){
                    ItemRow.add(item);
                }else {
                    List<String> NewItemRow = new List<String>();
                    NewItemRow.add(item);
                    ItemList.add(NewItemRow);
                }
            }
        }
        System.debug('★★★Selection2Display：' + Selection2Display); //最終結果取得

    }
    public Map<String, Map<String, String>> convertList1(List<ProcurementRequest__c> tgtList){
        Map<String, Map<String, String>> retMap = new Map<String, Map<String, String>>(); //map<調達番号, map<'(カラム名)', '値'>>
        for(ProcurementRequest__c tgt : tgtList){
            String PRNumber = tgt.ProcurementRequestNumber__c; //調達番号
            // retMap.put(PRNumber, {カラム名 => 値});
            System.debug('☆☆☆tgtList:' + tgtList);
            System.debug('☆☆☆tgt:' + tgt);
            System.debug('☆☆☆PRNumber:' + PRNumber);

            // エラーになるためここで参照関係型を文字列に
            String VendorC = tgt.Vendor__c;
            String DeliveryPlaceC = tgt.DeliveryPlace__c;

            Map<String, String> oneData = new Map<String, String>();
            oneData.put('ProcurementRequestNumberC', tgt.ProcurementRequestNumber__c); //調達依頼番号
            oneData.put('TransactionStatusC', tgt.TransactionStatus__c); //取引ステータス
            oneData.put('QuantityC' , (tgt.Quantity__c).format()); //数量
            oneData.put('QuantityUnitC' , tgt.QuantityUnit__c); //数量単位
            oneData.put('ItemNameC' , tgt.ItemName__c); //資材名：ID
            oneData.put('ItemNameR' , tgt.ItemName__r.Name); //資材名
            oneData.put('VendorR' , (tgt.Vendor__c != null) ? tgt.Vendor__r.Name : ''); //取引先
            oneData.put('VendorC' , (tgt.Vendor__c != null) ? VendorC : ''); //取引先：ID
            // oneData.put('VendorC' , tgt.Vendor__c );
            // oneData.put('VendorC' , '');
            oneData.put('DeliveryPlaceR' , (tgt.DeliveryPlace__c != NULL) ? tgt.DeliveryPlace__r.Name : ''); //納入先
            oneData.put('DeliveryPlaceC' , (tgt.DeliveryPlace__c != NULL) ? DeliveryPlaceC : ''); //納入先：ID
            oneData.put('DesiredDeliveryDateC' , (tgt.DesiredDeliveryDate__c != null) ? MB_DateTimeUtil.Datetime2Str(tgt.DesiredDeliveryDate__c, 'yyyy/MM/dd') : ''); //納入期限
            oneData.put('Id' , tgt.Id); //ID ProcurementRequestRemarks__c
            oneData.put('ProcurementRequestRemarksC' , (tgt.ProcurementRequestRemarks__c != null) ? tgt.ProcurementRequestRemarks__c : ''); //備考 -> 却下リスト取得時にこの項目がnullになる
            oneData.put('Check' , 'false'); //チェックボックス
            oneData.put('AmPm' , (tgt.AmPm__c != null) ? tgt.AmPm__c : ''); //AMPM

            System.debug('☆☆☆oneData:' + oneData);
            retMap.put(PRNumber, oneData);

            // retMap.put(PRNumber, new Map<String, String>{'ProcurementRequestNumber__c' => tgt.ProcurementRequestNumber__c}); // 調達依頼番号
            // retMap.put(PRNumber, new Map<String, String>{'TransactionStatus__c' => tgt.TransactionStatus__c});               // 取引ステータス
            // retMap.put(PRNumber, new Map<String, String>{'Quantity__c' => (tgt.Quantity__c).format()});                                 // 数量
            // retMap.put(PRNumber, new Map<String, String>{'QuantityUnit__c' => tgt.QuantityUnit__c});                         // 数量単位
            // retMap.put(PRNumber, new Map<String, String>{'ItemName__r' => tgt.ItemName__r.Name});                            // 資材名
            // retMap.put(PRNumber, new Map<String, String>{'Vendor__r' => tgt.Vendor__r.Name});                                // 仕入先
            // retMap.put(PRNumber, new Map<String, String>{'DeliveryPlace__r' => tgt.DeliveryPlace__r.Name});                  // 納入先
            // retMap.put(PRNumber, new Map<String, String>{'DesiredDeliveryDate__c' => MB_DateTimeUtil.Datetime2Str(tgt.DesiredDeliveryDate__c, 'yyyy/MM/dd')});           // 希望納期
            // retMap.put(PRNumber, {'' => });
        }
        System.debug('☆☆☆retMap:' + retMap);

        return retMap;
    }

    //バリデーション
    //資材選択1,工事番号必須
    @RemoteAction
    public static String CheckSelection1(String tgt, String type, String material){
        String errMsg = '';
        String lf = '';

        // 工事番号レコードタイプ（見積用）
        String constructionRecordTypeIdEstimates = ID.valueOf(MB_SobjectUtil.getRecordType('Construction__c', 'Estimate')); 
        String materialSmallName = CommonItems.MATERIAL_LIST_SMALL;

        if(String.isBlank(tgt)){
            errMsg = '工事番号を選択してください。';
            lf = '\n';  
        } else {
            // 見積用の工事番号では小口の注文はできない
            if(type ==  ConstructionRecordTypeIdEstimates) {
                if (material == materialSmallName) {
                    errMsg = errMsg + lf + '見積用の工事番号ではB材(小口)を取り扱うことができません。';
                    lf = '\n';
                }
            }
        }

        return errMsg;
    }

    // バリデーション
    // 資材選択4
    @RemoteAction
    public static String CheckSelection4(String quantity_str, String procurementRequestRemarks, Integer minimumOrdering) {
        String errMsg = '';
        String lf = '';

        //数量 -> 1以上のチェック・最低発注数以上のチェック・項目の桁数チェック
        if (MB_ValidateUtil.isEmpty(quantity_str)) {
            // 必須チェック
           errMsg = errMsg + lf + '数量：数量に値を入力してください。';
           lf = '\n';
        }else {
            if (!MB_ValidateUtil.isNumber(quantity_str)){
                // 数値チェック
                errMsg = errMsg + lf + '数量：数量には1以上の数値を入力してください。';
                lf = '\n';
            } else {
                if (!MB_ValidateUtil.isGreaterEqual(quantity_str,1)) {
                    // 最低数チェック
                   errMsg = errMsg + lf + '数量：数量には1以上の数値を入力してください。';
                   lf = '\n';
                } else if (!MB_ValidateUtil.isGreaterEqual(quantity_str,minimumOrdering)) {
                   // 最低発注数チェック
                   errMsg = errMsg + lf + '数量：最低発注数 [' +  minimumOrdering + '] 以上の数値を入力してください。';
                   lf = '\n';
                } else if(!MB_ValidateUtil.isLessEqualBy(quantity_str, 5)) {
                   // 最大桁数チェック
                   errMsg = errMsg + lf + '数量：5桁以下の数値を入力してください。';
                   lf = '\n';
                }
            }
        }

        //備考 -> 項目の桁数チェック
        if (!MB_ValidateUtil.isEmpty(quantity_str)) {
            // 値があるときのみチェック
            if(!MB_ValidateUtil.isLessEqualBy(procurementRequestRemarks, 255)){
                // 最大桁数チェック
                   errMsg = errMsg + lf + '備考：255桁以下の数値を入力してください。';
                   lf = '\n';
            }
        }

        return errMsg;
    }
    // 資材マスタ検索
    // キーワード検索
    // 資材選択2,
    @RemoteAction
    public static List<Item__c> SearchItemList(String classification, String keyword){
        
        List<Item__c> itemList = DaoItem.getSearchList(classification, keyword);
        System.debug('1☆最終的に返しているものチェック:' + DaoItem.getSearchList(classification, keyword));
        return itemList;
    }

    // 調達依頼データ登録
    @RemoteAction
    public static Boolean RegistProcurementRequest(Map<String,String> prm) {
        System.debug('★★★prm：' + prm);

        Category__c category = new Category__c();
        category.Classification__c = prm.get('classification');
        category.Material__c = prm.get('material');
        category.Item__c = prm.get('item');
        category.Standard1__c = prm.get('standard1');
        category.Standard2__c = prm.get('standard2');

        String size = prm.get('size');

        // 資材取得
        item__c itemObj = DaoItem.getItem(category, size);
        System.debug('★★★itemObj：' + itemObj);

        // 登録データ作成
        ProcurementRequest__c item = new ProcurementRequest__c();
        item.ConstructionNumber__c = DaoConstruction.getConstructionObject(prm.get('ConstructionNumber')).Id; // 工事番号
        item.RecordTypeId = MB_SobjectUtil.getRecordType('ProcurementRequest__c', CommonItems.RECORDE_TYPE_MATERIAL.get(prm.get('division'))); // レコードタイプ
        item.MaterialList__c = prm.get('division'); // 区分
        item.ItemName__c = itemObj.id;  // 資材名
        item.Quantity__c = Integer.valueOf(prm.get('quantity'));  // 数量
        item.ProcurementRequestRemarks__c = prm.get('procurementRequestRemarks');// 資材備考
        item.TransactionStatus__c = CommonItems.PROCUREMENTS_STATUS_INPUT; // 取引ステータス
        if(prm.get('PRId') != null){
            ID PRId = ID.valueOf(prm.get('PRId'));
            item.Id = ID.valueOf(prm.get('PRId')); //ID
        }
        item.ASTPerson__c = UserInfo.getUserId(); //AST決裁者

        System.debug(item.RecordTypeId);
        System.debug('★★★item：' + item);

        Boolean ret = DaoProcurementRequest.Regist(item);

        return ret;
    }

    // 仕入先検索
    // 　資材一覧①
    @RemoteAction
    public static List<AggregateResult> List1SearchVendor(String constructionNumber,String itemId) {
        
        // 資材を取り扱っている取引先リスト取得
        List<AggregateResult> vendorList = DaoUnitPrice.getItemVendorList(itemId);

        // 検索用リスト作成
        List<String> searchList = new List<String>();
        for(AggregateResult up : vendorList) {
            String sId = String.valueOf(up.get('Vendor__c'));
            searchList.add(sId);
        }

        // 仕入れ先リスト取得
        List<AggregateResult> accountList = DaoConstructionAccount.getAccountList(constructionNumber, searchList);

        return accountList;
    }

// 納入先検索
    // 　資材一覧①
    @RemoteAction
    public static List<AggregateResult> List1SearchDeliveryPlace(String constructionNumber) {

        List<AggregateResult> placeList = DaoConstructionPlace.getPlaceList(constructionNumber);
        // placeList = DaoConstructionPlace.

        return placeList;
    }

    //バリデーション
    //資材一覧1
    // 引数：1)B材,2)チェックされた項目の必須チェック項目(調達番号、取引先、納入先、希望納期)
    // 返値：エラーメッセージ
    @RemoteAction
    public static String CheckList1(String mateB, Map<String,Map<String,String>> validItems) {
        String errMes = '';
        String lf = '';

        if(mateB == CommonItems.MATERIAL_LIST_SMALL){
            //小口
            for(Map<String,String> tgt : validItems.values()){
                if(MB_ValidateUtil.isEmpty(tgt.get('Vendor'))){ //仕入先
                    errMes = errMes + lf + '仕入先が選択されていません';
                    lf = '\n';
                }else if(MB_ValidateUtil.isEmpty(tgt.get('DeliveryPlace'))){ //納入先
                    errMes = errMes + lf + '納入先が選択されていません';
                    lf = '\n';
                }else if(MB_ValidateUtil.isEmpty(tgt.get('DesiredDeliveryDate'))){ //希望納期
                    errMes = errMes + lf + '希望納期が選択されていません';
                    lf = '\n';
                }
            }
        }else if(mateB == CommonItems.MATERIAL_LIST_BIG){
            //大口
            for(Map<String,String> tgt : validItems.values()){
                if(!MB_ValidateUtil.isEmpty(tgt.get('Vendor'))){ //仕入先 - 念のため
                    errMes = errMes + lf + '仕入先は入力できません';
                    lf = '\n';
                // }else if(MB_ValidateUtil.isEmpty(tgt.get('DeliveryPlace'))){ //納入先
                //     errMes = errMes + lf + '';
                //     lf = '\n';
                // }else if(MB_ValidateUtil.isEmpty(tgt.get('DesiredDeliveryDate'))){ //希望納期
                //     errMes = errMes + lf + '';
                //     lf = '\n';
                }
            }
        }
        return errMes;
    }

    // 調達依頼削除
    // 引数：削除するIDのList
    // return：削除の成功失敗
    @RemoteAction
    public static Boolean List1ProcurementRequestDelete(List<String> delList){
        System.debug('☆delList:' + delList);
        Boolean ret = false;
        List<ID> idList = new List<ID>();
        for(String val : delList){
            idList.add(ID.valueOf(val));
        }
        System.debug('☆idList:' + idList);
        ret = DaoProcurementRequest.Remove(idList); //この処理の前にList<ID>に変換する必要があるかも ID.valueOf

        return ret;
    }

    // 一括入力データ取得
    @RemoteAction
    public static Map<String, List<AggregateResult>> SearchBulkDataList(String constructionNumber, String mateB){
        
        // 仕入先リスト取得
        List<AggregateResult> accountList = null;
        if(mateB == CommonItems.MATERIAL_LIST_SMALL){
            // B材(小口)の場合
            accountList = DaoConstructionAccount.getConstructionAccountList(constructionNumber);      
        }else if(mateB == CommonItems.MATERIAL_LIST_BIG){
            // B材(大口)の場合はnulllのまま
        }        

        // 納入先リスト取得
        List<AggregateResult> placeList = DaoConstructionPlace.getPlaceList(constructionNumber);

        Map<String, List<AggregateResult>> retList = new Map<String, List<AggregateResult>>();
        retList.put('account', accountList);
        retList.put('place', placeList);

        return retList;
    }

    // 一括入力データ存在チェック
    @RemoteAction
    public static Map<String, String> CheckBulkVendorData(String procurementRequestNumber,String itemId,  String vendorId){
        
        // 仕入先リスト取得
        Map<String, String> result = DaoUnitPrice.isItem(procurementRequestNumber,itemId, vendorId);

        return result;
    }


}