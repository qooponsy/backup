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
    public partial class LineSelectForm : Form
    {
        public LineData Line;

        public LineSelectForm(LineData line)
        {
            InitializeComponent();
            this.Line = line;
        }

        private void LineSelectForm_Load(object sender, EventArgs e)
        {
            // 初期表示
            Init();
        }

        private void Init()
        {

            // キャラクターセット
            SetCharacter();

            // 編集データ挿入
            tbVoiceNo.Text = Line.VoiceNo;
            tbText.Text = Line.Voice;

            // キャラクターを扱う場合は文字の編集が必要
            var charName = EditCharacterName(Line.Character);
            cbCharacter.SelectedValue = charName;

            // 初期カーソル位置を台詞に
            tbText.SelectionStart = tbText.Text.Length;
            this.ActiveControl = tbText;

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

        private string EditCharacterName(string before)
        {
            var after = before.Replace("【", "").Replace("】", "");
            return after;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
