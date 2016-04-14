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
            eliminatorPolja = new KlasičniEliminatorPolja();
        }

        public Brodograditelj(IEliminatorPolja eliminator)
        {
            eliminatorPolja = eliminator;
        }

        public Flota SložiFlotu(int redaka, int stupaca, int[] duljineBrodova)
        {
            const int brojPokušaja = 5;
            for (int i = 0; i < brojPokušaja; ++i)
            {
                try
                {
                    Mreža mreža = new Mreža(redaka, stupaca);
                    return SložiBrodove(duljineBrodova, mreža);
                }
                catch (ApplicationException) { }
            }
            // ako ne uspije složiti niti nakon 5 pokušaja, baca iznimku
            throw new ApplicationException();
        }

        private Flota SložiBrodove(int[] duljineBrodova, Mreža mreža)
        {
            Flota flota = new Flota();
            // za svaku duljinu broda:
            for (int i = 0; i < duljineBrodova.Length; ++i)
            {
                var slobodnaPolja = mreža.DajSlobodnaPolja();
                var pp = IzaberiPočetnoPolje(slobodnaPolja, duljineBrodova[i]);
                var pbr = mreža.DajPoljaZaBrod(pp.Smjer, pp.Polje, duljineBrodova[i]);
                Brod b = new Brod(pbr);
                flota.DodajBrod(b);
                EliminirajPoljaOkoBroda(mreža, pbr);
            }
            return flota;
        }

        private void EliminirajPoljaOkoBroda(Mreža mreža, IEnumerable<Polje> brodskaPolja)
        {
            IEnumerable<Polje> zaEliminirati = eliminatorPolja.PoljaKojaTrebaUklonitiOkoBroda(brodskaPolja, mreža.Redaka, mreža.Stupaca);
            foreach (Polje p in zaEliminirati)
                mreža.EliminirajPolje(p);
        }

        // pomoćna klasa koja pojednostavnjuje korištenje rezultata metode IzaberiPočetnoPolje.
        private class PoljeSmjer
        {
            public PoljeSmjer(Smjer smjer, Polje polje)
            {
                Smjer = smjer;
                Polje = polje;
            }
            public readonly Polje Polje;
            public readonly Smjer Smjer;
        }

        private PoljeSmjer IzaberiPočetnoPolje(IEnumerable<Polje> slobodnaPolja, int duljinaBroda)
        {
            var horizontalnaPolja = DajHorizontalnaPočetnaPolja(slobodnaPolja, duljinaBroda);
            var vertikalnaPolja = DajVertikalnaPočetnaPolja(slobodnaPolja, duljinaBroda);
            int ukupnoKandidata = horizontalnaPolja.Count() + vertikalnaPolja.Count();
            if (ukupnoKandidata == 0)
                throw new ApplicationException();
            int izbor = slučajni.Next(0, ukupnoKandidata);
            if (izbor >= horizontalnaPolja.Count())
                return new PoljeSmjer(Smjer.Vertikalno, vertikalnaPolja.ElementAt(izbor - horizontalnaPolja.Count()));
            return new PoljeSmjer(Smjer.Horizontalno, horizontalnaPolja.ElementAt(izbor));
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

        Random slučajni = new Random();

        IEliminatorPolja eliminatorPolja;
    }
}
