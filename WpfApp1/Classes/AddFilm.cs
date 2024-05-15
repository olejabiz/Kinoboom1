using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1.Classes
{
    public class AddFilm
    {
        KinoboomEntities ef = new KinoboomEntities();
        Util util = new Util();
        public bool IsAdded(string Title)
        {
            if (ef.Film.Where(r => r.Name == Title).Count() == 0)
                return true;
            MessageBox.Show("Такой фильм уже есть", "Ошибка");
            return false;
        }

        public void addFilm(string Title, string Description)
        {
            if (!util.CheckEmptyTwo(Title, Description) && IsAdded(Title))
            {
                Film film = new Film(Title, Description);
                ef.Film.Add(film);
                ef.SaveChanges();
                addShowing(Title);
                MessageBox.Show("Фильм успешно добавлен!");
            }
        }

        private void addShowing(string Title)
        {
            ShowingFilm sf;
            foreach (var item in ef.Film)
            {
                if (item.Name == Title)
                {
                    sf = new ShowingFilm(item.FilmID, "200");
                    ef.ShowingFilm.Add(sf);
                    break;
                }
            }
            ef.SaveChanges();
        }
    }
}
