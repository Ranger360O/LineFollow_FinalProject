namespace LineFollow_FinalProject
{
    partial class Form1
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
            this.picBoxDef = new System.Windows.Forms.PictureBox();
            this.picWorkImg = new System.Windows.Forms.PictureBox();
            this.SelectorL = new System.Windows.Forms.TrackBar();
            this.SelectorR = new System.Windows.Forms.TrackBar();
            this.picGrayImg = new System.Windows.Forms.PictureBox();
            this.SelectLabelL = new System.Windows.Forms.Label();
            this.SelectLabelR = new System.Windows.Forms.Label();
            this.UpSelector = new System.Windows.Forms.TrackBar();
            this.DownSelector = new System.Windows.Forms.TrackBar();
            this.LabelUp = new System.Windows.Forms.Label();
            this.LabelDown = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Direction = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.s1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.s2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.s3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.s4ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.s5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.s6ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.videoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.v1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.webcamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.builtInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.externalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EnableLines = new System.Windows.Forms.CheckBox();
            this.xPosText = new System.Windows.Forms.Label();
            this.yPosText = new System.Windows.Forms.Label();
            this.xPosSlider = new System.Windows.Forms.TrackBar();
            this.yPosSlider = new System.Windows.Forms.TrackBar();
            this.SlopeBox = new System.Windows.Forms.Label();
            this.OpenSerial = new System.Windows.Forms.CheckBox();
            this.AvgXText = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxDef)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWorkImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelectorL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelectorR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGrayImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DownSelector)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xPosSlider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yPosSlider)).BeginInit();
            this.SuspendLayout();
            // 
            // picBoxDef
            // 
            this.picBoxDef.Location = new System.Drawing.Point(15, 27);
            this.picBoxDef.Name = "picBoxDef";
            this.picBoxDef.Size = new System.Drawing.Size(257, 200);
            this.picBoxDef.TabIndex = 0;
            this.picBoxDef.TabStop = false;
            // 
            // picWorkImg
            // 
            this.picWorkImg.Location = new System.Drawing.Point(278, 27);
            this.picWorkImg.Name = "picWorkImg";
            this.picWorkImg.Size = new System.Drawing.Size(257, 200);
            this.picWorkImg.TabIndex = 1;
            this.picWorkImg.TabStop = false;
            // 
            // SelectorL
            // 
            this.SelectorL.Location = new System.Drawing.Point(278, 234);
            this.SelectorL.Maximum = 125;
            this.SelectorL.Minimum = 1;
            this.SelectorL.Name = "SelectorL";
            this.SelectorL.Size = new System.Drawing.Size(125, 45);
            this.SelectorL.TabIndex = 3;
            this.SelectorL.Value = 1;
            this.SelectorL.Scroll += new System.EventHandler(this.SelectorL_Scroll);
            // 
            // SelectorR
            // 
            this.SelectorR.Location = new System.Drawing.Point(409, 234);
            this.SelectorR.Maximum = 256;
            this.SelectorR.Minimum = 132;
            this.SelectorR.Name = "SelectorR";
            this.SelectorR.Size = new System.Drawing.Size(125, 45);
            this.SelectorR.TabIndex = 4;
            this.SelectorR.Value = 132;
            this.SelectorR.Scroll += new System.EventHandler(this.SelectorR_Scroll);
            // 
            // picGrayImg
            // 
            this.picGrayImg.Location = new System.Drawing.Point(541, 27);
            this.picGrayImg.Name = "picGrayImg";
            this.picGrayImg.Size = new System.Drawing.Size(257, 200);
            this.picGrayImg.TabIndex = 5;
            this.picGrayImg.TabStop = false;
            // 
            // SelectLabelL
            // 
            this.SelectLabelL.AutoSize = true;
            this.SelectLabelL.Location = new System.Drawing.Point(278, 281);
            this.SelectLabelL.Name = "SelectLabelL";
            this.SelectLabelL.Size = new System.Drawing.Size(55, 13);
            this.SelectLabelL.TabIndex = 7;
            this.SelectLabelL.Text = "Left Value";
            // 
            // SelectLabelR
            // 
            this.SelectLabelR.AutoSize = true;
            this.SelectLabelR.Location = new System.Drawing.Point(407, 281);
            this.SelectLabelR.Name = "SelectLabelR";
            this.SelectLabelR.Size = new System.Drawing.Size(62, 13);
            this.SelectLabelR.TabIndex = 8;
            this.SelectLabelR.Text = "Right Value";
            // 
            // UpSelector
            // 
            this.UpSelector.Location = new System.Drawing.Point(278, 306);
            this.UpSelector.Maximum = 95;
            this.UpSelector.Minimum = 1;
            this.UpSelector.Name = "UpSelector";
            this.UpSelector.Size = new System.Drawing.Size(125, 45);
            this.UpSelector.TabIndex = 9;
            this.UpSelector.Value = 1;
            this.UpSelector.Scroll += new System.EventHandler(this.UpSelector_Scroll);
            // 
            // DownSelector
            // 
            this.DownSelector.Location = new System.Drawing.Point(410, 306);
            this.DownSelector.Maximum = 199;
            this.DownSelector.Minimum = 105;
            this.DownSelector.Name = "DownSelector";
            this.DownSelector.Size = new System.Drawing.Size(125, 45);
            this.DownSelector.TabIndex = 10;
            this.DownSelector.Value = 105;
            this.DownSelector.Scroll += new System.EventHandler(this.DownSelector_Scroll);
            // 
            // LabelUp
            // 
            this.LabelUp.AutoSize = true;
            this.LabelUp.Location = new System.Drawing.Point(278, 354);
            this.LabelUp.Name = "LabelUp";
            this.LabelUp.Size = new System.Drawing.Size(51, 13);
            this.LabelUp.TabIndex = 11;
            this.LabelUp.Text = "Up Value";
            // 
            // LabelDown
            // 
            this.LabelDown.AutoSize = true;
            this.LabelDown.Location = new System.Drawing.Point(407, 354);
            this.LabelDown.Name = "LabelDown";
            this.LabelDown.Size = new System.Drawing.Size(65, 13);
            this.LabelDown.TabIndex = 12;
            this.LabelDown.Text = "Down Value";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(538, 306);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(538, 329);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(538, 352);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "label3";
            // 
            // Direction
            // 
            this.Direction.AutoSize = true;
            this.Direction.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Direction.Location = new System.Drawing.Point(15, 281);
            this.Direction.Name = "Direction";
            this.Direction.Size = new System.Drawing.Size(70, 25);
            this.Direction.TabIndex = 16;
            this.Direction.Text = "label4";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(810, 24);
            this.menuStrip1.TabIndex = 18;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.imageToolStripMenuItem,
            this.videoToolStripMenuItem,
            this.webcamToolStripMenuItem});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // imageToolStripMenuItem
            // 
            this.imageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.s1ToolStripMenuItem,
            this.s2ToolStripMenuItem,
            this.s3ToolStripMenuItem,
            this.s4ToolStripMenuItem,
            this.s5ToolStripMenuItem,
            this.s6ToolStripMenuItem});
            this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            this.imageToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.imageToolStripMenuItem.Text = "Image";
            // 
            // s1ToolStripMenuItem
            // 
            this.s1ToolStripMenuItem.Name = "s1ToolStripMenuItem";
            this.s1ToolStripMenuItem.Size = new System.Drawing.Size(85, 22);
            this.s1ToolStripMenuItem.Text = "s1";
            this.s1ToolStripMenuItem.Click += new System.EventHandler(this.s1ToolStripMenuItem_Click);
            // 
            // s2ToolStripMenuItem
            // 
            this.s2ToolStripMenuItem.Name = "s2ToolStripMenuItem";
            this.s2ToolStripMenuItem.Size = new System.Drawing.Size(85, 22);
            this.s2ToolStripMenuItem.Text = "s2";
            this.s2ToolStripMenuItem.Click += new System.EventHandler(this.s2ToolStripMenuItem_Click);
            // 
            // s3ToolStripMenuItem
            // 
            this.s3ToolStripMenuItem.Name = "s3ToolStripMenuItem";
            this.s3ToolStripMenuItem.Size = new System.Drawing.Size(85, 22);
            this.s3ToolStripMenuItem.Text = "s3";
            this.s3ToolStripMenuItem.Click += new System.EventHandler(this.s3ToolStripMenuItem_Click);
            // 
            // s4ToolStripMenuItem
            // 
            this.s4ToolStripMenuItem.Name = "s4ToolStripMenuItem";
            this.s4ToolStripMenuItem.Size = new System.Drawing.Size(85, 22);
            this.s4ToolStripMenuItem.Text = "s4";
            this.s4ToolStripMenuItem.Click += new System.EventHandler(this.s4ToolStripMenuItem_Click);
            // 
            // s5ToolStripMenuItem
            // 
            this.s5ToolStripMenuItem.Name = "s5ToolStripMenuItem";
            this.s5ToolStripMenuItem.Size = new System.Drawing.Size(85, 22);
            this.s5ToolStripMenuItem.Text = "s5";
            this.s5ToolStripMenuItem.Click += new System.EventHandler(this.s5ToolStripMenuItem_Click);
            // 
            // s6ToolStripMenuItem
            // 
            this.s6ToolStripMenuItem.Name = "s6ToolStripMenuItem";
            this.s6ToolStripMenuItem.Size = new System.Drawing.Size(85, 22);
            this.s6ToolStripMenuItem.Text = "s6";
            this.s6ToolStripMenuItem.Click += new System.EventHandler(this.s6ToolStripMenuItem_Click);
            // 
            // videoToolStripMenuItem
            // 
            this.videoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.v1ToolStripMenuItem});
            this.videoToolStripMenuItem.Name = "videoToolStripMenuItem";
            this.videoToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.videoToolStripMenuItem.Text = "Video";
            // 
            // v1ToolStripMenuItem
            // 
            this.v1ToolStripMenuItem.Name = "v1ToolStripMenuItem";
            this.v1ToolStripMenuItem.Size = new System.Drawing.Size(86, 22);
            this.v1ToolStripMenuItem.Text = "v1";
            this.v1ToolStripMenuItem.Click += new System.EventHandler(this.v1ToolStripMenuItem_Click);
            // 
            // webcamToolStripMenuItem
            // 
            this.webcamToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.builtInToolStripMenuItem,
            this.externalToolStripMenuItem});
            this.webcamToolStripMenuItem.Name = "webcamToolStripMenuItem";
            this.webcamToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.webcamToolStripMenuItem.Text = "Webcam";
            // 
            // builtInToolStripMenuItem
            // 
            this.builtInToolStripMenuItem.Name = "builtInToolStripMenuItem";
            this.builtInToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.builtInToolStripMenuItem.Text = "Internal";
            this.builtInToolStripMenuItem.Click += new System.EventHandler(this.builtInToolStripMenuItem_Click);
            // 
            // externalToolStripMenuItem
            // 
            this.externalToolStripMenuItem.Name = "externalToolStripMenuItem";
            this.externalToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.externalToolStripMenuItem.Text = "External";
            this.externalToolStripMenuItem.Click += new System.EventHandler(this.externalToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Enabled = false;
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // EnableLines
            // 
            this.EnableLines.AutoSize = true;
            this.EnableLines.Location = new System.Drawing.Point(281, 380);
            this.EnableLines.Name = "EnableLines";
            this.EnableLines.Size = new System.Drawing.Size(87, 17);
            this.EnableLines.TabIndex = 19;
            this.EnableLines.Text = "Enable Lines";
            this.EnableLines.UseVisualStyleBackColor = true;
            this.EnableLines.CheckedChanged += new System.EventHandler(this.EnableLines_CheckedChanged);
            // 
            // xPosText
            // 
            this.xPosText.AutoSize = true;
            this.xPosText.Location = new System.Drawing.Point(671, 281);
            this.xPosText.Name = "xPosText";
            this.xPosText.Size = new System.Drawing.Size(36, 13);
            this.xPosText.TabIndex = 23;
            this.xPosText.Text = "x Pos:";
            // 
            // yPosText
            // 
            this.yPosText.AutoSize = true;
            this.yPosText.Location = new System.Drawing.Point(542, 281);
            this.yPosText.Name = "yPosText";
            this.yPosText.Size = new System.Drawing.Size(39, 13);
            this.yPosText.TabIndex = 22;
            this.yPosText.Text = "y Pos: ";
            // 
            // xPosSlider
            // 
            this.xPosSlider.Location = new System.Drawing.Point(673, 234);
            this.xPosSlider.Maximum = 256;
            this.xPosSlider.Minimum = 4;
            this.xPosSlider.Name = "xPosSlider";
            this.xPosSlider.Size = new System.Drawing.Size(125, 45);
            this.xPosSlider.TabIndex = 21;
            this.xPosSlider.Value = 132;
            this.xPosSlider.Scroll += new System.EventHandler(this.xPosSlider_Scroll);
            // 
            // yPosSlider
            // 
            this.yPosSlider.Location = new System.Drawing.Point(542, 234);
            this.yPosSlider.Maximum = 125;
            this.yPosSlider.Minimum = 4;
            this.yPosSlider.Name = "yPosSlider";
            this.yPosSlider.Size = new System.Drawing.Size(125, 45);
            this.yPosSlider.TabIndex = 20;
            this.yPosSlider.Value = 4;
            this.yPosSlider.Scroll += new System.EventHandler(this.yPosSlider_Scroll);
            // 
            // SlopeBox
            // 
            this.SlopeBox.AutoSize = true;
            this.SlopeBox.Location = new System.Drawing.Point(17, 234);
            this.SlopeBox.Name = "SlopeBox";
            this.SlopeBox.Size = new System.Drawing.Size(34, 13);
            this.SlopeBox.TabIndex = 24;
            this.SlopeBox.Text = "Slope";
            // 
            // OpenSerial
            // 
            this.OpenSerial.AutoSize = true;
            this.OpenSerial.Location = new System.Drawing.Point(20, 309);
            this.OpenSerial.Name = "OpenSerial";
            this.OpenSerial.Size = new System.Drawing.Size(112, 17);
            this.OpenSerial.TabIndex = 25;
            this.OpenSerial.Text = "Enable Serial Com";
            this.OpenSerial.UseVisualStyleBackColor = true;
            this.OpenSerial.CheckedChanged += new System.EventHandler(this.OpenSerial_CheckedChanged);
            // 
            // AvgXText
            // 
            this.AvgXText.AutoSize = true;
            this.AvgXText.Location = new System.Drawing.Point(17, 259);
            this.AvgXText.Name = "AvgXText";
            this.AvgXText.Size = new System.Drawing.Size(54, 13);
            this.AvgXText.TabIndex = 26;
            this.AvgXText.Text = "Avg X Val";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(102, 259);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Avg X Val";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 380);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Avg X Val";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(810, 486);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.AvgXText);
            this.Controls.Add(this.OpenSerial);
            this.Controls.Add(this.SlopeBox);
            this.Controls.Add(this.xPosText);
            this.Controls.Add(this.yPosText);
            this.Controls.Add(this.xPosSlider);
            this.Controls.Add(this.yPosSlider);
            this.Controls.Add(this.EnableLines);
            this.Controls.Add(this.Direction);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LabelDown);
            this.Controls.Add(this.LabelUp);
            this.Controls.Add(this.DownSelector);
            this.Controls.Add(this.UpSelector);
            this.Controls.Add(this.SelectLabelR);
            this.Controls.Add(this.SelectLabelL);
            this.Controls.Add(this.picGrayImg);
            this.Controls.Add(this.SelectorR);
            this.Controls.Add(this.SelectorL);
            this.Controls.Add(this.picWorkImg);
            this.Controls.Add(this.picBoxDef);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picBoxDef)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picWorkImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelectorL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SelectorR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picGrayImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.UpSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DownSelector)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.xPosSlider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yPosSlider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picBoxDef;
        private System.Windows.Forms.PictureBox picWorkImg;
        private System.Windows.Forms.TrackBar SelectorL;
        private System.Windows.Forms.TrackBar SelectorR;
        private System.Windows.Forms.PictureBox picGrayImg;
        private System.Windows.Forms.Label SelectLabelL;
        private System.Windows.Forms.Label SelectLabelR;
        private System.Windows.Forms.TrackBar UpSelector;
        private System.Windows.Forms.TrackBar DownSelector;
        private System.Windows.Forms.Label LabelUp;
        private System.Windows.Forms.Label LabelDown;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Direction;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem videoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem s1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem s2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem s3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem s4ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem s5ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem s6ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem v1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem webcamToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem builtInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem externalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.CheckBox EnableLines;
        private System.Windows.Forms.Label xPosText;
        private System.Windows.Forms.Label yPosText;
        private System.Windows.Forms.TrackBar xPosSlider;
        private System.Windows.Forms.TrackBar yPosSlider;
        private System.Windows.Forms.Label SlopeBox;
        private System.Windows.Forms.CheckBox OpenSerial;
        private System.Windows.Forms.Label AvgXText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

