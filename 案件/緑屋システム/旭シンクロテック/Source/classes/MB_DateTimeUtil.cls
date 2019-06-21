public class MB_DateTimeUtil{

    /**
     * 現在時刻を取得
     */
    public Static Datetime getDatetimeNow(){
        return Datetime.now();
    } 

    /**
     * 現在日付を取得
     */
    public Static Date getToday(){
        return Date.today();
    }

    /**
     * Datetimeを指定フォーマットのStringに変更
     */
    public Static String Datetime2Str(Datetime dt, String format){
        return dt.format(format, UserInfo.getTimeZone().getId());
    }

    /**
     * Dateを指定フォーマットのStringに変更
     */
    public Static String Date2Str(Date d, String format){
        if (d == null) {
            return '';
        }
        
        Datetime dt = Datetime.newInstance(d.year(), d.month(), d.day());
        return dt.format(format, UserInfo.getTimeZone().getId());
    }


    /**
    * 月初日付取得
    */
    public static Date getMonthOfStartDay(Date prmDate) {
        return Date.newInstance(prmDate.year(), prmDate.month(), 1);
    }

    /**
    * 月末日付取得
    */
    public static Date getMonthOfEndDay(Date prmDate) {
        return Date.newInstance(prmDate.year(), prmDate.month() + 1 ,0);
    }

}