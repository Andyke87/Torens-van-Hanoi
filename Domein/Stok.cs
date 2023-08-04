using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorensVanHanoiDomein
{
    public class Stok
    {
        private int Nummer { get; set; }
        private Schijf Disk { get; set; }

        private List<Schijf> Schijven;

        public Stok(int nummer, int aantalSchijven)
        {
            Schijven = new List<Schijf>();
            Nummer = nummer;


            for (int i = 0; i < aantalSchijven; i++)
            {
                Schijven.Add(new Schijf(i));
            }
        }
        public Schijf SchijfVerwijderen()
        {
            if (Schijven.Count == 0)
            {
                throw new ArgumentException("Er hangen geen schijven rond de stok");
            }
            Disk = Schijven[0];
            Schijven.Remove(Schijven[0]);
            return Disk;
        }
        public void SchijfToevoegen(Schijf s)
        {
            if (Schijven.Count > 0)
            {

                if (s.Diameter > Schijven.First().Diameter)
                {
                    throw new ArgumentException("De schijf is groter dan de bovenste schijf");
                }
                else 
                { 
                    Schijven.Insert(0, s); 
                }
            }
            else
            {
                Schijven.Add(s);
            }

        }
        public int GeefAantalSchijven()
        {
            return Schijven.Count();
        }
        public List<string> VisualiseerStok(int lagen)
        {
            List<string> result = new List<string>();
            foreach (Schijf schijf in Schijven)
            {
                string spaties = lagen - schijf.Diameter > 0 ? string.Concat(Enumerable.Repeat(" ", lagen - schijf.Diameter)) : "";
                string streepjes = string.Concat(Enumerable.Repeat("-", schijf.Diameter));
                result.Add($"{spaties}{streepjes}|{streepjes}{spaties}");
            }
            for (int j = lagen - Schijven.Count; j > 0; j--)
            {
                string spaties = string.Concat(Enumerable.Repeat(" ", lagen));
                result.Insert(0, $"{spaties}|{spaties}");
            }
            return result;
        }
    }

}
