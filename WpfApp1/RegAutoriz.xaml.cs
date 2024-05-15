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
using System.Windows.Shapes;
using WpfApp1.Classes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для RegAutoriz.xaml
    /// </summary>
    public partial class RegAutoriz : Window
    {
        KinoboomEntities ef;
        AutorizReg AutorizReg = new AutorizReg();
        Util util = new Util();
        public RegAutoriz()
        {
            InitializeComponent();
            ef = new KinoboomEntities();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!util.CheckEmptyTwo(AufTelNumTxt.Text, AufPasTxt.Text)
                    && AutorizReg.IsAutoriz(AufTelNumTxt.Text, AufPasTxt.Text))
            {
                if (AutorizReg.RoleAdminCheck(AufTelNumTxt.Text))
                {
                    AddFilmWindow en = new AddFilmWindow(AufTelNumTxt.Text, true);
                    en.Show();
                    this.Close();
                }
                else
                {
                    Entered en = new Entered(AufTelNumTxt.Text, false);
                    en.Show();
                    this.Close();
                }
            }
        }

        private void Reg_Click(object sender, RoutedEventArgs e)
        {
            Client user = new Client();
            if (!util.CheckEmptyTwo(RegTelNum.Text, RegPass.Text) 
                    && AutorizReg.IsRegistered(RegTelNum.Text))
            {
                user.TelNum = RegTelNum.Text.Trim();
                user.Password = RegPass.Text.Trim();
                user.Role = "User";
                ef.Client.Add(user);
                ef.SaveChanges();
                Entered gen = new Entered(RegTelNum.Text, false);
                gen.Show();
                this.Close();
                MessageBox.Show("Вы успешно зарегистрировались!");
            }
        }
    }
}
