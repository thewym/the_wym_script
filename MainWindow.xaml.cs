using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace the_wym_script;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    // 配置按钮点击事件处理方法
    private void ConfigButton_Click(object sender, RoutedEventArgs e)
    {
        // 创建并显示配置窗口（假设已创建SettingsWindow）
        var settingsWindow = new SettingsWindow();
        settingsWindow.ShowDialog(); // 模态窗口，确保配置完成后再返回主窗口
    }
}