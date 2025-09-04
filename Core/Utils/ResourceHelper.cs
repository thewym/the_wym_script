using System;
using System.Linq;
using System.Windows;

namespace The_wym_script.Core.Utils
{
    /// <summary>
    /// 资源操作工具类，提供资源字典加载、合并等通用方法
    /// </summary>
    public static class ResourceHelper
    {
        /// <summary>
        /// 将指定路径的资源字典合并到应用全局资源中（自动去重）
        /// </summary>
        /// <param name="sourcePath">资源文件的相对路径（如"Resources/Styles/WindowControlStyles.xaml"）</param>
        /// <returns>是否加载成功</returns>
        public static bool MergeResourceDictionary(string sourcePath)
        {
            // 校验路径合法性
            if (string.IsNullOrWhiteSpace(sourcePath))
            {
                ShowError("资源路径不能为空");
                return false;
            }

            try
            {
                // 创建资源字典并设置路径
                var resourceDict = new ResourceDictionary
                {
                    Source = new Uri(sourcePath, UriKind.Relative)
                };

                // 查找是否已存在相同资源（根据路径判断，避免重复加载）
                var existingDict = Application.Current.Resources.MergedDictionaries
                    .FirstOrDefault(d => d.Source?.OriginalString == sourcePath);

                // 移除旧资源（如果存在）
                if (existingDict != null)
                {
                    Application.Current.Resources.MergedDictionaries.Remove(existingDict);
                }

                // 添加新资源到全局资源
                Application.Current.Resources.MergedDictionaries.Add(resourceDict);
                return true;
            }
            catch (UriFormatException)
            {
                ShowError($"资源路径格式错误：{sourcePath}");
            }
            catch (Exception ex)
            {
                ShowError($"加载资源失败：{sourcePath}\n{ex.Message}");
            }

            return false;
        }

        /// <summary>
        /// 显示资源操作错误信息
        /// </summary>
        private static void ShowError(string message)
        {
            MessageBox.Show(message, "资源加载错误", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
