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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для EditClWindow.xaml
    /// </summary>
    public partial class EditClWindow : Window
    {
        private KinoboomEntities _ef;
        private Client _client;
        private AddFilmWindow _window;
        Util util = new Util();
        public EditClWindow(KinoboomEntities kinoentities, object o, AddFilmWindow afWindow)
        {
            InitializeComponent();
            _client = (o as Button).DataContext as Client;
            this._ef = kinoentities;
            this._window = afWindow;
            TxtTelNum.Text = _client.TelNum;
            TxtPass.Text = _client.Password;
            TxtRole.Text = _client.Role;
        }
        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            _ef.Client.Remove(_client);
            _ef.SaveChanges();
            AddFilmWindow mn = new AddFilmWindow(TxtTelNum.Text, true);
            mn.Show();
            this.Close();
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            _client.TelNum = TxtTelNum.Text;
            _client.Password = TxtPass.Text;
            _client.Role = TxtRole.Text;

            _ef.SaveChanges();
            AddFilmWindow mn = new AddFilmWindow(TxtTelNum.Text, true);
            mn.Show();
            this.Close();
        }
    }
}
