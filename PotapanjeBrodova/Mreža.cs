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
            Redaka = redaka;
            Stupaca = stupaca;
            for (int r = 0; r < redaka; ++r)
            {
                for (int s = 0; s < stupaca; ++s)
                    polja.Add(new Polje(r, s));
            }
        }

        public IEnumerable<Polje> DajSlobodnaPolja()
        {
            return polja;
        }

        public void EliminirajPolje(Polje p)
        {
            polja.Remove(p);
        }

        private List<Polje> polja = new List<Polje>();
        public readonly int Redaka;
        public readonly int Stupaca;
    }
}
