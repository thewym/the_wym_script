using System.Windows;
using System.Windows.Controls;

namespace The_wym_script.UI.Views.Settings
{
    public partial class SettingsView : UserControl
    {
        public SettingsView()
        {
            InitializeComponent();
        }

        // 保存按钮点击事件
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("设置已保存！");
        }
    }
}