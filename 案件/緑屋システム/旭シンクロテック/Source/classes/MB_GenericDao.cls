/**
 * generic DAO
 */
public class MB_GenericDao{

    public MB_GenericDao(String objectName){
        this.objectName = objectName;
    }

    /**  オブジェクト名称 */
    public String objectName {get; set;}

    public Schema.SObjectType getSobjectType() {
        return ((SObject)Type.forName(objectName).newInstance()).getSObjectType();
    }
 
    /**
     * Select句の生成を行う
     */
    public String getSelectStr(Set<String> selectFields) {
        String query = 'Select ';

        if (selectFields == null) {

            query += 'Id,';
            Map<String, Schema.SObjectField> fmap = getSobjectType().getDescribe().fields.getMap();
            for (String fieldKey : fmap.keySet() ) {
                if (fieldKey != 'Id') {
                    query += fieldKey + ',';
                }
            }

        } else {

            for (String field : selectFields) {
                query += field + ',';
            }

        }
        query = query.substring(0,query.length()-1);

        // query.removeEnd(',');

        query += ' From ';
        query += objectName;

        return query;
    }

    /**
     * Select句の生成を行う
     */
    public String getAllSelectStr(Set<String> selectFields) {
        String query = 'Select ';

        query += 'Id,';
        Map<String, Schema.SObjectField> fmap = getSobjectType().getDescribe().fields.getMap();
        for (String fieldKey : fmap.keySet() ) {
            if (fieldKey != 'Id') {
                query += fieldKey + ',';
            }
        }

        if (selectFields != null) {
            for (String field : selectFields) {
                query += field + ',';
            }
        }

        query = query.substring(0,query.length()-1);

        // query.removeEnd(',');

        query += ' From ';
        query += objectName;

        return query;
    }

    /**
     * Idの配列から対象オブジェクトの一覧を返す
     */
    public List<SObject> getAllByIds (Set<String> selectFields, Set<Id> ids, String orderBy) {

        String query = getAllSelectStr(selectFields);
        query += ' Where Id In : ids ';
        query += MB_ValidateUtil.isEmpty(orderBy) ? '' : ' ORDER BY ' + orderBy;
        System.debug(query);
        return Database.query(query);

    }

    /**
     * Idの配列から対象オブジェクトの一覧を返す
     */
    public List<SObject> getByIds (Set<String> selectFields, List<Id> ids) {

        String query = getSelectStr(selectFields);
        query += ' Where Id In : ids';
        System.debug(query);
        return Database.query(query);

    }

    /**
     * Idの配列から対象オブジェクトの一覧を返す
     */
    public List<SObject> getByIds (Set<String> selectFields, Set<Id> ids) {

        String query = getSelectStr(selectFields);
        query += ' Where Id In : ids';
        System.debug(query);
        return Database.query(query);

    }

    /**
     * Idから対象オブジェクトの情報を返す
     */
    public SObject getAllById (Set<String> selectFields, Id id) {

        String query = getAllSelectStr(selectFields);
        query += ' Where Id = \'' + id + '\'';
        System.debug(query);
        return uniqueResult(query);

    }

    /**
     * Idから対象オブジェクトの情報を返す
     */
    public SObject getById (Set<String> selectFields, Id id) {

        String query = getSelectStr(selectFields);
        query += ' Where Id = \'' + id + '\'';
        System.debug(query);
        return uniqueResult(query);

    }

    /**
     * 単一Select結果を返す。
     * Select結果がない場合はNullを返す
     */
    public SObject uniqueResult (String query) {
        List<SObject> temp = Database.query(query);
        if (temp.isEmpty()) {
            return null;
        }
        return temp.get(0);
    }

}