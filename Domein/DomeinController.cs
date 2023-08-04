namespace TorensVanHanoiDomein
{
    public class DomeinController
    {
        private DateTime StartTijdstip { get; set; }
        private DateTime EindTijdstip { get; set; }
        private TimeSpan Speeltijd { get; set; }
        private int AantalZetten { get; set; }
        private Spel spel;
        public void StartSpel(int aantalSchijven)
        {
            spel = new Spel(aantalSchijven);
            StartTijdstip = DateTime.Now;
        }
        public void VerplaatsBovensteSchijf(int vanStok, int naarStok)
        {
           spel.VerplaatsBovensteSchijf(vanStok, naarStok);
        }
        public List<string> MaakSpel()
        {
            return spel.MaakSpel();
        }
        public bool EindeSpel()
        {
            EindTijdstip = DateTime.Now;
            return spel.EindeSpel();
        }
        public int GeefAantalZetten()
        {
            AantalZetten = spel.GeefAantalZetten();
            return AantalZetten;
        }
        public TimeSpan GeefTotaleSpeeltijd()
        {
            Speeltijd = EindTijdstip - StartTijdstip;
            return Speeltijd;
        }
    }

}