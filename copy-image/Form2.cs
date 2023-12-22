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
using System.Reflection;
using Microsoft.Win32;
using System.IO;
using System.Xml.Linq;

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
            textBoxExePath.Text = Assembly.GetExecutingAssembly().Location;
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
            if (val != Settings.Default.AutoClose)
            {
                Settings.Default.AutoClose = val;
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
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
                    DialogResult result = MessageBox.Show("为文件类型 " + ftype + " 添加右键菜单项失败，请尝试以管理员权限运行。", ShellMenuItemMgr.extName, MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                    if (result == DialogResult.Retry)
                    {
                        i--;
                        continue;
                    }
                    else if (result == DialogResult.Abort)
                    {
                        infos.Add($".{ftype} 添加失败");
                        break;
                    }
                    else if (result == DialogResult.Ignore)
                    {
                        infos.Add($".{ftype} 添加失败");
                        continue;
                    }
                }
                infos.Add($".{ftype} 添加成功");
            }
            MessageBox.Show(string.Join(Environment.NewLine, infos), ShellMenuItemMgr.extName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    DialogResult result = MessageBox.Show("为文件类型 " + ftype + " 删除右键菜单项失败，请尝试以管理员权限运行。", ShellMenuItemMgr.extName, MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Error);
                    if (result == DialogResult.Retry)
                    {
                        i--;
                        continue;
                    }
                    else if (result == DialogResult.Abort)
                    {
                        infos.Add($".{ftype} 删除失败");
                        break;
                    }
                    else if (result == DialogResult.Ignore)
                    {
                        infos.Add($".{ftype} 删除失败");
                        continue;
                    }
                }
                infos.Add($".{ftype} 删除成功");
            }
            MessageBox.Show(string.Join(Environment.NewLine, infos), ShellMenuItemMgr.extName, MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    infos.Add($".{ftype} 已存在");
                }
                else
                {
                    infos.Add($".{ftype} 不存在");
                }
            }
            MessageBox.Show(string.Join(Environment.NewLine, infos), ShellMenuItemMgr.extName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void checkBoxAutoSize_CheckedChanged(object sender, EventArgs e)
        {
            Settings.Default.AutoSize = checkBoxAutoSize.Checked;
            numericAutoSizeW.Enabled = checkBoxAutoSize.Checked;
            numericAutoSizeH.Enabled = checkBoxAutoSize.Checked;
        }

        private void numericAutoSizeW_ValueChanged(object sender, EventArgs e)
        {
            Settings.Default.AutoSizeW = numericAutoSizeW.Value;
        }

        private void numericAutoSizeH_ValueChanged(object sender, EventArgs e)
        {
            Settings.Default.AutoSizeH = numericAutoSizeH.Value;
        }
    }
}
