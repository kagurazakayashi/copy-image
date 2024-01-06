using Microsoft.Win32;
using System;

namespace copy_image
{
    // 右鍵選單管理
    internal class ShellMenuItemMgr
    {
        // 定義一個靜態字串作為註冊表中的鍵值
        private static string key = "CopyImageToClipboard";

        // 添加右鍵選單的靜態方法
        public static bool AddContextMenu(string extension, string exec, string name)
        {
            // 構造註冊表路徑，用於添加選單項
            string menuKeyPath = $@"Software\Classes\.{extension}\shell\{key}";
            // 構造註冊表路徑，用於添加命令
            string commandKeyPath = $@"Software\Classes\.{extension}\shell\{key}\command";
            try
            {
                // 嘗試創建或打開用於選單項的註冊表鍵
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
                // 嘗試創建或打開用於命令的註冊表鍵
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

        // 移除右鍵選單的靜態方法
        public static bool RemoveContextMenu(string extension)
        {
            // 構造註冊表路徑，用於刪除選單項及其所有相關設定
            string menuKeyPath = $@"Software\Classes\.{extension}\shell\{key}";
            try
            {
                // 嘗試刪除整個註冊表鍵
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

        // 檢查右鍵選單是否存在的靜態方法
        public static bool CheckContextMenuExists(string extension)
        {
            // 構造註冊表路徑，用於檢查選單項是否存在
            string menuKeyPath = $@"Software\Classes\.{extension}\shell\{key}";
            using (RegistryKey menuKey = Registry.CurrentUser.OpenSubKey(menuKeyPath))
            {
                if (menuKey != null)
                {
                    // 若找到註冊表鍵，表示選單項存在
                    Console.WriteLine($"Context menu for *.{extension} files exists.");
                    return true;
                }
                else
                {
                    // 若未找到註冊表鍵，表示選單項不存在
                    Console.WriteLine($"No context menu for *.{extension} files.");
                }
            }
            return false;
        }
    }

}
