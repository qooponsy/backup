@isTest 
public class AST_TestCommon_TRAN {
    public static boolean isException = true;
    
    public User user1 {get; set;}
    public User user2 {get; set;}
    public User user3 {get; set;}
    public User user4 {get; set;}
    public User user5 {get; set;}
    public User communityUser1 {get; set;}
    
    public Account acc1 {get; set;}
    public Contact cont1 {get; set;}
    
    public Item__c item1 {get; set;}
    public UnitPrice__c unitPrice1 {get; set;}
    public Place__c place1  {get; set;}
    public Construction__c construction {get; set;}
    public Construction_Account__c constAcc1 {get; set;}
    public Construction_Place__c constPlace1 {get; set;}
    
    public ProcurementRequest__c pr1 {get; set;}
    public ProcurementRequest__c pr2 {get; set;}
    public ProcurementRequest__c pr3 {get; set;}
    public ProcurementRequest__c pr4 {get; set;}
    public List<ProcurementRequest__c> pr5 {get; set;}
    public List<ProcurementRequest__c> pr6 {get; set;}
    
    public ProcurementHeader__c ph1 {get; set;}
    public ProcurementHeader__c ph2 {get; set;}
    public ProcurementHeader__c ph3 {get; set;}
    
    public ProcurementDetails__c pdB1 {get; set;}
    public ProcurementDetails__c pdB2 {get; set;}
    public ProcurementDetails__c pdA {get; set;}
    
    public EstimatesAnswerHeader__c eah {get; set;}
    
    public EstimatesAnswerDetails__c ead {get; set;}
    
    public ShipmentHeader__c sh {get; set;}
    
    public ShipmentDetails__c sd1 {get; set;}
    public ShipmentDetails__c sd2 {get; set;}
    public ShipmentDetails__c sd3 {get; set;}
    
    public InvoiceInfo__c invhed {get; set;}
    public List<InvoiceInfo__c> invhedList1 {get; set;}
    public List<InvoiceInfo__c> invhedList2 {get; set;}
    public List<InvoiceInfo__c> invhedList3 {get; set;}
    
    public InvoiceInfo__c invdet {get; set;}
    public List<InvoiceInfo__c> invdet1 {get; set;}
    public List<InvoiceInfo__c> invdet2 {get; set;}
    public List<InvoiceInfo__c> invdet3 {get; set;}

    public Date sysDate {get; set;}
    
    public void createTranTestData() {

        user1 = AST_TestCommon.createUser('工事'); 
        user2 = AST_TestCommon.createUser('業務');
        user3 = AST_TestCommon.createUser('システム管理者');
        user4 = AST_TestCommon.createUser('経理');
        user5 = AST_TestCommon.createUser('購買');

        FixedValueList__c sInfo = new FixedValueList__c();
        sInfo.TriggerInvalid__c = true;
        sInfo.BulkUpdateMoveListView__c = '';
        sInfo.EstimateMoveListView__c = '';
        sInfo.PurchaseEMail__c = 'aaa@bbb.com.test';
        sInfo.VendorURL__c = '';
        sInfo.ErrorURL__c = '';
        sInfo.Tax__c = 8;
        sInfo.UnApprovedListURL__c = '';

        insert sInfo; 


        
        acc1 =  AST_TestCommon.createAccount1(user3);
        cont1 = AST_TestCommon.createContact1(acc1);
        communityUser1 = AST_TestCommon.createcommunityUser1('仕入先',acc1);
        item1 = AST_TestCommon.createItem1();
        unitPrice1 = AST_TestCommon.createUnitPrice1(item1, acc1);
        
        place1 = AST_TestCommon.createPlace1();
        construction = AST_TestCommon.createConstruction1(user1,null,null,null,null);
        constAcc1 = AST_TestCommon.createConstructionAccount1(acc1, construction);
        constPlace1 = AST_TestCommon.createConstructionPlace1(place1, construction);
        
        pr1 = createProcurementRequestSmall(user1, construction, place1, item1, acc1);
        pr2 = createProcurementRequestBig(user1, construction, place1, item1);
        pr3 = createProcurementRequestSmall2(user1, construction, place1, item1, acc1);
        pr4 = createProcurementRequestSmall3(user1, construction, place1, item1, acc1);
        pr5 = createProcurementRequestSmall4(user1, construction, place1, item1, acc1);
        pr6 = createProcurementRequestSmall5(user1, construction, place1, item1, acc1);
        
        ph1 = createProcurementHeader('B_Material_Small', user1, construction, place1, item1, acc1);
        ph2 = createProcurementHeader('B_Material_Big', user1, construction, place1, item1, acc1);
        ph3 = createProcurementHeader('A_Material', user1, construction, place1, item1, acc1);
        
        
        pdB1 = createProcurementDetailB(ph1, pr1, item1);
        pdB2 = createProcurementDetailB(ph2, pr2, item1);
        
        pdA = createProcurementDetailA(ph3, item1);
        
        eah = createEstimatesAnswerHeader(user1, construction, place1, item1, acc1);
        ead = createEstimatesAnswerdetails(eah, pr2, item1);
        
        sh = createShipmentHeader(acc1);
        sd1 = createShipmentDetails(sh, pdB1);
        sd2 = createShipmentDetails(sh, pdB2);
        sd3 = createShipmentDetails(sh, pdA);
        
        sysDate = Date.today(); 
        invhed  = createInvoiceInfoHeader1(construction, acc1, sysDate.toStartOfMonth().addMonths(-1)); 
        invhedList1 = createInvoiceInfoHeader2(construction, acc1, sysDate.toStartOfMonth().addMonths(-1));
        invhedList2 = createInvoiceInfoHeader2(construction, acc1, sysDate.toStartOfMonth().addMonths(-2));
        invhedList3 = createInvoiceInfoHeader2(construction, acc1, sysDate.toStartOfMonth().addMonths(-3));
        
        invdet = createInvoiceInfoDetail1(invhed);
        invdet1 = createInvoiceInfoDetail2(invhedList1);
        invdet2 = createInvoiceInfoDetail2(invhedList2);
        invdet3 = createInvoiceInfoDetail2(invhedList3); 

        sInfo.TriggerInvalid__c = false; 
        update sInfo; //更新

    }

    // 調達依頼　B材小口作成
    public static ProcurementRequest__c createProcurementRequestSmall(User user1, Construction__c construction, Place__c place, Item__c item, Account acc1){
    
        String uniqueStr = System.now().format('hhmmssSSS');//

        ProcurementRequest__c data = new ProcurementRequest__c(
            RecordTypeId=MB_SobjectUtil.getRecordType('ProcurementRequest__c','B_Material_Small'),
            ASTPerson__c=user1.id,
            AmPm__c='AM',
            ConstructionNumber__c=construction.Id,
            DeliveryPlace__c=place.Id,
            DesiredDeliveryDate__c=MB_DateTimeUtil.getMonthOfStartDay(MB_DateTimeUtil.getToday()).addMonths(3),
            // EstimateVendors__c='',
            ItemName__c=item.Id,
            MaterialList__c='B材（小口）',
            ProcurementRequestRemarks__c='備考',
            Quantity__c=100,
            Tax__c=8,
            TransactionStatus__c='入力中',
            UnitPrice__c=100,
            Vendor__c=acc1.Id
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
    
    // 調達依頼　B材小口作成
    public static ProcurementRequest__c createProcurementRequestSmall2(User user1, Construction__c construction, Place__c place, Item__c item, Account acc1){
    
        String uniqueStr = System.now().format('hhmmssSSS');//

        ProcurementRequest__c data = new ProcurementRequest__c(
            RecordTypeId=MB_SobjectUtil.getRecordType('ProcurementRequest__c','B_Material_Small'),
            ASTPerson__c=user1.id,
            AmPm__c='AM',
            ConstructionNumber__c=construction.Id,
            DeliveryPlace__c=place.Id,
            DesiredDeliveryDate__c=MB_DateTimeUtil.getMonthOfStartDay(MB_DateTimeUtil.getToday()).addMonths(3),
            // EstimateVendors__c='',
            ItemName__c=item.Id,
            MaterialList__c='B材（小口）',
            ProcurementRequestRemarks__c='備考',
            Quantity__c=100,
            Tax__c=8,
            TransactionStatus__c='決裁者確認中',
            UnitPrice__c=100,
            Vendor__c=acc1.Id
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
    
    // 調達依頼　B材小口作成
    public static ProcurementRequest__c createProcurementRequestSmall3(User user1, Construction__c construction, Place__c place, Item__c item, Account acc1){
    
        String uniqueStr = System.now().format('hhmmssSSS');//

        ProcurementRequest__c data = new ProcurementRequest__c(
            RecordTypeId=MB_SobjectUtil.getRecordType('ProcurementRequest__c','B_Material_Small'),
            ASTPerson__c=user1.id,
            AmPm__c='AM',
            ConstructionNumber__c=construction.Id,
            DeliveryPlace__c=place.Id,
            DesiredDeliveryDate__c=MB_DateTimeUtil.getMonthOfStartDay(MB_DateTimeUtil.getToday()).addMonths(3),
            // EstimateVendors__c='',
            ItemName__c=item.Id,
            MaterialList__c='B材（小口）',
            ProcurementRequestRemarks__c='備考',
            Quantity__c=100,
            Tax__c=8,
            TransactionStatus__c='承認',
            UnitPrice__c=100,
            Vendor__c=acc1.Id
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
    
    // 調達依頼　B材大口作成
    public static List<ProcurementRequest__c> createProcurementRequestSmall4(User user1, Construction__c construction, Place__c place, Item__c item, Account acc1){
    
        String uniqueStr = System.now().format('hhmmssSSS');//

        List<ProcurementRequest__c> data = new List<ProcurementRequest__c>();
        ProcurementRequest__c p = new ProcurementRequest__c();
            
        p.RecordTypeId=MB_SobjectUtil.getRecordType('ProcurementRequest__c','B_Material_Small');
        p.ASTPerson__c=user1.id;
        p.AmPm__c='AM';
        p.ConstructionNumber__c=construction.Id;
        p.DeliveryPlace__c=place.Id;
        p.DesiredDeliveryDate__c=MB_DateTimeUtil.getMonthOfStartDay(MB_DateTimeUtil.getToday()).addMonths(3);
        // EstimateVendors__c='';
        p.ItemName__c=item.Id;
        p.MaterialList__c='B材（小口）';
        p.ProcurementRequestRemarks__c='備考';
        p.Quantity__c=100;
        p.Tax__c=8;
        p.TransactionStatus__c='決裁者確認中';
        p.UnitPrice__c=100;
        p.Vendor__c=acc1.Id;
        
        data.add(p);
        
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
    
    // 調達依頼　B材大口作成
    public static List<ProcurementRequest__c> createProcurementRequestSmall5(User user1, Construction__c construction, Place__c place, Item__c item, Account acc1){
    
        String uniqueStr = System.now().format('hhmmssSSS');//

        List<ProcurementRequest__c> data = new List<ProcurementRequest__c>();
        ProcurementRequest__c p = new ProcurementRequest__c();
            
        p.RecordTypeId=MB_SobjectUtil.getRecordType('ProcurementRequest__c','B_Material_Big');
        p.ASTPerson__c=user1.id;
        p.AmPm__c='AM';
        p.ConstructionNumber__c=construction.Id;
        p.DeliveryPlace__c=place.Id;
        p.DesiredDeliveryDate__c=MB_DateTimeUtil.getMonthOfStartDay(MB_DateTimeUtil.getToday()).addMonths(3);
        // EstimateVendors__c='';
        p.ItemName__c=item.Id;
        p.MaterialList__c='B材（大口）';
        p.ProcurementRequestRemarks__c='備考';
        p.Quantity__c=100;
        p.Tax__c=8;
        p.TransactionStatus__c='決裁者確認中';
        p.UnitPrice__c=100;
        p.Vendor__c=acc1.Id;
        
        data.add(p);
        
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
    

    // 調達依頼　B材大口作成
    public static ProcurementRequest__c createProcurementRequestBig(User user1, Construction__c construction, Place__c place, Item__c item){
    
        String uniqueStr = System.now().format('hhmmssSSS');//

        ProcurementRequest__c data = new ProcurementRequest__c(
            RecordTypeId=MB_SobjectUtil.getRecordType('ProcurementRequest__c','B_Material_Big'),
            ASTPerson__c=user1.id,
            AmPm__c='AM',
            ConstructionNumber__c=construction.Id,
            DeliveryPlace__c=place.Id,
            DesiredDeliveryDate__c=MB_DateTimeUtil.getMonthOfStartDay(MB_DateTimeUtil.getToday()).addMonths(3),
            ItemName__c=item.Id,
            MaterialList__c='B材（大口）',
            ProcurementRequestRemarks__c='',
            Quantity__c=100,
            Tax__c=8,
            TransactionStatus__c='入力中',
            UnitPrice__c=100
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

    // 調達ヘッダー
    public static ProcurementHeader__c createProcurementHeader(String recordType, User user1, Construction__c construction, Place__c place, Item__c item, Account acc1){
    
        String uniqueStr = System.now().format('hhmmssSSS');//

        ProcurementHeader__c data = new ProcurementHeader__c(
            RecordTypeId=MB_SobjectUtil.getRecordType('ProcurementHeader__c',recordType),
            ASTPerson__c=user1.id,
            Account__c=acc1.Id,
            ConstructionNumber__c=construction.Id,
            DeliveryPlace__c=place.Id,
            DesiredDeliveryDate__c=MB_DateTimeUtil.getMonthOfStartDay(MB_DateTimeUtil.getToday()).addMonths(3),
            ProcurementHeaderRemarks__c='',
            TransactionStatus__c='注文'
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


    // 調達明細　B材作成
    public static ProcurementDetails__c createProcurementDetailB(ProcurementHeader__c header, ProcurementRequest__c request, Item__c item){
    
        String uniqueStr = System.now().format('hhmmssSSS');//

        ProcurementDetails__c data = new ProcurementDetails__c(
            RecordTypeId=MB_SobjectUtil.getRecordType('ProcurementDetails__c','TypeB'),
            ItemName__c = item.Id,
            ProcurementDetailCompanyRemarks__c='社内備考',
            ProcurementDetailRemarks__c='備考',
            ProcurementTitle__c=header.id,
            Quantity__c=100,
            Tax__c=8,
            UnitPrice__c=100

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

    // 調達明細　A材作成
    public static ProcurementDetails__c createProcurementDetailA(ProcurementHeader__c header, Item__c item){
    
        String uniqueStr = System.now().format('hhmmssSSS');//

        ProcurementDetails__c data = new ProcurementDetails__c(
            RecordTypeId=MB_SobjectUtil.getRecordType('ProcurementDetails__c','TypeA'),
            DetailStatus__c='未出荷',
            ManualItemCode__c='A001',
            ManualItemName__c='A材',
            ManualUnit__c='個',
            Manufacturer__c='メーカー',
            ProcurementDetailCompanyRemarks__c='社内備考',
            ProcurementDetailRemarks__c='備考',
            ProcurementTitle__c=header.id,
            Quantity__c=100,
            RepresentativeForm__c='代表形式',
            Tax__c=8,
            UnitPrice__c=100
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
    
    // 見積回答ヘッダ
    public static EstimatesAnswerHeader__c createEstimatesAnswerHeader(User user1, Construction__c construction, Place__c place, Item__c item, Account acc1){
    
        String uniqueStr = System.now().format('hhmmssSSS');//

        EstimatesAnswerHeader__c data = new EstimatesAnswerHeader__c (
            ASTPerson__c=user1.id,
            Account__c=acc1.Id,
            AnswerDeliveryDate__c = MB_DateTimeUtil.getMonthOfStartDay(MB_DateTimeUtil.getToday()).addDays(1),
            ConstructionNumber__c=construction.Id,
            DesiredDeliveryDate__c = MB_DateTimeUtil.getMonthOfStartDay(MB_DateTimeUtil.getToday()).addMonths(3),
            OrderDate__c = MB_DateTimeUtil.getMonthOfStartDay(MB_DateTimeUtil.getToday()),
            DeliveryPlace__c = place.Id,
            EstimateCompanyRemarks__c = '社内備考'
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
    
    
    // 見積回答明細
    public static EstimatesAnswerDetails__c createEstimatesAnswerdetails(EstimatesAnswerHeader__c header, ProcurementRequest__c request, Item__c item){
    
        String uniqueStr = System.now().format('hhmmssSSS');//

        EstimatesAnswerDetails__c data = new EstimatesAnswerDetails__c (
            AnswerDeliveryDate__c = MB_DateTimeUtil.getMonthOfStartDay(MB_DateTimeUtil.getToday()).addDays(2),
            ApprovalNumber__c = request.Id,
            EstimateQty__c = 10,
            EstimatesAnswerHeader__c = header.Id,
            EstimatesUnit__c = 10,
            EstimateUnitPlice__c = 100,
            EstimsteRatio__c = 10,
            Item__c = item.Id,
            ItemPrice__c = 100,
            ProcurementDetailCompanyRemarks__c = '社内備考',
            ProcurementDetailRemarks__c = '備考',
            Quantity__c = 10,
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
    
    // 出荷ヘッダ
    public static ShipmentHeader__c createShipmentHeader(Account acc1){
    
        String uniqueStr = System.now().format('hhmmssSSS');//

        ShipmentHeader__c data = new ShipmentHeader__c(
            ShipmentStatus__c = '未出荷',
            ShipDate__c = MB_DateTimeUtil.getMonthOfStartDay(MB_DateTimeUtil.getToday()),
            Shipping__c = false,
            Vendor__c = acc1.Id,
            DeliveryNoteFinished__c = false
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
    
    // 出荷明細
    public static ShipmentDetails__c createShipmentDetails(ShipmentHeader__c header, ProcurementDetails__c detail){
    
        String uniqueStr = System.now().format('hhmmssSSS');//

        ShipmentDetails__c data = new ShipmentDetails__c(
            InvoiceMonth__c = MB_DateTimeUtil.getMonthOfStartDay(MB_DateTimeUtil.getToday()),
            ProcurementDetails__c = detail.Id,
            PurchaseInspectionDate__c = MB_DateTimeUtil.getMonthOfStartDay(MB_DateTimeUtil.getToday()),
            ShipmentDetailStatus__c = '未出荷',
            ShipmentUnit__c = 10,
            ShippingHeader__c = header.Id
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
    
    // 請求書情報ヘッダ
    public static InvoiceInfo__c createInvoiceinfoHeader1(Construction__c construction, Account acc1, Date invoiceMonth){
    
        String uniqueStr = System.now().format('hhmmssSSS');//
        
        InvoiceInfo__c data = new InvoiceInfo__c(        
            AccountName__c = acc1.Id,
            ConstructionNumber__c = construction.Id,
            InvoiceCheck__c = false,
            InvoiceMonth__c = invoiceMonth,
            RecordTypeId = MB_SobjectUtil.getRecordType('InvoiceInfo__c','InvoiceInfoHeader')
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
    
    
    
    // 請求書情報ヘッダ
    public static List<InvoiceInfo__c> createInvoiceinfoHeader2(Construction__c construction, Account acc1, Date invoiceMonth){
    
        String uniqueStr = System.now().format('hhmmssSSS');//
        
        List<InvoiceInfo__c> data = new List<InvoiceInfo__c>();
        InvoiceInfo__c i = new InvoiceInfo__c();
        
        i.AccountName__c = acc1.Id;
        i.ConstructionNumber__c = construction.Id;
        i.InvoiceCheck__c = false;
        i.InvoiceMonth__c = invoiceMonth;
        i.RecordTypeId = MB_SobjectUtil.getRecordType('InvoiceInfo__c','InvoiceInfoHeader');
        
        data.add(i);


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
    
    // 請求書情報明細
    public static InvoiceInfo__c createInvoiceinfoDetail1(InvoiceInfo__c header){
    
        String uniqueStr = System.now().format('hhmmssSSS');//
        
        InvoiceInfo__c data = new InvoiceInfo__c(
        
            MoneyIncludTaxSave__c = 1000,
            UnitPriceSave__c = 10,
            QuantitySave__c = 100,
            MoneySave__c = 1000,
            InvoiceInfoHeader__c = header.Id,
            RecordTypeId = MB_SobjectUtil.getRecordType('InvoiceInfo__c','InvoiceInfoDetail')
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
    
    
    // 請求書情報明細
    public static List<InvoiceInfo__c> createInvoiceinfoDetail2(List<InvoiceInfo__c> header){
    
        String uniqueStr = System.now().format('hhmmssSSS');//
        
        List<InvoiceInfo__c> data = new List<InvoiceInfo__c>();
        InvoiceInfo__c i = new InvoiceInfo__c();
        
        i.MoneyIncludTaxSave__c = 1000;
        i.UnitPriceSave__c = 10;
        i.QuantitySave__c = 100;
        i.MoneySave__c = 1000;
        i.InvoiceInfoHeader__c = header[0].Id;
        i.RecordTypeId = MB_SobjectUtil.getRecordType('InvoiceInfo__c','InvoiceInfoDetail');
        
        data.add(i);
        
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