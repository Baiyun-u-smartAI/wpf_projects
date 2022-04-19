using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        private Button button_access;
        public MainWindow()
        {
            InitializeComponent();
            StackPanel SP = new StackPanel();///创建stack布局
            this.Content = SP;/// 覆盖当前应用的Content
            Label label = new Label() {
                BorderThickness = new Thickness(1),
                Margin = new Thickness() /// 边界设置
                {
                    Left = 16,
                    Top =16,
                    Right = 16,
                    Bottom =0
                },
                BorderBrush = Brushes.Black,
            };
            StackPanel SP_2 = new StackPanel()
            {
                Orientation = Orientation.Horizontal
            
            };
            label.Content = SP_2;//label标签里面有StackPanel SP_2
            SP_2.Children.Add(new Image()
            {
                Source = new BitmapImage(new Uri("https://pics.freeicons.io/uploads/icons/png/283439861606062169-512.png") ),
                Width = 50.0
            }/// SP_2的第一项里面包含了一张图片
            );

            button_access = new Button()
            {
                Margin = new Thickness()
                {
                    Left = 5,
                    Top = 0,
                    Right = 0,
                    Bottom = 0
                },
            };
            button_access.Content = new AccessText() ///button_access内包含有AccessText
            {
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                FontSize = 35.0,
                Text = "Message (_a)",
                ToolTip = "快捷键Alt+A"
            };
            button_access.Click += (object sender, RoutedEventArgs e) =>
            {
                Console.WriteLine(11);
                
                SP_2.Children.Remove(button_access);

            };
            SP_2.Children.Add(button_access);/// SP_2的第二项包含了带有AccessText的按钮
            SP.Children.Add(label);// 应用布局


        }



        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(11);
            button_access.Click -= Button_Click;

        }
    }
}
