using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using copy_image.Properties;

namespace copy_image
{
    public partial class Form2 : Form
    {
        public string imagePath = string.Empty;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            int autoClose = Settings.Default.autoclose;
            if (autoClose < trackBarAutoClose.Minimum)
            {
                autoClose = trackBarAutoClose.Minimum;
            }
            else if (autoClose > trackBarAutoClose.Maximum)
            {
                autoClose = trackBarAutoClose.Maximum;
            }
            trackBarAutoClose.Value = autoClose;
            trackBarAutoClose_Scroll(sender, e);
        }

        private void trackBarAutoClose_Scroll(object sender, EventArgs e)
        {
            string splitchar = ": ";
            string timeTitle = groupBoxAutoClose.Text.Split(splitchar)[0];
            int val = trackBarAutoClose.Value;
            if (val == trackBarAutoClose.Minimum)
            {
                timeTitle += splitchar + labelAutoCloseInfo1.Text;
            }
            else if (val == trackBarAutoClose.Maximum)
            {
                timeTitle += splitchar + labelAutoCloseInfo2.Text;
            }
            else
            {
                timeTitle += splitchar + val.ToString() + " 秒";
            }
            groupBoxAutoClose.Text = timeTitle;
            if (val != Settings.Default.autoclose)
            {
                Settings.Default.autoclose = val;
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Settings.Default.Save();
        }
    }
}
