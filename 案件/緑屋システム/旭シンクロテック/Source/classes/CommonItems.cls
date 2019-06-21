public class CommonItems {
    //B材
    public static final String MATERIAL_LIST_SMALL = 'B材（小口）';
    public static final String MATERIAL_LIST_BIG = 'B材（大口）';

    //B材レコードタイプ名
    public static Map<String, String> RECORDE_TYPE_MATERIAL = new Map<String, String>{
        MATERIAL_LIST_SMALL => 'B_Material_Small',
        MATERIAL_LIST_BIG => 'B_Material_Big'
    };

    //AM/PM区分
    public static List<String> AMPM_LIST = new List<String>{
        'AM',
        'PM'
    };

    //資材一覧/ステータス
    public static final String PROCUREMENTS_STATUS_INPUT = '入力中';
    public static final String PROCUREMENTS_STATUS_CHECK = '決裁者確認中';
    public static final String PROCUREMENTS_STATUS_APPROVAL = '承認';
    public static final String PROCUREMENTS_STATUS_REJECTION = '却下';
    public static final String PROCUREMENTS_STATUS_PROCUREMENT = '調達依頼中';     // 未使用

    // public static void Init() {
    //     // B材レコードタイプ初期化
    //     RECORDE_TYPE_MATERIAL.put(MATERIAL_LIST_SMALL, 'B_Material_Small');
    //     RECORDE_TYPE_MATERIAL.put(MATERIAL_LIST_BIG, 'B_Material_Big');

    //     System.debug('★★★初期処理：' + CommonItems.RECORDE_TYPE_MATERIAL);
    // }
}