using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DaihonConverter
{
    public partial class OutputForm : Form
    {

        // デフォルト値
        private const int DEFAULT_FONT_SIZE = 10;   // フォントサイズ

        public OutputForm()
        {
            InitializeComponent();
        }

        private void OutputForm_Load(object sender, EventArgs e)
        {
            Init();
        }

        private void Init()
        {

            // キャラクターセット
            SetCharacter();

            // サイズ
            SetFontSizeList(ref cbFontSize, "aa");

        }

        private void SetCharacter()
        {
            // サンプル用コード
            var src = new List<CharacterData>();
            src.Add(new CharacterData("", "(なし)"));
            src.Add(new CharacterData("音也", "音也"));
            src.Add(new CharacterData("真斗", "真斗"));
            src.Add(new CharacterData("那月", "那月"));
            src.Add(new CharacterData("トキヤ", "トキヤ"));
            src.Add(new CharacterData("レン", "レン"));
            src.Add(new CharacterData("翔", "翔"));
            src.Add(new CharacterData("セシル", "セシル"));

            cbCharacter.DataSource = src;
            cbCharacter.DisplayMember = "name";
            cbCharacter.ValueMember = "code";
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

        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            if(chkAll.Checked)
            {
                tbHidden1.Visible = true;
                tbHidden2.Visible = true;
                tbHidden3.Visible = true;

                cbCharacter.Visible = false;
                tbFontColor.Visible = false;
                cbFontSize.Visible = false;
            }
            else
            {
                tbHidden1.Visible = false;
                tbHidden2.Visible = false;
                tbHidden3.Visible = false;

                cbCharacter.Visible = true;
                tbFontColor.Visible = true;
                cbFontSize.Visible = true;
            }
        }

        private void tbFontColor_Click(object sender, EventArgs e)
        {
            var cd = new ColorDialog();

            // ダイヤログ表示
            if (cd.ShowDialog() == DialogResult.OK)
            {
                
                tbFontColor.BackColor = cd.Color;

            }
        }
    }
}
