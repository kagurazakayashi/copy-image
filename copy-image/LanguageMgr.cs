using copy_image.Properties;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace copy_image
{
    internal class LanguageMgr
    {
        // 所有支援的語言和描述
        private static readonly string[,] langData = new string[,]
        {
            { "en-US", "English" },
            { "zh-CN", "简体中文" },
            { "zh-TW", "繁體中文" },
            { "ja-JP", "日本語" }
        };

        // 根據語言碼取語言描述 或 根據語言描述取語言碼 不區分大小寫
        public static string langInfo(string key)
        {
            string lkey = key.ToLower();
            if (lkey == "auto")
            {
                return lkey;
            }
            for (int i = 0; i < langData.GetLength(0); i++)
            {
                if (langData[i, 0].ToLower() == lkey)
                {
                    return langData[i, 1];
                }
                else if (langData[i, 1].ToLower() == lkey)
                {
                    return langData[i, 0];
                }
            }
            return langData[0, 0];
        }

        // 取 0語言碼列表 或 1語言描述列表
        public static string[] langList(int id = 1)
        {
            int numberOfRows = langData.GetLength(0);
            string[] secondElements = new string[numberOfRows];
            for (int i = 0; i < numberOfRows; i++)
            {
                secondElements[i] = langData[i, id];
            }
            return secondElements;
        }

        // 自動設定程式語言
        public static string[] autoSetLanguage(bool isSet = true, bool enableAuto = false)
        {
            CultureInfo ci = CultureInfo.CurrentCulture;
            string langSys = ci.Name;
            string langSet = Settings.Default.DefaultLanguage;
            string langUse = langSys;
            if (langSet.Length > 1 && langSet != "auto")
            {
                langUse = langSet;
            }
            string[] lang = langUse.Split('-');
            bool lang2 = lang.Length > 1;
            if (lang2)
            {
                lang[1] = lang[1].ToLower();
            }
            if (lang[0] == "zh")
            {
                if (lang2 && (lang[1] == "hant" || lang[1] == "hk" || lang[1] == "tw" || lang[1] == "mo"))
                {
                    langUse = "zh-TW";
                }
                else
                {
                    langUse = "zh-CN";
                }
            }
            else if (lang[0] == "ja")
            {
                langUse = "ja-JP";
            }
            else if (lang[0] == "en")
            {
                langUse = "en-US";
            }
            else
            {
                if (enableAuto)
                {
                    langUse = "auto";
                }
            }
            if (isSet)
            {
                ci = new CultureInfo(langUse);
                Thread.CurrentThread.CurrentUICulture = ci;
                Thread.CurrentThread.CurrentCulture = ci;
            }
            return new string[] { langSys, langSet, langUse };
        }
    }
}
