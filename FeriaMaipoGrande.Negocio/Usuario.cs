using System;
using FeriaMaipoGrande.Datos;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FeriaMaipoGrande.Negocio
{
    public class Usuario //: Persona
    {
        private int userID, rol;
        private string username, password, email;

        /*public Usuario(int idPersona, string username, string nombre, string apellidoPaterno, string apellidoMaterno, string direccion, string ciudad, string pais, string numIdentificador) : base(idPersona, nombre, apellidoPaterno, apellidoMaterno, direccion, ciudad, pais, numIdentificador)
        {
        }*/

        public Usuario(int userID, string username, string password, int rol, string email)
        {
            UserID = userID;
            Username = username;
            Password = password;
            Rol = rol;
            Email = email;
        }
        public Usuario()
        {
        }

        public string Password { get => password; set => password = value; }
        public string Username { get => username; set => username = value; }
        public int Rol { get => rol; set => rol = value; }
        public int UserID { get => userID; set => userID = value; }
        public string Email { get => email; set => email = value; }

        public dynamic listarUsuarios()
        {
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            dynamic listaUsuarios = usuarioDAO.listarUsuariosDAO();
            return listaUsuarios;
        }

        public void eliminarUsuario(string username)
        {
            UsuarioDAO usuarioDAO = new UsuarioDAO();
            usuarioDAO.eliminarUsuarioDAO(username);
        }

        public void crearUsuario()
        {
            UsuarioDAO usuarioDAO = new UsuarioDAO();

            usuarioDAO.UserID = UserID;
            usuarioDAO.Username = Username;
            usuarioDAO.Password = Password;
            usuarioDAO.Rol = Rol;
            usuarioDAO.Email = Email;

            usuarioDAO.crearUsuarioDAO(usuarioDAO);
        }

        public void actualizarUsuario(string username)
        {
            UsuarioDAO usuarioDAO = new UsuarioDAO();

            usuarioDAO.UserID = UserID;
            usuarioDAO.Username = Username;
            usuarioDAO.Password = Password;
            usuarioDAO.Rol = Rol;
            usuarioDAO.Email = Email;

            usuarioDAO.actualizarUsuarioDAO(username, usuarioDAO);
        }

        public dynamic listarRoles()
        {
            UsuarioDAO user = new UsuarioDAO();
            dynamic roles = user.rolesUsuariosDAO();
            return roles;
        }
    }
}

