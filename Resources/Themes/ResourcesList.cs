namespace The_wym_script.Resources.Themes
{
    public static class ThemesResourcesList
    {
        public static readonly List<string> RequiredColorKeys =
        [
            "Window.Background",       // 窗口背景色
            "Window.Foreground",       // 窗口文字色
            "TitleBar.Background",     // 标题栏背景色
            "Button.Primary.Background", // 主按钮背景色
            "Button.Primary.Foreground"  // 主按钮文字色
        ];
        public static List<string> GetAllRequiredKeys()
        {
            var allKeys = new List<string>();
            allKeys.AddRange(RequiredColorKeys);
            // allKeys.AddRange(RequiredStyleKeys);
            // allKeys.AddRange(RequiredTemplateKeys);
            return allKeys;
        }


    }
}