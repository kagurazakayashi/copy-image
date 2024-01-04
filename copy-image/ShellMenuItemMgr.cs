using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace copy_image
{
    internal class ShellMenuItemMgr
    {
        private static string key = "CopyImageToClipboard";
        public static bool AddContextMenu(string extension, string exec, string name)
        {
            string menuKeyPath = $@"Software\Classes\.{extension}\shell\{key}";
            string commandKeyPath = $@"Software\Classes\.{extension}\shell\{key}\command";
            try
            {
                using (RegistryKey menuKey = Registry.CurrentUser.CreateSubKey(menuKeyPath))
                {
                    if (menuKey != null)
                    {
                        // 設定選單項名稱
                        menuKey.SetValue("", name);
                        // 設定選單項圖示
                        menuKey.SetValue("Icon", exec);
                        Console.WriteLine($"Menu item for *.{extension} set with name and icon.");
                    }
                    else
                    {
                        Console.WriteLine($"Failed to set menu item for *.{extension}.");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to set menu item for *.{extension} : {ex.Message}");
                return false;
            }
            try
            {
                using (RegistryKey commandKey = Registry.CurrentUser.CreateSubKey(commandKeyPath))
                {
                    if (commandKey != null)
                    {
                        // 設定命令列
                        commandKey.SetValue("", $@"{exec} ""%1""");
                        Console.WriteLine($"Command added for *.{extension} files.");
                    }
                    else
                    {
                        Console.WriteLine($"Failed to add command for *.{extension} files.");
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to add command for *.{extension}: {ex.Message}");
                return false;
            }
        }

        public static bool RemoveContextMenu(string extension)
        {
            // 刪除整個鍵，這將移除選單項及其所有相關設定
            string menuKeyPath = $@"Software\Classes\.{extension}\shell\{key}";
            try
            {
                Registry.CurrentUser.DeleteSubKeyTree(menuKeyPath);
                Console.WriteLine($"Context menu for *.{extension} files removed successfully.");
                return true;
            }
            catch (ArgumentException)
            {
                // 指定的子鍵不存在時會丟擲 ArgumentException
                Console.WriteLine($"Menu item for *.{extension} does not exist.");
            }
            catch (Exception ex)
            {
                // 處理其他可能的異常，例如許可權不足
                Console.WriteLine($"Failed to remove context menu for *.{extension}: {ex.Message}");
            }
            return false;
        }

        public static bool CheckContextMenuExists(string extension)
        {
            string menuKeyPath = $@"Software\Classes\.{extension}\shell\{key}";
            using (RegistryKey menuKey = Registry.CurrentUser.OpenSubKey(menuKeyPath))
            {
                if (menuKey != null)
                {
                    Console.WriteLine($"Context menu for *.{extension} files exists.");
                    return true;
                }
                else
                {
                    Console.WriteLine($"No context menu for *.{extension} files.");
                }
            }
            return false;
        }
    }
}
