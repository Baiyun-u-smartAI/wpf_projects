using System;

using System.Windows;
using System.Windows.Controls;


namespace WpfApp6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string others_typing = "type anything"; // 全局保存输入框的历史记录
        public MainWindow()
        {
            InitializeComponent();

            Button button = new Button();
            button.Content = "To Lock Y2 input";
            //替换YYY4的RadioButton选项内容为按钮clicked me!
            RadioButton 选项4 = (RadioButton)YYY4;
            button.Click += Button4_Click;
            选项4.Content = button;
            YYY2.Content = "other";// 把选项2内容改为other
        }

        // 锁定Y2的输入
        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            var input = YYY2.Content as TextBox; // 如果Y2未显示输入框，则为null
            if (!(input is null))
            {
                input.IsReadOnly = !input.IsReadOnly;
            }   

        }

        //todo 改函数由八个RadioButton触发
        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            RadioButton rec = (RadioButton)sender;// 也可以写成 RadioButton rec = sender as RadioButton;
            
            switch (rec.Name)// 判断是哪个按钮触发的)，也可以写成(sender as RadioButton).Name
            {
                case "XXX1": Console.WriteLine("XXX LEVEL:A");break;
                case "XXX2": Console.WriteLine("XXX LEVEL:B");break;
                case "XXX3": Console.WriteLine("XXX LEVEL:C");break;
                case "XXX4": Console.WriteLine("XXX LEVEL:D");break;
                case "YYY1": 
                    Console.WriteLine("YYY LEVEL:A"); 
                    Logo1.Visibility = Visibility.Visible; // todo xaml布局隐藏了一个图标Logo1，这里被激活
                    this.YYY2_LostFocus(YYY2, new RoutedEventArgs());  // todo 使选项2收起输入框
                    break;
                case "YYY2": 
                    Console.WriteLine("YYY LEVEL:B"); 
                    Logo1.Visibility = Visibility.Collapsed; // todo 隐藏了图标Logo1
                    break;
                case "YYY3": Console.WriteLine("YYY LEVEL:C"); Logo1.Visibility = Visibility.Collapsed; this.YYY2_LostFocus(YYY2, new RoutedEventArgs()); break;
                case "YYY4": 
                    Logo1.Visibility = Visibility.Collapsed; 
                    this.YYY2_LostFocus(YYY2, new RoutedEventArgs()); 
                    if ((bool)rec.IsChecked) 
                        Console.WriteLine("YYY LEVEL:D"); // 这里防止点击按钮，但没有选择该选项就输出
                    break;
                default:
                    break;
            }
            if (rec.GroupName=="YYY")
            {
                if (rec.Tag != null && rec.Tag.ToString() == "Y2")
                {
                    if ((bool)rec.IsChecked)
                        Console.WriteLine("2 has been selected");
                }
            }

            
        }


        // 当YYY2选项被点击或者焦点转移，other选项就变成输入框input
        private void YYY2_GotFocus(object sender, RoutedEventArgs e)
        {
            RadioButton y2 = sender as RadioButton;
            Console.WriteLine("YYY2 has been focused");
            if (y2.Content.ToString() == "other") // 只有当前选项是other时才创建输入框input
            {
                TextBox input = new TextBox
                {
                    FontSize = 30.0,
                    TextAlignment = TextAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Text = this.others_typing,
                    IsReadOnly = false // 允许修改
                };
                input.TextChanged += this.inputOnTextChanged;
                y2.Content = input;
            }

        }

        private void inputOnTextChanged(object sender, TextChangedEventArgs e)
        {
            this.others_typing = (sender as TextBox).Text; // 实时修改更新属性：others_typing
        }

        // 失去焦点事件，收起输入框
        private void YYY2_LostFocus(object sender, RoutedEventArgs e)
        {
            RadioButton y2 = sender as RadioButton;
            // y2.IsChecked判断是为了防止点击按钮时会收起输入框
            // y2.Content.ToString() != "other" 是为了判断当前输入框是否以及被收起
            if (y2.Content.ToString() != "other" && !(bool)y2.IsChecked) 
            {
                Console.WriteLine("YYY2 has been out of focused");

                y2.Content = "other";// 收起输入框后选项只剩下other
            }
            
        }
    }
}
