using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaMaipoGrande.Negocio
{
    public class Productor : Persona
    {

        private int idProductor;

        public Productor()
        {
        }

        public Productor(int idProductor)
        {
            this.IdProductor = idProductor;
        }

        public int IdProductor { get => idProductor; set => idProductor = value; }
    }
}
