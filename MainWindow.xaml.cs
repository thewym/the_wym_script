using System.Windows;
using System.Windows.Controls;
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

            Switch_Main_View<HomeView>(); // 切换到主界面
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








        // // “主界面”按钮点击事件
        // private void HomeButton_Click(object sender, RoutedEventArgs e)
        // {
        //     Switch_Main_View<HomeView>(); // 切换到主界面
        // }

        // // “设置”按钮点击事件
        // private void SettingsButton_Click(object sender, RoutedEventArgs e)
        // {
        //     Switch_Main_View<SettingsView>(); // 切换到设置界面
        // }
    }
}