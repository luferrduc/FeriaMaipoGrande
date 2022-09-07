using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaMaipoGrande.Datos
{
    public class AdministradorDAO : PersonaDAO
    {
        private int idAdmnistrador;

        public AdministradorDAO()
        {
        }

        public AdministradorDAO(int idAdmnistrador)
        {
            this.IdAdmnistrador = idAdmnistrador;
        }

        public AdministradorDAO(int idPersona, string nombre, string apellidoPaterno, string apellidoMaterno, string direccion, string ciudad, string pais, string numIdentificador) : base(idPersona, nombre, apellidoPaterno, apellidoMaterno, direccion, ciudad, pais, numIdentificador)
        {
        }

        public int IdAdmnistrador { get => idAdmnistrador; set => idAdmnistrador = value; }
    }

    /* public void DeleteUser()
    {

    }
    */
}

