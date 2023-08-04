using TorensVanHanoiDomein;
using Cui;

namespace StartUp
{
    public class StartUp
    {
        public static void Main()
        {
            string antwoord;
            do
            {
                DomeinController dc = new DomeinController();
                TorensVanHanoiApp app = new TorensVanHanoiApp(dc);
                app.Start();

                Console.WriteLine("\nWilt u nog eens spelen?");
                Console.Write("Geef ja in of eender welke toets om te stoppen: ");
                antwoord = Console.ReadLine();
                Console.WriteLine();
            } while (antwoord.ToLower().Trim() == "ja");

            Console.WriteLine("Bedankt voor te spelen, tot de volgende keer!");

        }
    }
}