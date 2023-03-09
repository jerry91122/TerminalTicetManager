using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TerminalTicetManager
{
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public static List<User> listaUzytkownikow = new List<User>();

       
        public User(string login, string haslo, string rola)
        {
            Login = login;
            Password = haslo;
            Role = rola;
        }
        public static void AddUser()
        {
            Console.Clear();

            string log, passwd, rol;

            System.Console.WriteLine("Dodaj nowego użytkownika");
            System.Console.Write("Podaj login: ");
            log = Console.ReadLine();

            System.Console.Write("Podaj hasło: ");
            passwd = Console.ReadLine();

            System.Console.WriteLine("Wybierz role użytkownika");
            System.Console.WriteLine("1. Standard || 2. Admin ");
            int jakiKlawisz;
            jakiKlawisz = int.Parse(Console.ReadLine());
            if (jakiKlawisz == 1)
            {
                rol = "Standard";
            }
            else
            {
                rol = "Admin";
            }
            User newUser = new User(log, passwd, rol);
            listaUzytkownikow.Add(newUser);
            //App.AppRun();//przywrócić jak bd potpieta DB
            WhoLogin.Check();//dopóki nie bd potpięta DB
        }
        public static void EditUser()
        {
            string log;
            System.Console.WriteLine("edycja użytkownika");
            //wpisz login usera
            System.Console.Write("Podaj login do edycji:");
            log = Console.ReadLine();
            for (int i = 0; i < listaUzytkownikow.Count; i++)
            {
                if (log == listaUzytkownikow[i].Login)
                {
                    System.Console.WriteLine("co chcesz zrobić? 1. Zmien hasło || 2. Zmień role || 3.Nic nie rób");
                    int UserjakiKlawisz;
                    switch (UserjakiKlawisz = int.Parse(Console.ReadLine()))
                    {
                        case 1:
                            System.Console.Write("Wprowadz nowe hasło: ");
                            listaUzytkownikow[i].Password = Console.ReadLine();
                            App.AppRun();
                            break;
                        case 2:
                            int zmienRole;
                            System.Console.Write("Zmien role:  ");
                            System.Console.WriteLine("1. Standard || 2. Admin ");
                            zmienRole = int.Parse(Console.ReadLine());
                            if (zmienRole == 1)
                            {
                                listaUzytkownikow[i].Role = "Standard";
                            }
                            else
                            {
                                listaUzytkownikow[i].Role = "Admin";
                            }
                            App.AppRun();
                            break;
                        case 3:
                            App.AppRun();
                            break;
                    }
                }
            }
        }
        public static void DelateUser()
        {
            string log;
            System.Console.WriteLine("edycja użytkownika");
            //wpisz login usera
            System.Console.Write("Podaj login do usuniecia:");
            log = Console.ReadLine();
            for (int i = 0; i < listaUzytkownikow.Count; i++)
            {
                if (log == listaUzytkownikow[i].Login)
                {
                    listaUzytkownikow.Remove(listaUzytkownikow[i]);
                }
                App.AppRun();
            }
        }
        public static void ShowAll()
        {
            for (int i = 0; i <  listaUzytkownikow.Count; i++)
            {
                System.Console.WriteLine(listaUzytkownikow[i].Login);
            }
            System.Console.WriteLine("wcisnij dowolny klawisz");
            Console.ReadKey();
            App.AppRun();
        }
    }
}
