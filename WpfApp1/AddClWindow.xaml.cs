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
    /// Логика взаимодействия для AddClWindow.xaml
    /// </summary>
    public partial class AddClWindow : Window
    {
        private KinoboomEntities _ef;
        private AddFilmWindow _window;
        public AddClWindow(KinoboomEntities kinoentities, AddFilmWindow addfilmWindow)
        {
            InitializeComponent();
            
            this._ef = kinoentities;
            this._window = addfilmWindow;
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            _ef.Client.Add(new Client() { TelNum = TxtTelNum.Text, Password = TxtPass.Text, Role = TxtRole.Text });
            _ef.SaveChanges();
            AddFilmWindow af = new AddFilmWindow(TxtTelNum.Text, true);
            af.Show();
            this.Close();
        }
    }
}
