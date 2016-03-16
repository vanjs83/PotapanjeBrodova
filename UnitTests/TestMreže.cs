using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PotapanjeBrodova;

namespace UnitTests
{
    /// <summary>
    /// Summary description for TestMreže
    /// </summary>
    [TestClass]
    public class TestMreže
    {
        [TestMethod]
        public void Mreža_DajSlobodnaPoljaInicijalnoDajeSvaPoljaUMreži()
        {
            Mreža m = new Mreža(10, 10);
            Assert.AreEqual(100, m.DajSlobodnaPolja().Count);
            Assert.IsTrue(m.DajSlobodnaPolja().Exists(polje => polje.Redak == 1 && polje.Stupac == 1));
        }

        [TestMethod]
        public void Mreža_DajSlobodnaPoljaNakonEliminiranjaJednogPoljaVraćaOstatak()
        {
            Mreža m = new Mreža(10, 10);
            m.EliminirajPolje(1, 1);
            Assert.AreEqual(99, m.DajSlobodnaPolja().Count);
            Assert.IsFalse(m.DajSlobodnaPolja().Exists(polje => polje.Redak == 1 && polje.Stupac == 1));
        }

        [TestMethod]
        public void Mreža_DajSlobodnaPoljaNakonEliminiranjaDvaPoljaVraćaOstatak()
        {
            Mreža m = new Mreža(10, 10);
            m.EliminirajPolje(1, 1);
            m.EliminirajPolje(2, 2);
            Assert.AreEqual(98, m.DajSlobodnaPolja().Count);
            Assert.IsFalse(m.DajSlobodnaPolja().Exists(polje => polje.Redak == 1 && polje.Stupac == 1));
            Assert.IsFalse(m.DajSlobodnaPolja().Exists(polje => polje.Redak == 2 && polje.Stupac == 2));
        }

        [TestMethod]
        public void Mreža_DajSlobodnaPoljaNakonEliminiranjaDvaIstaPoljaVraćaOstatak()
        {
            Mreža m = new Mreža(10, 10);
            m.EliminirajPolje(1, 1);
            m.EliminirajPolje(1, 1);
            Assert.AreEqual(99, m.DajSlobodnaPolja().Count);
        }

    }
}
