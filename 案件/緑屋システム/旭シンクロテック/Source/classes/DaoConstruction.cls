public class DaoConstruction {

    private final static String OBJECT_NAME = 'Construction__c';  // オブジェクト名称

    /**
     * Select句の生成を行う
     */
    public static String getSelectStr(Set<String> selectFields) {

        MB_GenericDao dao = new MB_GenericDao(OBJECT_NAME);

        String query = dao.getSelectStr(selectFields);

        return query;
    }

    public static List<Construction__c> getConstructionList(){

        Set<String> fields = new Set<String>{};
        fields.add('Name');
        fields.add('ConstructionName__c'); 
        fields.add('RecordTypeId'); 

        String query =getSelectStr(fields);
        query += ' ';
        query += 'Where ExpirationDate__c >= TODAY ';
        query += 'AND ExpirationDateFrom__c <= TODAY ';
        query += 'Order By Name';

        List<Construction__c> constructionList =Database.query(query);
        return constructionList;
    }

    public static Construction__c getConstructionObject(String constructionNumber){

        Set<String> fields = new Set<String>{};
        fields.add('Id');
        fields.add('Name');

        String query =getSelectStr(fields);
        query += ' ';
        query += 'Where Name = :constructionNumber ';

        List<Construction__c> constructionList =Database.query(query);
        return constructionList[0];

    }

}