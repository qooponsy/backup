public class MB_CalculateUtil{

    /** 小数第一位を四捨五入 **/
    public static Decimal roundScale(Decimal d){
        if (d == null){
            return d;
        }
        Decimal ret = 0.0;
        ret = d.setscale(1,System.RoundingMode.HALF_UP);
        return ret;
    }

    /** 小数第一位を切上げ **/
    public static Decimal roundUpScale(Decimal d){
        if (d == null){
            return d;
        }
        Decimal ret = 0.0;
        ret = d.round(System.RoundingMode.UP);
        return ret;
    }

    public static Decimal addTax(Decimal tax, Decimal Amount) {
        return roundUpScale(Amount * (1+ tax / 100));

    }
}