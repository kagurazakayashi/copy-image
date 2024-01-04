namespace copy_image
{
    partial class Form2
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            pictureBox1 = new System.Windows.Forms.PictureBox();
            label1 = new System.Windows.Forms.Label();
            groupBoxAutoClose = new System.Windows.Forms.GroupBox();
            labelAutoCloseInfo1 = new System.Windows.Forms.Label();
            labelAutoCloseInfo2 = new System.Windows.Forms.Label();
            trackBarAutoClose = new System.Windows.Forms.TrackBar();
            groupBox1 = new System.Windows.Forms.GroupBox();
            buttonShellMenuItemStatus = new System.Windows.Forms.Button();
            textBoxFileTypes = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            buttonShellMenuItemAdd = new System.Windows.Forms.Button();
            buttonShellMenuItemRemove = new System.Windows.Forms.Button();
            textBoxShellMenuItemName = new System.Windows.Forms.TextBox();
            label3 = new System.Windows.Forms.Label();
            textBoxExePath = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            groupBox2 = new System.Windows.Forms.GroupBox();
            numericAutoSizeH = new System.Windows.Forms.NumericUpDown();
            label6 = new System.Windows.Forms.Label();
            numericAutoSizeW = new System.Windows.Forms.NumericUpDown();
            label5 = new System.Windows.Forms.Label();
            checkBoxAutoSize = new System.Windows.Forms.CheckBox();
            label7 = new System.Windows.Forms.Label();
            comboBoxThemeStyle = new System.Windows.Forms.ComboBox();
            comboBoxLanguage = new System.Windows.Forms.ComboBox();
            label8 = new System.Windows.Forms.Label();
            linkLabel1 = new System.Windows.Forms.LinkLabel();
            label9 = new System.Windows.Forms.Label();
            timer1 = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBoxAutoClose.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarAutoClose).BeginInit();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericAutoSizeH).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericAutoSizeW).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            pictureBox1.Image = Properties.Resources.copy_image_1;
            resources.ApplyResources(pictureBox1, "pictureBox1");
            pictureBox1.Name = "pictureBox1";
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            pictureBox1.MouseDown += pictureBox1_MouseDown;
            pictureBox1.MouseMove += pictureBox1_MouseMove;
            pictureBox1.MouseUp += pictureBox1_MouseUp;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // groupBoxAutoClose
            // 
            resources.ApplyResources(groupBoxAutoClose, "groupBoxAutoClose");
            groupBoxAutoClose.Controls.Add(labelAutoCloseInfo1);
            groupBoxAutoClose.Controls.Add(labelAutoCloseInfo2);
            groupBoxAutoClose.Controls.Add(trackBarAutoClose);
            groupBoxAutoClose.Name = "groupBoxAutoClose";
            groupBoxAutoClose.TabStop = false;
            // 
            // labelAutoCloseInfo1
            // 
            resources.ApplyResources(labelAutoCloseInfo1, "labelAutoCloseInfo1");
            labelAutoCloseInfo1.Name = "labelAutoCloseInfo1";
            // 
            // labelAutoCloseInfo2
            // 
            resources.ApplyResources(labelAutoCloseInfo2, "labelAutoCloseInfo2");
            labelAutoCloseInfo2.Name = "labelAutoCloseInfo2";
            // 
            // trackBarAutoClose
            // 
            resources.ApplyResources(trackBarAutoClose, "trackBarAutoClose");
            trackBarAutoClose.Cursor = System.Windows.Forms.Cursors.SizeWE;
            trackBarAutoClose.Maximum = 61;
            trackBarAutoClose.Name = "trackBarAutoClose";
            trackBarAutoClose.TickStyle = System.Windows.Forms.TickStyle.Both;
            trackBarAutoClose.Value = 3;
            trackBarAutoClose.Scroll += trackBarAutoClose_Scroll;
            // 
            // groupBox1
            // 
            resources.ApplyResources(groupBox1, "groupBox1");
            groupBox1.Controls.Add(buttonShellMenuItemStatus);
            groupBox1.Controls.Add(textBoxFileTypes);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(buttonShellMenuItemAdd);
            groupBox1.Controls.Add(buttonShellMenuItemRemove);
            groupBox1.Controls.Add(textBoxShellMenuItemName);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(textBoxExePath);
            groupBox1.Controls.Add(label2);
            groupBox1.Name = "groupBox1";
            groupBox1.TabStop = false;
            // 
            // buttonShellMenuItemStatus
            // 
            resources.ApplyResources(buttonShellMenuItemStatus, "buttonShellMenuItemStatus");
            buttonShellMenuItemStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            buttonShellMenuItemStatus.Name = "buttonShellMenuItemStatus";
            buttonShellMenuItemStatus.UseVisualStyleBackColor = true;
            buttonShellMenuItemStatus.Click += buttonShellMenuItemStatus_Click;
            // 
            // textBoxFileTypes
            // 
            resources.ApplyResources(textBoxFileTypes, "textBoxFileTypes");
            textBoxFileTypes.Name = "textBoxFileTypes";
            textBoxFileTypes.TextChanged += textBoxFileTypes_TextChanged;
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
            // 
            // buttonShellMenuItemAdd
            // 
            resources.ApplyResources(buttonShellMenuItemAdd, "buttonShellMenuItemAdd");
            buttonShellMenuItemAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            buttonShellMenuItemAdd.Name = "buttonShellMenuItemAdd";
            buttonShellMenuItemAdd.UseVisualStyleBackColor = true;
            buttonShellMenuItemAdd.Click += buttonShellMenuItemAdd_Click;
            // 
            // buttonShellMenuItemRemove
            // 
            resources.ApplyResources(buttonShellMenuItemRemove, "buttonShellMenuItemRemove");
            buttonShellMenuItemRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            buttonShellMenuItemRemove.Name = "buttonShellMenuItemRemove";
            buttonShellMenuItemRemove.UseVisualStyleBackColor = true;
            buttonShellMenuItemRemove.Click += buttonShellMenuItemRemove_Click;
            // 
            // textBoxShellMenuItemName
            // 
            resources.ApplyResources(textBoxShellMenuItemName, "textBoxShellMenuItemName");
            textBoxShellMenuItemName.Name = "textBoxShellMenuItemName";
            textBoxShellMenuItemName.TextChanged += textBox2_TextChanged;
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            // 
            // textBoxExePath
            // 
            resources.ApplyResources(textBoxExePath, "textBoxExePath");
            textBoxExePath.Name = "textBoxExePath";
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            // 
            // groupBox2
            // 
            resources.ApplyResources(groupBox2, "groupBox2");
            groupBox2.Controls.Add(numericAutoSizeH);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(numericAutoSizeW);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(checkBoxAutoSize);
            groupBox2.Name = "groupBox2";
            groupBox2.TabStop = false;
            // 
            // numericAutoSizeH
            // 
            resources.ApplyResources(numericAutoSizeH, "numericAutoSizeH");
            numericAutoSizeH.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericAutoSizeH.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericAutoSizeH.Name = "numericAutoSizeH";
            numericAutoSizeH.Value = new decimal(new int[] { 1080, 0, 0, 0 });
            numericAutoSizeH.ValueChanged += numericAutoSizeH_ValueChanged;
            // 
            // label6
            // 
            resources.ApplyResources(label6, "label6");
            label6.Name = "label6";
            // 
            // numericAutoSizeW
            // 
            resources.ApplyResources(numericAutoSizeW, "numericAutoSizeW");
            numericAutoSizeW.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericAutoSizeW.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericAutoSizeW.Name = "numericAutoSizeW";
            numericAutoSizeW.Value = new decimal(new int[] { 1920, 0, 0, 0 });
            numericAutoSizeW.ValueChanged += numericAutoSizeW_ValueChanged;
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.Name = "label5";
            // 
            // checkBoxAutoSize
            // 
            resources.ApplyResources(checkBoxAutoSize, "checkBoxAutoSize");
            checkBoxAutoSize.Cursor = System.Windows.Forms.Cursors.Hand;
            checkBoxAutoSize.Name = "checkBoxAutoSize";
            checkBoxAutoSize.UseVisualStyleBackColor = true;
            checkBoxAutoSize.CheckedChanged += checkBoxAutoSize_CheckedChanged;
            // 
            // label7
            // 
            resources.ApplyResources(label7, "label7");
            label7.Name = "label7";
            // 
            // comboBoxThemeStyle
            // 
            comboBoxThemeStyle.Cursor = System.Windows.Forms.Cursors.Hand;
            comboBoxThemeStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxThemeStyle.FormattingEnabled = true;
            resources.ApplyResources(comboBoxThemeStyle, "comboBoxThemeStyle");
            comboBoxThemeStyle.Name = "comboBoxThemeStyle";
            comboBoxThemeStyle.SelectedIndexChanged += comboBoxThemeStyle_SelectedIndexChanged;
            // 
            // comboBoxLanguage
            // 
            resources.ApplyResources(comboBoxLanguage, "comboBoxLanguage");
            comboBoxLanguage.Cursor = System.Windows.Forms.Cursors.Hand;
            comboBoxLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxLanguage.FormattingEnabled = true;
            comboBoxLanguage.Name = "comboBoxLanguage";
            comboBoxLanguage.SelectedIndexChanged += comboBoxLanguage_SelectedIndexChanged;
            // 
            // label8
            // 
            resources.ApplyResources(label8, "label8");
            label8.Name = "label8";
            // 
            // linkLabel1
            // 
            linkLabel1.ActiveLinkColor = System.Drawing.Color.Yellow;
            resources.ApplyResources(linkLabel1, "linkLabel1");
            linkLabel1.LinkColor = System.Drawing.Color.FromArgb(0, 192, 192);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.TabStop = true;
            linkLabel1.VisitedLinkColor = System.Drawing.Color.FromArgb(0, 192, 192);
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // label9
            // 
            resources.ApplyResources(label9, "label9");
            label9.Name = "label9";
            // 
            // timer1
            // 
            timer1.Interval = 30;
            timer1.Tick += timer1_Tick;
            // 
            // Form2
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(pictureBox1);
            Controls.Add(label9);
            Controls.Add(linkLabel1);
            Controls.Add(comboBoxLanguage);
            Controls.Add(label8);
            Controls.Add(comboBoxThemeStyle);
            Controls.Add(label7);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(groupBoxAutoClose);
            Controls.Add(label1);
            Name = "Form2";
            FormClosing += Form2_FormClosing;
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBoxAutoClose.ResumeLayout(false);
            groupBoxAutoClose.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarAutoClose).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericAutoSizeH).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericAutoSizeW).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxAutoClose;
        private System.Windows.Forms.TrackBar trackBarAutoClose;
        private System.Windows.Forms.Label labelAutoCloseInfo2;
        private System.Windows.Forms.Label labelAutoCloseInfo1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxExePath;
        private System.Windows.Forms.TextBox textBoxShellMenuItemName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button buttonShellMenuItemAdd;
        private System.Windows.Forms.Button buttonShellMenuItemRemove;
        private System.Windows.Forms.TextBox textBoxFileTypes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button buttonShellMenuItemStatus;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numericAutoSizeH;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericAutoSizeW;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox checkBoxAutoSize;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBoxThemeStyle;
        private System.Windows.Forms.ComboBox comboBoxLanguage;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Timer timer1;
    }
}