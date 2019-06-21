namespace DaihonConverter
{
    partial class OutputForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OutputForm));
            this.colorButton6 = new Pluslus.Forms.Controls.ColorButton();
            this.colorButton1 = new Pluslus.Forms.Controls.ColorButton();
            this.colorButton2 = new Pluslus.Forms.Controls.ColorButton();
            this.label3 = new System.Windows.Forms.Label();
            this.tbFilePath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbFontColor = new System.Windows.Forms.TextBox();
            this.cbCharacter = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.chkAll = new System.Windows.Forms.CheckBox();
            this.cbFontSize = new System.Windows.Forms.ComboBox();
            this.tbHidden1 = new System.Windows.Forms.TextBox();
            this.tbHidden2 = new System.Windows.Forms.TextBox();
            this.tbHidden3 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // colorButton6
            // 
            this.colorButton6.BackColor = System.Drawing.Color.LightGreen;
            this.colorButton6.CornerRadius = 10;
            this.colorButton6.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.colorButton6.ForeColor = System.Drawing.Color.Green;
            this.colorButton6.Location = new System.Drawing.Point(46, 198);
            this.colorButton6.Name = "colorButton6";
            this.colorButton6.Size = new System.Drawing.Size(105, 44);
            this.colorButton6.TabIndex = 4;
            this.colorButton6.Text = "印刷プレビュー";
            this.colorButton6.UseVisualStyleBackColor = false;
            // 
            // colorButton1
            // 
            this.colorButton1.BackColor = System.Drawing.Color.Green;
            this.colorButton1.CornerRadius = 10;
            this.colorButton1.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.colorButton1.ForeColor = System.Drawing.SystemColors.Control;
            this.colorButton1.Location = new System.Drawing.Point(172, 198);
            this.colorButton1.Name = "colorButton1";
            this.colorButton1.Size = new System.Drawing.Size(105, 44);
            this.colorButton1.TabIndex = 5;
            this.colorButton1.Text = "台本出力";
            this.colorButton1.UseVisualStyleBackColor = false;
            // 
            // colorButton2
            // 
            this.colorButton2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(153)))), ((int)(((byte)(138)))));
            this.colorButton2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(255)))), ((int)(((byte)(247)))));
            this.colorButton2.Location = new System.Drawing.Point(259, 24);
            this.colorButton2.Name = "colorButton2";
            this.colorButton2.Size = new System.Drawing.Size(44, 23);
            this.colorButton2.TabIndex = 12;
            this.colorButton2.Text = "参照";
            this.colorButton2.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label3.ForeColor = System.Drawing.Color.Green;
            this.label3.Location = new System.Drawing.Point(25, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 18);
            this.label3.TabIndex = 14;
            this.label3.Text = "出力フォルダ";
            // 
            // tbFilePath
            // 
            this.tbFilePath.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(255)))), ((int)(((byte)(247)))));
            this.tbFilePath.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(153)))), ((int)(((byte)(138)))));
            this.tbFilePath.Location = new System.Drawing.Point(135, 26);
            this.tbFilePath.Name = "tbFilePath";
            this.tbFilePath.ReadOnly = true;
            this.tbFilePath.Size = new System.Drawing.Size(118, 19);
            this.tbFilePath.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label2.Location = new System.Drawing.Point(28, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 18);
            this.label2.TabIndex = 7;
            this.label2.Text = "フォント色";
            // 
            // tbFontColor
            // 
            this.tbFontColor.BackColor = System.Drawing.SystemColors.InfoText;
            this.tbFontColor.Location = new System.Drawing.Point(129, 137);
            this.tbFontColor.Name = "tbFontColor";
            this.tbFontColor.Size = new System.Drawing.Size(19, 19);
            this.tbFontColor.TabIndex = 9;
            this.tbFontColor.Click += new System.EventHandler(this.tbFontColor_Click);
            // 
            // cbCharacter
            // 
            this.cbCharacter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cbCharacter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCharacter.ForeColor = System.Drawing.Color.Green;
            this.cbCharacter.FormattingEnabled = true;
            this.cbCharacter.Location = new System.Drawing.Point(129, 102);
            this.cbCharacter.Name = "cbCharacter";
            this.cbCharacter.Size = new System.Drawing.Size(168, 20);
            this.cbCharacter.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label5.ForeColor = System.Drawing.Color.Green;
            this.label5.Location = new System.Drawing.Point(19, 102);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 18);
            this.label5.TabIndex = 14;
            this.label5.Text = "キャラクター";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(19, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 18);
            this.label1.TabIndex = 14;
            this.label1.Text = "フォントサイズ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.label6.ForeColor = System.Drawing.Color.Green;
            this.label6.Location = new System.Drawing.Point(19, 137);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 18);
            this.label6.TabIndex = 14;
            this.label6.Text = "フォント色";
            // 
            // chkAll
            // 
            this.chkAll.AutoSize = true;
            this.chkAll.BackColor = System.Drawing.Color.Transparent;
            this.chkAll.Checked = true;
            this.chkAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAll.Location = new System.Drawing.Point(6, 62);
            this.chkAll.Name = "chkAll";
            this.chkAll.Size = new System.Drawing.Size(112, 16);
            this.chkAll.TabIndex = 15;
            this.chkAll.Text = "全キャラクター印刷";
            this.chkAll.UseVisualStyleBackColor = false;
            this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
            // 
            // cbFontSize
            // 
            this.cbFontSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.cbFontSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFontSize.ForeColor = System.Drawing.Color.Green;
            this.cbFontSize.FormattingEnabled = true;
            this.cbFontSize.Location = new System.Drawing.Point(129, 165);
            this.cbFontSize.Name = "cbFontSize";
            this.cbFontSize.Size = new System.Drawing.Size(40, 20);
            this.cbFontSize.TabIndex = 16;
            // 
            // tbHidden1
            // 
            this.tbHidden1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbHidden1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(153)))), ((int)(((byte)(138)))));
            this.tbHidden1.Location = new System.Drawing.Point(129, 102);
            this.tbHidden1.Name = "tbHidden1";
            this.tbHidden1.ReadOnly = true;
            this.tbHidden1.Size = new System.Drawing.Size(168, 19);
            this.tbHidden1.TabIndex = 17;
            // 
            // tbHidden2
            // 
            this.tbHidden2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbHidden2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(153)))), ((int)(((byte)(138)))));
            this.tbHidden2.Location = new System.Drawing.Point(129, 137);
            this.tbHidden2.Name = "tbHidden2";
            this.tbHidden2.ReadOnly = true;
            this.tbHidden2.Size = new System.Drawing.Size(19, 19);
            this.tbHidden2.TabIndex = 17;
            // 
            // tbHidden3
            // 
            this.tbHidden3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.tbHidden3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(153)))), ((int)(((byte)(138)))));
            this.tbHidden3.Location = new System.Drawing.Point(129, 166);
            this.tbHidden3.Name = "tbHidden3";
            this.tbHidden3.ReadOnly = true;
            this.tbHidden3.Size = new System.Drawing.Size(40, 19);
            this.tbHidden3.TabIndex = 17;
            // 
            // OutputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DaihonConverter.Properties.Resources.backimage;
            this.ClientSize = new System.Drawing.Size(327, 266);
            this.Controls.Add(this.tbHidden3);
            this.Controls.Add(this.tbHidden2);
            this.Controls.Add(this.tbHidden1);
            this.Controls.Add(this.cbFontSize);
            this.Controls.Add(this.chkAll);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbCharacter);
            this.Controls.Add(this.colorButton2);
            this.Controls.Add(this.tbFilePath);
            this.Controls.Add(this.tbFontColor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.colorButton6);
            this.Controls.Add(this.colorButton1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OutputForm";
            this.Text = "ストーリーテラー | 印刷設定";
            this.Load += new System.EventHandler(this.OutputForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Pluslus.Forms.Controls.ColorButton colorButton6;
        private Pluslus.Forms.Controls.ColorButton colorButton1;
        private Pluslus.Forms.Controls.ColorButton colorButton2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbFilePath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbFontColor;
        private System.Windows.Forms.ComboBox cbCharacter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkAll;
        private System.Windows.Forms.ComboBox cbFontSize;
        private System.Windows.Forms.TextBox tbHidden1;
        private System.Windows.Forms.TextBox tbHidden2;
        private System.Windows.Forms.TextBox tbHidden3;
    }
}