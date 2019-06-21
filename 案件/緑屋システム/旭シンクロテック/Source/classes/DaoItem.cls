public class DaoItem {
    private final static String OBJECT_NAME = 'Item__c';  // オブジェクト名称

    /**
     * Select句の生成を行う
     */
    public static String getSelectStr(Set<String> selectFields) {

        MB_GenericDao dao = new MB_GenericDao(OBJECT_NAME);

        String query = dao.getSelectStr(selectFields);

        return query;
    }

    /**
    * サイズリストの取得
    * 　選択されたカテゴリー情報で絞込み
    **/
    public static List<Item__c> getStandardList(Category__c category){
        Set<String> fields = new Set<String>{};
        fields.add('Name');
        fields.add('Size__c');
        fields.add('Unit__c');
        fields.add('MinimumOrdering__c');

        String Classification = category.Classification__c;
        String Material = category.Material__c;
        String Item = category.Item__c;
        String Standard1 = category.Standard1__c;
        String Standard2 = category.Standard2__c;

        String query =getSelectStr(fields);
        query += ' ';
        query += 'Where Classification__c = :Classification ';
        query += ' and Material__c = :Material ';
        query += ' and Item__c = :Item ';

        if(!String.isBlank(Standard1)){
            query += ' and Standard1__c = :Standard1 ';
        } else {
            query += ' and Standard1__c = null ';
        }

        if(!String.isBlank(Standard2)){
            query += ' and Standard2__c = :Standard2 ';
        } else {
            query += ' and Standard2__c =  null ';
        }

        query += 'Order By ItemCode__c ';
        System.debug('★★★query:' + query);
        List<Item__c> categoryList =Database.query(query);
        return categoryList;
    }

    public static item__c getItem(Category__c category, String size) {
        Set<String> fields = new Set<String>{};
        fields.add('Name');
        fields.add('ItemCode__c');

        System.debug('◇◇◇category:' + category);
        String Classification = category.Classification__c;
        String Material = category.Material__c;
        String Item = category.Item__c;
        String Standard1 = category.Standard1__c;
        String Standard2 = category.Standard2__c;

        String query =getSelectStr(fields);
        query += ' ';
        query += 'Where Classification__c = :Classification ';
        query += ' and Material__c = :Material ';
        query += ' and Item__c = :Item ';

        if(!String.isBlank(Standard1)){
            query += ' and Standard1__c = :Standard1 ';
        }

        if(!String.isBlank(Standard2)){
            query += ' and Standard2__c = :Standard2 ';
        }

        query += ' and Size__c = :size ';
        System.debug('★●★query:' + query);
        List<Item__c> itemList =Database.query(query);
        System.debug('◇◇◇itemList:' + itemList);
        return itemList[0];
    }

    /**
    * 資材リストの取得
    * 　IDで絞込み
    **/
    public static item__c getItemObject(String id) {
        Set<String> fields = new Set<String>{};
        fields.add('Classification__c'); //分類
        fields.add('Material__c'); //材質
        fields.add('Item__c'); //品名
        fields.add('Standard1__c'); //規格1
        fields.add('Standard2__c'); //規格2
        fields.add('Size__c'); //サイズ
        fields.add('Unit__c'); //単位
        fields.add('ItemRemarks__c'); //備考

        String query =getSelectStr(fields);
        query += ' ';
        query += 'Where Id = :id ';

        System.debug('★★★query:' + query);
        System.debug('★★★Id:' + id);
        List<Item__c> itemList =Database.query(query);
        System.debug('☆☆☆getItemObject,itemList:' + itemList);
        return itemList[0];
    }

    /**
    * 資材検索時のリスト取得
    */
    public static List<item__c> getSearchList(String classification, String itemName) {
        Set<String> fields = new Set<String>{};
        fields.add('Name'); //資材名
        fields.add('Classification__c'); //分類
        fields.add('Material__c'); //材質
        fields.add('Item__c'); //品名
        fields.add('Standard1__c'); //規格1
        fields.add('Standard2__c'); //規格2
        fields.add('Size__c'); //サイズ
        fields.add('Unit__c'); //単位

        String keyword = '%' + itemName + '%';
        String query =getSelectStr(fields);
        query += ' ';
        query += 'Where Classification__c = :classification	 ';
        query += ' and Name LIKE :keyword ';
        query += ' Order By ItemCode__c ';

        System.debug('★★★query:' + query);
        System.debug('★★★classification:' + classification);
        System.debug('★★★itemName:' + itemName);
        System.debug('★★★keyword:' + keyword);

        List<Item__c> itemList = Database.query(query);
        System.debug('2☆クエリが何を返しているのかチェック:' + Database.query(query));
        System.debug('☆☆☆getSearchList,itemList:' + itemList);
        return itemList;
    }

}