using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaMaipoGrande.Negocio
{
    class Subasta
    {
        private int IdSubasta { get; }
        private String Ganador { get; set; }
        private DateTime FechaIni { get; set; }
        private DateTime FechaTer { get; set; }
        private String Cargo { get; set; }
        private int Precio { get; set; }
        private String Estado { get; set; }

    }
}
