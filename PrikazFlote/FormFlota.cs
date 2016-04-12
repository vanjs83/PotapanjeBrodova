using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PotapanjeBrodova;

namespace PrikazFlote
{
    public partial class FormFlota : Form
    {
        public FormFlota()
        {
            InitializeComponent();
            mrežaZaFlotu.ZadajMrežu(redaka, stupaca);
        }

        private void buttonSložiFlotu_Click(object sender, EventArgs e)
        {
            Brodograditelj b = new Brodograditelj();
            var flota = b.SložiFlotu(redaka, stupaca, duljineBrodova);
            mrežaZaFlotu.ZadajFlotu(flota);
        }

        int redaka = 10;
        int stupaca = 10;
        int[] duljineBrodova = new int[] { 5, 4, 4, 3, 3, 3, 2, 2, 2, 2 };
    }
}
