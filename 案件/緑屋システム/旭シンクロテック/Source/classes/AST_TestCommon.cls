@isTest 
public class AST_TestCommon {

    public static boolean isException = true;
    
    public User user1 {get; set;} 
    public User user2 {get; set;}
    public User user3 {get; set;}
    public User user4 {get; set;}
    public User user5 {get; set;}
    public User communityUser1 {get; set;}
    public User communityUser2 {get; set;}
    
    public Account acc1 {get; set;}
    public Account acc2 {get; set;}
    public Contact cont1 {get; set;}
    public Item__c item1 {get; set;}
    public UnitPrice__c unitPrice1 {get; set;}
    public Place__c place1  {get; set;}
    public Construction__c construction {get; set;}
    public Construction_Account__c constAcc1 {get; set;}
    public Construction_Place__c constPlace1 {get; set;}
    
    public FixedValueList__c FixedValueList {get; set;}  
    
     
    public void createMasterTestData() {
        user1 = createUser('工事');
        user2 = createUser('業務');
        user3 = createUser('システム管理者');
        user4 = createUser('経理');
        user5 = createUser('購買');
        acc1 =  createAccount1(user3);
        acc2 =  createAccount2(user3);
        cont1 = createContact1(acc1);
        communityUser1 = createcommunityUser1('仕入先',acc1);
        communityUser2 = createcommunityUser1('仕入先',acc2);
        item1 = createItem1();
        unitPrice1 = createUnitPrice1(item1, acc1);

        place1 = createPlace1();
        construction = createConstruction1(user1,null,null,null,null);
        constAcc1 = createConstructionAccount1(acc1, construction);
        constPlace1 = createConstructionPlace1(place1, construction);
        
        FixedValueList = createFixedValueList();

    }

    
    /*
    *   Created User
    *   @param prifileName
    *   @return user
    *   @return 作成データ  Generated Data
    */
    public static User createUser(String profileName){
    
        List<Profile> testProfiles = [SELECT Id FROM Profile WHERE Name = :profileName LIMIT 1];
        if(testProfiles.size() == 0) {
            return null;
        }
        // Create user.
        String testUsername = System.now().format('yyyyMMddhhmmssSSS') + '@TestUser.com';//
        User testUser = new User(
            UserName=testUsername,
            MobilePhone='000-111-2222', 
            ManagerId=UserInfo.getUserId(), 
            Alias = 'ENT', 
            Email='ent1@test.com', 
            LastName='Testing', 
            ProfileId = testProfiles[0].Id, 
            EmailEncodingKey='UTF-8', 
            LanguageLocaleKey='ja', 
            LocaleSidKey='ja_JP', 
            TimeZoneSidKey='Asia/Tokyo'
            ); 
        try {
            insert testUser;
        } catch (Exception e) {
            if (isException) {
                throw e;
            }
            return null;
        }
        return testUser;
    }

    /*
    *   Created User
    *   @param prifileName
    *   @return user
    *   @return 作成データ  Generated Data
    */
    public static User createcommunityUser1(String profileName, Account acc){
    
        List<Profile> testProfiles = [SELECT Id FROM Profile WHERE Name = :profileName LIMIT 1];
        if(testProfiles.size() == 0) {
            return null;
        }

        Contact con = createContact1(acc);

        // Create user.
        String testUsername = System.now().format('yyyyMMddhhmmssSSS') + '@CommunityTestUser.com';//
        User testUser = new User(
            UserName=testUsername,
            MobilePhone='000-111-2222', 
            ManagerId=UserInfo.getUserId(), 
            Alias = 'ENT', 
            Email='ent1@test.com', 
            LastName='Testing', 
            ProfileId = testProfiles[0].Id, 
            EmailEncodingKey='UTF-8', 
            LanguageLocaleKey='ja', 
            LocaleSidKey='ja_JP', 
            TimeZoneSidKey='Asia/Tokyo',
            PortalRole = 'Manager',
            ContactId = con.Id
            ); 
        try {
            insert testUser;
        } catch (Exception e) {
            if (isException) {
                throw e;
            }
            return null;
        }
        return testUser;
    }

    public static Account createAccount1(User u){

        if (u == null) {
            u = createUser('システム管理者');
        }
        Account acc = new Account(Name = 'テストアカウント',  ShippingPostalCode = '0000000',
            ShippingCity = 'テスト市', ShippingStreet = '大田区平和島３−５−１', Phone = '090-0000-0000', Fax='111-222-3333',
            ASTPerson__c = u.Id, Email__c = u.Email, Representative__c = 'Representative', AccountID__c=System.now().format('mmssSSS'),
            AccountList__c = '仕入先', InvoiceStartDate__c = MB_DateTimeUtil.getMonthOfStartDay(MB_DateTimeUtil.getToday()),
            TermsOfPaymentDay__c = '月末払い', PaymentMethodCode__c = '翌月払い',
            TaxType__c='合計金額に対して税率を計算', cutoffDate__c='月末締め', 
            RecordTypeId=MB_SobjectUtil.getRecordType('Account','Vendor'),TermsOfPayment__c='翌月払い'
        );
              
        try{
            insert acc;
        }catch(Exception e){
            if (isException) {
                throw e;
            }
            return null;
        }
        return acc;
    }
    
    public static Account createAccount2(User u){

        if (u == null) {
            u = createUser('システム管理者');
        }
        Account acc = new Account(Name = 'テストアカウント',  ShippingPostalCode = '0000000',
            ShippingCity = 'テスト市', ShippingStreet = '大田区平和島３−５−１', Phone = '090-0000-0000', Fax='111-222-3333',
            ASTPerson__c = u.Id, Email__c = u.Email, Representative__c = 'Representative', AccountID__c=System.now().format('mmssSSS'),
            AccountList__c = '仕入先', InvoiceStartDate__c = MB_DateTimeUtil.getMonthOfStartDay(MB_DateTimeUtil.getToday()),
            TermsOfPaymentDay__c = '月末払い', PaymentMethodCode__c = '翌月払い',
            TaxType__c='明細金額ごとに税率を計算', cutoffDate__c='15日締め', 
            RecordTypeId=MB_SobjectUtil.getRecordType('Account','Vendor'),TermsOfPayment__c='翌月払い'
        );
              
        try{
            insert acc;
        }catch(Exception e){
            if (isException) {
                throw e;
            }
            return null;
        }
        return acc;
    }
    

    public static Contact createContact1(Account acc){

        if (acc == null) {
            acc = createAccount1(null);
        } 
        
        Contact oContact = new Contact();
        oContact.AccountId = acc.Id;
        oContact.LastName = 'TEST Contact ';  
        oContact.MailingCountry = 'BELGIUM';
        try{
            insert oContact;
        }catch(Exception e){
            if (isException) {
                throw e;
            }
            return null;
        }
        return oContact;
    }


    public static Item__c createItem1(){

        String uniqueStr = System.now().format('hhmmssSSS');//

        Item__c data = new Item__c(
            Name='TEST_ITEM',
            Classification__c='分類1',
            Discription__c='資材説明',
            Extra__c=100,
            ItemCodeForAppropriation__c='A01',
            ItemCode__c=uniqueStr,
            ItemRemarks__c='備考',
            Item__c='品名1',
            Material__c='材質1',
            MinimumOrdering__c=1,
            OfficialQuotation__c=100,
            Price__c=100,
            Size__c='サイズ',
            Standard1__c='規格1-1',
            Standard2__c='規格2-1',
            SteelExtra__c=100,
            Unit__c='個',
            Weight__c=100
        );

        try{
            insert data;
        }catch(Exception e){
            if (isException) {
                throw e;
            }
            return null;
        }
        return data;
    }


    public static UnitPrice__c createUnitPrice1(Item__c item, Account acc){

        String uniqueStr = System.now().format('hhmmssSSS');//

        if (acc == null) {
            acc = createAccount1(null);
        } 

        if (item == null) {
            item = createItem1();
        } 

        UnitPrice__c data = new UnitPrice__c(
            BasePrice__c=100,
            Item__c=item.id,
            Ratio__c=100,
            UnitPrice__c=100,
            VendorProductCode__c='仕入先商品コード1',
            PriceLogic__c='単価指定',
                    // 定価×掛率
                    // 重量×ベース単価
                    // 重量×(ベース単価＋エキストラ)
                    // 重量×(ベース単価＋エキストラ＋鋼種エキストラ)
                    // 重量×建値×掛率
                    // 単価指定
                    // 価格未決定            
            Vendor__c=acc.id
        );

        try{
            insert data;
        }catch(Exception e){
            if (isException) {
                throw e;
            }
            return null;
        }
        return data;
    }


    public static Place__c createPlace1(){

        String uniqueStr = System.now().format('hhmmssSSS');//

        Place__c data = new Place__c(
            Name='場所名1',
            Address__c='中原区',
            City__c='川崎市',
            Country__c='日本',
            PhoneNumber__c='000-111-2222',
            PlaceCode__c=uniqueStr,
            PlaceList__c='施工現場',
            PostalCode__c='2210014',
            Prefectures__c='神奈川県'
        );

        try{
            insert data;
        }catch(Exception e){
            if (isException) {
                throw e;
            }
            return null;
        }
        return data;
    }


    public static Construction__c createConstruction1(User user1, User user2, User user3, User user4, User user5){

        String uniqueStr = System.now().format('hhmmssSSS');//

        if (user1 == null) {
            user1 = createUser('システム管理者');
        } 

        Construction__c data = new Construction__c(
            Name=uniqueStr,
            ASTDecisionPerson1__c=user1.id,
            ConstructionName__c='現場名1',
            ConstructionRemarks__c='備考',
            Dummy__c=false,
            ExpirationDate__c=MB_DateTimeUtil.getMonthOfEndDay(MB_DateTimeUtil.getToday()).addMonths(1),
            ObicOrderNo__c='O00001',
            SalesOffice__c='釧路営業所'
        );

        try{
            insert data;
        }catch(Exception e){
            if (isException) {
                throw e;
            }
            return null;
        }
        return data;
    }


    public static Construction_Account__c createConstructionAccount1(Account acc, Construction__c construction){

        String uniqueStr = System.now().format('hhmmssSSS');//

        Construction_Account__c data = new Construction_Account__c(
            Account__c=acc.id,
            ConstructionNumber__c=construction.id
        );

        try{
            insert data;
        }catch(Exception e){
            if (isException) {
                throw e;
            }
            return null;
        }
        return data;
    }

    public static Construction_Place__c createConstructionPlace1(Place__c place, Construction__c construction){

        String uniqueStr = System.now().format('hhmmssSSS');//

        Construction_Place__c data = new Construction_Place__c(
            Place__c=place.id,
            ConstructionNumber__c=construction.id
        );

        try{
            insert data;
        }catch(Exception e){
            if (isException) {
                throw e;
            }
            return null;
        }
        return data;
    }
    
    // カスタム設定
    public static FixedValueList__c createFixedValueList(){

        String uniqueStr = System.now().format('hhmmssSSS');//

        FixedValueList__c data = new FixedValueList__c(
            Tax__c = 8
        );

        try{
            insert data;
        }catch(Exception e){
            if (isException) {
                throw e;
            }
            return null;
        }
        return data;
    }

}