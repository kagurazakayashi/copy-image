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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            pictureBox1 = new System.Windows.Forms.PictureBox();
            label1 = new System.Windows.Forms.Label();
            groupBoxAutoClose = new System.Windows.Forms.GroupBox();
            labelAutoCloseInfo2 = new System.Windows.Forms.Label();
            labelAutoCloseInfo1 = new System.Windows.Forms.Label();
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
            pictureBox1.Image = Properties.Resources.copy_image_1;
            pictureBox1.Location = new System.Drawing.Point(18, 15);
            pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(91, 79);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            label1.Location = new System.Drawing.Point(118, 15);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(648, 79);
            label1.TabIndex = 1;
            label1.Text = "使用方法：<程序名称>.exe <图片文件路径>\r\n不提供 <图片文件路径> 将显示本配置窗口。";
            // 
            // groupBoxAutoClose
            // 
            groupBoxAutoClose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBoxAutoClose.Controls.Add(labelAutoCloseInfo2);
            groupBoxAutoClose.Controls.Add(labelAutoCloseInfo1);
            groupBoxAutoClose.Controls.Add(trackBarAutoClose);
            groupBoxAutoClose.Location = new System.Drawing.Point(18, 101);
            groupBoxAutoClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBoxAutoClose.Name = "groupBoxAutoClose";
            groupBoxAutoClose.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBoxAutoClose.Size = new System.Drawing.Size(748, 106);
            groupBoxAutoClose.TabIndex = 2;
            groupBoxAutoClose.TabStop = false;
            groupBoxAutoClose.Text = "右下角提示窗自动关闭时间: 3 秒";
            // 
            // labelAutoCloseInfo2
            // 
            labelAutoCloseInfo2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            labelAutoCloseInfo2.AutoSize = true;
            labelAutoCloseInfo2.Location = new System.Drawing.Point(585, 76);
            labelAutoCloseInfo2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelAutoCloseInfo2.Name = "labelAutoCloseInfo2";
            labelAutoCloseInfo2.Size = new System.Drawing.Size(154, 21);
            labelAutoCloseInfo2.TabIndex = 4;
            labelAutoCloseInfo2.Text = "不要自动关闭提示窗";
            labelAutoCloseInfo2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelAutoCloseInfo1
            // 
            labelAutoCloseInfo1.AutoSize = true;
            labelAutoCloseInfo1.Location = new System.Drawing.Point(8, 76);
            labelAutoCloseInfo1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            labelAutoCloseInfo1.Name = "labelAutoCloseInfo1";
            labelAutoCloseInfo1.Size = new System.Drawing.Size(202, 21);
            labelAutoCloseInfo1.TabIndex = 4;
            labelAutoCloseInfo1.Text = "后台复制（最小化提示窗）";
            // 
            // trackBarAutoClose
            // 
            trackBarAutoClose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            trackBarAutoClose.Cursor = System.Windows.Forms.Cursors.SizeWE;
            trackBarAutoClose.Location = new System.Drawing.Point(8, 25);
            trackBarAutoClose.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            trackBarAutoClose.Maximum = 61;
            trackBarAutoClose.Name = "trackBarAutoClose";
            trackBarAutoClose.Size = new System.Drawing.Size(732, 45);
            trackBarAutoClose.TabIndex = 3;
            trackBarAutoClose.TickStyle = System.Windows.Forms.TickStyle.Both;
            trackBarAutoClose.Value = 3;
            trackBarAutoClose.Scroll += trackBarAutoClose_Scroll;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBox1.Controls.Add(buttonShellMenuItemStatus);
            groupBox1.Controls.Add(textBoxFileTypes);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(buttonShellMenuItemAdd);
            groupBox1.Controls.Add(buttonShellMenuItemRemove);
            groupBox1.Controls.Add(textBoxShellMenuItemName);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(textBoxExePath);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new System.Drawing.Point(15, 319);
            groupBox1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox1.Size = new System.Drawing.Size(750, 234);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "图片文件右键菜单项";
            // 
            // buttonShellMenuItemStatus
            // 
            buttonShellMenuItemStatus.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            buttonShellMenuItemStatus.Location = new System.Drawing.Point(10, 192);
            buttonShellMenuItemStatus.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            buttonShellMenuItemStatus.Name = "buttonShellMenuItemStatus";
            buttonShellMenuItemStatus.Size = new System.Drawing.Size(240, 33);
            buttonShellMenuItemStatus.TabIndex = 5;
            buttonShellMenuItemStatus.Text = "查看右键菜单状态";
            buttonShellMenuItemStatus.UseVisualStyleBackColor = true;
            buttonShellMenuItemStatus.Click += buttonShellMenuItemStatus_Click;
            // 
            // textBoxFileTypes
            // 
            textBoxFileTypes.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textBoxFileTypes.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxFileTypes.Location = new System.Drawing.Point(10, 154);
            textBoxFileTypes.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBoxFileTypes.Name = "textBoxFileTypes";
            textBoxFileTypes.Size = new System.Drawing.Size(732, 26);
            textBoxFileTypes.TabIndex = 6;
            textBoxFileTypes.Text = "jpg,jpeg,png,tif,tiff,bmp";
            textBoxFileTypes.TextChanged += textBoxFileTypes_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(10, 130);
            label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(200, 21);
            label4.TabIndex = 5;
            label4.Text = "支持的文件类型（ , 分隔）";
            label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // buttonShellMenuItemAdd
            // 
            buttonShellMenuItemAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            buttonShellMenuItemAdd.Location = new System.Drawing.Point(258, 192);
            buttonShellMenuItemAdd.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            buttonShellMenuItemAdd.Name = "buttonShellMenuItemAdd";
            buttonShellMenuItemAdd.Size = new System.Drawing.Size(240, 33);
            buttonShellMenuItemAdd.TabIndex = 4;
            buttonShellMenuItemAdd.Text = "添加右键菜单";
            buttonShellMenuItemAdd.UseVisualStyleBackColor = true;
            buttonShellMenuItemAdd.Click += buttonShellMenuItemAdd_Click;
            // 
            // buttonShellMenuItemRemove
            // 
            buttonShellMenuItemRemove.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            buttonShellMenuItemRemove.Location = new System.Drawing.Point(502, 192);
            buttonShellMenuItemRemove.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            buttonShellMenuItemRemove.Name = "buttonShellMenuItemRemove";
            buttonShellMenuItemRemove.Size = new System.Drawing.Size(240, 33);
            buttonShellMenuItemRemove.TabIndex = 4;
            buttonShellMenuItemRemove.Text = "移除右键菜单";
            buttonShellMenuItemRemove.UseVisualStyleBackColor = true;
            buttonShellMenuItemRemove.Click += buttonShellMenuItemRemove_Click;
            // 
            // textBoxShellMenuItemName
            // 
            textBoxShellMenuItemName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textBoxShellMenuItemName.Location = new System.Drawing.Point(10, 101);
            textBoxShellMenuItemName.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBoxShellMenuItemName.Name = "textBoxShellMenuItemName";
            textBoxShellMenuItemName.Size = new System.Drawing.Size(732, 28);
            textBoxShellMenuItemName.TabIndex = 3;
            textBoxShellMenuItemName.Text = "复制图片到剪贴板";
            textBoxShellMenuItemName.TextChanged += textBox2_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(10, 77);
            label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(138, 21);
            label3.TabIndex = 2;
            label3.Text = "右键菜单项名称：";
            // 
            // textBoxExePath
            // 
            textBoxExePath.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textBoxExePath.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            textBoxExePath.Location = new System.Drawing.Point(10, 46);
            textBoxExePath.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            textBoxExePath.Name = "textBoxExePath";
            textBoxExePath.Size = new System.Drawing.Size(732, 26);
            textBoxExePath.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(10, 22);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(122, 21);
            label2.TabIndex = 0;
            label2.Text = "程序文件路径：";
            // 
            // groupBox2
            // 
            groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBox2.Controls.Add(numericAutoSizeH);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(numericAutoSizeW);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(checkBoxAutoSize);
            groupBox2.Location = new System.Drawing.Point(15, 213);
            groupBox2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            groupBox2.Size = new System.Drawing.Size(750, 100);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "图片尺寸限制（像素）";
            // 
            // numericAutoSizeH
            // 
            numericAutoSizeH.Enabled = false;
            numericAutoSizeH.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericAutoSizeH.Location = new System.Drawing.Point(439, 58);
            numericAutoSizeH.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            numericAutoSizeH.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericAutoSizeH.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericAutoSizeH.Name = "numericAutoSizeH";
            numericAutoSizeH.Size = new System.Drawing.Size(150, 26);
            numericAutoSizeH.TabIndex = 4;
            numericAutoSizeH.Value = new decimal(new int[] { 1080, 0, 0, 0 });
            numericAutoSizeH.ValueChanged += numericAutoSizeH_ValueChanged;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(345, 59);
            label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(42, 21);
            label6.TabIndex = 3;
            label6.Text = "高度";
            // 
            // numericAutoSizeW
            // 
            numericAutoSizeW.Enabled = false;
            numericAutoSizeW.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            numericAutoSizeW.Location = new System.Drawing.Point(101, 58);
            numericAutoSizeW.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            numericAutoSizeW.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericAutoSizeW.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericAutoSizeW.Name = "numericAutoSizeW";
            numericAutoSizeW.Size = new System.Drawing.Size(150, 26);
            numericAutoSizeW.TabIndex = 2;
            numericAutoSizeW.Value = new decimal(new int[] { 1920, 0, 0, 0 });
            numericAutoSizeW.ValueChanged += numericAutoSizeW_ValueChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(8, 59);
            label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(42, 21);
            label5.TabIndex = 1;
            label5.Text = "宽度";
            // 
            // checkBoxAutoSize
            // 
            checkBoxAutoSize.AutoSize = true;
            checkBoxAutoSize.Location = new System.Drawing.Point(10, 25);
            checkBoxAutoSize.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            checkBoxAutoSize.Name = "checkBoxAutoSize";
            checkBoxAutoSize.Size = new System.Drawing.Size(317, 25);
            checkBoxAutoSize.TabIndex = 0;
            checkBoxAutoSize.Text = "如果图片大于以下尺寸，先缩小到该尺寸";
            checkBoxAutoSize.UseVisualStyleBackColor = true;
            checkBoxAutoSize.CheckedChanged += checkBoxAutoSize_CheckedChanged;
            // 
            // Form2
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(780, 570);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(groupBoxAutoClose);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4);
            Name = "Form2";
            Text = "快捷复制图片到剪贴板";
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
    }
}