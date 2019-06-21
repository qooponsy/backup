public class DaoProcurementRequest {
    private final static String OBJECT_NAME = 'ProcurementRequest__c';  // オブジェクト名称

    /**
     * Select句の生成を行う
     */
    public static String getSelectStr(Set<String> selectFields) {

        MB_GenericDao dao = new MB_GenericDao(OBJECT_NAME);

        String query = dao.getSelectStr(selectFields);

        return query;
    }

    /**
    * 調達依頼入力中のリストの取得
    * 　工事番号、区分、ステータスで絞込み
    **/
    public static List<ProcurementRequest__c> getInputList(String constructionNumber, String material, String transactionStatus, Integer limitation){
        String userId = UserInfo.getUserId();
        Set<String> fields = new Set<String>{};
        fields.add('ProcurementRequestNumber__c');  // 調達依頼番号
        fields.add('TransactionStatus__c');                  // 取引ステータス
        fields.add('Quantity__c');                               // 数量
        fields.add('QuantityUnit__c');                         // 数量単位
        fields.add('ItemName__r.Name');                            // 資材名
        fields.add('Vendor__r.Name');                                 // 仕入先
        fields.add('DeliveryPlace__r.Name');                        // 納入先
        fields.add('DesiredDeliveryDate__c');              // 希望納期
        fields.add('ProcurementRequestRemarks__c');              // 備考
        fields.add('AmPm__c');              // AMPM

        String query =getSelectStr(fields);
        query += ' ';
        query += 'Where ConstructionNumber__r.Name = :constructionNumber ';
        query += ' and MaterialList__c = :material ';
        query += ' and TransactionStatus__c = :transactionStatus ';
        query += ' and ASTPerson__c = :userId ';
        query += 'Order By CreatedDate  ';
        query += 'Limit :limitation ';
        System.debug(query);

        List<ProcurementRequest__c> ProcurementRequestList =Database.query(query);
        return ProcurementRequestList;
    }

    public static Boolean Regist(ProcurementRequest__c regItem){
        
        Boolean ret = true;
        try {
            // 登録処理
           Database.upsert(regItem);
        } catch (Exception ex) {
            System.debug('【登録エラー】' + '\n' + ex.getMessage());
            ret = false;
        }

        return ret;
    }

    public static Boolean Edit(List<ProcurementRequest__c> editItems){
        
        Boolean ret = true;
        try {
            // 登録処理
           Database.update(editItems);
        } catch (Exception ex) {
            System.debug('【更新エラー】' + '\n' + ex.getMessage());
            ret = false;
        }

        return ret;
    }

    public static Boolean Remove(List<Id> delIds){
        
        Boolean ret = true;
        try {
            // 登録処理
           Database.delete(delIds);
        } catch (Exception ex) {
            System.debug('【削除エラー】' + '\n' + ex.getMessage());
            ret = false;
        }

        return ret;
    }

}