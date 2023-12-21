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
            textBoxExePath.Text = Assembly.GetExecutingAssembly().Location;
            if (Settings.Default.shellitemname.Length > 0)
            {
                textBoxShellMenuItemName.Text = Settings.Default.shellitemname;
            }
            if (Settings.Default.fileTypes.Length > 0)
            {
                textBoxFileTypes.Text = Settings.Default.fileTypes;
            }
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.shellitemname = textBoxShellMenuItemName.Text.Trim();
        }

        private void textBoxFileTypes_TextChanged(object sender, EventArgs e)
        {
            Settings.Default.fileTypes = textBoxFileTypes.Text.Trim();
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
    }
}
