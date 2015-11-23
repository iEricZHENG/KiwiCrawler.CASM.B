namespace FormKiwiCrawler
{
    partial class frmAdd
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
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.txtPageNum = new System.Windows.Forms.TextBox();
            this.cbCaptureType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDetailPattern = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cbDetailPatternType = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtNextPagePattern = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbNextPagePatternType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtKeyWords = new System.Windows.Forms.TextBox();
            this.txtBusinessType = new System.Windows.Forms.TextBox();
            this.btnFinish = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(92, 18);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(447, 21);
            this.txtUrl.TabIndex = 0;
            // 
            // txtPageNum
            // 
            this.txtPageNum.Location = new System.Drawing.Point(92, 53);
            this.txtPageNum.Name = "txtPageNum";
            this.txtPageNum.Size = new System.Drawing.Size(51, 21);
            this.txtPageNum.TabIndex = 1;
            // 
            // cbCaptureType
            // 
            this.cbCaptureType.Cursor = System.Windows.Forms.Cursors.Default;
            this.cbCaptureType.FormattingEnabled = true;
            this.cbCaptureType.Items.AddRange(new object[] {
            "DomMode",
            "BrowserMode",
            "CaptureMode"});
            this.cbCaptureType.Location = new System.Drawing.Point(353, 52);
            this.cbCaptureType.Name = "cbCaptureType";
            this.cbCaptureType.Size = new System.Drawing.Size(114, 20);
            this.cbCaptureType.TabIndex = 4;
            this.cbCaptureType.Text = "DomMode";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "网址";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "总页数";
            // 
            // txtDetailPattern
            // 
            this.txtDetailPattern.Location = new System.Drawing.Point(69, 20);
            this.txtDetailPattern.Multiline = true;
            this.txtDetailPattern.Name = "txtDetailPattern";
            this.txtDetailPattern.Size = new System.Drawing.Size(447, 54);
            this.txtDetailPattern.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "模板";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(10, 93);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 11;
            this.label5.Text = "模板类型";
            // 
            // cbDetailPatternType
            // 
            this.cbDetailPatternType.Cursor = System.Windows.Forms.Cursors.Default;
            this.cbDetailPatternType.FormattingEnabled = true;
            this.cbDetailPatternType.Items.AddRange(new object[] {
            "正则表达式",
            "Dom元素",
            "Dom元素属性",
            "JavaScript代码"});
            this.cbDetailPatternType.Location = new System.Drawing.Point(69, 90);
            this.cbDetailPatternType.Name = "cbDetailPatternType";
            this.cbDetailPatternType.Size = new System.Drawing.Size(114, 20);
            this.cbDetailPatternType.TabIndex = 12;
            this.cbDetailPatternType.Text = "正则表达式";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDetailPattern);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cbDetailPatternType);
            this.groupBox1.Location = new System.Drawing.Point(23, 103);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(534, 135);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "详细页";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtNextPagePattern);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.cbNextPagePatternType);
            this.groupBox2.Location = new System.Drawing.Point(23, 272);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(534, 138);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "下一页";
            // 
            // txtNextPagePattern
            // 
            this.txtNextPagePattern.Location = new System.Drawing.Point(69, 20);
            this.txtNextPagePattern.Multiline = true;
            this.txtNextPagePattern.Name = "txtNextPagePattern";
            this.txtNextPagePattern.Size = new System.Drawing.Size(447, 60);
            this.txtNextPagePattern.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "模板";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 11;
            this.label6.Text = "模板类型";
            // 
            // cbNextPagePatternType
            // 
            this.cbNextPagePatternType.Cursor = System.Windows.Forms.Cursors.Default;
            this.cbNextPagePatternType.FormattingEnabled = true;
            this.cbNextPagePatternType.Items.AddRange(new object[] {
            "正则表达式",
            "Dom元素",
            "Dom元素属性",
            "JavaScript代码"});
            this.cbNextPagePatternType.Location = new System.Drawing.Point(69, 97);
            this.cbNextPagePatternType.Name = "cbNextPagePatternType";
            this.cbNextPagePatternType.Size = new System.Drawing.Size(114, 20);
            this.cbNextPagePatternType.TabIndex = 12;
            this.cbNextPagePatternType.Text = "正则表达式";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 427);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 18;
            this.label7.Text = "业务类型";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(293, 427);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 20;
            this.label8.Text = "关键字";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(293, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(53, 12);
            this.label9.TabIndex = 21;
            this.label9.Text = "爬取类型";
            // 
            // txtKeyWords
            // 
            this.txtKeyWords.Location = new System.Drawing.Point(353, 424);
            this.txtKeyWords.Name = "txtKeyWords";
            this.txtKeyWords.Size = new System.Drawing.Size(186, 21);
            this.txtKeyWords.TabIndex = 19;
            // 
            // txtBusinessType
            // 
            this.txtBusinessType.Location = new System.Drawing.Point(92, 424);
            this.txtBusinessType.Name = "txtBusinessType";
            this.txtBusinessType.Size = new System.Drawing.Size(100, 21);
            this.txtBusinessType.TabIndex = 17;
            // 
            // btnFinish
            // 
            this.btnFinish.Location = new System.Drawing.Point(231, 467);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(75, 23);
            this.btnFinish.TabIndex = 22;
            this.btnFinish.Text = "完成";
            this.btnFinish.UseVisualStyleBackColor = true;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // frmAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 502);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtKeyWords);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txtBusinessType);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbCaptureType);
            this.Controls.Add(this.txtPageNum);
            this.Controls.Add(this.txtUrl);
            this.MaximizeBox = false;
            this.Name = "frmAdd";
            this.Text = "添加URL";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.TextBox txtPageNum;
        private System.Windows.Forms.ComboBox cbCaptureType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDetailPattern;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbDetailPatternType;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtNextPagePattern;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbNextPagePatternType;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtKeyWords;
        private System.Windows.Forms.TextBox txtBusinessType;
        private System.Windows.Forms.Button btnFinish;
    }
}