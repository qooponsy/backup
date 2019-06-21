public class DaoConstructionPlace {
    private final static String OBJECT_NAME = 'Construction_Place__c';  // オブジェクト名称

    /**
     * Select句の生成を行う
     */
    public static String getSelectStr(Set<String> selectFields) {

        MB_GenericDao dao = new MB_GenericDao(OBJECT_NAME);

        String query = dao.getSelectStr(selectFields);

        return query;
    }

    public static List<AggregateResult> getPlaceList(String constructionNumber){

        Set<String> fields = new Set<String>{};
        fields.add('Place__c');
        fields.add('Place__r.Name');

        String query =getSelectStr(fields);
        query += ' ';
        query += 'Where ConstructionNumber__r.Name = :constructionNumber ';
        query += 'Group By Place__c,Place__r.Name ';

        System.debug('クエリ:' + query);
        System.debug('工事番号:' + constructionNumber);
        List<AggregateResult> PlaceList =Database.query(query);
        return PlaceList;
    }
}