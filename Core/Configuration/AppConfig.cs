namespace The_wym_script.Core.Configuration
{
    /// <summary>
    /// 应用程序配置模型，存储用户偏好设置
    /// </summary>
    public class AppConfig
    {
        /// <summary>
        /// 用户选中的主题名称（对应 Themes 目录下的子文件夹名：Light/Dark/Default）
        /// </summary>
        public string SelectedTheme { get; set; } = "Default"; // 默认使用 Default 主题

        /// <summary>
        /// 配置文件版本（用于后续配置结构升级兼容）
        /// </summary>
        public string ConfigVersion { get; set; } = "1.0.0";

        // 未来可扩展其他配置项，例如：
        // public int WindowWidth { get; set; } = 800; // 窗口默认宽度
        // public int WindowHeight { get; set; } = 600; // 窗口默认高度
        // public bool IsAutoStart { get; set; } = false; // 是否开机自启
    }
}
