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
        KinoboomEntities1 ef;
        Util util = new Util();
        AddFilm film1 = new AddFilm();
        public AddFilmWindow()
        {
            InitializeComponent();
            ef = new KinoboomEntities1();
        }

        private void AddFilmBtn_Click(object sender, RoutedEventArgs e)
        {
            film1.addFilm(FilmNameTxt.Text, FilmDescriptionTxt.Text);
        }
    }
}
