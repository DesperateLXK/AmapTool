namespace AMapTool
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.openTraceFileButton = new System.Windows.Forms.Button();
            this.LogRichTextBox = new System.Windows.Forms.RichTextBox();
            this.drawTraceStimButton = new System.Windows.Forms.Button();
            this.clearTraceStimButton = new System.Windows.Forms.Button();
            this.dirTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.closeTraceFileButton = new System.Windows.Forms.Button();
            this.targetPosTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.setTargetPosButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.isAMapRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.transComboBox = new System.Windows.Forms.ComboBox();
            this.clearTransButton = new System.Windows.Forms.Button();
            this.beginTransButton = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.rawDataTextBox = new System.Windows.Forms.TextBox();
            this.transedTextBox = new System.Windows.Forms.TextBox();
            this.isWGS84RadioButton = new System.Windows.Forms.RadioButton();
            this.directoryEntry1 = new System.DirectoryServices.DirectoryEntry();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.webBrowser1);
            this.groupBox1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1581, 957);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Version 2.1.2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(1476, -3);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 20);
            this.label4.TabIndex = 16;
            this.label4.Text = "NIEM_ZZU";
            this.label4.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.label4_MouseDoubleClick);
            // 
            // webBrowser1
            // 
            this.webBrowser1.AllowWebBrowserDrop = false;
            this.webBrowser1.IsWebBrowserContextMenuEnabled = false;
            this.webBrowser1.Location = new System.Drawing.Point(6, 24);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.ScrollBarsEnabled = false;
            this.webBrowser1.Size = new System.Drawing.Size(1569, 927);
            this.webBrowser1.TabIndex = 0;
            // 
            // openTraceFileButton
            // 
            this.openTraceFileButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.openTraceFileButton.Location = new System.Drawing.Point(1606, 21);
            this.openTraceFileButton.Name = "openTraceFileButton";
            this.openTraceFileButton.Size = new System.Drawing.Size(135, 45);
            this.openTraceFileButton.TabIndex = 1;
            this.openTraceFileButton.Text = "打开轨迹文件";
            this.openTraceFileButton.UseVisualStyleBackColor = true;
            this.openTraceFileButton.Click += new System.EventHandler(this.openTraceFileButton_Click);
            // 
            // LogRichTextBox
            // 
            this.LogRichTextBox.Font = new System.Drawing.Font("微软雅黑", 6.6F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LogRichTextBox.Location = new System.Drawing.Point(1613, 821);
            this.LogRichTextBox.Name = "LogRichTextBox";
            this.LogRichTextBox.Size = new System.Drawing.Size(275, 128);
            this.LogRichTextBox.TabIndex = 3;
            this.LogRichTextBox.Text = "";
            // 
            // drawTraceStimButton
            // 
            this.drawTraceStimButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.drawTraceStimButton.Location = new System.Drawing.Point(1612, 176);
            this.drawTraceStimButton.Name = "drawTraceStimButton";
            this.drawTraceStimButton.Size = new System.Drawing.Size(164, 45);
            this.drawTraceStimButton.TabIndex = 4;
            this.drawTraceStimButton.Text = "绘制轨迹与刺激点";
            this.drawTraceStimButton.UseVisualStyleBackColor = true;
            this.drawTraceStimButton.Click += new System.EventHandler(this.drawTraceStimButton_Click);
            // 
            // clearTraceStimButton
            // 
            this.clearTraceStimButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.clearTraceStimButton.Location = new System.Drawing.Point(1612, 227);
            this.clearTraceStimButton.Name = "clearTraceStimButton";
            this.clearTraceStimButton.Size = new System.Drawing.Size(164, 45);
            this.clearTraceStimButton.TabIndex = 5;
            this.clearTraceStimButton.Text = "清除轨迹与刺激点";
            this.clearTraceStimButton.UseVisualStyleBackColor = true;
            this.clearTraceStimButton.Click += new System.EventHandler(this.clearTraceStimButton_Click);
            // 
            // dirTextBox
            // 
            this.dirTextBox.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dirTextBox.Location = new System.Drawing.Point(1612, 96);
            this.dirTextBox.Name = "dirTextBox";
            this.dirTextBox.ReadOnly = true;
            this.dirTextBox.Size = new System.Drawing.Size(276, 27);
            this.dirTextBox.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(1608, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "文件路径：";
            // 
            // closeTraceFileButton
            // 
            this.closeTraceFileButton.Enabled = false;
            this.closeTraceFileButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.closeTraceFileButton.Location = new System.Drawing.Point(1753, 21);
            this.closeTraceFileButton.Name = "closeTraceFileButton";
            this.closeTraceFileButton.Size = new System.Drawing.Size(135, 45);
            this.closeTraceFileButton.TabIndex = 8;
            this.closeTraceFileButton.Text = "关闭轨迹文件";
            this.closeTraceFileButton.UseVisualStyleBackColor = true;
            this.closeTraceFileButton.Click += new System.EventHandler(this.closeTraceFileButton_Click);
            // 
            // targetPosTextBox
            // 
            this.targetPosTextBox.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.targetPosTextBox.Location = new System.Drawing.Point(1612, 353);
            this.targetPosTextBox.Name = "targetPosTextBox";
            this.targetPosTextBox.Size = new System.Drawing.Size(276, 27);
            this.targetPosTextBox.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(1607, 330);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 20);
            this.label2.TabIndex = 10;
            this.label2.Text = "目标位置(WGS84)：";
            // 
            // setTargetPosButton
            // 
            this.setTargetPosButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.setTargetPosButton.Location = new System.Drawing.Point(1753, 399);
            this.setTargetPosButton.Name = "setTargetPosButton";
            this.setTargetPosButton.Size = new System.Drawing.Size(135, 45);
            this.setTargetPosButton.TabIndex = 11;
            this.setTargetPosButton.Text = "设置";
            this.setTargetPosButton.UseVisualStyleBackColor = true;
            this.setTargetPosButton.Click += new System.EventHandler(this.setTargetPosButton_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(1611, 399);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(135, 45);
            this.button1.TabIndex = 12;
            this.button1.Text = "清除目标位置";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(1607, 798);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "文件数据信息显示:";
            // 
            // isAMapRadioButton
            // 
            this.isAMapRadioButton.AutoCheck = false;
            this.isAMapRadioButton.AutoSize = true;
            this.isAMapRadioButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.isAMapRadioButton.Location = new System.Drawing.Point(1612, 296);
            this.isAMapRadioButton.Name = "isAMapRadioButton";
            this.isAMapRadioButton.Size = new System.Drawing.Size(225, 24);
            this.isAMapRadioButton.TabIndex = 14;
            this.isAMapRadioButton.TabStop = true;
            this.isAMapRadioButton.Text = "设置目标位置使用高德坐标系";
            this.isAMapRadioButton.UseVisualStyleBackColor = true;
            this.isAMapRadioButton.Click += new System.EventHandler(this.isAMapRadioButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.transComboBox);
            this.groupBox2.Controls.Add(this.clearTransButton);
            this.groupBox2.Controls.Add(this.beginTransButton);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.rawDataTextBox);
            this.groupBox2.Controls.Add(this.transedTextBox);
            this.groupBox2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox2.Location = new System.Drawing.Point(1611, 471);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(274, 214);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "坐标转换工具";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 29);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 20);
            this.label8.TabIndex = 25;
            this.label8.Text = "转换选项：";
            // 
            // transComboBox
            // 
            this.transComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.transComboBox.FormattingEnabled = true;
            this.transComboBox.Location = new System.Drawing.Point(118, 26);
            this.transComboBox.Name = "transComboBox";
            this.transComboBox.Size = new System.Drawing.Size(150, 28);
            this.transComboBox.TabIndex = 24;
            // 
            // clearTransButton
            // 
            this.clearTransButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.clearTransButton.Location = new System.Drawing.Point(7, 173);
            this.clearTransButton.Name = "clearTransButton";
            this.clearTransButton.Size = new System.Drawing.Size(83, 35);
            this.clearTransButton.TabIndex = 23;
            this.clearTransButton.Text = "清除";
            this.clearTransButton.UseVisualStyleBackColor = true;
            this.clearTransButton.Click += new System.EventHandler(this.clearTransButton_Click);
            // 
            // beginTransButton
            // 
            this.beginTransButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.beginTransButton.Location = new System.Drawing.Point(185, 173);
            this.beginTransButton.Name = "beginTransButton";
            this.beginTransButton.Size = new System.Drawing.Size(83, 35);
            this.beginTransButton.TabIndex = 22;
            this.beginTransButton.Text = "转换";
            this.beginTransButton.UseVisualStyleBackColor = true;
            this.beginTransButton.Click += new System.EventHandler(this.beginTransButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(6, 117);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 20);
            this.label7.TabIndex = 21;
            this.label7.Text = "转换后坐标：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(6, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 20);
            this.label6.TabIndex = 19;
            this.label6.Text = "原始坐标：";
            // 
            // rawDataTextBox
            // 
            this.rawDataTextBox.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rawDataTextBox.Location = new System.Drawing.Point(6, 78);
            this.rawDataTextBox.Name = "rawDataTextBox";
            this.rawDataTextBox.Size = new System.Drawing.Size(262, 27);
            this.rawDataTextBox.TabIndex = 20;
            // 
            // transedTextBox
            // 
            this.transedTextBox.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.transedTextBox.Location = new System.Drawing.Point(6, 140);
            this.transedTextBox.Name = "transedTextBox";
            this.transedTextBox.ReadOnly = true;
            this.transedTextBox.Size = new System.Drawing.Size(262, 27);
            this.transedTextBox.TabIndex = 19;
            // 
            // isWGS84RadioButton
            // 
            this.isWGS84RadioButton.AutoCheck = false;
            this.isWGS84RadioButton.AutoSize = true;
            this.isWGS84RadioButton.Checked = true;
            this.isWGS84RadioButton.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.isWGS84RadioButton.Location = new System.Drawing.Point(1612, 138);
            this.isWGS84RadioButton.Name = "isWGS84RadioButton";
            this.isWGS84RadioButton.Size = new System.Drawing.Size(240, 24);
            this.isWGS84RadioButton.TabIndex = 18;
            this.isWGS84RadioButton.TabStop = true;
            this.isWGS84RadioButton.Text = "文件内坐标使用高德坐标系转换";
            this.isWGS84RadioButton.UseVisualStyleBackColor = true;
            this.isWGS84RadioButton.Click += new System.EventHandler(this.isWGS84RadioButton_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.linkLabel1.Location = new System.Drawing.Point(1610, 952);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(279, 20);
            this.linkLabel1.TabIndex = 19;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "河南省脑科学与脑机接口技术重点实验室";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1900, 981);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.isWGS84RadioButton);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.isAMapRadioButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.setTargetPosButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.targetPosTextBox);
            this.Controls.Add(this.closeTraceFileButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dirTextBox);
            this.Controls.Add(this.clearTraceStimButton);
            this.Controls.Add(this.drawTraceStimButton);
            this.Controls.Add(this.LogRichTextBox);
            this.Controls.Add(this.openTraceFileButton);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1918, 1028);
            this.MinimumSize = new System.Drawing.Size(1707, 783);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "显示轨迹与刺激点工具(v2.1.2)";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Button openTraceFileButton;
        private System.Windows.Forms.RichTextBox LogRichTextBox;
        private System.Windows.Forms.Button drawTraceStimButton;
        private System.Windows.Forms.Button clearTraceStimButton;
        private System.Windows.Forms.TextBox dirTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button closeTraceFileButton;
        private System.Windows.Forms.TextBox targetPosTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button setTargetPosButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton isAMapRadioButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton isWGS84RadioButton;
        private System.DirectoryServices.DirectoryEntry directoryEntry1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox rawDataTextBox;
        private System.Windows.Forms.TextBox transedTextBox;
        private System.Windows.Forms.Button clearTransButton;
        private System.Windows.Forms.Button beginTransButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox transComboBox;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

