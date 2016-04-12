using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotapanjeBrodova
{
    public class Brod
    {
        public Brod(IEnumerable<Polje> polja)
        {
            this.polja = polja;
        }

        public int Duljina
        {
            get { return polja.Count(); }
        }

        public readonly IEnumerable<Polje> polja;
    }
}
