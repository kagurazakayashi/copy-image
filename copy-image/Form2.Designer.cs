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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBoxAutoClose.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarAutoClose).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.copy_image_1;
            pictureBox1.Location = new System.Drawing.Point(14, 14);
            pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new System.Drawing.Size(73, 75);
            pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            label1.Location = new System.Drawing.Point(94, 14);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(518, 75);
            label1.TabIndex = 1;
            label1.Text = "使用方法：\r\n<程序名称>.exe <图片文件路径>\r\n不提供 <图片文件路径> 将显示本配置窗口。";
            // 
            // groupBoxAutoClose
            // 
            groupBoxAutoClose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            groupBoxAutoClose.Controls.Add(labelAutoCloseInfo2);
            groupBoxAutoClose.Controls.Add(labelAutoCloseInfo1);
            groupBoxAutoClose.Controls.Add(trackBarAutoClose);
            groupBoxAutoClose.Location = new System.Drawing.Point(14, 96);
            groupBoxAutoClose.Name = "groupBoxAutoClose";
            groupBoxAutoClose.Size = new System.Drawing.Size(598, 101);
            groupBoxAutoClose.TabIndex = 2;
            groupBoxAutoClose.TabStop = false;
            groupBoxAutoClose.Text = "右下角提示窗自动关闭时间: 3 秒";
            // 
            // labelAutoCloseInfo2
            // 
            labelAutoCloseInfo2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            labelAutoCloseInfo2.AutoSize = true;
            labelAutoCloseInfo2.Location = new System.Drawing.Point(457, 72);
            labelAutoCloseInfo2.Name = "labelAutoCloseInfo2";
            labelAutoCloseInfo2.Size = new System.Drawing.Size(135, 20);
            labelAutoCloseInfo2.TabIndex = 4;
            labelAutoCloseInfo2.Text = "不要自动关闭提示窗";
            labelAutoCloseInfo2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelAutoCloseInfo1
            // 
            labelAutoCloseInfo1.AutoSize = true;
            labelAutoCloseInfo1.Location = new System.Drawing.Point(6, 72);
            labelAutoCloseInfo1.Name = "labelAutoCloseInfo1";
            labelAutoCloseInfo1.Size = new System.Drawing.Size(107, 20);
            labelAutoCloseInfo1.TabIndex = 4;
            labelAutoCloseInfo1.Text = "禁止显示提示窗";
            // 
            // trackBarAutoClose
            // 
            trackBarAutoClose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            trackBarAutoClose.Cursor = System.Windows.Forms.Cursors.SizeWE;
            trackBarAutoClose.Location = new System.Drawing.Point(6, 24);
            trackBarAutoClose.Maximum = 61;
            trackBarAutoClose.Name = "trackBarAutoClose";
            trackBarAutoClose.Size = new System.Drawing.Size(586, 45);
            trackBarAutoClose.TabIndex = 3;
            trackBarAutoClose.TickStyle = System.Windows.Forms.TickStyle.Both;
            trackBarAutoClose.Value = 3;
            trackBarAutoClose.Scroll += trackBarAutoClose_Scroll;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(buttonShellMenuItemStatus);
            groupBox1.Controls.Add(textBoxFileTypes);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(buttonShellMenuItemAdd);
            groupBox1.Controls.Add(buttonShellMenuItemRemove);
            groupBox1.Controls.Add(textBoxShellMenuItemName);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(textBoxExePath);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new System.Drawing.Point(12, 203);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new System.Drawing.Size(600, 223);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "图片文件右键菜单项";
            // 
            // buttonShellMenuItemStatus
            // 
            buttonShellMenuItemStatus.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            buttonShellMenuItemStatus.Location = new System.Drawing.Point(8, 183);
            buttonShellMenuItemStatus.Name = "buttonShellMenuItemStatus";
            buttonShellMenuItemStatus.Size = new System.Drawing.Size(192, 31);
            buttonShellMenuItemStatus.TabIndex = 5;
            buttonShellMenuItemStatus.Text = "查看右键菜单状态";
            buttonShellMenuItemStatus.UseVisualStyleBackColor = true;
            buttonShellMenuItemStatus.Click += buttonShellMenuItemStatus_Click;
            // 
            // textBoxFileTypes
            // 
            textBoxFileTypes.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textBoxFileTypes.Location = new System.Drawing.Point(8, 146);
            textBoxFileTypes.Name = "textBoxFileTypes";
            textBoxFileTypes.Size = new System.Drawing.Size(586, 25);
            textBoxFileTypes.TabIndex = 6;
            textBoxFileTypes.Text = "jpg,jpeg,png,tif,tiff,bmp";
            textBoxFileTypes.TextChanged += textBoxFileTypes_TextChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(8, 123);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(174, 20);
            label4.TabIndex = 5;
            label4.Text = "支持的文件类型（ , 分隔）";
            label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // buttonShellMenuItemAdd
            // 
            buttonShellMenuItemAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            buttonShellMenuItemAdd.Location = new System.Drawing.Point(206, 183);
            buttonShellMenuItemAdd.Name = "buttonShellMenuItemAdd";
            buttonShellMenuItemAdd.Size = new System.Drawing.Size(192, 31);
            buttonShellMenuItemAdd.TabIndex = 4;
            buttonShellMenuItemAdd.Text = "添加右键菜单";
            buttonShellMenuItemAdd.UseVisualStyleBackColor = true;
            buttonShellMenuItemAdd.Click += buttonShellMenuItemAdd_Click;
            // 
            // buttonShellMenuItemRemove
            // 
            buttonShellMenuItemRemove.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            buttonShellMenuItemRemove.Location = new System.Drawing.Point(402, 183);
            buttonShellMenuItemRemove.Name = "buttonShellMenuItemRemove";
            buttonShellMenuItemRemove.Size = new System.Drawing.Size(192, 31);
            buttonShellMenuItemRemove.TabIndex = 4;
            buttonShellMenuItemRemove.Text = "移除右键菜单";
            buttonShellMenuItemRemove.UseVisualStyleBackColor = true;
            buttonShellMenuItemRemove.Click += buttonShellMenuItemRemove_Click;
            // 
            // textBoxShellMenuItemName
            // 
            textBoxShellMenuItemName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textBoxShellMenuItemName.Location = new System.Drawing.Point(8, 95);
            textBoxShellMenuItemName.Name = "textBoxShellMenuItemName";
            textBoxShellMenuItemName.Size = new System.Drawing.Size(586, 25);
            textBoxShellMenuItemName.TabIndex = 3;
            textBoxShellMenuItemName.Text = "复制图片到剪贴板(&P)";
            textBoxShellMenuItemName.TextChanged += textBox2_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(8, 72);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(121, 20);
            label3.TabIndex = 2;
            label3.Text = "右键菜单项名称：";
            // 
            // textBoxExePath
            // 
            textBoxExePath.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textBoxExePath.Location = new System.Drawing.Point(8, 44);
            textBoxExePath.Name = "textBoxExePath";
            textBoxExePath.Size = new System.Drawing.Size(586, 25);
            textBoxExePath.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(8, 21);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(107, 20);
            label2.TabIndex = 0;
            label2.Text = "程序文件路径：";
            // 
            // Form2
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(624, 437);
            Controls.Add(groupBox1);
            Controls.Add(groupBoxAutoClose);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
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
    }
}