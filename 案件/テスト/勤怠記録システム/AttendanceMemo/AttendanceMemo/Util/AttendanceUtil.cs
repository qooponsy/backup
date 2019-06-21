using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceMemo.Util
{
    public class AttendanceUtil
    {
        public String SaveFilePath;
        public List<AttendanceData> aList;

        public class AttendanceData
        {
            public String StartTime;
            public String EndTime;
            public String WorkingHours;
            public String Remarks;
        }
        
        // コンストラクタ
        public AttendanceUtil(String savePath)
        {
            var FolderName = DateTime.Now.ToString("yyyy年");
            var FileName = DateTime.Now.ToString("yyyy年MM月.txt");

            SaveFilePath = savePath + @"\" + FolderName + @"\" + FileName;
        }

        public String Input()
        {
            var errMsg = "";
            
            // 勤怠ファイルの取得
            errMsg = getInputFileData();

            if(errMsg == "")
            {
                // リストの最終行を確認
                var lastIndex = aList.Count - 1;
                var checkData = aList[lastIndex];

                // 入力値チェック
                if (checkData.EndTime != "")
                {
                    // 退勤時間が空でなければ新しい日付の出勤時間を記入


                }
                else if (checkData.StartTime != "" && checkData.EndTime == "")
                {
                    // 出勤時間が記入されていて退勤時間が未記入であれば退勤時間を記入

                }
                else
                {
                    // 存在しないパターンのためエラー
                    errMsg = "出勤記録ファイルが不正です。\nファイル内容を確認ください。";
                }
            }


            return errMsg;
        }

        public String getInputFileData()
        {
            var errMsg = new StringBuilder();

            try
            {
                // 格納用リストの初期化
                aList = null;
                aList = new List<AttendanceData>();

                // 設定ファイル読込
                var sr = new StreamReader(SaveFilePath);
                var headerFlg = true;

                // 1行ずつ読込
                while (sr.Peek() > -1)
                {
                    if (headerFlg)
                    {
                        // ヘッダ行はスキップ
                        headerFlg = false;
                    }
                    else
                    {
                        // 勤怠入力データを取得
                        var line = sr.ReadLine();
                        var items = line.Split('\t');

                        var input = new AttendanceData();
                        input.StartTime = items[0];
                        input.EndTime = items[1];
                        input.WorkingHours = items[2];
                        input.Remarks = items[3];

                        aList.Add(input);
                    }
                }

            }
            catch (Exception ex)
            {
                errMsg.AppendLine("勤怠ファイルの読込に失敗しました。");
                errMsg.AppendLine(CommonUtil.getErrorMessage(ex));
            }

            return errMsg.ToString();
        }
         
    }
}
