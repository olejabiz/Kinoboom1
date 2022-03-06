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
    /// Логика взаимодействия для Thanks.xaml
    /// </summary>
    public partial class Thanks : Window
    {
        string Phone;
        private static Random random = new Random();
        public Thanks(string Phone)
        {
            InitializeComponent();
            this.Phone = Phone;
            code.Content = RandomString(7);
        }

        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        private void BtnMain_Click(object sender, RoutedEventArgs e)
        {
            Entered ent = new Entered(Phone, false);
            ent.Show();
            this.Close();
        }
    }
}
