using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1.Classes
{
    public class AutorizReg
    {
        KinoboomEntities1 ef = new KinoboomEntities1();

        public bool IsAutoriz(string Phone, string pass)
        {
            if (ef.Client.Where(r => r.TelNum == Phone && r.Password == pass).Count() > 0)
                return true;
            MessageBox.Show("Нет такого пользователя", "Ошибка");
            return false;
        }

        public bool RoleAdminCheck(string Phone)
        {
            if (ef.Client.Where(r => r.TelNum == Phone && r.Role == "Admin").Count() > 0)
                return true;
            return false;
        }

        public bool IsRegistered(string Phone)
        {
            if (ef.Client.Where(r => r.TelNum == Phone).Count() == 0)
                return true;
            MessageBox.Show("Пользователь с таким логином уже есть", "Ошибка");
            return false;
        }
    }
}
