using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaMaipoGrande.Datos
{
    public class UsuarioDAO //: PersonaDAO
    {
        DBApi dbapi = new DBApi();

        private int userID, rol;
        private string username, password, email;

        /*public Usuario(int idPersona, string username, string nombre, string apellidoPaterno, string apellidoMaterno, string direccion, string ciudad, string pais, string numIdentificador) : base(idPersona, nombre, apellidoPaterno, apellidoMaterno, direccion, ciudad, pais, numIdentificador)
        {
        }*/

        public UsuarioDAO(int userID, string username, string password, int rol, string email)
        {
            UserID = userID;
            Username = username;
            Password = password;
            Rol = rol;
            Email = email;
        }
        public UsuarioDAO()
        {
        }
        [JsonProperty("password")]
        public string Password { get => password; set => password = value; }
        [JsonProperty("nombre_usuario")]
        public string Username { get => username; set => username = value; }
        [JsonProperty("id_rol")]
        public int Rol { get => rol; set => rol = value; }
        [JsonProperty("id_persona")]
        public int UserID { get => userID; set => userID = value; }
        [JsonProperty("email")]
        public string Email { get => email; set => email = value; }
        


        public async void eliminarUsuarioDAO(string username)
        {
            await dbapi.DeleteUsuarioAsync("usuarios/", username);
        }

        public dynamic listarUsuariosDAO()
        {
            dynamic datos = dbapi.GetUsuarios("usuarios");

            return datos;
        }

        public async void crearUsuarioDAO(UsuarioDAO usuario)
        {
            await dbapi.CrearUsuarioAsync("usuarios", usuario);
        }

        public async void actualizarUsuarioDAO(string username, UsuarioDAO usuario)
        {
            await dbapi.ActualizarUsuarioAsync("usuarios/", username, usuario);
        }

        public dynamic rolesUsuariosDAO()
        {
            dynamic roles = dbapi.GetRoles();
            return roles;
        }
    }
}
