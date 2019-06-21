public class MB_SobjectUtil{

    /**
     * レコードタイプ取得
     */
    public static ID getRecordType( String objectName, String recordTypeName ){
    
        List<RecordType> recordTypeList = [SELECT Id
                                           FROM RecordType
                                           WHERE SobjectType = :objectName
                                           AND DeveloperName = :recordTypeName
        ];
        return ( recordTypeList != null && !recordTypeList.isEmpty() ) ? recordTypeList[0].Id : null ;
    }

    /**
     * オブジェクト名からSobjectTypeを取得
     */
    public Static Schema.SObjectType getSobjectType(String objectName) {
        return ((SObject)Type.forName(objectName).newInstance()).getSObjectType();
    }

    /**
     * オブジェクトの項目一覧をリストで取得
     */
    public Static List<String> getSobjectFieldList(String objectName) {
        List<String> ret = new List<String>();
        Map<String, Schema.SObjectField> fmap = getSobjectType(objectName).getDescribe().fields.getMap();
        for (String fieldKey : fmap.keySet() ) {
            ret.add(fieldKey);
        }
        return ret;
    }

    /**
     * オブジェクトの項目をStringカンマ区切りで取得
     */
    public Static String getSobjectFieldStr(String objectName) {
        String ret = '';
        Map<String, Schema.SObjectField> fmap = getSobjectType(objectName).getDescribe().fields.getMap();
        for (String fieldKey : fmap.keySet() ) {
            ret += fieldKey + ',';
        }
        ret = ret.substring(0,ret.length()-1);
        return ret;
    }

    public Static object getByFieldNameFromSobject(Sobject obj, String fieldName){

        List<String> objRelList = fieldName.split('\\.'); 
        SObject s = obj;

        try {
            if (objRelList.size() > 1) {
                for (Integer i = 0; i < objRelList.size() - 1; i++) {
                    s = s.getSObject(objRelList[i]);
                }
            }
            return s.get(objRelList[objRelList.size()-1]);

        } catch(exception e) {
            return null;
        }


    }

    /**
     * Sobjectのリストから指定した項目名の値からSetを作成
     * 項目名(fieldNames)は複数指定可能。戻り値は指定した項目名(fieldNames)をキーにしたMap
     */
    public static Map<String,Set<String>> createSets (List<SObject> objects, String[] fieldNames) {

        Map<String,Set<String>> ret = new Map<String,Set<String>>();

        for (String fieldName : fieldNames) {
            Set<String> tmp = new Set<String>();
            ret.put(fieldName, tmp);
        }

        for (SObject obj : objects) {
            for (String fieldName : fieldNames) {
                Set<String> tmp = ret.get(fieldName);
                tmp.add((String)obj.get(fieldName));
                ret.put(fieldName, tmp);
            }
        }

        return ret;
    }


    /**
     * Sobjectのリストから指定した項目名の値をキーとして、指定した項目名の値が同じものListを値としたMapを作成
     * 項目名(fieldNames)は複数指定可能。戻り値は指定した項目名(fieldNames)をキーにしたMap
     */
    public static Map<String,Map<String,List<SObject>>> createListMaps (List<SObject> objects, String[] fieldNames) {

        Map<String,Map<String,List<SObject>>> ret = new Map<String,Map<String,List<SObject>>>();

        for (String field : fieldNames) {
            Map<String, List<SObject>> item = new Map<String, List<SObject>>();
            ret.put(field, item);
        }

        for (SObject obj : objects) {
            for (String field : fieldNames) {
                String key = String.valueof(obj.get(field));
                Map<String, List<SObject>> tmp = ret.get(field);
                List<SObject> tmpList = tmp.containsKey(key) ? tmp.get(key) : new List<SObject>();
                tmpList.add(obj);
                tmp.put(key, tmpList);
                ret.put(field, tmp);
            }
        }

        return ret;
    }


}