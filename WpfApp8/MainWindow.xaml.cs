using System;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace WpfApp8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static Timer timer;
        private bool changed = true;
        public MainWindow()
        {
            InitializeComponent();

            timer = new Timer(1000);
            timer.AutoReset = true;
            timer.Start();
            timer.Elapsed += OnTimedEvent;


        }

        private void thisImage_MouseUp(object sender, MouseButtonEventArgs e)
        {
            timer.Stop();
            timer.AutoReset = false;

        }

        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            // Updating the Label which displays the current second


            this.Dispatcher.Invoke(
                    new Action(() =>
                    {
                        if (changed) thisImage.Source = new BitmapImage(new Uri(@"/WpfApp8;component/Images/darknet.png", UriKind.Relative));
                        else thisImage.Source = new BitmapImage(new Uri("./Images/logo.jpg", UriKind.Relative));
                        changed = !changed;
                    }
                    )
                );


        }


    }
}
