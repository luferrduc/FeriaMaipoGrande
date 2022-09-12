using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FeriaMaipoGrande.Datos
{ 
    
    public class PersonaDAO
    {
        DBApi dbapi = new DBApi();
        private int idPersona;
        private string nombre, apellidoPaterno, apellidoMaterno, direccion, ciudad, pais, numIdentificador;

        //Constructor vacío
        public PersonaDAO()
        {
        }

        //Constructor con datos
        public PersonaDAO(int idPersona, string nombre, string apellidoPaterno, string apellidoMaterno, string direccion, string ciudad, string pais, string numIdentificador)
        {
            Nombre = nombre;
            ApellidoPaterno = apellidoPaterno;
            ApellidoMaterno = apellidoMaterno;
            Direccion = direccion;
            Ciudad = ciudad;
            Pais = pais;
            NumIdentificador = numIdentificador;
        }

        //Getters y setters
        [JsonProperty("nombre")]
        public string Nombre { get => nombre; set => nombre = value; }
        [JsonProperty("apellido_p")]
        public string ApellidoPaterno { get => apellidoPaterno; set => apellidoPaterno = value; }
        [JsonProperty("apellido_m")]
        public string ApellidoMaterno { get => apellidoMaterno; set => apellidoMaterno = value; }
        [JsonProperty("direccion")]
        public string Direccion { get => direccion; set => direccion = value; }
        [JsonProperty("ciudad")]
        public string Ciudad { get => ciudad; set => ciudad = value; }
        [JsonProperty("pais")]
        public string Pais { get => pais; set => pais = value; }
        [JsonProperty("num_identificador")]
        public string NumIdentificador { get => numIdentificador; set => numIdentificador = value; }


        public dynamic listarPersonasDAO()
        {
            dynamic datos = dbapi.GetPersonas("persona");

            return datos;
        }

        public async void eliminarPersonaDAO(string numIdentificador)
        {
            await dbapi.DeletePersonaAsync("persona/",numIdentificador);
        }

        public async void crearPersonaDAO(string path, PersonaDAO persona)
        {
            await dbapi.CrearPersonaAsync("persona", persona);
        }

        public async void actualizarPersonaDAO(string numIdentificador, PersonaDAO persona)
        {
            await dbapi.ActualizarPersonaAsync("persona/", numIdentificador, persona);
        }
    }
}
