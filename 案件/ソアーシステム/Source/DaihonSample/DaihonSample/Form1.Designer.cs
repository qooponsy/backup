namespace DaihonSample
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pbSelect = new System.Windows.Forms.PictureBox();
            this.pbText = new System.Windows.Forms.PictureBox();
            this.pbName = new System.Windows.Forms.PictureBox();
            this.pbCode = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbText)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCode)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(764, 545);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 35);
            this.button1.TabIndex = 0;
            this.button1.Text = "印刷プレビュー";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pbSelect);
            this.panel1.Controls.Add(this.pbText);
            this.panel1.Controls.Add(this.pbName);
            this.panel1.Controls.Add(this.pbCode);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(850, 520);
            this.panel1.TabIndex = 2;
            // 
            // pbSelect
            // 
            this.pbSelect.BackColor = System.Drawing.Color.Transparent;
            this.pbSelect.Location = new System.Drawing.Point(0, 0);
            this.pbSelect.Name = "pbSelect";
            this.pbSelect.Size = new System.Drawing.Size(100, 500);
            this.pbSelect.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbSelect.TabIndex = 2;
            this.pbSelect.TabStop = false;
            // 
            // pbText
            // 
            this.pbText.BackColor = System.Drawing.SystemColors.HighlightText;
            this.pbText.Location = new System.Drawing.Point(0, 240);
            this.pbText.Name = "pbText";
            this.pbText.Size = new System.Drawing.Size(773, 260);
            this.pbText.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbText.TabIndex = 1;
            this.pbText.TabStop = false;
            this.pbText.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pbText_MouseDoubleClick);
            // 
            // pbName
            // 
            this.pbName.BackColor = System.Drawing.SystemColors.HighlightText;
            this.pbName.Location = new System.Drawing.Point(0, 120);
            this.pbName.Name = "pbName";
            this.pbName.Size = new System.Drawing.Size(773, 120);
            this.pbName.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbName.TabIndex = 1;
            this.pbName.TabStop = false;
            this.pbName.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pbName_MouseDoubleClick);
            // 
            // pbCode
            // 
            this.pbCode.BackColor = System.Drawing.SystemColors.HighlightText;
            this.pbCode.Location = new System.Drawing.Point(0, 0);
            this.pbCode.Name = "pbCode";
            this.pbCode.Size = new System.Drawing.Size(773, 120);
            this.pbCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbCode.TabIndex = 1;
            this.pbCode.TabStop = false;
            this.pbCode.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pbCode_MouseDoubleClick);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 567);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "label1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(872, 592);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbSelect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbText)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCode)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbCode;
        private System.Windows.Forms.PictureBox pbText;
        private System.Windows.Forms.PictureBox pbName;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pbSelect;
    }
}

