using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace DaihonSample
{
    public partial class Form1 : Form
    {

        // 読込ファイルパス
        private const string EXCEL_FILE_NAME = @"Ev34_マタドール(レン）_プレビュー用.xlsx";

        // 描画フォント
        //private const string FONT_TYPE = "@ＭＳ ゴシック";
        private const string FONT_TYPE = "@ＭＳ 明朝";

        // PictureBoxサイズ
        private const int PICTURE_CODE_HEIGHT = 120;    // コードの縦幅
        private const int PICTURE_NAME_HEIGHT = 120;    // キャレクター名の縦幅
        private const int PICTURE_TEXT_HEIGHT = 260;    // 台詞の縦幅

        // 行間
        private const int LINE_SPACE_SIZE = 20;  // 行間のスペース
        private const int LINE_HEAD_SPACE_X = 20; // 文字列の開始スペース(x)
        private const int LINE_HEAD_SPACE_Y = 5; // 文字列の開始スペース(y)
        private const int LINE_TAIL_SPACE_Y = 5; // 文字列の終了スペース(y)

        // 描画開始位置（x）
        private float XCurrent = 0;
        private float XBefore = 0;

        // マウス選択位置（x）
        private float MouseStartX = float.MinValue;
        private float MouseEndX = float.MaxValue;

        // 読込データリスト
        private List<LineData> readList;

        public bool saveFlg = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // サンプル展開用
            label1.Visible = false;

            // 初期表示
            Init();
            // スクロールバーを一番右に
            panel1.AutoScrollPosition = new Point(3000, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Excelプレビュー表示
            ExcelPreview();
        }

        private void Init()
        {
            // 透過表示のために親PictureBoxを設定
            pbSelect.Parent = pbText;

            // テストデータ読込
            readList = LineData.CreateTestData();
            // リストを逆順に
            readList.Reverse();

            // 画面に描画
            SetVoiceLine(readList);

        }

        private void SetVoiceLine(List<LineData> list)
        {
            // 描画先
            var width = 3000;
            var canvasCode = new Bitmap(width, PICTURE_CODE_HEIGHT);
            var canvasName = new Bitmap(width, PICTURE_NAME_HEIGHT);
            var canvasText = new Bitmap(width, PICTURE_TEXT_HEIGHT);

            var fontSize = 10;
            var text = new StringBuilder();

            // yのスタート位置指定
            //var StartVoiceNoY = 0;
            //var EndVoiceNoY = PICTURE_CODE_HEIGHT;
            //var StartCharacterY = EndVoiceNoY;
            //var EndCharacterY = StartCharacterY + PICTURE_NAME_HEIGHT;
            //var StartVoiceY = EndCharacterY;
            //var EndVoiceY = StartVoiceY + PICTURE_TEXT_HEIGHT;

            foreach (var line in list)
            {
                WritePictureArea(canvasText, line.Voice, PICTURE_TEXT_HEIGHT, fontSize, true, true, ref line.StartX, ref line.EndX);
                WritePictureArea(canvasCode, line.VoiceNo, PICTURE_CODE_HEIGHT, fontSize, true, false, ref line.StartX, ref line.EndX);
                WritePictureArea(canvasName, line.Character, PICTURE_NAME_HEIGHT, fontSize, true, false, ref line.StartX, ref line.EndX);
            }

            pbCode.Image = canvasCode;
            pbName.Image = canvasName;
            pbText.Image = canvasText;
        }

        private void WritePictureArea(Bitmap canvas, String text, int endY,int fontSize, bool boldFlg, bool startReCalcFlg, ref float objStartX, ref float objEndX)
        {
            // グラフィック
            var g = Graphics.FromImage(canvas);
            
            Font fnt;
            
            // フォント
            if(boldFlg)
            {
                // 太字
                fnt = new Font(FONT_TYPE, fontSize,FontStyle.Bold);
            }
            else
            {
                // 指定なし
                fnt = new Font(FONT_TYPE, fontSize);
            }
            // 描画設定(縦書き + 右から左に表示)
            var sf = new StringFormat();
            sf.FormatFlags = StringFormatFlags.DirectionVertical | StringFormatFlags.DirectionRightToLeft;

            if (startReCalcFlg)
            {
                // x座標再計算
                var size = new SizeF(panel1.Width, PICTURE_TEXT_HEIGHT);
                var gSize = g.MeasureString(text, fnt, size ,sf);
                XBefore = XCurrent;
                XCurrent += LINE_HEAD_SPACE_X + LINE_SPACE_SIZE + gSize.Width;

                // オブジェクトごとにスタート位置を格納
                objStartX = XCurrent;
                objEndX = XBefore;
            }

            // 区切り線表示
            g.DrawLine(Pens.Black, XCurrent, 0, XCurrent, panel1.Height);

            // 文字列表示
            var textStartX = XCurrent - LINE_HEAD_SPACE_X;
            g.DrawString(text, fnt, Brushes.Black, textStartX, 1, sf);

            //var textStartX = XBefore + LINE_SPACE_SIZE;
            //var textStartY = LINE_HEAD_SPACE_Y;
            //var textEndX = XCurrent - LINE_HEAD_SPACE_X;
            //var textEndY = endY - LINE_TAIL_SPACE_Y;
            //var rect = new Rectangle((int)textStartX, textStartY, (int)textEndX, textEndY);
            //g.DrawString(text, fnt, Brushes.Black, rect, sf);

            //リソースを解放する
            sf.Dispose();
            fnt.Dispose();
            g.Dispose();
        }



        private void ExcelPreview()
        {

            Excel.Application exObj = null;    // Excelオブジェクト
            Excel.Workbook exBook = null;      // workbook

            try
            {

                exObj = new Excel.Application();
                //exObj.Visible = true;   // Excelウィンドウを表示する

                // Excelファイルオープン
                exBook = (Excel.Workbook)(exObj.Workbooks.Open(
                    Environment.CurrentDirectory + @"\" +  EXCEL_FILE_NAME // Excelファイル名
                    ));

                // 印刷プレビュー表示
                exObj.Visible = true;   // Excelウィンドウを表示する
                exBook.PrintPreview(true);

                exObj.Visible = false;   // Excelウィンドウを表示する
                exObj.Quit();

            } catch (Exception ex)
            {
                MessageBox.Show(GetExcetionMessage(ex),
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            } finally
            {
                if (exBook != null) { Marshal.ReleaseComObject(exBook); }
                if (exObj != null){ Marshal.ReleaseComObject(exObj);}
            }

        }


        /// <summary>
        /// エラーメッセージ生成
        /// </summary>
        /// <param name="ex"></param>
        /// <returns></returns>
        public String GetExcetionMessage(Exception ex)
        {

            var err = new StringBuilder();
            err.AppendLine("【エラー】" + ex.Message);
            err.AppendLine("【スタックトレース】");
            err.AppendLine(ex.StackTrace);

            return err.ToString();

        }

        private void pbCode_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowEditDialog(e);
        }

        private void pbName_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowEditDialog(e);
        }

        private void pbText_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowEditDialog(e);
        }

        private void ShowEditDialog(MouseEventArgs e)
        {

            var x = e.Location.X;

            var line = GetSelectLine(x);
            var d = new Form2(line);
            d.ShowDialog();

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            // マウスポインタの位置を取得
            var cursol = Cursor.Position;

            // クライアント座標に変換する
            var cp = pbText.PointToClient(cursol);

            var x = cp.X;
            if (MouseStartX < x || MouseEndX > x)
            {
                var line = GetSelectLine(x);

                label1.Text = "s:" + line.StartX + " e:" + line.EndX;

                // 描画先
                var width = 3000;
                var canvas = new Bitmap(width, panel1.Height);

                WriteSelectRectangle(ref canvas, line.EndX, line.StartX);

                pbSelect.Image = canvas;

                MouseStartX = line.EndX;
                MouseEndX = line.StartX;
            }
        }

        private LineData GetSelectLine(int x)
        {
            LineData ret = readList[0];
            foreach (var obj in readList)
            {
                if (x < obj.StartX)
                {
                    ret = obj;
                    break;
                }
            }

            return ret;
        }

        private void WriteSelectRectangle(ref Bitmap canvas, float startX, float endX)
        {
            var g = Graphics.FromImage(canvas);

            var b = new SolidBrush(Color.FromArgb(10, 0, 0, 255));
            g.FillRectangle(b, startX, 0, endX - startX, canvas.Height);

            g.Dispose();            
        }
    }
}
