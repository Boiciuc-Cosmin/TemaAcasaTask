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
using ConferenceLibrary;
using Conference.ViewModels;
using Microsoft.Win32;

namespace Conference.Views
{
    /// <summary>
    /// Interaction logic for Attendees.xaml
    /// </summary>
    public partial class AttendeesView : UserControl
    {
        public AttendeesView()
        {
            InitializeComponent();

            var attendees = new Attendees();
            
            List<Person> people = new List<Person>()
            { 
             new Person {FirstName="Cosma", LastName = "Boiciuc", Id = "#12", HasPaid = true, PayedNumber = 2451},
             new Person {FirstName="Mihai", LastName = "Cineva", Id = "#13", HasPaid = true, PayedNumber = 1234}
            };           

            List_View.ItemsSource = people;
        }

        
        private void IdTextBox_Enter(object sender, MouseEventArgs e)
        {
            if (IdTextBox.Text == "Enter ID")
            {
                IdTextBox.Text = "";
                IdTextBox.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void IdTextBox_Leave(object sender, MouseEventArgs e)
        {
            if (IdTextBox.Text == "")
            {
                IdTextBox.Text = "Enter ID";
                IdTextBox.Foreground = new SolidColorBrush(Colors.Silver);
            }
        }

        private void AddFromFile_Clicked(object sender, RoutedEventArgs e)
        {
            Attendees attendees = new Attendees();
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "CSV files (*.csv)|*.csv| All files(*.*)|*.*";
            openFileDialog.InitialDirectory = @"D:\projects\ConferenceSolution\ConferenceProgram\bin\Debug\netcoreapp3.1\Data";
            //openFileDialog.ShowDialog();
            MessageBox.Show(openFileDialog.FileName.ToString());
            if (openFileDialog.ShowDialog() == true)
            {
                attendees.ReadFromFile(openFileDialog.FileName);
                MessageBox.Show("file succesfully");
            }


        }
    }
}
