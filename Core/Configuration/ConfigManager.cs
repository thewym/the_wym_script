using System;
using System.IO;
using System.Text.Json;
using System.Windows;

namespace The_wym_script.Core.Configuration
{
    /// <summary>
    /// JSON配置管理器，负责保存、读取和删除应用配置
    /// </summary>
    public static class ConfigManager
    {
        /// <summary>
        /// 配置文件保存路径：%AppData%\the_wym_script\config.json
        /// </summary>
        private static string ConfigPath => Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "The_wym_script", // 与项目名称一致，避免配置文件冲突
            "config.json"
        );

        /// <summary>
        /// 保存配置到JSON文件
        /// </summary>
        /// <param name="config">要保存的配置对象</param>
        public static void SaveConfig(AppConfig config)
        {
            try
            {
                // 确保目录存在（首次运行时创建）
                string configDirectory = Path.GetDirectoryName(ConfigPath);
                if (!Directory.Exists(configDirectory))
                {
                    Directory.CreateDirectory(configDirectory);
                }

                // 序列化配置为格式化的JSON（便于人工编辑）
                string json = JsonSerializer.Serialize(config, new JsonSerializerOptions
                {
                    WriteIndented = true, // 格式化输出（换行+缩进）
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                });

                // 写入文件
                File.WriteAllText(ConfigPath, json);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"保存配置失败：{ex.Message}", "配置错误", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// 从JSON文件读取配置
        /// </summary>
        /// <returns>读取到的配置（文件不存在时返回默认配置）</returns>
        public static AppConfig LoadConfig()
        {
            try
            {
                if (File.Exists(ConfigPath))
                {
                    // 读取文件内容并反序列化为AppConfig对象
                    string json = File.ReadAllText(ConfigPath);
                    return JsonSerializer.Deserialize<AppConfig>(json) ?? new AppConfig();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"读取配置失败，将使用默认设置：{ex.Message}", "配置错误", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

            // 文件不存在或解析失败时，返回默认配置
            return new AppConfig();
        }

        /// <summary>
        /// 删除配置文件（用于重置设置）
        /// </summary>
        /// <param name="errorMessage">删除失败时的错误信息</param>
        /// <returns>是否删除成功</returns>
        public static bool DeleteConfig(out string errorMessage)
        {
            errorMessage = string.Empty;
            try
            {
                if (File.Exists(ConfigPath))
                {
                    File.Delete(ConfigPath);
                    return true;
                }
                errorMessage = "配置文件不存在，无需删除";
                return false;
            }
            catch (Exception ex)
            {
                errorMessage = $"删除失败：{ex.Message}";
                return false;
            }
        }
    }
}
