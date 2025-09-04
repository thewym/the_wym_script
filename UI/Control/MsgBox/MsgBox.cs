using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace The_wym_script.UI.Control.MsgBox
{
    public partial class MsgBox : UserControl
    {
        public enum MsgBoxResult
        {
            None,
            OK,
            Cancel,
            Yes,
            No
        }

        public enum MsgBoxButton
        {
            OK,
            OKCancel,
            YesNo,
            YesNoCancel
        }

        // 事件用于通知调用者消息框的结果
        public event Action<MsgBoxResult> OnResult;

        // 依赖属性，用于绑定消息和标题
        public static readonly DependencyProperty MessageProperty =
            DependencyProperty.Register("Message", typeof(string), typeof(MsgBox), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(MsgBox), new PropertyMetadata("提示"));

        public string Message
        {
            get { return (string)GetValue(MessageProperty); }
            set { SetValue(MessageProperty, value); }
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public MsgBox()
        {
            InitializeComponent();
            DataContext = this;
        }

        public void SetButtons(MsgBoxButton buttons)
        {
            // 清空现有按钮
            ButtonPanel.Children.Clear();

            // 根据按钮类型添加相应的按钮
            switch (buttons)
            {
                case MsgBoxButton.OK:
                    AddButton("确定", MsgBoxResult.OK);
                    break;
                case MsgBoxButton.OKCancel:
                    AddButton("确定", MsgBoxResult.OK);
                    AddButton("取消", MsgBoxResult.Cancel);
                    break;
                case MsgBoxButton.YesNo:
                    AddButton("是", MsgBoxResult.Yes);
                    AddButton("否", MsgBoxResult.No);
                    break;
                case MsgBoxButton.YesNoCancel:
                    AddButton("是", MsgBoxResult.Yes);
                    AddButton("否", MsgBoxResult.No);
                    AddButton("取消", MsgBoxResult.Cancel);
                    break;
            }
        }

        private void AddButton(string content, MsgBoxResult result)
        {
            var button = new Button
            {
                Content = content,
                Width = 70,
                Height = 28,
                Margin = new Thickness(5, 0, 0, 0),
                Tag = result
            };
            button.Click += Button_Click;
            ButtonPanel.Children.Add(button);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag is MsgBoxResult result)
            {
                OnResult?.Invoke(result);
                // 关闭消息框（实际应用中可能需要从父容器中移除）
                var window = Window.GetWindow(this);
                window?.Close();
            }
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            OnResult?.Invoke(MsgBoxResult.None);
            var window = Window.GetWindow(this);
            window?.Close();
        }

        // 静态方法，方便调用
        public static void Show(string message, string title = "提示", MsgBoxButton buttons = MsgBoxButton.OK)
        {
            Show(message, title, buttons, null);
        }

        public static void Show(string message, string title, MsgBoxButton buttons, Action<MsgBoxResult> resultAction)
        {
            var msgBoxWindow = new Window
            {
                Title = title,
                Width = 300,
                Height = 200,
                WindowStyle = WindowStyle.None, // 无边框窗口
                AllowsTransparency = true,
                Background = Brushes.Transparent,
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };

            var msgBox = new MsgBox
            {
                Message = message,
                Title = title
            };

            msgBox.SetButtons(buttons);
            msgBox.OnResult += result =>
            {
                resultAction?.Invoke(result);
                msgBoxWindow.Close();
            };

            msgBoxWindow.Content = msgBox;
            msgBoxWindow.ShowDialog();
        }
    }
}
