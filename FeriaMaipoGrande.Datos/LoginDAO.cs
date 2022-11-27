using Newtonsoft.Json;
using System;
using FeriaMaipoGrande;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FeriaMaipoGrande.Datos
{
    public class LoginDAO
    {
        DBApi dbapi = new DBApi();
        private string usuario, contrasena;
        public LoginDAO(string usuario, string contrasena)
        {
            Usuario = usuario;
            Contrasena = contrasena;
        }

        public LoginDAO()
        {
        }
        [JsonProperty("nombre_usuario")]
        public string Usuario { get => usuario; set => usuario = value; }
        [JsonProperty("password")]
        public string Contrasena { get => contrasena; set => contrasena = value; }

        public async Task<string> IniciarSesionDAO(LoginDAO login)
        {
            return await dbapi.IniciarSesionAsync(login);
        }


    }
}
