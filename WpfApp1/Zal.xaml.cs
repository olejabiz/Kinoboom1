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
    /// Логика взаимодействия для Zal.xaml
    /// </summary>
    public partial class Zal : Window
    {
        List<Ticket> masTicket;
        KinoboomEntities1 ef = new KinoboomEntities1();
        string Phone;
        int ShowingId;
        public Zal(string Phone, string Title, string time)
        {
            InitializeComponent();
            ShowingId = retShowingId(Title);
            this.Phone = Phone;
            masTicket = KinoboomEntities1.GetContext().Ticket.Where(r => r.ShowingID == ShowingId).ToList();
            Cost.Text = "0";
            UnvisableButton(ButtonMas);
        }
        private void BtnBuy_Click(object sender, RoutedEventArgs e)
        {
            if (Place.Text != "")
            {
                ef.SaveChanges();
                Oplata ent = new Oplata(Phone);
                ent.Show();
                this.Close();
            }
            else
                MessageBox.Show("Не выбрано место");
        }

        private int findClient(string Phone)
        {
            foreach (var item in ef.Client)
                if (item.TelNum == Phone)
                    return item.ID_Client;
            return -1;
        }

        private void UnvisableButton(WrapPanel ButtonPanel)
        {
            foreach (var item in ButtonPanel.Children)
                if (item is Button)
                    foreach (var item1 in masTicket)
                        if (item1.SeatNum.ToString() == ((Button)item).Content.ToString())
                            ((Button)item).Visibility = Visibility.Hidden;
        }

        private int retShowingId(string Titel)
        {
            foreach (var item1 in ef.Film)
                if (item1.Name == Titel)
                    foreach (var item in ef.ShowingFilm)
                        if (item.FilmID == item1.FilmID)
                            return item.ShowingID;
            return -1;
        }

        private void addTicket(int num)
        {
            if (num != 0)
            {
                Place.Text += num.ToString() + " ";
                Cost.Text = (Convert.ToInt32(Cost.Text) + 200).ToString();
                Ticket ticket = new Ticket(ShowingId, Convert.ToInt32(num), findClient(Phone));
                ef.Ticket.Add(ticket);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            addTicket(Convert.ToInt32(((Button)sender).Content));
            ((Button)sender).Visibility = Visibility.Hidden;
        }
    }
}
