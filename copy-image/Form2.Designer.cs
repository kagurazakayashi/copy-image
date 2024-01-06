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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxAutoClose = new System.Windows.Forms.GroupBox();
            this.labelAutoCloseInfo1 = new System.Windows.Forms.Label();
            this.labelAutoCloseInfo2 = new System.Windows.Forms.Label();
            this.trackBarAutoClose = new System.Windows.Forms.TrackBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonShellMenuItemStatus = new System.Windows.Forms.Button();
            this.textBoxFileTypes = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonShellMenuItemAdd = new System.Windows.Forms.Button();
            this.buttonShellMenuItemRemove = new System.Windows.Forms.Button();
            this.textBoxShellMenuItemName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxExePath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numericAutoSizeH = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numericAutoSizeW = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.checkBoxAutoSize = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxThemeStyle = new System.Windows.Forms.ComboBox();
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label9 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBoxAutoClose.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAutoClose)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericAutoSizeH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericAutoSizeW)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // groupBoxAutoClose
            // 
            resources.ApplyResources(this.groupBoxAutoClose, "groupBoxAutoClose");
            this.groupBoxAutoClose.Controls.Add(this.labelAutoCloseInfo1);
            this.groupBoxAutoClose.Controls.Add(this.labelAutoCloseInfo2);
            this.groupBoxAutoClose.Controls.Add(this.trackBarAutoClose);
            this.groupBoxAutoClose.Name = "groupBoxAutoClose";
            this.groupBoxAutoClose.TabStop = false;
            // 
            // labelAutoCloseInfo1
            // 
            resources.ApplyResources(this.labelAutoCloseInfo1, "labelAutoCloseInfo1");
            this.labelAutoCloseInfo1.Name = "labelAutoCloseInfo1";
            // 
            // labelAutoCloseInfo2
            // 
            resources.ApplyResources(this.labelAutoCloseInfo2, "labelAutoCloseInfo2");
            this.labelAutoCloseInfo2.Name = "labelAutoCloseInfo2";
            // 
            // trackBarAutoClose
            // 
            resources.ApplyResources(this.trackBarAutoClose, "trackBarAutoClose");
            this.trackBarAutoClose.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.trackBarAutoClose.Maximum = 61;
            this.trackBarAutoClose.Name = "trackBarAutoClose";
            this.trackBarAutoClose.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBarAutoClose.Value = 3;
            this.trackBarAutoClose.Scroll += new System.EventHandler(this.trackBarAutoClose_Scroll);
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.buttonShellMenuItemStatus);
            this.groupBox1.Controls.Add(this.textBoxFileTypes);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.buttonShellMenuItemAdd);
            this.groupBox1.Controls.Add(this.buttonShellMenuItemRemove);
            this.groupBox1.Controls.Add(this.textBoxShellMenuItemName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxExePath);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // buttonShellMenuItemStatus
            // 
            resources.ApplyResources(this.buttonShellMenuItemStatus, "buttonShellMenuItemStatus");
            this.buttonShellMenuItemStatus.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonShellMenuItemStatus.Name = "buttonShellMenuItemStatus";
            this.buttonShellMenuItemStatus.UseVisualStyleBackColor = true;
            this.buttonShellMenuItemStatus.Click += new System.EventHandler(this.buttonShellMenuItemStatus_Click);
            // 
            // textBoxFileTypes
            // 
            resources.ApplyResources(this.textBoxFileTypes, "textBoxFileTypes");
            this.textBoxFileTypes.Name = "textBoxFileTypes";
            this.textBoxFileTypes.TextChanged += new System.EventHandler(this.textBoxFileTypes_TextChanged);
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // buttonShellMenuItemAdd
            // 
            resources.ApplyResources(this.buttonShellMenuItemAdd, "buttonShellMenuItemAdd");
            this.buttonShellMenuItemAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonShellMenuItemAdd.Name = "buttonShellMenuItemAdd";
            this.buttonShellMenuItemAdd.UseVisualStyleBackColor = true;
            this.buttonShellMenuItemAdd.Click += new System.EventHandler(this.buttonShellMenuItemAdd_Click);
            // 
            // buttonShellMenuItemRemove
            // 
            resources.ApplyResources(this.buttonShellMenuItemRemove, "buttonShellMenuItemRemove");
            this.buttonShellMenuItemRemove.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonShellMenuItemRemove.Name = "buttonShellMenuItemRemove";
            this.buttonShellMenuItemRemove.UseVisualStyleBackColor = true;
            this.buttonShellMenuItemRemove.Click += new System.EventHandler(this.buttonShellMenuItemRemove_Click);
            // 
            // textBoxShellMenuItemName
            // 
            resources.ApplyResources(this.textBoxShellMenuItemName, "textBoxShellMenuItemName");
            this.textBoxShellMenuItemName.Name = "textBoxShellMenuItemName";
            this.textBoxShellMenuItemName.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // textBoxExePath
            // 
            resources.ApplyResources(this.textBoxExePath, "textBoxExePath");
            this.textBoxExePath.Name = "textBoxExePath";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.numericAutoSizeH);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.numericAutoSizeW);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.checkBoxAutoSize);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // numericAutoSizeH
            // 
            resources.ApplyResources(this.numericAutoSizeH, "numericAutoSizeH");
            this.numericAutoSizeH.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericAutoSizeH.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericAutoSizeH.Name = "numericAutoSizeH";
            this.numericAutoSizeH.Value = new decimal(new int[] {
            1080,
            0,
            0,
            0});
            this.numericAutoSizeH.ValueChanged += new System.EventHandler(this.numericAutoSizeH_ValueChanged);
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // numericAutoSizeW
            // 
            resources.ApplyResources(this.numericAutoSizeW, "numericAutoSizeW");
            this.numericAutoSizeW.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericAutoSizeW.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericAutoSizeW.Name = "numericAutoSizeW";
            this.numericAutoSizeW.Value = new decimal(new int[] {
            1920,
            0,
            0,
            0});
            this.numericAutoSizeW.ValueChanged += new System.EventHandler(this.numericAutoSizeW_ValueChanged);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // checkBoxAutoSize
            // 
            resources.ApplyResources(this.checkBoxAutoSize, "checkBoxAutoSize");
            this.checkBoxAutoSize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxAutoSize.Name = "checkBoxAutoSize";
            this.checkBoxAutoSize.UseVisualStyleBackColor = true;
            this.checkBoxAutoSize.CheckedChanged += new System.EventHandler(this.checkBoxAutoSize_CheckedChanged);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // comboBoxThemeStyle
            // 
            this.comboBoxThemeStyle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBoxThemeStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxThemeStyle.FormattingEnabled = true;
            resources.ApplyResources(this.comboBoxThemeStyle, "comboBoxThemeStyle");
            this.comboBoxThemeStyle.Name = "comboBoxThemeStyle";
            this.comboBoxThemeStyle.SelectedIndexChanged += new System.EventHandler(this.comboBoxThemeStyle_SelectedIndexChanged);
            // 
            // comboBoxLanguage
            // 
            resources.ApplyResources(this.comboBoxLanguage, "comboBoxLanguage");
            this.comboBoxLanguage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.comboBoxLanguage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.SelectedIndexChanged += new System.EventHandler(this.comboBoxLanguage_SelectedIndexChanged);
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // linkLabel1
            // 
            this.linkLabel1.ActiveLinkColor = System.Drawing.Color.Yellow;
            resources.ApplyResources(this.linkLabel1, "linkLabel1");
            this.linkLabel1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.TabStop = true;
            this.linkLabel1.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // timer1
            // 
            this.timer1.Interval = 30;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox1.Image = global::copy_image.Properties.Resources.copyimage1;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form2
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.comboBoxLanguage);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboBoxThemeStyle);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBoxAutoClose);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form2_FormClosing);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.groupBoxAutoClose.ResumeLayout(false);
            this.groupBoxAutoClose.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarAutoClose)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericAutoSizeH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericAutoSizeW)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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