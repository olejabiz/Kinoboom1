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
    /// Логика взаимодействия для Seans.xaml
    /// </summary>
    public partial class Seans : Window
    {
        string Phone;
        public Seans(string Phone)
        {
            InitializeComponent();
            this.Phone = Phone; 
            var films = KinoboomEntities1.GetContext().Film.ToList();
            ListFilms.ItemsSource = films;
        }
        private void John1_Click(object sender, RoutedEventArgs e)
        {
            object tag = ((Button)e.OriginalSource).Tag;
            Zal ent = new Zal(Phone, (string)tag, "12:00");
            ent.Show();
            this.Close();
        }

        private void John2_Click(object sender, RoutedEventArgs e)
        {
            object tag = ((Button)e.OriginalSource).Tag;
            Zal ent = new Zal(Phone, (string)tag, "15:00");
            ent.Show();
            this.Close();
        }

        private void John3_Click(object sender, RoutedEventArgs e)
        {
            object tag = ((Button)e.OriginalSource).Tag;
            Zal ent = new Zal(Phone, (string)tag, "18:00");
            ent.Show();
            this.Close();
        }
    }
}
