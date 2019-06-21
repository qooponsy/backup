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
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void StartForm_Load(object sender, EventArgs e)
        {
            //SetFormDesigh();

            // 初期表示
            Init();
        }

        private void Init()
        {
            // タイトル
            SetTitle();

            // ゲーム名
            SetGameName();

            // シナリオ
            SetScenario();

            // ルート
            SetRoute();

            // 章
            SetChapter();

            // 台本ファイル
            tbFilePath.Text = @"C:\test\台本システム\台本ファイル1.txt";
        }

        private void btnRead_Click(object sender, EventArgs e)
        {

            var main = new MainForm();
            main.ShowDialog();

        }

        ///////
        // サンプル用記述
        //↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

        private void SetTitle()
        {
            var src = new List<Title>();
            src.Add(new Title("", "うたの プリンスさまっ"));
            src.Add(new Title("", "デ・ジ・キャラット"));

            cbTitle.DataSource = src;
            cbTitle.DisplayMember = "name";
            cbTitle.ValueMember = "code";
        }

        private void SetGameName()
        {
            var src = new List<GameName>();
            src.Add(new GameName("", "うたプリRL"));
            src.Add(new GameName("", "うたプリAASST"));
            src.Add(new GameName("", "シャニライ"));

            cbGameName.DataSource = src;
            cbGameName.DisplayMember = "name";
            cbGameName.ValueMember = "code";
        }

        private void SetScenario()
        {
            var src = new List<Scenario>();
            src.Add(new Scenario("", "カルテットルート"));
            src.Add(new Scenario("", "レインボールート"));

            cbScenario.DataSource = src;
            cbScenario.DisplayMember = "name";
            cbScenario.ValueMember = "code";
        }

        private void SetRoute()
        {
            var src = new List<Route>();
            src.Add(new Route("", "音也 ルート"));
            src.Add(new Route("", "トキヤ ルート"));
            src.Add(new Route("", "真斗 ルート"));
            src.Add(new Route("", "レン ルート"));
            src.Add(new Route("", "那月 ルート"));
            src.Add(new Route("", "翔 ルート"));
            src.Add(new Route("", "セシル ルート"));

            cbRoute.DataSource = src;
            cbRoute.DisplayMember = "name";
            cbRoute.ValueMember = "code";
        }

        private void SetChapter()
        {
            var src = new List<Chapter>();
            src.Add(new Chapter("", "序章"));
            src.Add(new Chapter("", "1章"));
            src.Add(new Chapter("", "2章"));
            src.Add(new Chapter("", "3章"));

            cbChapter.DataSource = src;
            cbChapter.DisplayMember = "name";
            cbChapter.ValueMember = "code";
        }

        private void StartForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void btnRead_Click_1(object sender, EventArgs e)
        {
            var main = new MainForm();

            this.Visible = false;
            main.ShowDialog();
            this.Visible = true;
        }

        private void SetFormDesigh()
        {
            // フォームの境界線、タイトルバーを無しに設定
            this.FormBorderStyle = FormBorderStyle.None;

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
    }

    ///////
    // サンプル用記述
    //↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓↓

    public class Title
    {
        public String code { get; set; }
        public String name { get; set; }

        public Title(string c, string n)
        {
            this.code = c;
            this.name = n;
        }
    }

    public class GameName
    {
        public String code { get; set; }
        public String name { get; set; }

        public GameName(string c, string n)
        {
            this.code = c;
            this.name = n;
        }
    }

    public class Scenario
    {
        public String code { get; set; }
        public String name { get; set; }

        public Scenario(string c, string n)
        {
            this.code = c;
            this.name = n;
        }
    }

    public class Route
    {
        public String code { get; set; }
        public String name { get; set; }

        public Route(string c, string n)
        {
            this.code = c;
            this.name = n;
        }
    }

    public class Chapter
    {
        public String code { get; set; }
        public String name { get; set; }

        public Chapter(string c, string n)
        {
            this.code = c;
            this.name = n;
        }
    }

}
