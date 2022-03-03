using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            
            // ((Grid)hello.Parent).Children.Remove(hello);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // 直接找出控件然后删除
            
            (hello.Parent as Grid).Children.Remove(hello);
            NameScope.GetNameScope(this).UnregisterName("hello");// 注销名字 
            hello = null;
            UpdateLayout();
            Grid.SetRow(button, 0);
            button.Click -= Button_Click;
            ((Button)sender).FontSize = 10;

        }

        /*鼠标靠近时显示密码*/
        private void LicencePasswordBox_MouseEnter(object sender, MouseEventArgs e)
        {
            LicencePasswordBox.Visibility = Visibility.Hidden;//隐藏密码框
            LicencePasswordTextBox.Visibility = Visibility.Visible;//显示文字框
            LicencePasswordTextBox.SelectAll();
            LicencePasswordTextBox.Focus();
        }

        private void LicencePasswordBox_MouseLeave(object sender, MouseEventArgs e)
        {
            LicencePasswordBox.Visibility = Visibility.Visible;//隐藏文字框
            LicencePasswordTextBox.Visibility = Visibility.Hidden;//显示密码框
            LicencePasswordBox.Password = LicencePasswordTextBox.Text;
            Console.WriteLine(LicencePasswordBox.Password);
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);// 输入内容必须匹配正则表达式regex
        }


    }
}
