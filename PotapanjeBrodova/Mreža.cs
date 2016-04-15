using System.Collections.Generic;

namespace PotapanjeBrodova
{
    public enum Smjer
    {
        Horizontalno,
        Vertikalno
    }

    public class Mreža
    {
        public Mreža(int redaka, int stupaca)
        {
            Redaka = redaka;
            Stupaca = stupaca;
            polja = new Polje[Redaka, Stupaca];
            for (int r = 0; r < redaka; ++r)
            {
                for (int s = 0; s < stupaca; ++s)
                    polja[r, s] = new Polje(r, s);
            }
        }

        public IEnumerable<Polje> DajSlobodnaPolja()
        {
            // umjesto donje dvije petlje može i kraće (ali puno sporije):
            //return polja.Cast<Polje>().Where(polje => polje != null).ToList();
            List<Polje> slobodnaPolja = new List<Polje>();
            for (int r = 0; r < Redaka; ++r)
            {
                for (int s = 0; s < Stupaca; ++s)
                {
                    if (polja[r, s] != null)
                        slobodnaPolja.Add(polja[r, s]);
                }
            }
            return slobodnaPolja;
        }

        public void EliminirajPolje(Polje p)
        {
            polja[p.Redak, p.Stupac] = null;
        }

        public void EliminirajPolje(int redak, int stupac)
        {
            polja[redak, stupac] = null;
        }

        public IEnumerable<Polje> DajPoljaZaBrod(Smjer smjer, Polje početno, int duljinaBroda)
        {
            int redak = početno.Redak;
            int stupac = početno.Stupac;
            int deltaRedak = smjer == Smjer.Horizontalno ? 0 : 1;
            int deltaStupac = smjer == Smjer.Vertikalno ? 0 : 1;
            List<Polje> poljaZaBrod = new List<Polje>();
            for (int i = 0; i < duljinaBroda; ++i)
            {
                poljaZaBrod.Add(polja[redak, stupac]);
                EliminirajPolje(redak, stupac);
                redak += deltaRedak;
                stupac += deltaStupac;
            }
            return poljaZaBrod;
        }

        private Polje[,] polja;
        public readonly int Redaka;
        public readonly int Stupaca;
    }
}
