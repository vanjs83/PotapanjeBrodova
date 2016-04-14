using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PotapanjeBrodova
{
    public interface IEliminatorPolja
    {
        IEnumerable<Polje> PoljaKojaTrebaUklonitiOkoBroda(IEnumerable<Polje> brodskaPolja, int redaka, int stupaca);
    }
}
