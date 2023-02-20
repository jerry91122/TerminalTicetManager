using System;

namespace TerminalTicetManager
{
    public class App : WhoLogin
    {
        public static void AppRun()
        {
            Ticet.showList();
            System.Console.WriteLine();
            System.Console.WriteLine("wybierz numer akcji:");

            for (int i = 0; i < User.listaUzytkownikow.Count; i++)
            {
                if (Log == User.listaUzytkownikow[i].Login && User.listaUzytkownikow[i].Role == "Admin")
                {

                    System.Console.WriteLine("1. Nowy || 2. Edytuj ||3. Ustawienia ||4. Wyloguj ||5.Czat ||6. Zakończ Program");
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
                    }
                }
                System.Console.WriteLine();
            }
        }
    }
}
//ToDo
//obsługa plików txt jako baza danych
//ładne tabele ticetów i chatu
//walidacja wpisywania głupot
