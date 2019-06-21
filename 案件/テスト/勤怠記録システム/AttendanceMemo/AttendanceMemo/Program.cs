using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AttendanceMemo
{
    static class Program
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            var errMsg = "";

            // 設定ファイル読込
            errMsg = SettingsUtil.GetSttingsFile();

            if(errMsg == "")
            {
                // コマンドライン引数の取得
                errMsg = SettingsUtil.GetCommandLineParam();

                if(errMsg == "")
                {
                    if(SettingsUtil.isBatchMode())
                    {
                        // バッチモードで起動
                        BatchMain();
                    }
                    else
                    {
                        // フォームモードで起動
                        FormMain();
                    }
                }

            }

            if(errMsg != "")
            {
                // エラーあり
                MessageBox.Show(errMsg,
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// バッチ処理メイン
        /// </summary>
        public static void BatchMain()
        {

            

        }

        /// <summary>
        /// フォーム処理メイン
        /// </summary>
        public static void FormMain()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }

}
