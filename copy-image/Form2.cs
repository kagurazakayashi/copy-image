using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using copy_image.Properties;
using System.Reflection;
using Microsoft.Win32;
using System.IO;
using System.Xml.Linq;
using System.Resources;
using System.Diagnostics;

namespace copy_image
{
    public partial class Form2 : Form
    {
        public string imagePath = string.Empty;
        ResourceManager l;
        public string extName = "";
        AniEgg aniegg = null;
        private Size defaultSize;
        private bool initOK = false;

        public Form2(string path)
        {
            InitializeComponent();
            l = new ResourceManager("copy_image.Resource", typeof(Form2).Assembly);
            imagePath = path;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            string themesT = l.GetString("Theme");
            string[] themes = new string[0];
            if (themesT != null)
            {
                themes = themesT.Split(',');
            }
            extName = l.GetString("ExplorerExt");
            foreach (string theme in themes)
            {
                comboBoxThemeStyle.Items.Add(theme);
            }
            themes = LanguageMgr.langList();
            foreach (string theme in themes)
            {
                comboBoxLanguage.Items.Add(theme);
            }
            if (Settings.Default.ThemeStyle >= comboBoxThemeStyle.Items.Count)
            {
                comboBoxThemeStyle.SelectedIndex = 0;
            }
            else
            {
                comboBoxThemeStyle.SelectedIndex = Settings.Default.ThemeStyle;
            }
            if (Settings.Default.ThemeStyle == 2 || (GlobalSettings.IsDarkModeEnabled && Settings.Default.ThemeStyle == 0))
            {
                applyDarkTheme();
            }
            string showLang = LanguageMgr.autoSetLanguage(false, false)[2];
            showLang = LanguageMgr.langInfo(showLang);
            comboBoxLanguage.Text = showLang;
            if (imagePath != string.Empty)
            {
                label1.Text += $"\n{imagePath} {l.GetString("NotValidPath")}";
            }
            int autoClose = Settings.Default.AutoClose;
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
            textBoxExePath.Text = Assembly.GetExecutingAssembly().Location.Replace(".dll", ".exe");
            if (Settings.Default.MenuItemName.Length > 0)
            {
                textBoxShellMenuItemName.Text = Settings.Default.MenuItemName;
            }
            if (Settings.Default.fileExtensions.Length > 0)
            {
                textBoxFileTypes.Text = Settings.Default.fileExtensions;
            }
            decimal[] maxSize = new decimal[2] { Settings.Default.AutoSizeW, Settings.Default.AutoSizeH };
            if (maxSize[0] < numericAutoSizeW.Minimum)
            {
                maxSize[0] = numericAutoSizeW.Minimum;
            }
            else if (maxSize[0] > numericAutoSizeW.Maximum)
            {
                maxSize[0] = numericAutoSizeW.Maximum;
            }
            if (maxSize[1] < numericAutoSizeH.Minimum)
            {
                maxSize[1] = numericAutoSizeH.Minimum;
            }
            else if (maxSize[1] > numericAutoSizeH.Maximum)
            {
                maxSize[1] = numericAutoSizeH.Maximum;
            }
            checkBoxAutoSize.Checked = Settings.Default.AutoSize;
            numericAutoSizeW.Value = maxSize[0];
            numericAutoSizeH.Value = maxSize[1];
            numericAutoSizeW.Enabled = Settings.Default.AutoSize;
            numericAutoSizeH.Enabled = Settings.Default.AutoSize;
            defaultSize = Size;
            initOK = true;
        }

        private void applyDarkTheme()
        {
            BackColor = GlobalSettings.dark[0]; // 暗色背景
            ForeColor = GlobalSettings.dark[1]; // 淺灰色前景
            // 對於每個控制元件，也應用相應的顏色
            Control[] controlList = new Control[] { numericAutoSizeW, numericAutoSizeH, textBoxExePath, textBoxShellMenuItemName, textBoxFileTypes };
            Button[] buttonList = new Button[] { buttonShellMenuItemStatus, buttonShellMenuItemAdd, buttonShellMenuItemRemove };
            ComboBox[] comboBoxList = new ComboBox[] { comboBoxLanguage, comboBoxThemeStyle };
            TextBox[] textBoxList = new TextBox[] { textBoxExePath, textBoxShellMenuItemName, textBoxFileTypes };
            NumericUpDown[] numericUpDownList = new NumericUpDown[] { numericAutoSizeW, numericAutoSizeH };
            foreach (Control c in Controls)
            {
                c.BackColor = GlobalSettings.dark[0];
                c.ForeColor = GlobalSettings.dark[1];
            }
            foreach (Control c in controlList)
            {
                c.BackColor = GlobalSettings.dark[0];
                c.ForeColor = GlobalSettings.dark[1];
            }
            foreach (Button c in buttonList)
            {
                c.BackColor = GlobalSettings.dark[0];
                c.ForeColor = GlobalSettings.dark[1];
                c.FlatStyle = FlatStyle.Flat;
            }
            foreach (ComboBox c in comboBoxList)
            {
                c.FlatStyle = FlatStyle.Flat;
            }
            foreach (TextBox c in textBoxList)
            {
                c.BorderStyle = BorderStyle.FixedSingle;
            }
            foreach (NumericUpDown c in numericUpDownList)
            {
                c.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private void trackBarAutoClose_Scroll(object sender, EventArgs e)
        {
            string splitchar = ": ";
            string timeTitle = groupBoxAutoClose.Text.Split(new string[] { splitchar }, StringSplitOptions.RemoveEmptyEntries)[0];
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
                timeTitle += splitchar + val.ToString() + " " + l.GetString("Seconds");
            }
            groupBoxAutoClose.Text = timeTitle;
            if (val != Settings.Default.AutoClose)
            {
                Settings.Default.AutoClose = val;
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (aniegg != null)
            {
                aniegg.Stop();
            }
            Settings.Default.Save();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.MenuItemName = textBoxShellMenuItemName.Text.Trim();
        }

        private void textBoxFileTypes_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.fileExtensions = textBoxFileTypes.Text.Trim();
        }

        private void buttonShellMenuItemAdd_Click(object sender, EventArgs e)
        {
            string path = textBoxExePath.Text.Trim();
            string name = textBoxShellMenuItemName.Text.Trim();
            string[] fileTypes = textBoxFileTypes.Text.Trim().Split(',');
            List<string> infos = new List<string>();
            for (int i = 0; i < fileTypes.Length; i++)
            {
                string ftype = fileTypes[i];
                if (!ShellMenuItemMgr.AddContextMenu(ftype, path, name))
                {
                    DialogResult result = MessageBox.Show($".{ftype} {l.GetString("FailedAddMenu")}{l.GetString("TryAdmin")}", extName, MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                    if (result == DialogResult.Retry)
                    {
                        i--;
                        continue;
                    }
                    else if (result == DialogResult.Abort)
                    {
                        infos.Add($".{ftype} {l.GetString("AddFail")}");
                        break;
                    }
                    else if (result == DialogResult.Ignore)
                    {
                        infos.Add($".{ftype} {l.GetString("AddFail")}");
                        continue;
                    }
                }
                infos.Add($".{ftype} {l.GetString("AddOK")}");
            }
            MessageBox.Show(string.Join(Environment.NewLine, infos.ToArray()), extName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonShellMenuItemRemove_Click(object sender, EventArgs e)
        {
            string[] fileTypes = textBoxFileTypes.Text.Trim().Split(',');
            List<string> infos = new List<string>();
            for (int i = 0; i < fileTypes.Length; i++)
            {
                string ftype = fileTypes[i];
                if (!ShellMenuItemMgr.RemoveContextMenu(ftype))
                {
                    DialogResult result = MessageBox.Show($".{ftype} {l.GetString("FailedRemoveMenu")}{l.GetString("TryAdmin")}", extName, MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                    if (result == DialogResult.Retry)
                    {
                        i--;
                        continue;
                    }
                    else if (result == DialogResult.Abort)
                    {
                        infos.Add($".{ftype} {l.GetString("RmFail")}");
                        break;
                    }
                    else if (result == DialogResult.Ignore)
                    {
                        infos.Add($".{ftype} {l.GetString("RmFail")}");
                        continue;
                    }
                }
                infos.Add($".{ftype} {l.GetString("RmOK")}");
            }
            MessageBox.Show(string.Join(Environment.NewLine, infos.ToArray()), extName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonShellMenuItemStatus_Click(object sender, EventArgs e)
        {
            string[] fileTypes = textBoxFileTypes.Text.Trim().Split(',');
            List<string> infos = new List<string>();
            for (int i = 0; i < fileTypes.Length; i++)
            {
                string ftype = fileTypes[i];
                if (ShellMenuItemMgr.CheckContextMenuExists(ftype))
                {
                    infos.Add($".{ftype} {l.GetString("ExistsYes")}");
                }
                else
                {
                    infos.Add($".{ftype} {l.GetString("ExistsNo")}");
                }
            }
            MessageBox.Show(string.Join(Environment.NewLine, infos.ToArray()), extName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void checkBoxAutoSize_CheckedChanged(object sender, EventArgs e)
        {
            if (initOK)
            {
                Settings.Default.AutoSize = checkBoxAutoSize.Checked;
            }
            numericAutoSizeW.Enabled = checkBoxAutoSize.Checked;
            numericAutoSizeH.Enabled = checkBoxAutoSize.Checked;
        }

        private void numericAutoSizeW_ValueChanged(object sender, EventArgs e)
        {
            if (initOK)
                Settings.Default.AutoSizeW = numericAutoSizeW.Value;
        }

        private void numericAutoSizeH_ValueChanged(object sender, EventArgs e)
        {
            if (initOK)
                Settings.Default.AutoSizeH = numericAutoSizeH.Value;
        }

        private void comboBoxThemeStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (initOK)
                Settings.Default.ThemeStyle = comboBoxThemeStyle.SelectedIndex;
        }

        private void comboBoxLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (initOK)
            {
                Settings.Default.DefaultLanguage = LanguageMgr.langInfo(comboBoxLanguage.Text);
                Close();
                Application.Restart();
                Environment.Exit(0);
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new ProcessStartInfo()
            {
                FileName = "https://github.com/kagurazakayashi/copy-image",
                UseShellExecute = true
            });
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (aniegg != null)
            {
                aniegg.Tick();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (aniegg == null)
            {
                WindowState = FormWindowState.Normal;
                Size = defaultSize;
                MaximumSize = defaultSize;
                MaximizeBox = false;
                aniegg = new AniEgg(ClientSize.Height, pictureBox1, timer1);
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (aniegg != null)
            {
                aniegg.Down();
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (aniegg != null)
            {
                aniegg.Move();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (aniegg != null)
            {
                aniegg.Up();
            }
        }
    }
}
