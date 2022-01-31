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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void TextBlock_GotFocus(object sender, RoutedEventArgs e)
        {
            // System.Diagnostics.Process.Start可以外部启动任何一个能在cmd上运行的指令
            //System.Diagnostics.Process.Start("cmd.exe");

            TextBlock lb1 = (TextBlock)FindName("paragraph");// paragraph有了个别名叫lb1
            stack.Children.Remove(lb1);// 通过stack移除lb1


            // 创建hyperlink的C#代码
            Hyperlink Baidu = new Hyperlink()
            {
                NavigateUri = new System.Uri("http://www.baidu.com"),//设置关联的链接

            };

            Baidu.Inlines.Add("dsahdhdf");// Inlines.Add 相当于在xaml中的 <xxx> </xxx> 标签之中在最后添加内容
            Baidu.RequestNavigate += new RequestNavigateEventHandler(delegate (object sender, RequestNavigateEventArgs e)
            {
                try
                {
                    System.Diagnostics.Process.Start(e.Uri.AbsoluteUri);//启动默认浏览器打开网址
                }
                catch (Exception ex)//失败了
                {
                    Console.WriteLine(ex.Message);//输出原因
                }
            });

            // 创建要在stack里面替换的TextBlock lb2
            TextBlock lb2 = new TextBlock
            {
                Name = "haha",
                Text = "hello go to ",
                FontSize = 20,
                Foreground = new SolidColorBrush(Color.FromRgb(0xff, 0x2f, 0x4a))
            };
            lb2.Inlines.Add(Baidu);//在 <TextBlock>hello go to </TextBlock>的to后面添加Hyperlink Baidu
            stack.Children.Add(lb2);// 将TextBlock lb2添加到stack上面
        }
    }
}
