using System.Drawing;

public static class GlobalSettings
{
    // 用來儲存當前是否啟用暗色模式的靜態屬性。可以通過這個屬性來檢查或設定暗色模式是否被啟用。
    public static bool IsDarkModeEnabled { get; set; }

    // 定義一個靜態唯讀陣列，用來儲存暗色模式下使用的兩種顏色。
    // dark[0] 為深背景色，使用 RGB 值為 (18, 18, 18) 的顏色。
    // dark[1] 為亮文字色，使用 RGB 值為 (224, 224, 224) 的顏色。
    public static readonly Color[] dark = new Color[2] { Color.FromArgb(255, 18, 18, 18), Color.FromArgb(255, 224, 224, 224) };
}
