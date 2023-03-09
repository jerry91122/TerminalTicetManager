using System;
using ConsoleTables;


namespace TerminalTicetManager
{
    public class Ticet : KtoryUzytk
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string WhoCreated { get; set; }
        public DateTime Created { get; set; }
        public string WhoMake { get; set; }
        public int Status { get; set; }

        public static List<Ticet> nowaLista = new List<Ticet>();

        public Ticet()
        {

        }
        public Ticet(string Tytul, string Opis)
        {
            Id = nowaLista.Count + 1;
            Title = Tytul;
            Description = Opis;
            Created = DateTime.Now;
            WhoMake = "Nieprzypisane";
            Status = 1;
            WhoCreated = User.listaUzytkownikow[licznik].Login;
        }
        public static void NewTicet()
        {
            string NewTicetTitle;
            string NewTicetDescription;
            Console.Clear();
            System.Console.Write("Podaj Tytuł zgłoszenia:");
            NewTicetTitle = Console.ReadLine();
            System.Console.Write("Podaj treść zgłoszenia:");
            NewTicetDescription = Console.ReadLine();
            Ticet newTicet = new Ticet(NewTicetTitle, NewTicetDescription);
            nowaLista.Add(newTicet);
            App.AppRun();

        }
        public static void showList()
        {
            //create new tabel
            DrawTabel.UpTabel();
            System.Console.WriteLine("lista Ticetów");
            var tableTicet = new ConsoleTable("ID", "Tytuł", "Opis", "Do kogo przypisane", "Data Utworzenia", "Status", "Kto zgłosił");
            tableTicet.Options.EnableCount = false;
            if (nowaLista.Count == 0)
            {
                System.Console.WriteLine("lista jest pusta");
            }
            else
            {
                if (User.listaUzytkownikow[licznik].Role == "Admin")
                {
                    foreach (var item in nowaLista)
                    {
                        tableTicet.AddRow(item.Id, item.Title, item.Description, item.WhoMake, item.Created, item.Status, item.WhoCreated);
                    }
                    tableTicet.Write();

                    System.Console.WriteLine($"ilość ticetów: {nowaLista[nowaLista.Count - 1].Id}");
                    DrawTabel.DownTabel();
                }
                else
                {
                    var filter = from c in nowaLista
                                 where c.WhoCreated == User.listaUzytkownikow[licznik].Login
                                 select c;
                    // wypisanie w konsoli wszystkich elementów

                    foreach (var item in filter)
                    {
                        tableTicet.AddRow(item.Id, item.Title, item.Description, item.WhoMake, item.Created, item.Status, item.WhoCreated);
                    }
                    tableTicet.Write();

                    System.Console.WriteLine($"ilość ticetów: {nowaLista[nowaLista.Count - 1].Id}");
                    DrawTabel.DownTabel();
                }
            }
        }
        public static void editTicet()
        {
            int IdToEdit, swichNumber;
            System.Console.Write("podaj Id ticetu do edycji: ");
            IdToEdit = int.Parse(Console.ReadLine()) - 1;
            System.Console.WriteLine("Edytujesz:");
            System.Console.WriteLine($"{nowaLista[IdToEdit].Id}  {nowaLista[IdToEdit].Title}  {nowaLista[IdToEdit].Description}      {nowaLista[IdToEdit].WhoMake}  {nowaLista[IdToEdit].Created}  {nowaLista[IdToEdit].Status}     ");
            System.Console.WriteLine("jak pole chcesz edytować? 1. Do kogo przypisane || 2.Status || 3. nic nie rób");
            swichNumber = int.Parse(Console.ReadLine());
            switch (swichNumber)
            {
                case 1:
                    System.Console.WriteLine("do kogo przypisać");
                    nowaLista[IdToEdit].WhoMake = Console.ReadLine();
                    App.AppRun();
                    break;
                case 2:
                    System.Console.WriteLine("Wprowadz status od 1 do 3");
                    nowaLista[IdToEdit].Status = int.Parse(Console.ReadLine());
                    App.AppRun();
                    break;
                case 3:
                    //main menu
                    App.AppRun();
                    break;
            }
        }
        public static void SearchTicet()
        {
            string SearchWord;
            System.Console.WriteLine("wprowadz szukaną frazę:");
            SearchWord = Console.ReadLine();

            DrawTabel.UpTabel();
            //METODA WYSZUKIWANIA W TABELI ZA POMOCĄ LINQ  <----
            /* var list = from c in nowaLista
                        where c.Description.Contains(SearchWord) || c.Title.Contains(SearchWord)
                        select c;
            */
            //TO SAMO TYLKO ZAPISANE JAKO WYRAŻENIE LAMBDA  <----
            var listTest = nowaLista.Where(c => c.Description.Contains(SearchWord) || c.Title.Contains(SearchWord));
            //narysuj tabelę
            var tableTicet = new ConsoleTable("ID", "Tytuł", "Opis", "Do kogo przypisane", "Data Utworzenia", "Status", "Kto zgłosił");
            tableTicet.Options.EnableCount = false;

            foreach (var item in listTest)
            {
                System.Console.WriteLine(tableTicet.AddRow(item.Id, item.Title, item.Description, item.WhoMake, item.Created, item.Status, item.WhoCreated));
            }
            DrawTabel.DownTabel();
        }
    }
}