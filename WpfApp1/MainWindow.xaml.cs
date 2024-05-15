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
using System.Runtime.Remoting;
using RemoteLib;
using System.Runtime.Remoting.Lifetime;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BookStore bookApp;
        private KinoboomEntities _context = new KinoboomEntities();
        public MainWindow()
        {
            InitializeComponent();
            var films = KinoboomEntities.GetContext().Film.ToList();
            ListFilms.ItemsSource = films;
            RemotingConfiguration.Configure("C:\\Users\\Олег\\Desktop\\sa\\BookStore\\ZooPark\\App1.config", false);
            bookApp = new BookStore();
            try
            {
                bookApp.startApp();
                ILease lease = (ILease)bookApp.GetLifetimeService();
                TimeSpan time = new TimeSpan(0, 0, 20);
                lease.Renew(time);
                MessageBox.Show("Сервер работает");
            }
            catch
            {
                MessageBox.Show("Сервер не работает");
            }
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
