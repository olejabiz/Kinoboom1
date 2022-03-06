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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Entered.xaml
    /// </summary>
    public partial class Entered : Window
    {
        string phone;
        public Entered(string phone ,bool admin)
        {
            InitializeComponent();
            this.phone = phone;
            var films = KinoboomEntities1.GetContext().Film.ToList();
            ListFilms.ItemsSource = films;
            if (admin)
                AdminButton.Visibility = Visibility.Visible;
        }
        private void BtnLk_Click(object sender, RoutedEventArgs e)
        {
            Lkab ent = new Lkab();
            ent.Show();
            this.Close();
        }

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow ent = new MainWindow();
            ent.Show();
            this.Close();
        }

        private void BuyTicket_Click(object sender, RoutedEventArgs e)
        {
            Seans ent = new Seans(phone);
            ent.Show();
            this.Close();
        }

        private void AdminButton_Click_1(object sender, RoutedEventArgs e)
        {
            AddFilmWindow addfilmwindow = new AddFilmWindow();
            addfilmwindow.ShowDialog();
            var films = KinoboomEntities1.GetContext().Film.ToList();
            ListFilms.ItemsSource = films;
        }
    }
}
