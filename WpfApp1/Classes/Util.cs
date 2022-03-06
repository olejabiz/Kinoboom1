using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1.Classes
{
    public class Util
    {
        private string retString(Object Element)
        {
            if (Element is TextBox)
                return ((TextBox)Element).Text;
            else if (Element is PasswordBox)
                return ((PasswordBox)Element).Password;
            return null;
        }

        public bool CheckEmptyMas(Grid one)
        {
            foreach (var item in one.Children)
                if (CheckEmpty(retString(item)))
                    return true;
            return false;
        }

        public bool CheckEmpty(string str)
        {
            if (str != "")
                return false;
            MessageBox.Show("Пустые поля", "Ошибка");
            return true;
        }
        public bool CheckEmptyTwo(string str, string str2)
        {
            if (str != "" && str2 != "")
                return false;
            MessageBox.Show("Пустые поля", "Ошибка");
            return true;
        }
    }
}
