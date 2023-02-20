using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TerminalTicetManager
{
    public class Settings
    {
        public static void Set()
        {   
            Console.Clear();
            System.Console.WriteLine("Ustawienia");

            System.Console.WriteLine("wybierz numer akcji:");
            System.Console.WriteLine("1. Nowy Użytkownik|| 2. Edytuj Użytkonika ||3. Usuń Użytkownika ||4. Pokaż Wszystkich ||5. Cofnij");
            int jakiKlawisz;
            switch (jakiKlawisz = int.Parse(Console.ReadLine()))
            {
                case 1:
                    User.AddUser();
                    break;
                case 2:
                    User.EditUser();
                    break;
                case 3:
                User.DelateUser();
                    break;
                case 4:
                    User.ShowAll();
                    
                    break;
                case 5:
                App.AppRun();
                    break;
            }
        }
    }
}