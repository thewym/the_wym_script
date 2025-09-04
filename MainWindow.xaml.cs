using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using The_wym_script.UI.Views;
using The_wym_script.UI.Views.Settings;
namespace The_wym_script
{
    public partial class MainWindow : Window
    {

        private readonly Dictionary<Type, UserControl> _mainWindowViews = [];


        public MainWindow()
        {
            InitializeComponent();
            MessageBox.Show(
                messageBoxText: "这是自动触发的测试弹窗！\n可以查看主题下的弹窗样式（字体、颜色等）",
                caption: "测试弹窗",
                button: MessageBoxButton.OKCancel, // 显示“确定”和“取消”按钮
                icon: MessageBoxImage.Information // 显示信息图标
            );
        }

        /// <summary>
        /// 切换到指定界面
        /// </summary>
        /// <typeparam name="T">要切换的界面类型，必须是 UserControl 的子类且包含无参构造函数</typeparam>
        public void Switch_Main_View<T>() where T : UserControl, new()
        {
            Type viewType = typeof(T);
            if (!_mainWindowViews.TryGetValue(viewType, out UserControl? viewInstance))
            {
                viewInstance = new T();
                _mainWindowViews.Add(viewType, viewInstance);
            }
            MainContentContainer.Content = viewInstance;
        }


        // 窗口拖动功能
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        // “主界面”按钮点击事件
        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            Switch_Main_View<HomeView>(); // 切换到主界面
        }

        // “设置”按钮点击事件
        private void SettingsButton_Click(object sender, RoutedEventArgs e)
        {
            Switch_Main_View<SettingsView>(); // 切换到设置界面
        }
        // 仅标题栏可拖动
        private void TitleBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        // 窗口控制按钮功能
        private void WindowControlButton_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button?.Tag.ToString() == "Minimize")
            {
                this.WindowState = WindowState.Minimized;
            }
            else if (button?.Tag.ToString() == "Close")
            {
                this.Close();
            }
        }

    }
}