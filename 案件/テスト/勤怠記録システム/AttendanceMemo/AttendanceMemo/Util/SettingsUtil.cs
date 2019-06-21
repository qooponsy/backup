using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceMemo
{
    public class SettingsUtil
    {

        public const String SETTING_FILE_NAME = @"setting.config";
        public const String PRM_FILE_PATH = "ファイル保存先";
        public const String PRM_START_TIME = "出勤時刻";
        public const String PRM_END_TIME = "退勤時刻";
        public const String PRM_ENTRY_UNIT_FLG = "記入単位フラグ";
        public const String PRM_ENTRY_UNIT = "記入単位(分)";

        public const String CMD_PRM_NAME = "-batch";

        public static String FilePath;
        public static DateTime StartTime;
        public static DateTime EndTime;
        public static int EntryUnitFlg;
        public static int EntryUnit;

        private static Boolean batchMode = false;

        public static String GetSttingsFile()
        {
            var ret = new StringBuilder();

            try
            {
                // 設定ファイル読込
                var sr = new StreamReader(SETTING_FILE_NAME);
                
                // 1行ずつ読込
                while (sr.Peek() > -1 )
                {
                    var line = sr.ReadLine();
                    var prams = line.Split('=');

                    // ファイル保存先
                    if (prams[0] == PRM_FILE_PATH)
                    {
                        if(prams[1] != "")
                        {
                            // 設定あり
                            FilePath = prams[1];
                        } else
                        {
                            // 設定なし
                            //  デスクトップをデフォルトで設定
                            FilePath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\勤怠";
                        }

                    }

                    // 出勤時刻
                    if (prams[0] == PRM_START_TIME)
                    {
                        if (prams[1] != "")
                        {
                            // 設定あり
                            StartTime = ConvertToDayDateTime(prams[1]);
                        }
                        else
                        {
                            // 設定なし
                            StartTime = DateTime.MinValue;
                        }
                    }

                    // 退勤時刻
                    if (prams[0] == PRM_END_TIME)
                    {
                        if (prams[1] != "")
                        {
                            // 設定あり
                            EndTime = ConvertToDayDateTime(prams[1]);
                        }
                        else
                        {
                            // 設定なし
                            EndTime = DateTime.MinValue;
                        }

                    }

                    // 記入単位フラグ
                    if (prams[0] == PRM_ENTRY_UNIT_FLG )
                    {
                        if (prams[1] != "")
                        {
                            // 設定あり
                            EntryUnitFlg = int.Parse(prams[1]);
                        }
                        else
                        {
                            // 設定なし
                            EntryUnitFlg = 0;
                        }
                    }

                    // 記入単位(分)
                    if (prams[0] == PRM_ENTRY_UNIT)
                    {
                        if (prams[1] != "" && EntryUnitFlg != 0)
                        {
                            // 設定あり
                            EntryUnit = int.Parse(prams[1]);
                        }
                        else
                        {
                            // 設定なし
                            EntryUnit = 0;
                        }

                    }
                }
                
            }
            catch (Exception ex)
            {
                ret.AppendLine("設定ファイルの読込に失敗しました。\n");
                ret.AppendLine(CommonUtil.getErrorMessage(ex));
            }

            return ret.ToString();
        }

        public static String GetCommandLineParam()
        {
            var ret = new StringBuilder();
            try
            {
                // コマンドライン引数を配列で取得
                var cmds = Environment.GetCommandLineArgs();
                if(cmds.Length == 2)
                {
                    // 値確認
                    if(cmds[1] == CMD_PRM_NAME)
                    {
                        batchMode = true;
                    }
                }
                else if (cmds.Length > 2)
                {

                }
            }
            catch(Exception ex)
            {
                ret.AppendLine("コマンドライン引数の読込に失敗しました。\n");
                ret.AppendLine(CommonUtil.getErrorMessage(ex));
            }

            return ret.ToString();
        }

        public static Boolean isBatchMode()
        {
            return batchMode;
        }

        public static DateTime ConvertToDayDateTime(String timeStr)
        {
            var today = DateTime.Now.ToString("yyyy/MM/dd");
            var DateStr = today + " " + timeStr;

            var ret = DateTime.Parse(DateStr);

            return ret;
        }
    }
}
