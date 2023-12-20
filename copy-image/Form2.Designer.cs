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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBoxAutoClose.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarAutoClose).BeginInit();
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
            groupBoxAutoClose.Size = new System.Drawing.Size(598, 112);
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
            // Form2
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(624, 441);
            Controls.Add(groupBoxAutoClose);
            Controls.Add(label1);
            Controls.Add(pictureBox1);
            Font = new System.Drawing.Font("Microsoft YaHei UI", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            Name = "Form2";
            Text = "配置";
            FormClosing += Form2_FormClosing;
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBoxAutoClose.ResumeLayout(false);
            groupBoxAutoClose.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trackBarAutoClose).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxAutoClose;
        private System.Windows.Forms.TrackBar trackBarAutoClose;
        private System.Windows.Forms.Label labelAutoCloseInfo2;
        private System.Windows.Forms.Label labelAutoCloseInfo1;
    }
}