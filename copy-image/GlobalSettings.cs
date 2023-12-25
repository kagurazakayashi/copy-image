using System.Drawing;

public static class GlobalSettings
{
    public static bool IsDarkModeEnabled { get; set; }
    public static Color[] dark = new Color[2] { Color.FromArgb(255, 18, 18, 18), Color.FromArgb(255, 224, 224, 224) };
}
