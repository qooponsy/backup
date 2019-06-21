@isTest
public class InvoiceVerificationControllerTest {
	//テストする関数をメモ
    //InvoiceVerificationController
    //getInvoiceInfo
    //invoiceVerification
    //DateStrFormat
    //TransitionErrorReport
	//正常処理
    static testMethod void InvoiceVerificationTest(){
        //請求書情報作成　InvoiceInfo__c InvoiceInfoHeader InvoiceInfoDetail
		
        
        //取引先作成	Account
        Account InsAccount = new Account(
            				Name = '取引先１'
                            ,RecordTypeId = getRecordTypeIdByQuery('Account','Vendor')
                            ,AccountID__c = '0000000001'
                            ,Representative__c = '代表者名'
                            );
        insert InsAccount;
        //工事番号作成	Construction__c
        Construction__c InsConstruction = new Construction__c(
                            Name = '工事番号１'
                            ,ConstructionName__c = '現場名'
                            );
        insert InsConstruction;
    }
    
    public static ID getRecordTypeIdByQuery( String objectName, String recordTypeName ){
        
        List<RecordType> recordTypeList = [SELECT Id
                                           FROM RecordType
                                           WHERE SobjectType = :objectName
                                           AND DeveloperName = :recordTypeName
                                          ];
        return ( recordTypeList != null && !recordTypeList.isEmpty() ) ? recordTypeList[0].Id : null ;
    }
}