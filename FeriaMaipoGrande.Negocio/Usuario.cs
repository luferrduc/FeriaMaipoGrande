using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaMaipoGrande.Negocio
{
    public class Usuario : Persona
    {
        private int userID;
        private string password, rol, email;

        public Usuario(int idPersona, string nombre, string apellidoPaterno, string apellidoMaterno, string direccion, string ciudad, string pais, string numIdentificador) : base(idPersona, nombre, apellidoPaterno, apellidoMaterno, direccion, ciudad, pais, numIdentificador)
        {
        }

        public Usuario(int userID, string password, string rol, string email)
        {
            UserID = userID;
            Password = password;
            Rol = rol;
            Email = email;
        }
        public Usuario()
        {
        }
        public int UserID { get => userID; set => userID = value; }
        public string Password { get => password; set => password = value; }
        public string Rol { get => rol; set => rol = value; }
        public string Email { get => email; set => email = value; }
    }
}

