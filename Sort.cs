using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConsoleTables;

namespace TerminalTicetManager
{
    public class Sort : Ticet
    {
        public static void SortBy()
        {
            string tytul = "Jak chcesz sortować";
            string[] opcje = { "ID", "Data", "Użytkownik", "Status" };
            SortMenu noweMenu = new SortMenu(tytul, opcje);
            int wybranyIndeks = noweMenu.Run();
            DrawTabel.UpTabel();
            var tableTicet = new ConsoleTable("ID", "Tytuł", "Opis", "Do kogo przypisane", "Data Utworzenia", "Status", "Kto zgłosił");
            tableTicet.Options.EnableCount = false;

            switch (wybranyIndeks)
            {
                case 0://po ID
                    var sortById = from id in nowaLista
                                   orderby id.Id descending
                                   select id;

                    foreach (var item in sortById)
                    {   
                        tableTicet.AddRow(item.Id, item.Title, item.Description, item.WhoMake, item.Created, item.Status, item.WhoCreated);
                    }
                    tableTicet.Write();
                    break;
                case 1:// po dacie

                    var sortByDate = from date in nowaLista
                                     orderby date.Created descending
                                     select date;

                    foreach (var item in sortByDate)
                    {
                       tableTicet.AddRow(item.Id, item.Title, item.Description, item.WhoMake, item.Created, item.Status, item.WhoCreated);
                    }
                    tableTicet.Write();
                    DrawTabel.DownTabel();
                    break;
                case 2://po użytkowniku alfabetycznie
                    var sortByUser = from user in nowaLista
                                     orderby user.WhoCreated descending
                                     select user;

                    foreach (var item in sortByUser)
                    {
                       tableTicet.AddRow(item.Id, item.Title, item.Description, item.WhoMake, item.Created, item.Status, item.WhoCreated);
                    }
                    tableTicet.Write();
                    DrawTabel.DownTabel();
                    break;
                case 3://po statusie 
                    var sortByStatus = from status in nowaLista
                                       orderby status.Status descending
                                       select status;
                    
                
                    foreach (var item in sortByStatus)
                    {
                           tableTicet.AddRow(item.Id, item.Title, item.Description, item.WhoMake, item.Created, item.Status, item.WhoCreated);
                    }
                    tableTicet.Write();
                    DrawTabel.DownTabel();
                    break;
            }
        }
    }
}
