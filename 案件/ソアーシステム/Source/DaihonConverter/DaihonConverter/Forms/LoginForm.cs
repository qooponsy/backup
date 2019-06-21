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
    public partial class LoginForm : Form
    {
        bool closeFlg = true;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // ロゴ画像セット
            Bitmap bitmap = Properties.Resources.logo;
            pbLogo.BackColor = Color.Transparent;
            pbLogo.Image = bitmap; // MEMO : 直接リソースからImageに入れても表示される可能性あり
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(closeFlg)
            {
                Application.Exit();
            }
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            // ログイン処理
            closeFlg = false;

            // サンプル
            var start = new StartForm();
            start.Show();

            this.Close();
        }
    }
}
