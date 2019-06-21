using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CreateShortcutTool
{
    static class Program
    {

        public static string BATCH_MODE_STR = "-batch";

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {

            var errMsg = "";

            // ショートカットの作成(バッチ)
            errMsg = CreateShortcutTool(BATCH_MODE_STR);

            if (errMsg == "")
            {
                // ショートカットの作成(Form)
                errMsg = CreateShortcutTool("");
            }

            if (errMsg != "")
            {
                MessageBox.Show(errMsg,
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("デスクトップにショートカットを作成しました。",
                    "ショートカット作成",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

        }


        static String CreateShortcutTool(String mode)
        {
            var ret = new StringBuilder();

            try
            {

                var lnkFileName = "勤怠バッチ(form).lnk";
                var cmdStr = "";

                if (mode == BATCH_MODE_STR)
                {
                    lnkFileName = "勤怠バッチ.lnk";
                    cmdStr = BATCH_MODE_STR;
                }   

                // ショートカット保存先（デスクトップ）
                var savePath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory) + @"\" +lnkFileName;

                // 起動アプリケーションの指定
                var exeFilePath = Environment.CurrentDirectory + @"\" + "AttendanceMemo.exe";

                // WshShellを作成
                var shell = new IWshRuntimeLibrary.WshShell();

                // ショートカットのお明日を指定してWshShortcutオブジェクトを作成
                var shortcutFile = (IWshRuntimeLibrary.IWshShortcut)shell.CreateShortcut(savePath);

                // ショートカットのリンク先を指定
                shortcutFile.TargetPath = exeFilePath;

                // コマンドライン引数を指定
                shortcutFile.Arguments = cmdStr;

                // 作業フォルダの指定?
                shortcutFile.WorkingDirectory = Application.StartupPath;

                // ショートカットの作成
                shortcutFile.Save();

                // Wshオブジェクトを破棄する
                System.Runtime.InteropServices.Marshal.ReleaseComObject(shortcutFile);

            }
            catch (Exception ex)
            {
                ret.AppendLine("ショートカットの作成に失敗しました。\n");
                ret.AppendLine(ex.Message);
                ret.AppendLine(ex.StackTrace);
            }

            return ret.ToString();
        }

    }
}
