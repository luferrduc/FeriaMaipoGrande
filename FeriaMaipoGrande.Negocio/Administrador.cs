using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaMaipoGrande.Negocio
{
    public class admnistrador : Persona
    {
        private int idAdmnistrador;

        public admnistrador()
        {
        }

        public admnistrador(int idAdmnistrador)
        {
            this.IdAdmnistrador = idAdmnistrador;
        }

        public int IdAdmnistrador { get => idAdmnistrador; set => idAdmnistrador = value; }
    }
}
