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
    /// Логика взаимодействия для Oplata.xaml
    /// </summary>
    public partial class Oplata : Window
    {
        string phone;
        Util util = new Util();
        public Oplata(string phone)
        {
            InitializeComponent();
            this.phone = phone;
        }
        private void BtnBuyT_Click(object sender, RoutedEventArgs e)
        {
            if (!util.CheckEmptyTwo(Name.Text, Card.Text))
            {
                Thanks ent = new Thanks(phone);
                ent.Show();
                this.Close();
            }
            else
                MessageBox.Show("Пустые поля");
        }
    }
}
