using TorensVanHanoiDomein;
using TorensVanHanoiDomein;
namespace Cui;

public class TorensVanHanoiApp
{
    private DomeinController _dc;
 
    public TorensVanHanoiApp(DomeinController dc)
    {
        _dc = dc;
    }
    public void Start()
    {
        int aantalSchijven = 0;
        bool invoerOk;
        string antwoordTekst;
        int vanStok;
        int naarStok;
        Console.WriteLine("Welkom tot Torens Van Hanoi!");
        Console.Write("Kent u de Spelregels? ja/nee : ");
        string antwoord = Console.ReadLine();
        if (antwoord.Trim().ToLower() == "nee")
        {
            Console.WriteLine("\nBij het Torens van Hanoi spel moet je een stapel schijven van groot naar klein verplaatsen" +
                "\nDeze schijven moeten vanaf de eerste paal naar de andere laatste paal verplaatst worden. " +
                "\nDe regels zijn eenvoudig:\n\n- Je kan slechts één schijf per keer verplaatsen. " +
                "\n- Een grotere schijf kan nooit bovenop een kleinere schijf worden geplaatst.\n" +
                "\nVeel succes!");
        }
        else Console.WriteLine("Game on!");
        do
        {
            try
            {
                Console.Write("\nMet hoeveel schijven [1-8] wens je te spelen? : ");
                antwoordTekst = Console.ReadLine();
                invoerOk = int.TryParse(antwoordTekst, out aantalSchijven);
                Console.WriteLine();
                if (aantalSchijven >= 1 && aantalSchijven <= 8)
                {
                    continue;
                }
                else
                {
                    throw new Exception();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Het ingegeven getal past niet binnen de range [1-8]");
            }
        } while (aantalSchijven < 1 || aantalSchijven > 8); // aantal schijven ingeven

        _dc.StartSpel(aantalSchijven);
        do
        {
            foreach (string lijn in _dc.MaakSpel())
            {
                Console.WriteLine(lijn);
            }
            Console.WriteLine();
            do
            {
                Console.Write("Van welke stok wil je de bovenste schijf verplaatsen:  ");
                antwoordTekst = Console.ReadLine();
                invoerOk = int.TryParse(antwoordTekst, out vanStok);
            } while (invoerOk == false); // van welke stok
            do
            {
                Console.Write("Naar welke stok wil je de bovenste schijf verplaatsen: ");
                antwoordTekst = Console.ReadLine();
                invoerOk = int.TryParse(antwoordTekst, out naarStok); Console.WriteLine();
            } while (invoerOk == false); // naar welke stok
            try
            {
                _dc.VerplaatsBovensteSchijf(vanStok - 1, naarStok - 1);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            } // verplaatsen van schijf

        } while (!_dc.EindeSpel());
        int teller = _dc.GeefAantalZetten();
        TimeSpan speeltijd = _dc.GeefTotaleSpeeltijd();

        Console.WriteLine($"Gefeliciteerd, je heeft het spel uitgespeeld! Speelduur {speeltijd}");
        Console.WriteLine($"Je hebt voor dit spel {teller} beurten nodig gehad ");
    }
}