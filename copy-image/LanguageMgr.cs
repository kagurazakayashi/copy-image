using copy_image.Properties;
using System.Globalization;
using System.Threading;

namespace copy_image
{
    internal class LanguageMgr
    {
        // 定義一個靜態變數，用以儲存所有支援的語言及其描述
        private static readonly string[,] langData = new string[,]
        {
        { "en-US", "English" }, // 英文
        { "zh-CN", "简体中文" }, // 簡體中文
        { "zh-TW", "繁體中文" }, // 繁體中文
        { "ja-JP", "日本語" }    // 日文
        };

        // 根據輸入的語言代碼或語言描述來查找對應的語言描述或代碼，不區分大小寫
        public static string langInfo(string key)
        {
            string lkey = key.ToLower(); // 將輸入轉為小寫以便比對
            if (lkey == "auto") // 若輸入為"auto"，直接返回
            {
                return lkey;
            }
            for (int i = 0; i < langData.GetLength(0); i++) // 遍歷語言數據
            {
                // 比對語言代碼
                if (langData[i, 0].ToLower() == lkey)
                {
                    return langData[i, 1]; // 返回語言描述
                }
                // 比對語言描述
                else if (langData[i, 1].ToLower() == lkey)
                {
                    return langData[i, 0]; // 返回語言代碼
                }
            }
            // 若未找到匹配，返回預設語言代碼
            return langData[0, 0];
        }

        // 取得語言代碼列表或語言描述列表
        public static string[] langList(int id = 1)
        {
            int numberOfRows = langData.GetLength(0); // 獲取語言數量
            string[] secondElements = new string[numberOfRows]; // 創建一個新的字串陣列來存儲結果
            for (int i = 0; i < numberOfRows; i++)
            {
                secondElements[i] = langData[i, id]; // 根據id參數決定是取代碼還是描述
            }
            return secondElements; // 返回結果陣列
        }

        // 自動設定程式的語言
        public static string[] autoSetLanguage(bool isSet = true, bool enableAuto = false)
        {
            CultureInfo ci = CultureInfo.CurrentCulture; // 獲取當前文化訊息
            string langSys = ci.Name; // 系統語言
            string langSet = Settings.Default.DefaultLanguage; // 使用者設定的語言
            string langUse = langSys; // 預設使用系統語言
            if (langSet.Length > 1 && langSet != "auto")
            {
                langUse = langSet; // 若使用者設定了語言，且不是"auto"，則使用該設定
            }
            string[] lang = langUse.Split('-'); // 分割語言代碼
            bool lang2 = lang.Length > 1; // 判斷是否有地區代碼
            if (lang2)
            {
                lang[1] = lang[1].ToLower(); // 地區代碼轉小寫
            }
            // 根據語言及地區代碼設定語言
            if (lang[0] == "zh")
            {
                if (lang2 && (lang[1] == "hant" || lang[1] == "hk" || lang[1] == "tw" || lang[1] == "mo"))
                {
                    langUse = "zh-TW"; // 繁體中文
                }
                else
                {
                    langUse = "zh-CN"; // 簡體中文
                }
            }
            else if (lang[0] == "ja")
            {
                langUse = "ja-JP"; // 日文
            }
            else if (lang[0] == "en")
            {
                langUse = "en-US"; // 英文
            }
            else
            {
                if (enableAuto)
                {
                    langUse = "auto"; // 若啟用自動，則設為自動
                }
            }
            if (isSet) // 是否設定語言
            {
                ci = new CultureInfo(langUse); // 創建新的文化訊息
                Thread.CurrentThread.CurrentUICulture = ci; // 設定UI文化
                Thread.CurrentThread.CurrentCulture = ci; // 設定文化
            }
            return new string[] { langSys, langSet, langUse }; // 返回系統語言、設定語言和使用語言
        }
    }

}
