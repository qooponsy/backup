@isTest
private class InvoiceOutputControllerTest{

    @isTest
    private static void constructorTest() {
        
        InvoiceOutputController ctrl = new InvoiceOutputController();
        
        AST_TestCommon_TRAN testTran = new AST_TestCommon_TRAN();
        testTran.createTranTestData();
        
        ctrl.selectDate = '2019/02/01,2019/02/01,2019/02/28';
        ctrl.invoiceList = new List<SelectOption>(); 
        ctrl.invoiceEndDate = testTran.sysDate;
        ctrl.lastBillingMonth = testTran.sysDate;
        ctrl.userId = testTran.communityUser1.Id;
        ctrl.loginUser = testTran.communityUser1;
        ctrl.cutoffDate = '月末締め';
        ctrl.invoiceInfoList = new List<InvoiceInfo__c>();
        ctrl.updateInvoiceInfoList = new List<InvoiceInfo__c>();
        ctrl.headerRecordType = '0120k000000CVODAA4';        
        ctrl.detailRecordType = '0120k000000CVOIAA4';        
        ctrl.goUrl = '1';
        
    }
    
    @isTest
    private static void initTest01() {
        
        InvoiceOutputController ctrl = new InvoiceOutputController();
        
        ctrl.selectDate = '2019-02-01,2019-02-01,2019-02-28';
        
        AST_TestCommon testCommon = new AST_TestCommon();
        testCommon.createMasterTestData();
        
        AST_TestCommon_TRAN testTran = new AST_TestCommon_TRAN();
        testTran.createTranTestData();
        
        System.runAs(testCommon.communityUser1) {
            Test.startTest();

            ctrl.init();
            ctrl.getInvoiceInfo(testTran.invhedList2[0].InvoiceMonth__c);
            ctrl.getDetailInvoiceInfo(testTran.invhedList1);
            
            
            ctrl.invoiceOutput();
            
            for (Integer i = 0; i < testTran.invdet1.size(); i++) {
                testTran.invdet1[i].recalculateFormulas();
            }
            
            ctrl.updateInvoiceInfo(testTran.invhed, testTran.invdet1, testTran.sysDate, testTran.sysDate);
            
            Test.stopTest();

        }
    
    }
    
    @isTest
    private static void initTest02() {
        
        InvoiceOutputController ctrl = new InvoiceOutputController();
        
        
        AST_TestCommon testCommon = new AST_TestCommon();
        testCommon.createMasterTestData();
        
        AST_TestCommon_TRAN testTran = new AST_TestCommon_TRAN();
        testTran.createTranTestData();
        
        System.runAs(testCommon.communityUser2) {
        
            Test.startTest();
            
            
            
            ctrl.init();
            ctrl.getInvoiceInfo(testTran.invhedList3[0].InvoiceMonth__c);
            ctrl.getDetailInvoiceInfo(testTran.invhedList1);
            
            for (Integer i = 0; i < testTran.invdet1.size(); i++) {
                testTran.invdet1[i].recalculateFormulas();
            }
            
            ctrl.updateInvoiceInfo(testTran.invhed, testTran.invdet1, testTran.sysDate, testTran.sysDate);
            
            Test.stopTest();
        }
    
    }

}