public class DaoConstructionAccount {
    private final static String OBJECT_NAME = 'Construction_Account__c';  // オブジェクト名称

    /**
     * Select句の生成を行う
     */
    public static String getSelectStr(Set<String> selectFields) {

        MB_GenericDao dao = new MB_GenericDao(OBJECT_NAME);

        String query = dao.getSelectStr(selectFields);

        return query;
    }

    /**
    * 取引先の取得
    * 　工事番号、掛率単価マスタで絞込んだ取引先名で検索
    **/
    public static List<AggregateResult> getAccountList(String constructionNumber,List<String> vendorList){
        Set<String> fields = new Set<String>{};
        fields.add('Account__c');  
        fields.add('Account__r.Name');

        String query =getSelectStr(fields);
        query += ' ';
        query += 'Where ConstructionNumber__r.Name = :constructionNumber ';
        query += ' and Account__c IN ';
        query += '(';
        String comma = '';
        for(String vendor : vendorList){
            query += comma + '\'' + vendor + '\'';
            comma = ',';
        }
        query += ') ';
        query += 'Group By Account__c,Account__r.Name ';
        System.debug('query:' + query);

        List<AggregateResult> AccountList =Database.query(query);
        System.debug('AccountList:' + AccountList);
        return AccountList;
    }

    public static List<AggregateResult> getConstructionAccountList(String constructionNumber){
        Set<String> fields = new Set<String>{};
        fields.add('Account__c');  
        fields.add('Account__r.Name');

        String query =getSelectStr(fields);
        query += ' ';
        query += 'Where ConstructionNumber__r.Name = :constructionNumber ';
        query += 'Group By Account__c,Account__r.Name ';
        System.debug('query:' + query);

        List<AggregateResult> AccountList =Database.query(query);
        System.debug('AccountList:' + AccountList);
        return AccountList;
    }

}