using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorensVanHanoiDomein
{
    public class Spel
    {
        private int AantalZetten { get; set; }
        private int AantalSchijven { get; set; }
        private List<Stok> Stokken;
        public Spel(int schijven)
        {
            int leeg = 0;
            AantalZetten = 0;
            AantalSchijven = schijven;
            Stokken = new List<Stok>() {
             new Stok(1, AantalSchijven),
             new Stok(2,leeg),
             new Stok(3,leeg)};
        }
        public void VerplaatsBovensteSchijf(int vanToren, int naarToren)
        {
            if (vanToren == naarToren)
            {
                throw new ArgumentException("Selecteer een andere stok \n");
            }
            else if (vanToren < 0 || vanToren >= Stokken.Count())
            {
                throw new ArgumentException("Gelieve een stok te selecteren binnen de range van de lijst \n");
            }
            else if (naarToren < 0 || naarToren >= Stokken.Count())
            {
                throw new ArgumentException("Gelieve een stok te selecteren binnen de range van de lijst \n");
            }

            var bovensteSchijf = Stokken[vanToren].SchijfVerwijderen();
            try
            {
                Stokken[naarToren].SchijfToevoegen(bovensteSchijf);
                AantalZetten += 1;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                Stokken[vanToren].SchijfToevoegen(bovensteSchijf);
            }
        }
        public List<string> MaakSpel()
        {
            List<string> res = new List<string>(AantalSchijven);
            for (int i = 0; i < AantalSchijven; i++)
            {
                res.Add(string.Empty);
            }
            foreach (var stok in Stokken)
            {
                var lijnen = stok.VisualiseerStok(AantalSchijven);
                for (int j = 0; j < AantalSchijven; j++)
                {
                    res[j] += lijnen[j];
                }
            }
            return res;
        }
        public int GeefAantalZetten()
        {
            return AantalZetten;
        }
        public bool EindeSpel()
        {
            return Stokken.Skip(1).Any(stok => stok.GeefAantalSchijven() == AantalSchijven);
        }

    }

}
