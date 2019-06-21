public class DaoCategory {

    private final static String OBJECT_NAME = 'Category__c';  // オブジェクト名称

    /**
     * Select句の生成を行う
     */
    public static String getSelectStr(Set<String> selectFields) {

        MB_GenericDao dao = new MB_GenericDao(OBJECT_NAME);

        String query = dao.getSelectStr(selectFields);

        return query;
    }

    public static List<Category__c> getItemList(){
        Set<String> fields = new Set<String>{};
        fields.add('Classification__c');
        fields.add('Material__c'); 
        fields.add('Item__c');
        fields.add('SortClassification__c');
        fields.add('SortMaterial__c');
        fields.add('SortItem__c');
     
        String query =getSelectStr(fields);
        query += ' ';
        query += 'Group By Classification__c, Material__c, Item__c, SortClassification__c, SortMaterial__c, SortItem__c ';
        query += 'Order By SortClassification__c, SortMaterial__c, SortItem__c ';

        System.debug('★★★クエリ：' + query);

        List<Category__c> categoryList = new List<Category__c>();

        try{
            List<AggregateResult> aggregateList = Database.query(query);
            
            for (AggregateResult ar : aggregateList){
                Category__c c = new Category__c();
                c.Classification__c = String.valueOf(ar.get('Classification__c'));
                c.Material__c = String.valueOf(ar.get('Material__c'));
                c.Item__c = String.valueOf(ar.get('Item__c'));
                c.SortClassification__c = String.valueOf(ar.get('SortClassification__c'));
                c.SortMaterial__c = String.valueOf(ar.get('SortMaterial__c'));
                c.SortItem__c = String.valueOf(ar.get('SortItem__c'));

                categoryList.add(c);
            }
        }catch(Exception e){
            system.debug(e);
        }
        
        return categoryList;
    }

    /**
    * 規格リストの取得
    * 　分類、材質、品名で絞込み
    **/
    public static List<Category__c> getStandardList(String classification, String material, String item){
        Set<String> fields = new Set<String>{};
        fields.add('Standard1__c');
        fields.add('Standard2__c'); 

        String query =getSelectStr(fields);
        query += ' ';
        query += 'Where Classification__c = :classification ';
        query += ' and Material__c = :material ';
        query += ' and Item__c = :item ';
        query += 'Order By Name ';

        List<Category__c> categoryList =Database.query(query);
        return categoryList;
    }


}