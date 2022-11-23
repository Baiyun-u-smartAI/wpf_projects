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

namespace WpfApp7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private CheckBox[] 选项;// 整个窗体对象的公共属性
        public MainWindow()
        {
            InitializeComponent();
            // 创建第一个按钮 全选
            CheckBox 全选 = new CheckBox()
            {
                Content = "全选",
                IsChecked = null,
                IsThreeState = true,
                FontSize = 28,
                VerticalContentAlignment = VerticalAlignment.Center
            };
            选项 = new CheckBox[2]; // 创建两个按钮的数组

            选项[0] = new CheckBox()
            {
                Content = "选项A",
                Margin = new Thickness(15, 5, 0, 0),
                FontSize = 28,
                VerticalContentAlignment = VerticalAlignment.Center
            };
            选项[1] = new CheckBox()
            {
                Content = "选项B",
                Margin = new Thickness(15, 5, 0, 0),
                FontSize = 28,
                VerticalContentAlignment = VerticalAlignment.Center
            };
            // thisStack是xaml文件里面的标签
            thisStack.Children.Add(全选);
            thisStack.Children.Add(选项[0]);
            thisStack.Children.Add(选项[1]);
            //thisStack.Children.RemoveAt(1);
            选项[0].Click += 选项_Click; // 响应函数
            选项[1].Click += 选项_Click;
            全选.Click += 全选_Click;

            // 确认按钮
            Button Comfirmed = new Button
            {
                Content="确认",
                HorizontalContentAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(15, 0, 15, 0),
                FontSize = 28
            };

            thisStack.Children.Add(Comfirmed);
            Comfirmed.Click += Comfirmed_Click;
        }

        private void Comfirmed_Click(object sender, RoutedEventArgs e)
        {
            bool c1 = false, c2 = false;
            if (thisStack.Children.IndexOf(选项[0]) != -1 && thisStack.Children.IndexOf(选项[1]) != -1)
            {

                c1 = (bool)(thisStack.Children[1] as CheckBox)/*选项A*/.IsChecked;
                c2 = (bool)(thisStack.Children[2] as CheckBox)/*选项B*/.IsChecked;
            }
            Console.WriteLine("选项A:{0}, 选项B:{1}", c1, c2);// 输出选项结果
        }

        private void 全选_Click(object sender, RoutedEventArgs e)
        {
            if ((thisStack.Children[0] as CheckBox).IsChecked == true)
            {
                // todo 如果缺乏选项[0]和[1]就插入到thisStack中
                if (thisStack.Children.IndexOf(选项[0]) == -1 && thisStack.Children.IndexOf(选项[1]) == -1)
                {
                    thisStack.Children.Insert(1, 选项[0]);
                    thisStack.Children.Insert(2, 选项[1]);
                }
                
                (thisStack.Children[1] as CheckBox).IsChecked/*选项A*/ = true;
                (thisStack.Children[2] as CheckBox).IsChecked/*选项B*/ = true;
            }
            else if ((thisStack.Children[0] as CheckBox).IsChecked == null)
            {
                //todo 阻止用户选择时出现中间选项
                (thisStack.Children[0] as CheckBox).IsChecked = false;

                //todo 隐藏选项
                (thisStack.Children[1] as CheckBox).IsChecked/*选项A*/ = false;
                (thisStack.Children[2] as CheckBox).IsChecked/*选项B*/ = false;
                thisStack.Children.RemoveAt(1);
                thisStack.Children.RemoveAt(1);
            }
            else
            {
                //todo 如果全选的勾被人为剔除掉，就隐藏选项
                (thisStack.Children[1] as CheckBox).IsChecked/*选项A*/ = false;
                (thisStack.Children[2] as CheckBox).IsChecked/*选项B*/ = false;
                
                thisStack.Children.RemoveAt(1);
                thisStack.Children.RemoveAt(1);
            }
        }

        private void 选项_Click(object sender, RoutedEventArgs e)
        {
            bool c1 = (bool)(thisStack.Children[1] as CheckBox).IsChecked;
            bool c2 = (bool)(thisStack.Children[2] as CheckBox).IsChecked;
            if (c1 == true && c2 == true)
            {
                (thisStack.Children[0] as CheckBox).IsChecked = true;
            }
            else if (c1 == false && c2 == false)
            {
                (thisStack.Children[0] as CheckBox).IsChecked = false;
            }
            else
            {
                (thisStack.Children[0] as CheckBox).IsChecked = null;
            }

        }


    }
}
