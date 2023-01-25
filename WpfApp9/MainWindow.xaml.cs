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

namespace WpfApp9
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

        private void myCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            IList<DateTime> a = (sender as Calendar).SelectedDates.ToList();
            foreach (var item in a)
            {
                Console.WriteLine(item.ToLongDateString());
            }
            Console.WriteLine("**********************");
        }

        private void myPicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((sender as DatePicker).SelectedDate != null)
            {
                MessageBox.Show("你选择的日期是" + (sender as DatePicker).SelectedDate.Value.ToLongDateString());
            }
        }
    }
}
