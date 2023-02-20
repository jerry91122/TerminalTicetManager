using System;

namespace TerminalTicetManager
{
    public class Ticet:KtoryUzytk
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string WhoCreated { get; set; }
        public DateTime Created { get; set; }
        public string WhoMake { get; set; }
        public int Status { get; set; }

        public static List<Ticet> nowaLista = new List<Ticet>();

        public Ticet(string Tytul, string Opis)
        {
            Id = nowaLista.Count + 1;
            Title = Tytul;
            Description = Opis;
            Created = DateTime.Now;
            WhoMake = "Nieprzypisane";
            Status = 1;
            WhoCreated=User.listaUzytkownikow[licznik].Login;
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
            Console.Clear();
            System.Console.WriteLine($"App Console Ticet Manger             zalogowany jako:{User.listaUzytkownikow[licznik].Login}");
            System.Console.WriteLine("lista Ticetów");
            System.Console.WriteLine();
            if (nowaLista.Count == 0)
            {
                System.Console.WriteLine("lista jest pusta");
            }
            else
            {
                for (int i = 0; i < nowaLista.Count; i++)
                {
                    System.Console.WriteLine($"{nowaLista[i].Id}  {nowaLista[i].Title}  {nowaLista[i].Description}      {nowaLista[i].WhoMake}  {nowaLista[i].Created}  {nowaLista[i].Status}       {nowaLista[i].WhoCreated}");

                }
                System.Console.WriteLine();
                System.Console.WriteLine($"ilość ticetów: {nowaLista[nowaLista.Count - 1].Id}");
            }
        }
        public static void editTicet()
        {
            int IdToEdit, swichNumber;
            System.Console.Write("podaj Id ticetu do edycji: ");
            IdToEdit = int.Parse(Console.ReadLine());
            System.Console.WriteLine("Edytujesz:");
            System.Console.WriteLine($"{nowaLista[IdToEdit].Id}  {nowaLista[IdToEdit].Title}  {nowaLista[IdToEdit].Description}      {nowaLista[IdToEdit].WhoMake}  {nowaLista[IdToEdit].Created}  {nowaLista[IdToEdit].Status}     ");
            System.Console.WriteLine("jakie pole chcesz edytować? 1. Do kogo przypisane || 2.Status || 3. nic nie rób");
            swichNumber = int.Parse(Console.ReadLine());
            switch (swichNumber)
            {
                case 1:
                App.AppRun();
                    break;
                case 2:
                App.AppRun();
                    break;
                case 3:
                //main menu
                    App.AppRun();
                    break;
            }
        }
    }
}