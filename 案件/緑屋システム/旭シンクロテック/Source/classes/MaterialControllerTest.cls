@isTest
public class MaterialControllerTest{

    //リダイレクト
    @isTest
    static void redirectTest(){
    
        MaterialController MC = new MaterialController();
        MC.checkRedirect();

    }

    //画面表示
    @isTest
    static void Selection2DisplayTest(){

        MaterialController MC = new MaterialController();
        MC.transition1Next();

    }
    @isTest
    static void Selection3DisplayTest(){

        //カテゴリマスタ
        Category__c RegCategory = new Category__c();
        RegCategory.Classification__c = '管財';
        RegCategory.SortClassification__c = '01';
        RegCategory.Material__c = 'SUS18';
        RegCategory.SortMaterial__c = '02';
        RegCategory.Item__c = 'ネジ';
        RegCategory.SortItem__c = '03';
        //RegCategory.Standard1__c = 'UT';
        RegCategory.SortStandard1__c = '04';
        //RegCategory.Standard2__c = 'IT';
        RegCategory.SortStandard2__c = '04';
        RegCategory.Sort__c = '10';
        insert RegCategory;
         

        MaterialController MC = new MaterialController();
        MaterialController.classification = RegCategory.Classification__c;
        MaterialController.material= RegCategory.Material__c;
        MaterialController.item= RegCategory.Item__c;
        MC.transition2Next();

    }
    @isTest
    static void Selection3DisplayTest2(){

        //カテゴリマスタ
        Category__c RegCategory = new Category__c();
        RegCategory.Classification__c = '管財';
        RegCategory.SortClassification__c = '01';
        RegCategory.Material__c = 'SUS18';
        RegCategory.SortMaterial__c = '02';
        RegCategory.Item__c = 'ネジ';
        RegCategory.SortItem__c = '03';
        RegCategory.Standard1__c = 'UT';
        RegCategory.SortStandard1__c = '04';
        RegCategory.Standard2__c = 'IT';
        RegCategory.SortStandard2__c = '04';
        RegCategory.Sort__c = '10';
        insert RegCategory;
        Category__c RegCategory2 = new Category__c();
        RegCategory2.Classification__c = '管財';
        RegCategory2.SortClassification__c = '01';
        RegCategory2.Material__c = 'SUS18';
        RegCategory2.SortMaterial__c = '02';
        RegCategory2.Item__c = 'ネジ';
        RegCategory2.SortItem__c = '03';
        RegCategory2.Standard1__c = 'UT2';
        RegCategory2.SortStandard1__c = '04';
        RegCategory2.Standard2__c = 'IT2';
        RegCategory2.SortStandard2__c = '04';
        RegCategory2.Sort__c = '10';
        insert RegCategory2;
         

        MaterialController MC = new MaterialController();
        MaterialController.classification = RegCategory.Classification__c;
        MaterialController.material= RegCategory.Material__c;
        MaterialController.item= RegCategory.Item__c;
        MC.transition2Next();

    }
    
    
    @isTest
    static void Selection4DisplayTest(){

        MaterialController MC = new MaterialController();
        MC.transition3Next();

    }
    @isTest
    static void List1DisplayTest(){

        MaterialController MC = new MaterialController();
        MC.transitionToList1();

    }
    @isTest
    static void List2DisplayTest(){

        MaterialController MC = new MaterialController();
        Map<String,String> testMap = new Map<String,String>();
        testMap.put('AmPm','AM');
        testMap.put('Check','true');
        Map<String,Map<String,String>> testinput= new Map<String,Map<String,String>>();
        testinput.put('Input', testMap);

        MC.List1InputMap= testinput;
        MC.List1RejectionMap= testinput;
        MC.transitionList1Next();

    }
    
    //検索処理
    @isTest
    static void Selection2SearchTest(){

        MaterialController MC = new MaterialController();
        MC.transition2SearchNext();

    }
    
    //戻る処理
    @isTest
    static void Selection2BackTest(){

        MaterialController MC = new MaterialController();
        MC.transition2Back();

    }
    @isTest
    static void Selection3BackTest(){

        MaterialController MC = new MaterialController();
        MC.transition3Back();

    }
    @isTest
    static void Selection4BackTest(){

        MaterialController MC = new MaterialController();
        MC.transition4Back();

    }
    
    //一覧1画面
    @isTest
    static void toList1Test(){
    
        MaterialController MC = new MaterialController();
        MC.transitionToList1();

    }
    @isTest
    static void List1EditTest(){
    
        //日付
        date myDate = date.today();
        date NewDate = myDate.addMonths (1);

        //プロファイル
        Profile profile;
        String setProfileId;
        profile = getStandardProfile('システム管理者');
        setProfileId = profile.id;

        //ユーザー
        User Reguser = new User();
        Reguser.Email = 'test@xx.xxx.com';
        Reguser.UserName = 'test@xx.xxx.com';
        Reguser.FirstName = 'test';
        Reguser.LastName = '123';
        Reguser.Alias = 'test';
        Reguser.ProfileId = setProfileId;
        //Reguser.UserRoleId = role.Id;
        Reguser.EmailEncodingKey = 'ISO-2022-JP';
        Reguser.LanguageLocaleKey = 'ja';
        Reguser.LocaleSidKey = 'ja_JP';
        Reguser.TimeZoneSidKey = 'Asia/Tokyo';
        insert Reguser;

        //取引先
        Account RegAcc = new Account();
        RegAcc.AccountID__c = 'V-0001';
        RegAcc.Name = 'ITAST';
        RegAcc.Representative__c = '代表者';
        RegAcc.TermsOfPaymentDay__c = '月末払い';
        RegAcc.TermsOfPayment__c = '翌月払い';
        RegAcc.Email__c = 'xxxxxx@ast.test.xxxx';
        insert RegAcc;

        // 
        Contact con = AST_TestCommon.createContact1(RegAcc);

        // 
        User communityUser1 = AST_TestCommon.createcommunityUser1('仕入先',RegAcc);
            
        //工事番号マスタ
        Construction__c RegConst = new Construction__c();
        RegConst.RecordTypeId = ID.valueOf(getRecordType('Construction__c', 'Order')); 
        RegConst.Name = 'IT20251231';
        RegConst.ConstructionName__c = '北浦和東口';
        RegConst.ASTDecisionPerson1__c = Reguser.ID;
        RegConst.ExpirationDate__c = NewDate;
        Insert RegConst; 
            
        //資材マスタ
        Item__c RegItem = new Item__c();
        RegItem.Classification__c = 'ガスケット';
        RegItem.ItemCode__c = '102';
        RegItem.Item__c = 'ガスケット';
        RegItem.Material__c = 'EPDM';
        RegItem.Size__c = '50cm';
        RegItem.Standard1__c = '10K';
        insert RegItem;
        
        //場所マスタ
        Place__c RegPlace = new Place__c();
        RegPlace.Name = 'testPlace';
        insert RegPlace;
        
        //工事番号-取引先
        Construction_Account__c RegCA = new Construction_Account__c();
        RegCA.ConstructionNumber__c = RegConst.ID;
        RegCA.Account__c = RegAcc.ID;
        insert RegCA;
        
        //工事番号-場所
        Construction_Place__c RegCP = new Construction_Place__c();
        RegCP.ConstructionNumber__c = RegConst.ID;
        RegCP.Place__c = RegPlace.ID;
        insert RegCP;
        
        //掛率単価マスタ
        UnitPrice__c RegUnitPrice = new UnitPrice__c();
        RegUnitPrice.Vendor__c = RegAcc.Id;
        RegUnitPrice.PriceLogic__c = '定価×掛率';
        RegUnitPrice.Item__c = RegItem.Id;
        RegUnitPrice.UnitPrice__c = 10000;
        Insert RegUnitPrice;

        
        //カテゴリマスタ
        Category__c RegCategory = new Category__c();
        RegCategory.Classification__c = '管財';
        RegCategory.SortClassification__c = '01';
        RegCategory.Material__c = 'SUS18';
        RegCategory.SortMaterial__c = '02';
        RegCategory.Item__c = 'ネジ';
        RegCategory.SortItem__c = '03';
        RegCategory.Standard1__c = 'UT';
        RegCategory.SortStandard1__c = '04';
        RegCategory.Standard2__c = 'IT';
        RegCategory.SortStandard2__c = '04';
        RegCategory.Sort__c = '10';
        insert RegCategory;
        
        //調達依頼
        ProcurementRequest__c RegPR = new ProcurementRequest__c();
        RegPR.RecordTypeId = ID.valueOf(getRecordType('ProcurementRequest__c', 'B_Material_Small')); 
        //RegPR.ProcurementRequestNumber__c = '1000';
        RegPR.TransactionStatus__c = '入力中';
        RegPR.Quantity__c = 18;
        //RegPR.QuantityUnit__c = '個';
        RegPR.ITEMNAME__c = RegItem.ID;
        RegPR.Vendor__c = RegAcc.ID;
        RegPR.DeliveryPlace__c = RegPlace.ID;
        RegPR.DesiredDeliveryDate__c = NewDate; 
        RegPR.AmPm__c = 'AM';
        RegPR.ASTDECISIONPERSON1__C = Reguser.Id;
        RegPR.ASTPERSON__C = Reguser.Id;
        RegPR.CONSTRUCTIONNUMBER__C = RegConst.ID;
        RegPR.MATERIALLIST__C = 'B材（小口）';
        RegPR.UNITPRICE__C = 10000;
        RegPR.TAX__C = 8;
        insert RegPR;

        // 一括入力データ取得
        MaterialController.SearchBulkDataList(String.valueOf(RegConst.ID),RegPR.MATERIALLIST__C);

        MaterialController.CheckBulkVendorData(String.valueOf(RegConst.ID), String.valueOf(RegItem.ID),  String.valueOf(RegAcc.ID));
    
        //画面から渡される想定のデータ
        PageReference pageRefList1 = Page.MaterialList1;
        //パラメータをセット
        pageRefList1.getParameters().put('classification', RegCategory.Classification__c);
        pageRefList1.getParameters().put('material', RegCategory.Material__c);
        pageRefList1.getParameters().put('item', RegItem.Name);
        pageRefList1.getParameters().put('division', 'B材(小口)');
        pageRefList1.getParameters().put('standard1', RegCategory.Standard1__c);
        pageRefList1.getParameters().put('standard2', '');
        pageRefList1.getParameters().put('size', '');
        pageRefList1.getParameters().put('volume', '');
        pageRefList1.getParameters().put('note', '');
        pageRefList1.getParameters().put('MaterialId', RegItem.ID);
        pageRefList1.getParameters().put('ProcurementRequestNumber', RegPR.ID);
        pageRefList1.getParameters().put('Id', RegPR.ID);
        Test.setCurrentPage(pageRefList1);

        MaterialController MC = new MaterialController();
        MC.transitionList1Edit();

    }
    
   //承認申請
    @isTest
    static void appUpdateList2Test(){

        MaterialController MC = new MaterialController();
        MC.appUpdateList2();

    }
    
   //transition
    @isTest
    static void transition1Test(){

        MaterialController MC = new MaterialController();
        MC.transition1();

    }
    
    @isTest
    static void transition3Test(){

        MaterialController MC = new MaterialController();
        MC.transition3();

    }
    
    @isTest
    static void transition4Test(){

        MaterialController MC = new MaterialController();
        MC.transition4();

    }
    
    //リモート系
    @isTest
    static void remoteCheckSelection1Test(){
        String tgt = '';

        MaterialController MC = new MaterialController();
        //MC.CheckSelection1(tgt);

    }

    @isTest
    static void remoteCheckSelection4Test(){
        String quantity_str = ''; //数量
        String procurementRequestRemarks = ''; //備考
        Integer minimumOrdering = 100; //最低発注数

        //必須チェックエラー
        MaterialController.CheckSelection4(quantity_str,procurementRequestRemarks,minimumOrdering);

        //数値チェックエラー
        quantity_str = 'あ';
        MaterialController.CheckSelection4(quantity_str,procurementRequestRemarks,minimumOrdering);

        //最低数量(0)チェックエラー
        quantity_str = '0';
        MaterialController.CheckSelection4(quantity_str,procurementRequestRemarks,minimumOrdering);

        //最低発注数チェックエラー
        quantity_str = '10';
        MaterialController.CheckSelection4(quantity_str,procurementRequestRemarks,minimumOrdering);

        //最大桁数チェックエラー
        quantity_str = '100000';
        MaterialController.CheckSelection4(quantity_str,procurementRequestRemarks,minimumOrdering);

        //備考型桁チェックエラー
        procurementRequestRemarks = 'ああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああああ';
        MaterialController.CheckSelection4(quantity_str,procurementRequestRemarks,minimumOrdering);
    }
    
    
    //資材マスタキーワード検索
    @isTest
    static void remoteSearchItemListTest(){
        String classification = 'EPDM';
        String keyword = '_';

        MaterialController.SearchItemList(classification,keyword);

    }
    
    //調達依頼登録
    @isTest
    static void remoteRegistProcurementRequestTest(){

        //日付
        date myDate = date.today();
        date NewDate = myDate.addMonths (1);

        //プロファイル
        Profile profile;
        String setProfileId;
        profile = getStandardProfile('システム管理者');
        setProfileId = profile.id;

        //ユーザー
        User Reguser = new User();
        Reguser.Email = 'test@xx.xxx.com';
        Reguser.UserName = 'test@xx.xxx.com';
        Reguser.FirstName = 'test';
        Reguser.LastName = '123';
        Reguser.Alias = 'test';
        Reguser.ProfileId = setProfileId;
        //Reguser.UserRoleId = role.Id;
        Reguser.EmailEncodingKey = 'ISO-2022-JP';
        Reguser.LanguageLocaleKey = 'ja';
        Reguser.LocaleSidKey = 'ja_JP';
        Reguser.TimeZoneSidKey = 'Asia/Tokyo';
        insert Reguser;

        //取引先
        Account RegAcc = new Account();
        RegAcc.AccountID__c = 'V-0001';
        RegAcc.Name = 'ITAST';
        RegAcc.Representative__c = '代表者';
        RegAcc.TermsOfPaymentDay__c = '月末払い';
        RegAcc.TermsOfPayment__c = '翌月払い';
        RegAcc.Email__c = 'xxxxxx@ast.test.xxxx';
        insert RegAcc;

        // 
        Contact con = AST_TestCommon.createContact1(RegAcc);

        // 
        User communityUser1 = AST_TestCommon.createcommunityUser1('仕入先',RegAcc);
            
        //工事番号マスタ
        Construction__c RegConst = new Construction__c();
        RegConst.RecordTypeId = ID.valueOf(getRecordType('Construction__c', 'Order')); 
        RegConst.Name = 'IT20251231';
        RegConst.ConstructionName__c = '北浦和東口';
        RegConst.ASTDecisionPerson1__c = Reguser.ID;
        RegConst.ExpirationDate__c = NewDate;
        Insert RegConst; 
            
        //資材マスタ
        Item__c RegItem = new Item__c();
        RegItem.Classification__c = 'ガスケット';
        RegItem.ItemCode__c = '102';
        RegItem.Item__c = 'ガスケット';
        RegItem.Material__c = 'EPDM';
        RegItem.Size__c = '50cm';
        RegItem.Standard1__c = '10K';
        insert RegItem;
        
        //場所マスタ
        Place__c RegPlace = new Place__c();
        RegPlace.Name = 'testPlace';
        insert RegPlace;
        
        //工事番号-取引先
        Construction_Account__c RegCA = new Construction_Account__c();
        RegCA.ConstructionNumber__c = RegConst.ID;
        RegCA.Account__c = Regacc.ID;
        insert RegCA;
        
        //工事番号-場所
        Construction_Place__c RegCP = new Construction_Place__c();
        RegCP.ConstructionNumber__c = RegConst.ID;
        RegCP.Place__c = RegPlace.ID;
        insert RegCP;
        
        //掛率単価マスタ
        UnitPrice__c RegUnitPrice = new UnitPrice__c();
        RegUnitPrice.Vendor__c = RegAcc.Id;
        RegUnitPrice.PriceLogic__c = '定価×掛率';
        RegUnitPrice.Item__c = RegItem.Id;
        RegUnitPrice.UnitPrice__c = 10000;
        Insert RegUnitPrice;

        
        //カテゴリマスタ
        Category__c RegCategory = new Category__c();
        RegCategory.Classification__c = '管財';
        RegCategory.SortClassification__c = '01';
        RegCategory.Material__c = 'SUS18';
        RegCategory.SortMaterial__c = '02';
        RegCategory.Item__c = 'ネジ';
        RegCategory.SortItem__c = '03';
        RegCategory.Standard1__c = 'UT';
        RegCategory.SortStandard1__c = '04';
        RegCategory.Standard2__c = 'IT';
        RegCategory.SortStandard2__c = '04';
        RegCategory.Sort__c = '10';
        insert RegCategory;
       
        Map<String,String> prm = new Map<String,String>();
        prm.put('classification',RegItem.Classification__c);
        prm.put('material',RegItem.Material__c);
        prm.put('item',RegItem.Item__c);
        prm.put('standard1',RegItem.Standard1__c);
        prm.put('standard2',null);
        prm.put('size',RegItem.Size__c);
        prm.put('ConstructionNumber',RegConst.Name);
        prm.put('division','B材（小口）');
        prm.put('quantity','100');
        prm.put('procurementRequestRemarks', '');

        MaterialController.RegistProcurementRequest(prm);

    }
    
     //仕入れ先検索
    @isTest
    static void remoteList1SearchVendorTest(){
    
        //取引先
        Account RegAcc = new Account();
        RegAcc.AccountID__c = 'V-0001';
        RegAcc.Name = 'ITAST';
        RegAcc.Representative__c = '代表者';
        RegAcc.TermsOfPaymentDay__c = '月末払い';
        RegAcc.TermsOfPayment__c = '翌月払い';
        RegAcc.Email__c = 'xxxxxx@ast.test.xxxx';
        insert RegAcc;
    
        //資材マスタ
        Item__c RegItem = new Item__c();
        RegItem.Classification__c = 'ガスケット';
        RegItem.ItemCode__c = '102';
        RegItem.Item__c = 'ガスケット';
        RegItem.Material__c = 'EPDM';
        RegItem.Size__c = '50cm';
        RegItem.Standard1__c = '10K';
        insert RegItem;
        
        //掛率単価マスタ
        UnitPrice__c RegUnitPrice = new UnitPrice__c();
        RegUnitPrice.Vendor__c = RegAcc.Id;
        RegUnitPrice.PriceLogic__c = '定価×掛率';
        RegUnitPrice.Item__c = RegItem.Id;
        RegUnitPrice.UnitPrice__c = 10000;
        Insert RegUnitPrice;
    
        String constructionNumber = '';
        String itemId = RegItem.Id;

        MaterialController.List1SearchVendor(constructionNumber,itemId);

    }
    
    //納入先検索
    @isTest
    static void remoteList1SearchDeliveryPlaceTest(){
        String constructionNumber = '';

        MaterialController.List1SearchDeliveryPlace(constructionNumber);

    }
    
    //一覧1画面バリデーション
    @isTest
    static void remoteCheckList1Test(){
        String mateB = 'B材（小口）';
        Map<String,Map<String,String>> validItems = new Map<String,Map<String,String>>();
        Map<String,String> tmpItems = new Map<String,String>();
        tmpItems.put('Vendor', '仕入れ先');
        tmpItems.put('DeliveryPlace', '納入先');
        tmpItems.put('DesiredDeliveryDate', '希望納期');
        validItems.put('1', tmpItems);
        //正常系(小口)
        MaterialController.CheckList1(mateB,validItems);
        //正常系(大口)
        mateB = 'B材（大口）';
        MaterialController.CheckList1(mateB,validItems);
        //異常系(仕入れ先なし)
        mateB = 'B材（小口）';
        tmpItems.clear();
        validItems.clear();
        tmpItems.put('Vendor', '');
        tmpItems.put('DeliveryPlace', '納入先');
        tmpItems.put('DesiredDeliveryDate', '希望納期');
        validItems.put('1', tmpItems);
        MaterialController.CheckList1(mateB,validItems);
        //異常系(納入先なし)
        tmpItems.clear();
        validItems.clear();
        tmpItems.put('Vendor', '仕入れ先');
        tmpItems.put('DeliveryPlace', '');
        tmpItems.put('DesiredDeliveryDate', '希望納期');
        validItems.put('1', tmpItems);
        MaterialController.CheckList1(mateB,validItems);
        //異常系(希望納期なし)
        tmpItems.clear();
        validItems.clear();
        tmpItems.put('Vendor', '仕入れ先');
        tmpItems.put('DeliveryPlace', '納入先');
        tmpItems.put('DesiredDeliveryDate', '');
        validItems.put('1', tmpItems);
        MaterialController.CheckList1(mateB,validItems);

    }
    
    //調達依頼削除
    @isTest
    static void remoteList1ProcurementRequestDeleteTest(){
    
         //日付
        date myDate = date.today();
        date NewDate = myDate.addMonths (1);

        //プロファイル
        Profile profile;
        String setProfileId;
        profile = getStandardProfile('システム管理者');
        setProfileId = profile.id;

        //ユーザー
        User Reguser = new User();
        Reguser.Email = 'test@xx.xxx.com';
        Reguser.UserName = 'test@xx.xxx.com';
        Reguser.FirstName = 'test';
        Reguser.LastName = '123';
        Reguser.Alias = 'test';
        Reguser.ProfileId = setProfileId;
        //Reguser.UserRoleId = role.Id;
        Reguser.EmailEncodingKey = 'ISO-2022-JP';
        Reguser.LanguageLocaleKey = 'ja';
        Reguser.LocaleSidKey = 'ja_JP';
        Reguser.TimeZoneSidKey = 'Asia/Tokyo';
        insert Reguser;

        //取引先
        Account RegAcc = new Account();
        RegAcc.AccountID__c = 'V-0001';
        RegAcc.Name = 'ITAST';
        RegAcc.Representative__c = '代表者';
        RegAcc.TermsOfPaymentDay__c = '月末払い';
        RegAcc.TermsOfPayment__c = '翌月払い';
        RegAcc.Email__c = 'xxxxxx@ast.test.xxxx';
        insert RegAcc;

        // 
        Contact con = AST_TestCommon.createContact1(RegAcc);

        // 
        User communityUser1 = AST_TestCommon.createcommunityUser1('仕入先',RegAcc);
            
        //工事番号マスタ
        Construction__c RegConst = new Construction__c();
        RegConst.RecordTypeId = ID.valueOf(getRecordType('Construction__c', 'Order')); 
        RegConst.Name = 'IT20251231';
        RegConst.ConstructionName__c = '北浦和東口';
        RegConst.ASTDecisionPerson1__c = Reguser.ID;
        RegConst.ExpirationDate__c = NewDate;
        Insert RegConst; 
            
        //資材マスタ
        Item__c RegItem = new Item__c();
        RegItem.Classification__c = 'ガスケット';
        RegItem.ItemCode__c = '102';
        RegItem.Item__c = 'ガスケット';
        RegItem.Material__c = 'EPDM';
        RegItem.Size__c = '50cm';
        RegItem.Standard1__c = '10K';
        insert RegItem;
        
        //場所マスタ
        Place__c RegPlace = new Place__c();
        RegPlace.Name = 'testPlace';
        insert RegPlace;
        
        //工事番号-取引先
        Construction_Account__c RegCA = new Construction_Account__c();
        RegCA.ConstructionNumber__c = RegConst.ID;
        RegCA.Account__c = Regacc.ID;
        insert RegCA;
        
        //工事番号-場所
        Construction_Place__c RegCP = new Construction_Place__c();
        RegCP.ConstructionNumber__c = RegConst.ID;
        RegCP.Place__c = RegPlace.ID;
        insert RegCP;
        
        //カテゴリマスタ
        Category__c RegCategory = new Category__c();
        RegCategory.Classification__c = '管財';
        RegCategory.SortClassification__c = '01';
        RegCategory.Material__c = 'SUS18';
        RegCategory.SortMaterial__c = '02';
        RegCategory.Item__c = 'ネジ';
        RegCategory.SortItem__c = '03';
        RegCategory.Standard1__c = 'UT';
        RegCategory.SortStandard1__c = '04';
        RegCategory.Standard2__c = 'IT';
        RegCategory.SortStandard2__c = '04';
        RegCategory.Sort__c = '10';
        insert RegCategory;
        
        //掛率単価マスタ
        UnitPrice__c RegUnitPrice = new UnitPrice__c();
        RegUnitPrice.Vendor__c = RegAcc.Id;
        RegUnitPrice.PriceLogic__c = '定価×掛率';
        RegUnitPrice.Item__c = RegItem.Id;
        RegUnitPrice.UnitPrice__c = 10000;
        Insert RegUnitPrice;

        
        //調達依頼
        ProcurementRequest__c RegPR = new ProcurementRequest__c();
        RegPR.RecordTypeId = ID.valueOf(getRecordType('ProcurementRequest__c', 'B_Material_Small')); 
        //RegPR.ProcurementRequestNumber__c = '1000';
        RegPR.TransactionStatus__c = '入力中';
        RegPR.Quantity__c = 18;
        //RegPR.QuantityUnit__c = '個';
        RegPR.ITEMNAME__c = RegItem.ID;
        RegPR.Vendor__c = RegAcc.ID;
        RegPR.DeliveryPlace__c = RegPlace.ID;
        RegPR.DesiredDeliveryDate__c = NewDate; 
        RegPR.AmPm__c = 'AM';
        RegPR.ASTDECISIONPERSON1__C = Reguser.Id;
        RegPR.ASTPERSON__C = Reguser.Id;
        RegPR.CONSTRUCTIONNUMBER__C = RegConst.ID;
        RegPR.MATERIALLIST__C = 'B材（小口）';
        RegPR.UNITPRICE__C = 10000;
        RegPR.TAX__C = 8;
        insert RegPR;
    
    
        //Item__c ItemRegItem = new Item__c();
        List<String> delList = new List<String>();
        delList.add(RegPR.Id);
        MaterialController.List1ProcurementRequestDelete(delList);

    }
    
    //リストコンバート
    @isTest
    static void convertList1(){
    
         //日付
        date myDate = date.today();
        date NewDate = myDate.addMonths (1);

        //プロファイル
        Profile profile;
        String setProfileId;
        profile = getStandardProfile('システム管理者');
        setProfileId = profile.id;

        //ユーザー
        User Reguser = new User();
        Reguser.Email = 'test@xx.xxx.com';
        Reguser.UserName = 'test@xx.xxx.com';
        Reguser.FirstName = 'test';
        Reguser.LastName = '123';
        Reguser.Alias = 'test';
        Reguser.ProfileId = setProfileId;
        //Reguser.UserRoleId = role.Id;
        Reguser.EmailEncodingKey = 'ISO-2022-JP';
        Reguser.LanguageLocaleKey = 'ja';
        Reguser.LocaleSidKey = 'ja_JP';
        Reguser.TimeZoneSidKey = 'Asia/Tokyo';
        insert Reguser;

        //取引先
        Account RegAcc = new Account();
        RegAcc.AccountID__c = 'V-0001';
        RegAcc.Name = 'ITAST';
        RegAcc.Representative__c = '代表者';
        RegAcc.TermsOfPaymentDay__c = '月末払い';
        RegAcc.TermsOfPayment__c = '翌月払い';
        RegAcc.Email__c = 'xxxxxx@ast.test.xxxx';
        insert RegAcc;

        // 
        Contact con = AST_TestCommon.createContact1(RegAcc);

        // 
        User communityUser1 = AST_TestCommon.createcommunityUser1('仕入先',RegAcc);
            
        //工事番号マスタ
        Construction__c RegConst = new Construction__c();
        RegConst.RecordTypeId = ID.valueOf(getRecordType('Construction__c', 'Order')); 
        RegConst.Name = 'IT20251231';
        RegConst.ConstructionName__c = '北浦和東口';
        RegConst.ASTDecisionPerson1__c = Reguser.ID;
        RegConst.ExpirationDate__c = NewDate;
        Insert RegConst; 
            
        //資材マスタ
        Item__c RegItem = new Item__c();
        RegItem.Classification__c = 'ガスケット';
        RegItem.ItemCode__c = '102';
        RegItem.Item__c = 'ガスケット';
        RegItem.Material__c = 'EPDM';
        RegItem.Size__c = '50cm';
        RegItem.Standard1__c = '10K';
        insert RegItem;
        
        //場所マスタ
        Place__c RegPlace = new Place__c();
        RegPlace.Name = 'testPlace';
        insert RegPlace;
        
        //工事番号-取引先
        Construction_Account__c RegCA = new Construction_Account__c();
        RegCA.ConstructionNumber__c = RegConst.ID;
        RegCA.Account__c = Regacc.ID;
        insert RegCA;
        
        //工事番号-場所
        Construction_Place__c RegCP = new Construction_Place__c();
        RegCP.ConstructionNumber__c = RegConst.ID;
        RegCP.Place__c = RegPlace.ID;
        insert RegCP;
        
        //カテゴリマスタ
        Category__c RegCategory = new Category__c();
        RegCategory.Classification__c = '管財';
        RegCategory.SortClassification__c = '01';
        RegCategory.Material__c = 'SUS18';
        RegCategory.SortMaterial__c = '02';
        RegCategory.Item__c = 'ネジ';
        RegCategory.SortItem__c = '03';
        RegCategory.Standard1__c = 'UT';
        RegCategory.SortStandard1__c = '04';
        RegCategory.Standard2__c = 'IT';
        RegCategory.SortStandard2__c = '04';
        RegCategory.Sort__c = '10';
        insert RegCategory;
        
        //掛率単価マスタ
        UnitPrice__c RegUnitPrice = new UnitPrice__c();
        RegUnitPrice.Vendor__c = RegAcc.Id;
        RegUnitPrice.PriceLogic__c = '定価×掛率';
        RegUnitPrice.Item__c = RegItem.Id;
        RegUnitPrice.UnitPrice__c = 10000;
        Insert RegUnitPrice;

        
        //調達依頼
        ProcurementRequest__c RegPR = new ProcurementRequest__c();
        RegPR.RecordTypeId = ID.valueOf(getRecordType('ProcurementRequest__c', 'B_Material_Small')); 
        //RegPR.ProcurementRequestNumber__c = '1000';
        RegPR.TransactionStatus__c = '入力中';
        RegPR.Quantity__c = 18;
        //RegPR.QuantityUnit__c = '個';
        RegPR.ITEMNAME__c = RegItem.ID;
        RegPR.Vendor__c = RegAcc.ID;
        RegPR.DeliveryPlace__c = RegPlace.ID;
        RegPR.DesiredDeliveryDate__c = NewDate; 
        RegPR.AmPm__c = 'AM';
        RegPR.ASTDECISIONPERSON1__C = Reguser.Id;
        RegPR.ASTPERSON__C = Reguser.Id;
        RegPR.CONSTRUCTIONNUMBER__C = RegConst.ID;
        RegPR.MATERIALLIST__C = 'B材（小口）';
        RegPR.UNITPRICE__C = 10000;
        RegPR.TAX__C = 8;
        insert RegPR;
        List<ProcurementRequest__c> tgtList;
        tgtList = [SELECT Id 
                    ,Vendor__c
                    ,DeliveryPlace__c
                    ,ProcurementRequestNumber__c
                    ,TransactionStatus__c
                    ,Quantity__c
                    ,QuantityUnit__c
                    ,ItemName__c
                    ,ProcurementRequestRemarks__c
                    ,ItemName__r.Name
                    ,Vendor__r.Name
                    ,DeliveryPlace__r.Name 
                    ,DesiredDeliveryDate__c
                    ,AmPm__c
                    FROM ProcurementRequest__c];

        MaterialController MC = new MaterialController();
        MC.convertList1(tgtList);

    }

    /**
     * プロファイルID取得
     */
    static Profile getStandardProfile(String proName){
        Profile[] profiles;
        profiles =  [select Id From Profile where Name = :proName limit 1];
        return profiles[0];
    }

    /**
     * レコードタイプID取得
     */
    static ID getRecordType( String objectName, String recordTypeName ){
    
        List<RecordType> recordTypeList = [SELECT Id
                                           FROM RecordType
                                           WHERE SobjectType = :objectName
                                           AND DeveloperName = :recordTypeName
        ];
        return ( recordTypeList != null && !recordTypeList.isEmpty() ) ? recordTypeList[0].Id : null ;
    }

}