using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotapanjeBrodova
{
    public class Brodograditelj
    {
        public Brodograditelj()
        {
        }

        public Flota SložiFlotu(int redaka, int stupaca, int[] duljineBrodova)
        {
            Flota f = new Flota();
            // napravi mrežu
            Mreža m = new Mreža(redaka, stupaca);
            // za svaku duljinu broda:
            for (int i = 0; i < duljineBrodova.Length; ++i)
            {
                // od mreže zatraži slobodna polja
                var slobodnaPolja = m.DajSlobodnaPolja();
                // izaberi početno polje za brod

                // napravi brod i dodaj ga u flotu

                // mreži kaži da eliminira polja od i oko broda
            }
            return f;
        }

        public IEnumerable<Polje> DajHorizontalnaPočetnaPolja(IEnumerable<Polje> slobodnaPolja, int duljinaBroda)
        {
            List<Polje> polja = new List<Polje>();
            foreach (Polje p in slobodnaPolja)
            {
                if (ImaDovoljnoPoljaDesno(p, slobodnaPolja, duljinaBroda))
                    polja.Add(p);
            }
            return polja;
        }

        public IEnumerable<Polje> DajVertikalnaPočetnaPolja(IEnumerable<Polje> slobodnaPolja, int duljinaBroda)
        {
            List<Polje> polja = new List<Polje>();
            foreach (Polje p in slobodnaPolja)
            {
                if (ImaDovoljnoPoljaIspod(p, slobodnaPolja, duljinaBroda))
                    polja.Add(p);
            }
            return polja;
        }

        bool ImaDovoljnoPoljaDesno(Polje p, IEnumerable<Polje> slobodnaPolja, int duljinaBroda)
        {
            return true;
        }

        bool ImaDovoljnoPoljaIspod(Polje p, IEnumerable<Polje> slobodnaPolja, int duljinaBroda)
        {
            return true;
        }
    }
}
