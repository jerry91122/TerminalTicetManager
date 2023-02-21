using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TerminalTicetManager
{
    public class WhoLogin
    {
    public static int licznik=0;
    public static string  Log, Paswd;
        public static void Check()
        {
           
            Console.Clear();
            
            Console.Write($"Login:");
            Log = Console.ReadLine();
            Console.Write($"Hasło:");
            Paswd =Console.ReadLine();
            licznik=0;

            if (Log == "" && Paswd == "")
            {
                App.AppRun();
            }
            else
            {
                
                for (int i = 0; i < User.listaUzytkownikow.Count; i++)
                {
                    licznik=i;
                    if (Log == User.listaUzytkownikow[i].Login && Paswd == User.listaUzytkownikow[i].Password)
                    {
                        App.AppRun();
                    }
                }
                System.Console.WriteLine("Hasło lub login jest nie prawidłowe");
                Console.ReadKey();
                Check();
            }
        }  
    }
    public class KtoryUzytk : WhoLogin
        {
            public int Licznik()
            {
                return licznik;
            }
        }
}