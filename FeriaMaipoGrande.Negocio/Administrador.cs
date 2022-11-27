using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FeriaMaipoGrande.Negocio
{
    public class Administrador : Persona
    {
        private int idAdmnistrador;

        public Administrador()
        {
        }

        public Administrador(int idAdmnistrador)
        {
            this.IdAdmnistrador = idAdmnistrador;
        }

        public Administrador(string nombre, string apellidoPaterno, string apellidoMaterno, string direccion, string ciudad, string pais, string numIdentificador) : base(nombre, apellidoPaterno, apellidoMaterno, direccion, ciudad, pais, numIdentificador)
        {
        }

        public int IdAdmnistrador { get => idAdmnistrador; set => idAdmnistrador = value; }
    }



}
