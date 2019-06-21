/**
 * 取引先の請求月計算用の共通クラス
 *
 * @author Daiki.Uematsu
 * @createAt 2019/1/31
 */

public class MB_AccUtil{

    /**
     * 取引先の請求月計算
     */
    public static Date getLastBillingMonth(String cutoffDateStr) {
        
        // 当日日付
        Date today = MB_DateTimeUtil.getToday();
        Integer cutoffDate;
        if(cutoffDateStr == '月末締め') {
            Date monthOfEndDay = MB_DateTimeUtil.getMonthOfEndDay(today);
            cutoffDate = monthOfEndDay.day();
        } else {
            cutoffDateStr = cutoffDateStr.replace('日締め','');
            cutoffDate = Integer.valueOf(cutoffDateStr);
        }

        if (cutoffDate < today.day()){
            return MB_DateTimeUtil.getMonthOfStartDay(today);
        } else {
            Date lastMonth = today.addMonths(-1);
            return MB_DateTimeUtil.getMonthOfStartDay(lastMonth);
        } 
    }

    /**
     * 取引先の請求日計算
     *    引数1=請求月(yyyy/MM)　
     *    引数2=支払サイト(月区分)　
     *    引数3=支払サイト(日区分)
     */
    public static Date getBillingDate(Date tgt, String termsOfPayment, String termsOfPaymentDay) {

        // String bullingDayStr = billingMonthStr + '1日';
        // Date bullingDay = Date.valueOf(bullingDayStr);

        // 月計算
        Date billingMonth = calcBillingMonth(tgt, termsOfPayment);

        // 日計算
        Date billingMonthDay =  calcBillingDay(billingMonth, termsOfPaymentDay);

        return billingMonthDay;
    }

    /**
     * 取引先の請求月の計算
     *    引数1=請求月　
     *    引数2=支払サイト(月区分)　
     */
    public static Date calcBillingMonth(Date billingMonth, String termsOfPayment) {

        Date ret = null;
        switch on termsOfPayment {
           when '翌月払い' {
               ret = billingMonth.addMonths(1);
           }
           when '翌々月払い' {
               ret = billingMonth.addMonths(2);
           }
           when '三ヶ月後払い' {
               ret = billingMonth.addMonths(3);
           }
           when else {
               ret = null;
           }
        }

        return ret;
    }

    /**
     * 取引先の請求日の計算
     *    引数1=請求月　
     *    引数2=支払サイト(日区分)　
     */
    public static Date calcBillingDay(Date billingDay, String termsOfPaymentDay) {

        Date ret = null;
        switch on termsOfPaymentDay {
           when '5日払い' {
               ret = date.newinstance(billingDay.year(), billingDay.month(), 5);
           }
           when '10日払い' {
               ret = date.newinstance(billingDay.year(), billingDay.month(), 10);
           }
           when '15日払い' {
               ret = date.newinstance(billingDay.year(), billingDay.month(), 15);
           }
           when '20日払い' {
               ret = date.newinstance(billingDay.year(), billingDay.month(), 20);
           }
           when '25日払い' {
               ret = date.newinstance(billingDay.year(), billingDay.month(), 25);
           }
           when '月末払い' {
               ret = MB_DateTimeUtil.getMonthOfEndDay(billingDay);
           }
           when else {
               ret = null;
           }
        }

        return ret;
    }

}