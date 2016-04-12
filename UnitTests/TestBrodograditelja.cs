using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using PotapanjeBrodova;

namespace UnitTests
{
    [TestClass]
    public class TestBrodograditelja
    {
        [TestMethod]
        public void Brodograditelj_DajHorizontalnaPočetnaPoljaZa5HorizontalnihPoljaVraća2KrajnjaLijevaPoljaZaBrodDuljine4()
        {
            List<Polje> polja = new List<Polje>
            {
                new Polje(0, 0),
                new Polje(0, 1),
                new Polje(0, 2),
                new Polje(0, 3),
                new Polje(0, 4)
            };

            Brodograditelj b = new Brodograditelj();
            var slobodnaPolja = b.DajHorizontalnaPočetnaPolja(polja, 4);
            Assert.AreEqual(2, slobodnaPolja.Count());
            Assert.IsTrue(slobodnaPolja.Contains(new Polje(0, 0)));
            Assert.IsTrue(slobodnaPolja.Contains(new Polje(0, 1)));
        }

        [TestMethod]
        public void Brodograditelj_DajHorizontalnaPočetnaPoljaZa5HorizontalnihPoljaVraćaSvaPoljaZaBrodDuljine1()
        {
            List<Polje> polja = new List<Polje>
            {
                new Polje(0, 0),
                new Polje(0, 1),
                new Polje(0, 2),
                new Polje(0, 3),
                new Polje(0, 4)
            };

            Brodograditelj b = new Brodograditelj();
            var slobodnaPolja = b.DajHorizontalnaPočetnaPolja(polja, 1);
            Assert.AreEqual(5, slobodnaPolja.Count());
            Assert.IsTrue(slobodnaPolja.Contains(new Polje(0, 0)));
            Assert.IsTrue(slobodnaPolja.Contains(new Polje(0, 1)));
            Assert.IsTrue(slobodnaPolja.Contains(new Polje(0, 2)));
            Assert.IsTrue(slobodnaPolja.Contains(new Polje(0, 3)));
            Assert.IsTrue(slobodnaPolja.Contains(new Polje(0, 4)));
        }

        [TestMethod]
        public void Brodograditelj_DajHorizontalnaPočetnaPoljaZa4HorizontalnaPoljaNeVraćaNitiJednoPoljeZaBrodDuljine5()
        {
            List<Polje> polja = new List<Polje>
            {
                new Polje(0, 1),
                new Polje(0, 2),
                new Polje(0, 3),
                new Polje(0, 4)
            };

            Brodograditelj b = new Brodograditelj();
            var slobodnaPolja = b.DajHorizontalnaPočetnaPolja(polja, 5);
            Assert.AreEqual(0, slobodnaPolja.Count());
        }


        [TestMethod]
        public void Brodograditelj_DajVertikalnaPočetnaPoljaZa5VertikalnihPoljaVraća2KrajnjaGornjaPoljaZaBrodDuljine4()
        {
            List<Polje> polja = new List<Polje>
            {
                new Polje(1, 2),
                new Polje(2, 2),
                new Polje(3, 2),
                new Polje(4, 2),
                new Polje(5, 2)
            };

            Brodograditelj b = new Brodograditelj();
            var slobodnaPolja = b.DajVertikalnaPočetnaPolja(polja, 4);
            Assert.AreEqual(2, slobodnaPolja.Count());
            Assert.IsTrue(slobodnaPolja.Contains(new Polje(1, 2)));
            Assert.IsTrue(slobodnaPolja.Contains(new Polje(2, 2)));
        }

        [TestMethod]
        public void Brodograditelj_DajVertikalnaPočetnaPoljaZa5VertikalnihPoljaVraćaSvaPoljaZaBrodDuljine1()
        {
            List<Polje> polja = new List<Polje>
            {
                new Polje(3, 3),
                new Polje(4, 3),
                new Polje(5, 3),
                new Polje(6, 3),
                new Polje(7, 3)
            };

            Brodograditelj b = new Brodograditelj();
            var slobodnaPolja = b.DajVertikalnaPočetnaPolja(polja, 1);
            Assert.AreEqual(5, slobodnaPolja.Count());
            Assert.IsTrue(slobodnaPolja.Contains(new Polje(3, 3)));
            Assert.IsTrue(slobodnaPolja.Contains(new Polje(4, 3)));
            Assert.IsTrue(slobodnaPolja.Contains(new Polje(5, 3)));
            Assert.IsTrue(slobodnaPolja.Contains(new Polje(6, 3)));
            Assert.IsTrue(slobodnaPolja.Contains(new Polje(7, 3)));
        }

        [TestMethod]
        public void Brodograditelj_DajVertikalnaPočetnaPoljaZa4VertikalnaPoljaNeVraćaNitiJednoPoljeZaBrodDuljine5()
        {
            List<Polje> polja = new List<Polje>
            {
                new Polje(2, 1),
                new Polje(3, 1),
                new Polje(4, 1),
                new Polje(5, 1)
            };

            Brodograditelj b = new Brodograditelj();
            var slobodnaPolja = b.DajVertikalnaPočetnaPolja(polja, 5);
            Assert.AreEqual(0, slobodnaPolja.Count());
        }

        [TestMethod]
        public void Brodograditelj_DajPoljaZaBrodVraćaListuOd3HorizontalnaPolja()
        {
            Brodograditelj b = new Brodograditelj();
            var polja = b.DajPoljaZaBrod(Smjer.Horizontalno, new Polje(3, 6), 3);
            Assert.AreEqual(3, polja.Count());
            Assert.IsTrue(polja.Contains(new Polje(3, 6)));
            Assert.IsTrue(polja.Contains(new Polje(3, 7)));
            Assert.IsTrue(polja.Contains(new Polje(3, 8)));
        }

        [TestMethod]
        public void Brodograditelj_DajPoljaZaBrodVraćaListuOd2VertikalnaPolja()
        {
            Brodograditelj b = new Brodograditelj();
            var polja = b.DajPoljaZaBrod(Smjer.Vertikalno, new Polje(3, 6), 2);
            Assert.AreEqual(2, polja.Count());
            Assert.IsTrue(polja.Contains(new Polje(3, 6)));
            Assert.IsTrue(polja.Contains(new Polje(4, 6)));
        }

        [TestMethod]
        public void Brodograditelj_PoljaKojaTrebaEliminiratiOkoBrodaVraćaPoljaBrodaISvaOkolnaPoljaZaBrodUSrediniMreže()
        {
            int redaka = 10;
            int stupaca = 10;
            int duljinaBroda = 4;
            Polje početnoPolje = new Polje(3, 2);
            Smjer smjer = Smjer.Vertikalno;

            Brodograditelj b = new Brodograditelj();
            var poljaBroda = b.DajPoljaZaBrod(smjer, početnoPolje, duljinaBroda);

            var zaEliminirati = b.PoljaKojaTrebaEliminiratiOkoBroda(poljaBroda, redaka, stupaca);
            Assert.AreEqual(18, zaEliminirati.Count());
            foreach (Polje p in poljaBroda)
                Assert.IsTrue(zaEliminirati.Contains(p));
            // provjerimo polja u uglovima broda (lijevo-gore, lijevo-dolje, desno-gore i desno-dolje)
            Assert.IsTrue(zaEliminirati.Contains(new Polje(2, 1)));
            Assert.IsTrue(zaEliminirati.Contains(new Polje(2, 3)));
            Assert.IsTrue(zaEliminirati.Contains(new Polje(7, 1)));
            Assert.IsTrue(zaEliminirati.Contains(new Polje(7, 3)));
        }

        [TestMethod]
        public void Brodograditelj_PoljaKojaTrebaEliminiratiOkoBrodaVraćaPoljaBrodaIPoljaIspodIDesnoZaBrodUGornjemLijevomKutuMreže()
        {
            int redaka = 10;
            int stupaca = 10;
            int duljinaBroda = 4;
            Polje početnoPolje = new Polje(0, 0);
            Smjer smjer = Smjer.Horizontalno;

            Brodograditelj b = new Brodograditelj();
            var poljaBroda = b.DajPoljaZaBrod(smjer, početnoPolje, duljinaBroda);

            var zaEliminirati = b.PoljaKojaTrebaEliminiratiOkoBroda(poljaBroda, redaka, stupaca);
            Assert.AreEqual(10, zaEliminirati.Count());
            foreach (Polje p in poljaBroda)
                Assert.IsTrue(zaEliminirati.Contains(p));
            // provjerimo 3 krajnja polja uz brod (ispod-lijevo, ispod-desno, desno)
            Assert.IsTrue(zaEliminirati.Contains(new Polje(1, 0)));
            Assert.IsTrue(zaEliminirati.Contains(new Polje(1, 4)));
            Assert.IsTrue(zaEliminirati.Contains(new Polje(0, 4)));
        }

        [TestMethod]
        public void Brodograditelj_PoljaKojaTrebaEliminiratiOkoBrodaVraćaPoljaBrodaIPoljaLijevoIIspodZaBrodUGornjemDesnomKutuMreže()
        {
            int redaka = 10;
            int stupaca = 10;
            int duljinaBroda = 4;
            Polje početnoPolje = new Polje(0, stupaca - 1);
            Smjer smjer = Smjer.Vertikalno;

            Brodograditelj b = new Brodograditelj();
            var poljaBroda = b.DajPoljaZaBrod(smjer, početnoPolje, duljinaBroda);

            var zaEliminirati = b.PoljaKojaTrebaEliminiratiOkoBroda(poljaBroda, redaka, stupaca);
            Assert.AreEqual(10, zaEliminirati.Count());
            foreach (Polje p in poljaBroda)
                Assert.IsTrue(zaEliminirati.Contains(p));
            // provjerimo 3 krajnja polja uz brod (lijevo-gore, lijevo-ispod, ispod)
            Assert.IsTrue(zaEliminirati.Contains(new Polje(0, stupaca - 2)));
            Assert.IsTrue(zaEliminirati.Contains(new Polje(duljinaBroda, stupaca - 2)));
            Assert.IsTrue(zaEliminirati.Contains(new Polje(duljinaBroda, stupaca - 1)));
        }

        [TestMethod]
        public void Brodograditelj_PoljaKojaTrebaEliminiratiOkoBrodaVraćaPoljaBrodaIPoljaLijevoIIznadZaBrodUDonjemDesnomKutuMreže()
        {
            int redaka = 10;
            int stupaca = 10;
            int duljinaBroda = 4;
            Polje početnoPolje = new Polje(redaka - 1, stupaca - duljinaBroda);
            Smjer smjer = Smjer.Horizontalno;

            Brodograditelj b = new Brodograditelj();
            var poljaBroda = b.DajPoljaZaBrod(smjer, početnoPolje, duljinaBroda);

            var zaEliminirati = b.PoljaKojaTrebaEliminiratiOkoBroda(poljaBroda, redaka, stupaca);
            Assert.AreEqual(10, zaEliminirati.Count());
            foreach (Polje p in poljaBroda)
                Assert.IsTrue(zaEliminirati.Contains(p));
            // provjerimo 3 krajnja polja uz brod (lijevo, lijevo-iznad, desno iznad)
            Assert.IsTrue(zaEliminirati.Contains(new Polje(redaka - 1, početnoPolje.Stupac - 1)));
            Assert.IsTrue(zaEliminirati.Contains(new Polje(redaka - 2, početnoPolje.Stupac - 1)));
            Assert.IsTrue(zaEliminirati.Contains(new Polje(redaka - 2, stupaca - 1)));
        }

        [TestMethod]
        public void Brodograditelj_PoljaKojaTrebaEliminiratiOkoBrodaVraćaPoljaBrodaIPoljaLijevoIIznadZaBrodUDonjemLijevomKutuMreže()
        {
            int redaka = 10;
            int stupaca = 10;
            int duljinaBroda = 4;
            Polje početnoPolje = new Polje(redaka - duljinaBroda, 0);
            Smjer smjer = Smjer.Vertikalno;

            Brodograditelj b = new Brodograditelj();
            var poljaBroda = b.DajPoljaZaBrod(smjer, početnoPolje, duljinaBroda);

            var zaEliminirati = b.PoljaKojaTrebaEliminiratiOkoBroda(poljaBroda, redaka, stupaca);
            Assert.AreEqual(10, zaEliminirati.Count());
            foreach (Polje p in poljaBroda)
                Assert.IsTrue(zaEliminirati.Contains(p));
            // provjerimo 3 krajnja polja uz brod (iznad, iznad-desno, desno dolje)
            Assert.IsTrue(zaEliminirati.Contains(new Polje(početnoPolje.Redak - 1, 0)));
            Assert.IsTrue(zaEliminirati.Contains(new Polje(početnoPolje.Redak - 1, 1)));
            Assert.IsTrue(zaEliminirati.Contains(new Polje(redaka - 1, 1)));
        }
    }
}
