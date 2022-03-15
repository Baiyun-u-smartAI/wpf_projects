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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            StackPanel SP = new StackPanel();///创建stack布局
            this.Content = SP;/// 覆盖当前应用的Content

            ///在stack第一栏添加文字标签helloworld
            TextBlock 自定义Text = new TextBlock();
            自定义Text.Text = "Hello World";
            SP.Children.Add(自定义Text);

            ///在stack第二栏添加文字标签helloworld！
            TextBlock 自定义Text2 = new TextBlock();
            自定义Text2.Inlines.Add(new Run("Hello World!")
            {
                Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0, 0)),// 字体颜色
                TextDecorations = TextDecorations.Underline,// 下划线
                FontStyle = FontStyles.Italic,// 斜体
                FontWeight = FontWeights.Bold,// 加粗
                FontSize = 28,
                FontFamily = new FontFamily("Simsun"),//字体

        });
            SP.Children.Add(自定义Text2);


            /// C#声明对象数组
            ColumnDefinition[] colDef = new ColumnDefinition[2];
            RowDefinition[] rowDef = new RowDefinition[2];
            TextBlock[,] 矩阵数值 = new TextBlock[2,2];
            
            Grid grid = new Grid();/// 创建grid布局

            for (int i = 0; i < 2; i++)
            {
                colDef[i] = new ColumnDefinition();/// 初始化ColumnDefinition
                grid.ColumnDefinitions.Add(colDef[i]);/// 循环使得grid具有两列
            }
            for (int i = 0; i < 2; i++)
            {
                rowDef[i] = new RowDefinition();/// 初始化RowDefinition
                grid.RowDefinitions.Add(rowDef[i]);/// 循环使得grid具有两行
            }

            for (int i = 0; i < 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    矩阵数值[i, j] = new TextBlock();// 初始化TextBlock的二维数组
                    矩阵数值[i, j].Text = (i + 2 * j + 1).ToString();
                    矩阵数值[i, j].FontSize = 28;/// 字体大小28
                    /// 设置textblock的Grid.Column 和Grid.Row属性...
                    Grid.SetColumn(矩阵数值[i, j], i);
                    Grid.SetRow(矩阵数值[i, j], j);
                    Grid.SetColumnSpan(矩阵数值[i, j], 1);
                    Grid.SetRowSpan(矩阵数值[i, j], 1);
                    grid.Children.Add(矩阵数值[i, j]);/// 将textblock应用到当前的grid
                }
            }
            

            SP.Children.Add(grid);// 将grid添加到stack的最后一栏


        }
    }
}
