using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotapanjeBrodova
{
    public class Mreža
    {
        public Mreža(int redaka, int stupaca)
        {
            this.redaka = redaka;
            this.stupaca = stupaca;
            polja = new Polje[redaka, stupaca];
            for (int r = 0; r < redaka; ++r)
            {
                for (int s = 0; s < stupaca; ++s)
                    polja[r, s] = new Polje(r, s);
            }
        }

        public List<Polje> DajSlobodnaPolja()
        {
            List<Polje> slobodnaPolja = new List<Polje>();
            for (int r = 0; r < redaka; ++r)
            {
                for (int s = 0; s < stupaca; ++s)
                {
                    if (polja[r, s] != null)
                        slobodnaPolja.Add(polja[r, s]);
                }
            }
            return slobodnaPolja;
        }

        public void EliminirajPolje(int redak, int stupac)
        {
            polja[redak, stupac] = null;
        }

        private Polje[,] polja;
        private int redaka;
        private int stupaca;
    }
}
