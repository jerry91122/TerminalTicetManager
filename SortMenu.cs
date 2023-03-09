using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TerminalTicetManager
{
    public class SortMenu
    {
        public int wybranuIndeks { get; set; }
        public string[] opcje { get; set; }
        public string tytul { get; set; }


        public SortMenu(string Title, string[] Option)
        {
            wybranuIndeks = 0;
            opcje = Option;
            tytul = Title;
        }
        private void WyświetlOpcje()
        {
            System.Console.WriteLine(tytul);
            for (int i = 0; i < opcje.Length; i++)
            {
                string aktualnaOpcja = opcje[i];
                string prefix;
                if (i == wybranuIndeks)
                {
                    prefix = "*";
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.White;

                }
                else
                {
                    prefix = " ";
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;

                }
                Console.WriteLine($"{prefix}<<{aktualnaOpcja}>>");

            }
            Console.ResetColor();
        }
        public int Run()
        {
            ConsoleKey wciscniecieKlawisza;
            do
            {
                System.Console.Clear();
                WyświetlOpcje();
                ConsoleKeyInfo jakiKlawisz = Console.ReadKey(true);
                wciscniecieKlawisza = jakiKlawisz.Key;

                //update indeks

                if (jakiKlawisz.Key == ConsoleKey.UpArrow)
                {
                    wybranuIndeks--;
                    if (wybranuIndeks < 0)
                    {
                        wybranuIndeks = opcje.Length - 1;
                    }

                }
                else if (jakiKlawisz.Key == ConsoleKey.DownArrow)
                {
                    wybranuIndeks++;
                    if (wybranuIndeks > opcje.Length - 1)
                    {
                        wybranuIndeks = 0;
                    }
                }

            } while (wciscniecieKlawisza != ConsoleKey.Enter);

            return wybranuIndeks;
        }

    }
}
