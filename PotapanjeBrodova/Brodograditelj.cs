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
                var pp = IzaberiPočetnoPolje(slobodnaPolja, duljineBrodova[i]);
                var pbr = DajPoljaZaBrod(pp.Item1, pp.Item2, duljineBrodova[i]);

                // napravi brod i dodaj ga u flotu

                // mreži kaži da eliminira polja od i oko broda
            }
            return f;
        }

        public IEnumerable<Polje> DajPoljaZaBrod(Smjer smjer, Polje početno, int duljinaBroda)
        {
            int redak = početno.Redak;
            int stupac = početno.Stupac;
            int deltaRedak = smjer == Smjer.Horizontalno ? 0 : 1;
            int deltaStupac = smjer == Smjer.Vertikalno ? 0 : 1;
            List<Polje> polja = new List<Polje>();
            for (int i = 0; i < duljinaBroda; ++i)
            {
                polja.Add(new Polje(redak, stupac));
                redak += deltaRedak;
                stupac += deltaStupac;
            }
            return polja;
        }

        public Tuple<Smjer, Polje> IzaberiPočetnoPolje(IEnumerable<Polje> slobodnaPolja, int duljinaBroda)
        {
            var horizontalnaPolja = DajHorizontalnaPočetnaPolja(slobodnaPolja, duljinaBroda);
            var vertikalnaPolja = DajVertikalnaPočetnaPolja(slobodnaPolja, duljinaBroda);
            int ukupnoKandidata = horizontalnaPolja.Count() + vertikalnaPolja.Count();
            Random slučajni = new Random();
            int izbor = slučajni.Next(0, ukupnoKandidata);
            if (izbor >= horizontalnaPolja.Count())
                return new Tuple<Smjer, Polje>(Smjer.Vertikalno, vertikalnaPolja.ElementAt(izbor - horizontalnaPolja.Count()));
            return new Tuple<Smjer, Polje>(Smjer.Horizontalno, horizontalnaPolja.ElementAt(izbor));
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
            int redak = p.Redak;
            int stupac = p.Stupac;
            for (int s = stupac + 1; s < stupac + duljinaBroda; ++s)
                if (!slobodnaPolja.Contains(new Polje(redak, s)))
                    return false;
            return true;
        }

        bool ImaDovoljnoPoljaIspod(Polje p, IEnumerable<Polje> slobodnaPolja, int duljinaBroda)
        {
            int redak = p.Redak;
            int stupac = p.Stupac;
            for (int r = redak + 1; r < redak + duljinaBroda; ++r)
                if (!slobodnaPolja.Contains(new Polje(r, stupac)))
                    return false;
            return true;
        }
    }
}
