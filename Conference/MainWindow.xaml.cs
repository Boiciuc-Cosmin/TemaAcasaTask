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
using System.Windows.Threading;
using Conference.ViewModels;

namespace Conference
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DispatcherTimer LiveTime = new DispatcherTimer();
            LiveTime.Interval = TimeSpan.FromSeconds(1);
            LiveTime.Tick += TimerTicks;
            LiveTime.Start();
        }

        private void TimerTicks(object sender, EventArgs e)
        {
            LiveTimeLabel.Content = DateTime.Now.ToString();
        }
        private void Attendees_BtnClicked(object sender, RoutedEventArgs e)
        {
            DataContext = new AttendeesViewModel();
        }

        private void Speakers_BtnClicked(object sender, RoutedEventArgs e)
        {
            DataContext = new SpeakersViewModel();
        }

        private void Talks_Btn_Clicked(object sender, RoutedEventArgs e)
        {
            DataContext = new TalksViewModel();
        }

        private void Workshop_BtnClicked(object sender, RoutedEventArgs e)
        {
            DataContext = new WorkshopViewModel();
        }
    }
}
