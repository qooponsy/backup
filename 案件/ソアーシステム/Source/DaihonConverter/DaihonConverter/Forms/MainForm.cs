// ColorButton for .NET
// Copyright(c) 2014 Pluslus (http://www.pluslus.com/)

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DaihonConverter
{
    public partial class MainForm : Form
    {
        // 描画フォント
        private const string FONT_TYPE_M = "@ＭＳ 明朝";
        private const string FONT_TYPE_G = "@ＭＳ ゴシック";

        // PictureBoxサイズ
        private const int PICTURE_CODE_HEIGHT = 120;    // コードの縦幅
        private const int PICTURE_NAME_HEIGHT = 120;    // キャレクター名の縦幅
        // private const int PICTURE_TEXT_HEIGHT = 460;    // 台詞の縦幅 ※未使用

        // 行間
        private const int LINE_SPACE_SIZE = 20;  // 行間のスペース
        private const int LINE_HEAD_SPACE_X = 20; // 文字列の開始スペース(x)
        private const int LINE_HEAD_SPACE_Y = 5; // 文字列の開始スペース(y)
        private const int LINE_TAIL_SPACE_Y = 5; // 文字列の終了スペース(y)

        // スクロールバー幅
        private const int SCROLL_BAR_SIZE = 20;

        // デフォルト値
        private const int DEFAULT_FONT_SIZE = 9;   // フォントサイズ

        // 描画開始位置（x）
        private float XCurrent = 0;
        private float XBefore = 0;

        // マウス選択位置（x）
        private float MouseStartX = float.MinValue;
        private float MouseEndX = float.MaxValue;

        // カラーパレットリスト
        private Dictionary<String, TextBox> ColorList;

        // 読込データリスト
        private List<LineData> ReadList;

        // 描画

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // フォームデザインを変更
            //SetFormDesigh();

            // 初期表示
            Init();
            
            // スクロールバーを一番右に
            pnlMain.AutoScrollPosition = new Point(3000, 0);

            // サンプル用コード
            // キャラクターセット
            SetCharacter();
        }

        private void SetCharacter()
        {
            // サンプル用コード
            var src = new List<CharacterData>();
            src.Add(new CharacterData("", "(なし)"));
            src.Add(new CharacterData("音也", "音也"));
            src.Add(new CharacterData("レン", "レン"));

            cbCharacter.DataSource = src;
            cbCharacter.DisplayMember = "name";
            cbCharacter.ValueMember = "code";
        }

        private void SetFormDesigh()
        {
            // フォームの角を丸くする
            var radius = 40;
            var diameter = radius * 2;
            var gp = new GraphicsPath();

            // 左上
            gp.AddPie(0, 0, diameter, diameter, 180, 90);
            // 右上
            gp.AddPie(this.Width - diameter, 0, diameter, diameter, 270, 90);
            // 左下
            gp.AddPie(0, this.Height - diameter, diameter, diameter, 90, 90);
            // 右下
            gp.AddPie(this.Width - diameter, this.Height - diameter, diameter, diameter, 0, 90);
            // 中央
            gp.AddRectangle(new Rectangle(radius, 0, this.Width - diameter, this.Height));
            // 左
            gp.AddRectangle(new Rectangle(0, radius, radius, this.Height - diameter));
            // 右
            gp.AddRectangle(new Rectangle(this.Width - radius, radius, radius, this.Height - diameter));


            this.Region = new Region(gp);

        }

        private void Init()
        {
            pbOnMouse.Parent = pbCanvas;

            // 台本データ読込
            ReadDaihonFile();

            // 台本データを逆順に
            ReadList.Reverse();

            // 台本データ描画
            PictureDrawing();

            ColorList = new Dictionary<string, TextBox>();

            //////////////
            // サンプル用コード
            // ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

            SetFontSizeList(ref cbFont1, "音也");
            SetFontSizeList(ref cbFont2, "レン");
            SetFontSizeList(ref cbFont3, "音也、レン");

            ColorList.Add(textBox1.Name, textBox1);
            ColorList.Add(textBox2.Name, textBox2);
            ColorList.Add(textBox3.Name, textBox3);

            textBox1.Click += ShowColorPallet;
            textBox2.Click += ShowColorPallet;
            textBox3.Click += ShowColorPallet;

        }

        private void ReadDaihonFile()
        {

            //////////////
            // サンプル用コード
            // ↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

            ReadList = LineData.CreateTestData();

        }

        private void PictureDrawing()
        {
            // 描画キャンバス
            var width = 2900;
            var canvas = new Bitmap(width, pnlMain.Height - SCROLL_BAR_SIZE);

            var fontSize = DEFAULT_FONT_SIZE;

            // yのスタート位置指定
            var StartVoiceNoY = 0;
            var EndVoiceNoY = PICTURE_CODE_HEIGHT;
            var StartCharacterY = EndVoiceNoY;
            var EndCharacterY = StartCharacterY + PICTURE_NAME_HEIGHT;
            var StartVoiceY = EndCharacterY;
            //var EndVoiceY = StartVoiceY + PICTURE_TEXT_HEIGHT;
            //var EndVoiceY = pnlMain.Height;
            var EndVoiceY = (pnlMain.Height - StartVoiceY) + StartVoiceY;

            foreach (var line in ReadList)
            {
                // 描画準備

                var g = Graphics.FromImage(canvas); // グラフィック

                // 描画設定(縦書き + 右から左に表示)
                var sf = new StringFormat();
                sf.FormatFlags = StringFormatFlags.DirectionVertical | StringFormatFlags.DirectionRightToLeft;

                Font fnt = SetFont(false, FONT_TYPE_M, fontSize); // フォント

                // 描画座標計算
                SetLineSize(line, g, fnt, sf);

                // 描画
                WritePictureArea(g, fnt, sf, line.Character, line.StartX, StartCharacterY, EndCharacterY, line.PrintFlg);
                WritePictureArea(g, fnt, sf, line.Voice, line.StartX, StartVoiceY, EndVoiceY, line.PrintFlg);

                // ボイスNoのみフォント変更
                fnt = SetFont(false, FONT_TYPE_G, fontSize);
                WritePictureArea(g, fnt, sf, line.VoiceNo, line.StartX, StartVoiceNoY, EndVoiceNoY, line.PrintFlg);

                // エラーであれば背景を赤く
                if (line.ErrorFlg)
                {
                    WriteErrorRectangle(g, line.EndX, line.StartX, 0, EndVoiceY);
                }

                //リソースを解放する
                sf.Dispose();
                fnt.Dispose();
                g.Dispose();

            }

            pbCanvas.Image = canvas;

        }

        private Font SetFont(bool boldFlg, string font, int fontSize)
        {
            Font fnt; // フォント

            if (boldFlg)  // キャラクターごとの太字チェック
            {
                // 太字
                fnt = new Font(font, fontSize, FontStyle.Bold);
            }
            else
            {
                // 指定なし
                fnt = new Font(font, fontSize);
            }

            return fnt;
        }

        private void SetLineSize(LineData line, Graphics g, Font fnt, StringFormat sf)
        {
            // x座標再計算
            var size = new SizeF(pnlMain.Width, pnlMain.Height);
            var gSize = g.MeasureString(line.Voice, fnt, size, sf);
            XBefore = XCurrent;
            XCurrent += LINE_HEAD_SPACE_X + LINE_SPACE_SIZE + gSize.Width;

            // オブジェクトごとにスタート位置を格納
            line.StartX = XCurrent;
            line.EndX = XBefore;
        }

        private void WritePictureArea(Graphics g, Font fnt, StringFormat sf, String text, float textX ,float textStartY, float textEndY, bool printFlg)
        {

            // 区切り線表示
            if (printFlg)
            {
                // 破線で表示
                var pen = new Pen(Color.Blue, 5);
                pen.DashStyle = DashStyle.DashDot;
                g.DrawLine(pen, textX, textStartY, textX, textEndY);
            } else
            {
                g.DrawLine(Pens.Black, textX, textStartY, textX, textEndY);
            }

            // 文字列表示
            var textStartX = textX - LINE_HEAD_SPACE_X;
            g.DrawString(text, fnt, Brushes.Black, textStartX, textStartY, sf);

            
        }

        private void WriteErrorRectangle(Graphics g, float startX, float endX, float startY, float EndY)
        {

            var brush = new SolidBrush(Color.FromArgb(100, 255, 0, 0));
            g.FillRectangle(brush, startX, startY, endX - startX, EndY);

        }

        private void SetFontSizeList(ref ComboBox cb, String CharCode)
        {
            var src = FontSizeData.GetFontSizeList(CharCode);

            cb.DataSource = src;
            cb.DisplayMember = "Size";
            cb.ValueMember = "Code";

            // デフォルト値設定
            cb.Text = DEFAULT_FONT_SIZE.ToString();
        }

        private void ShowColorPallet(object sender, EventArgs e)
        {
            var cd = new ColorDialog();

            // ダイヤログ表示
            if(cd.ShowDialog() == DialogResult.OK)
            {
                var code = ((TextBox)sender).Name;
                var tb = ColorList[code];

                tb.BackColor = cd.Color;

            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {

            // マウスポインタの位置を取得
            var cursol = Cursor.Position;

            if (pnlMain.ClientRectangle.Contains(pnlMain.PointToClient(cursol)))
            {
                // マウスがメインパネルの上にあるときのみ描画
                // クライアント座標に変換する
                var cp = pbCanvas.PointToClient(cursol);

                var x = cp.X;
                if (MouseStartX < x || MouseEndX > x)
                {

                    var line = GetSelectLine(x);

                    // 描画先
                    var canvas = new Bitmap(pbCanvas.Width, pbCanvas.Height);

                    WriteSelectRectangle(ref canvas, line.EndX, line.StartX);

                    // リソースリーク対策
                    var oldImg = pbOnMouse.Image;
                    pbOnMouse.Image = canvas;    // キャンバスイメージ書き換え
                    if (oldImg != null)
                    {
                        oldImg.Dispose();       // 旧キャンバスイメージ開放
                    }

                    // 現在マウス座標書き換え
                    MouseStartX = line.EndX;
                    MouseEndX = line.StartX;
                }
            }

        }

        private LineData GetSelectLine(int x)
        {
            LineData ret = ReadList[0];
            foreach(var obj in ReadList)
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

            var brush = new SolidBrush(Color.FromArgb(10, 0, 0, 255));
            g.FillRectangle(brush, startX, 0, endX - startX, canvas.Height);

            g.Dispose();
        }

        private void pbOnMouse_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ShowEditDialog(e);
        }

        private void ShowEditDialog(MouseEventArgs e)
        {
            var x = e.Location.X;

            var line = GetSelectLine(x);
            var editForm = new LineSelectForm(line);
            editForm.ShowDialog();
        }

        private void btnOutPut_Click(object sender, EventArgs e)
        {
            //var outForm = new OutputForm();
            //outForm.ShowDialog();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (pnlMenu.Visible == true)
            {
                pnlMenu.Visible = false;
            }
            else
            {
                pnlMenu.Visible = true;
            }
        }
    }

}
