using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleTables;


namespace TerminalTicetManager
{
    public class Chat : KtoryUzytk
    {
        public static int IDChat;
        public string Text { get; set; }
        public DateTime Created { get; set; }
        public string Name { get; set; }
        public int IdTicet { get; set; }

        public static List<Chat> nowyCzat = new List<Chat>();
        public Chat(string text)
        {
            Text = text;
            Created = DateTime.Now;
            Name = User.listaUzytkownikow[licznik].Login;
         
            IdTicet = IDChat;
        }
        //show Chat with filter who login
        public static void ShowChat()
        {
            
            var tableChat = new ConsoleTable("Wiadomość", "Kto napisał", "Czas");
            tableChat.Options.EnableCount = false;
            for (int i = 0; i < nowyCzat.Count; i++)
            {
                if (nowyCzat[i].IdTicet == IDChat)
                {
                    System.Console.WriteLine(tableChat.AddRow(nowyCzat[i].Text,nowyCzat[i].Name,nowyCzat[i].Created));
                }
            }
            SendChat();
        }
        public static void SendChat()
        {
            
            System.Console.WriteLine("co chcesz zrobić?");
            System.Console.WriteLine("Enter - nowa wiadomość || ESC - Cofnij");
            switch (Console.ReadKey().Key)
            {
                case ConsoleKey.Escape:
                    App.AppRun();
                    break;
                case ConsoleKey.Enter:
                    System.Console.WriteLine("Wpisz swoją wiadomość");
                    string nowaWiadomosc;
                    nowaWiadomosc = Console.ReadLine();
                    Chat wiadomosc = new Chat(nowaWiadomosc);
                    nowyCzat.Add(wiadomosc);
                    Console.Clear();
                    break;
            }
            ShowChat();
            System.Console.WriteLine();
        }
        public static void StartChat()
        {
            System.Console.WriteLine("Chat");
            System.Console.Write("Wprowadz ID zgłoszenia");
            IDChat = int.Parse(Console.ReadLine()) - 1;
            SendChat();
        }
    }
}