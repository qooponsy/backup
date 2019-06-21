public class DaoUnitPrice {
    private final static String OBJECT_NAME = 'UnitPrice__c';  // オブジェクト名称

    /**
     * Select句の生成を行う
     */
    public static String getSelectStr(Set<String> selectFields) {

        MB_GenericDao dao = new MB_GenericDao(OBJECT_NAME);

        String query = dao.getSelectStr(selectFields);

        return query;
    }

    /**
    * 
    **/
    public static List<AggregateResult> getItemVendorList(String itemId){

        Set<String> fields = new Set<String>{};
        fields.add('Vendor__c');

        String query =getSelectStr(fields);
        query += ' ';
        query += 'Where Item__c = :itemId ';
        query += 'Group By Vendor__c ';

        System.debug('★★★ID：' + itemId);
        System.debug('★★★query：' + query);

        // 登録処理
        List<AggregateResult > vendorList =Database.query(query);

        return vendorList;
    }

    public static Map<String, String> isItem(String procurementRequestNumber ,String itemId,  String vendorId){
        
        Set<String> fields = new Set<String>{};
        fields.add('Name');

        String query =getSelectStr(fields);
        query += ' ';
        query += 'Where Item__c = :itemId ';
        query += ' and Vendor__c = :vendorId ';

        System.debug('★★★itemId：' + itemId);
        System.debug('★★★vendorId：' + vendorId);
        System.debug('★★★query：' + query);

        List<UnitPrice__c > unitPriceList =Database.query(query);

        // 件数チェック
        String ret = 'true';
        if (unitPriceList.size() == 0) {
            ret = 'false';
        }

        Map<String,String> retMap = new Map<String,String>();
        retMap.put('ProcurementRequestNumber', procurementRequestNumber);
        retMap.put('check', ret);

        return retMap;
    }

}