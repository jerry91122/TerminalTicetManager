using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleTables;

namespace TerminalTicetManager
{
    public class DrawTabel : KtoryUzytk
    {
        public static void UpTabel()
        {
            Console.Clear();
            System.Console.WriteLine($"App Console Ticet Manger             zalogowany jako:{User.listaUzytkownikow[licznik].Login}");
            System.Console.WriteLine();
            
        }
        public static void DownTabel()
        {
            System.Console.WriteLine("wybierz numer akcji:");

            for (int i = 0; i < User.listaUzytkownikow.Count; i++)
            {
                if (Log == User.listaUzytkownikow[i].Login && User.listaUzytkownikow[i].Role == "Admin")
                {

                    System.Console.WriteLine("1. Nowy || 2. Edytuj ||3. Ustawienia ||4. Wyloguj ||5.Czat ||6. Zakończ Program|| 7. Szukaj || 8.Sortuj");
                    int jakiKlawisz;
                    switch (jakiKlawisz = int.Parse(Console.ReadLine()))
                    {
                        case 1:
                            Ticet.NewTicet();
                            break;
                        case 2:
                            Ticet.editTicet();
                            break;
                        case 3:
                            Settings.Set();
                            break;
                        case 4:
                            WhoLogin.Check();
                            break;
                        case 5:
                            Chat.StartChat();
                            break;
                        case 6:
                            Environment.Exit(0);
                            break;
                        case 7:
                            Ticet.SearchTicet();
                            break;
                        case 8:
                            Sort.SortBy();
                            //sortuj
                            break;
                    }
                }
                else if (Log == User.listaUzytkownikow[i].Login && User.listaUzytkownikow[i].Role == "Standard")
                {
                    System.Console.WriteLine("1. Nowy ||2. Wyloguj ||3.Czat ||4. Zakończ Program");
                    int jakiKlawisz;
                    switch (jakiKlawisz = int.Parse(Console.ReadLine()))
                    {
                        case 1:
                            Ticet.NewTicet();
                            break;
                        case 2:
                            WhoLogin.Check();
                            break;
                        case 3:
                            Chat.StartChat();
                            break;
                        case 4:
                            Environment.Exit(0);
                            break;
                        case 5:
                            Ticet.SearchTicet();
                            break;
                        case 6:
                            //sortuj
                            break;
                    }
                }
                System.Console.WriteLine();
            }
        }
    }
}