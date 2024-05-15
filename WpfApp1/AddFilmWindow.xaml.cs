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
using WpfApp1.Classes;
using WpfApp1.Properties;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для AddFilmWindow.xaml
    /// </summary>
    public partial class AddFilmWindow : Window
    {
        string phone;
        KinoboomEntities _ef;
        Util util = new Util();
        public AddFilmWindow(string phone, bool admin)
        {
            InitializeComponent();
            _ef = new KinoboomEntities();
            this.phone = phone;
            if (admin)
                DataGridClients.Visibility = Visibility.Visible;
            var clients = KinoboomEntities.GetContext().Client.ToList();
            DataGridClients.ItemsSource = clients;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            AddClWindow ad = new AddClWindow(_ef, this);
            ad.Show();
            this.Close();
        }
        private void BtnEditClient_Click(object sender, RoutedEventArgs e)
        {
            EditClWindow ap = new EditClWindow(_ef, sender, this);
            ap.Show();
            this.Close();
        }

        private void DataGridClients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
