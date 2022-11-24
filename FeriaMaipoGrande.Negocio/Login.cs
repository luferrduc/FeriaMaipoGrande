using FeriaMaipoGrande.Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaMaipoGrande.Negocio
{
    public class Login
    {
        private string usuario, contrasena;
        public Login(string usuario, string contrasena)
        {
            Usuario = usuario;
            Contrasena = contrasena;
        }

        public Login()
        {
        }

        public string Usuario { get => usuario; set => usuario = value; }

        public string Contrasena { get => contrasena; set => contrasena = value; }

        public void IniciarSesion()
        {
            LoginDAO loginDAO = new LoginDAO();

            loginDAO.Usuario = Usuario;
            loginDAO.Contrasena = Contrasena;

            loginDAO.iniciarSesionDAO(loginDAO);
        }

    }
}
