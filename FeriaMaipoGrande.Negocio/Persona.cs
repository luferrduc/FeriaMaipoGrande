using FeriaMaipoGrande.Datos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FeriaMaipoGrande.Negocio
{
    public class Persona
    {
        private int idPersona;
        private string nombre, apellidoPaterno, apellidoMaterno, direccion, ciudad, pais, numIdentificador;

        //Constructor vacío
        public Persona()
        {
        }

        //Constructor con datos
        public Persona(int idPersona ,string nombre, string apellidoPaterno, string apellidoMaterno, string direccion, string ciudad, string pais, string numIdentificador)
        {
            Nombre = nombre;
            ApellidoPaterno = apellidoPaterno;
            NumIdentificador = numIdentificador;
            ApellidoMaterno = apellidoMaterno;
            Direccion = direccion;
            Pais = pais;
            Ciudad = ciudad;
        }

        //Getters y setters
        //[JsonProperty("id_persona")]
        //public int IdPersona { get => idPersona; set => idPersona = value; }
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


        public dynamic listarPersonas()
        {
            PersonaDAO personaDAO = new PersonaDAO();
            dynamic listaPersonas = personaDAO.listarPersonasDAO();
            return listaPersonas;
        }

        public void eliminarPersona(string numIdentificador)
        {
            PersonaDAO personaDAO = new PersonaDAO();
            personaDAO.eliminarPersonaDAO(numIdentificador);
        }

        public void crearPersona()
        {
            PersonaDAO personaDAO = new PersonaDAO();

            personaDAO.Nombre = Nombre;
            personaDAO.NumIdentificador = NumIdentificador;
            personaDAO.Pais = Pais;
            personaDAO.ApellidoMaterno = ApellidoMaterno;
            personaDAO.ApellidoPaterno = ApellidoPaterno;
            personaDAO.Ciudad = Ciudad;
            personaDAO.Direccion = Direccion;
            personaDAO.crearPersonaDAO("persona", personaDAO);
        }
    }
}
