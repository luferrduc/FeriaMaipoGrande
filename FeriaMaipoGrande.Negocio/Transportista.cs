using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaMaipoGrande.Negocio
{
    public class Transportista : Persona
    {
        private int idTranpostista;

        public Transportista( string nombre, string apellidoPaterno, string apellidoMaterno, string direccion, string ciudad, string pais, string numIdentificador) : base(nombre, apellidoPaterno, apellidoMaterno, direccion, ciudad, pais, numIdentificador)
        {
        }

        public Transportista(int idTranpostista)
        {
            IdTranpostista = idTranpostista;
        }

        public Transportista()
        {
        }

        public int IdTranpostista { get => idTranpostista; set => idTranpostista = value; }
    }
}

