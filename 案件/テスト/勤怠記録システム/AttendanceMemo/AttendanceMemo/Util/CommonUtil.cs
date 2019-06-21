using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceMemo
{
    public class CommonUtil
    {


        public static String getErrorMessage(Exception ex)
        {
            var errMsg = new StringBuilder();
            errMsg.AppendLine(ex.Message);
            errMsg.AppendLine("[スタックトレース]");
            errMsg.AppendLine(ex.StackTrace);

            return errMsg.ToString();
        }

    }
}
