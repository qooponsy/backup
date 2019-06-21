public class MB_ValidateUtil{
    /**
     * 引数の文字列が全角であるか確認する
     * [入力不可の文字]
     *  !"#$%&'()*+,-./
     * 0123456789:;<=>?
     * @ABCDEFGHIJKLMNO
     * PQRSTUVWXYZ[\]^_
     * `abcdefghijklmno
     * pqrstuvwxyz{|}~
     *
     */
    public static boolean isZenkaku(String arg) {
        if(String.isBlank(arg)){
            return true;
        }
        return !Pattern.matches('^.*[¥x20-¥x7F].*$', arg);
    }
    /**
     * 引数の文字列が半角であるか確認する
     * [入力可能な文字]
     *  !"#$%&'()*+,-./
     * 0123456789:;<=>?
     * @ABCDEFGHIJKLMNO
     * PQRSTUVWXYZ[\]^_
     * `abcdefghijklmno
     * pqrstuvwxyz{|}~
     */
    public static boolean isHankaku(String arg) {
        if(String.isBlank(arg)){
            return true;
        }
//        return Pattern.matches('^[?x20-?x7F]+$', arg);
        arg = arg.replace('[','');
        arg = arg.replace(']','');
        arg = arg.replace('\\','');
        if (arg <> '') {
            return Pattern.matches('^[a-zA-Z0-9 !"#$%&\'()*+,-./:;<=>?@^_`{|}~]+$', arg);
        }
        return true;
    }
    /**
     * 引数の文字列が英数字であるか確認する
     */
    public static boolean isAlphanumeric(String arg) {
        if(String.isBlank(arg)){
            return true;
        }
        
        return arg.isAlphanumericSpace();
    }
    /**
     * 引数の文字列が英字であるか確認する
     */
    public static boolean isAlpha(String arg) {
        return arg.isAlphaSpace();
    }
    /**
     * 引数の文字列が数値であるか確認する
     */
    public static boolean isNumber(String arg) {
        if(String.isBlank(arg)){
            return true;
        }
        
        if(isZenkaku(arg)){
            return false;
        }
        
        try {
            Decimal num = toNumber(arg);
        } catch ( Exception e ) {
            return false;
        }
        return true;
    }
    /**
     * 引数の文字列を数値型に変換する
     */
    public static Decimal toNumber(String arg) {
        if(String.isBlank(arg)) {
            return null;
        }
        return Decimal.valueOf(arg.replace(',', ''));
    }
    /**
     * 引数の文字列が電話番号型であるか確認する
     */
    public static boolean isTel(String arg) {
        Pattern telPattern = Pattern.compile('^[0-9+][0-9]*$');
        return telPattern.matcher(arg).matches();
    }
    /**
     * 引数の文字列が郵便番号型であるか確認する
     */
    public static boolean isYBN(String arg) {
        Pattern telPattern = Pattern.compile('^[0-9]*$');
        return telPattern.matcher(arg).matches();
    }
    /**
     * 引数の文字列が日付型であるか確認する
     */
    public static boolean isDate(String arg) {
        if(String.isBlank(arg)){
            return true;
        }
        try {
            Date d = toDate(arg);
        } catch ( Exception e ) {
            return false;
        }
        return true;
    }
    /**
     * 引数の文字列を日付型に変換する
     */
    public static Date toDate(String arg) {
        if(String.isBlank(arg)) {
            return null;
        }
        return Date.valueOf(arg.replace('/', '-'));
    }
    /**
     * 引数の文字列が指定された桁数（以下）か確認する
     */
    public static boolean isLessEqualBy(String arg, Integer degit) {
        return ((String.isBlank(arg) ? '' : arg).length() <= degit);
    }
    /**
     * 引数の文字列が指定された桁数（以上）か確認する
     */
    public static boolean isGreaterEqualBy(String arg, Integer degit) {
        return ((String.isBlank(arg) ? '' : arg).length() >= degit);
    }
    /**
     * 引数の文字列が指定された桁数（一致）か確認する
     */
    public static boolean isEqualsTo(String arg, Integer degit) {
        return ((String.isBlank(arg) ? '' : arg).length() == degit);
    }
    /**
     * 引数の文字列が指定された数値以上であることを確認する
     */
    public static boolean isGreaterEqual(String arg, Decimal basis) {
        try {
            return toNumber(arg) >= basis ;
        } catch ( Exception e ) {
            return false;
        }
    }
    /**
     * 引数の文字列が指定された数値以下であることを確認する
     */
    public static boolean isLessEqual(String arg, Decimal basis) {
        try {
            return toNumber(arg) <= basis ;
        } catch ( Exception e ) {
            return false;
        }
    }
    /**
     * 引数のFrom-Toの日付関係が妥当であるか確認する
     */
    public static boolean isFromToDate(String fromDay, String toDay) {
        Date fromDate = toDate(fromDay);
        Date toDate = toDate(toDay);
        if ( fromDate==null || toDate==null ) {
            return true;
        }
        return (fromDate.daysBetween(toDate) >= 0);
    }
    /**
     * 引数の少数（数字文字列）が指定されたフォーマットの形式となっているか確認する
     * （formatが「3.2」の場合、整数部３桁、小数部２桁以内の文字列を許可）
     */
    public static boolean isDecimalFormat(String arg, Decimal format) {
        if(String.isBlank(arg)){
            return true;
        }
        
        try {
            String degits = String.valueOf(format);
            String[] degit = degits.split('\\.');
            Integer upperFormat = Integer.valueOf((degit.size()==0 || String.isBlank(degit[0]))?'0':degit[0]);
            Integer lowerFormat = Integer.valueOf((degit.size()==1 || String.isBlank(degit[1]))?'0':degit[1]);
           
            String[] val = arg.split('\\.');
            String upperVal = (val.size()==0||(String.isBlank(val[0]))?'':val[0]).replace(',', '');
            String lowerVal = (val.size()==1||(String.isBlank(val[1]))?'':val[1]).replace(',', '');

            if ( upperVal.length() > upperFormat || lowerVal.length() > lowerFormat ) {
                return false;
            }
        } catch ( Exception e ) {
            System.debug(e);
            return false;
        }
        return true;
    }

    /**
    * 引数の文字列がnullもしくは空であるか確認する
    */
    public static Boolean isEmpty(String target) {
        return (target == null || target == '');
    }

    /**
    * 引数のListオブジェクトがnullもしくは空であるか確認する
    */
    public static Boolean isEmpty(List<Object> target) {
        return (target == null || target.isEmpty());
    }
}