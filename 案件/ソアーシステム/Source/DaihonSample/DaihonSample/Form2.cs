using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DaihonSample
{
    public partial class Form2 : Form
    {

        public LineData line;

        public Form2(LineData l)
        {
            InitializeComponent();
            this.line = l;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // 初期表示
            Init();
        }

        private void Init()
        {

            // キャラクターセット
            SetCharacter();

            // 編集データ挿入
            tbVoiceNo.Text = line.VoiceNo;
            tbText.Text = line.Voice;

            // キャラクターは編集が必要
            var charName = EditCharcterName(line.Character);
            cbCharacter.SelectedValue = charName;

            // 初期カーソル位置を台詞に
            tbText.SelectionStart = tbText.Text.Length;
            this.ActiveControl = tbText;

        }

        private String EditCharcterName(string before)
        {
            var after = before.Replace("【", "").Replace("】", "");
            return after;
        }

        private void SetCharacter()
        {
            var src = new List<Character>();
            src.Add(new Character("", "(なし)"));
            src.Add(new Character("音也", "音也"));
            src.Add(new Character("真斗", "真斗"));
            src.Add(new Character("那月", "那月"));
            src.Add(new Character("トキヤ", "トキヤ"));
            src.Add(new Character("レン", "レン"));
            src.Add(new Character("翔", "翔"));
            src.Add(new Character("セシル", "セシル"));

            cbCharacter.DataSource = src;
            cbCharacter.DisplayMember = "name";
            cbCharacter.ValueMember = "code";

            //cbCharacter.Items.Add("音也");
            //cbCharacter.Items.Add("真斗");
            //cbCharacter.Items.Add("那月");
            //cbCharacter.Items.Add("トキヤ");
            //cbCharacter.Items.Add("レン");
            //cbCharacter.Items.Add("翔");
            //cbCharacter.Items.Add("セシル");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public class Character
        {
            public String code { get; set; }
            public String name { get; set; }

            public Character(string c, string n)
            {
                this.code = c;
                this.name = n;
            }
        }

    }
}
