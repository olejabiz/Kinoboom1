using System;
using WpfApp1.Properties;
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
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private KinoboomEntities1 _context = new KinoboomEntities1();
        public MainWindow()
        {
            InitializeComponent();
            var films = KinoboomEntities1.GetContext().Film.ToList();
            ListFilms.ItemsSource = films;
        }

        private void BtnEnter_Click(object sender, RoutedEventArgs e)
        {
            RegAutoriz ent = new RegAutoriz();
            ent.Show();
            this.Close();
        }

        private void BuyTicket_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Войдите в аккаунт или зарегистрируйтесь для покупки билета!");
        }
    }
}
