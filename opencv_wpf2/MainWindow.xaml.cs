using System;
using System.Threading;
using System.Windows;
using OpenCvSharp;
using OpenCvSharp.WpfExtensions;
using MahApps.Metro.Controls;

namespace opencv_wpf2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private Mat src;
        private Thread action;
        public MainWindow()
        {
            InitializeComponent();
            this.src = Cv2.ImRead("aec655d5c73d4167942ad8bc409733d0.png");
            ImageCV.Source = this.src.ToWriteableBitmap();
            

        }

        private void BrightnessBar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            status.Content = new ProgressRing
            {
                Width = 25,
                Height = 25
            };
            //Console.WriteLine(e.NewValue);
            //int val = (int)e.NewValue;
            action = new Thread(ChangeBrightness); // 在子线程运行更新UI（异步）
            action.Start();
            
        }

        private void ChangeBrightness()
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));
            int val = (int)BrightnessBar.Value;
            Mat dst = this.src + new Scalar(val, val, val);
            this.Dispatcher.Invoke(new Action(() =>
            {
                
                ImageCV.Source = dst.ToWriteableBitmap();
                if (val > 0)
                {
                    status.Content = "亮度增强 +" + val.ToString();
                }
                else if (val < 0)
                {
                    status.Content = "亮度减弱 " + val.ToString();
                }
                else
                {
                    status.Content = "原图";
                }
                
            }
            )
                );
        }
    }
}
