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
            IdPersona = idPersona;
            Nombre = nombre;
            ApellidoPaterno = apellidoPaterno;
            ApellidoMaterno = apellidoMaterno;
            Direccion = direccion;
            Ciudad = ciudad;
            Pais = pais;
            NumIdentificador = numIdentificador;
        }

        //Getters y setters
        public int IdPersona { get => idPersona; set => idPersona = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string ApellidoPaterno { get => apellidoPaterno; set => apellidoPaterno = value; }
        public string ApellidoMaterno { get => apellidoMaterno; set => apellidoMaterno = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Ciudad { get => ciudad; set => ciudad = value; }
        public string Pais { get => pais; set => pais = value; }
        public string NumIdentificador { get => numIdentificador; set => numIdentificador = value; }


        public dynamic listarPersonasDAO()
        {
            dynamic datos = dbapi.Get();

            return datos;
        }

        public async void eliminarPersonaDAO(string numIdentificador)
        {
            await dbapi.DeletePersonaAsync(numIdentificador);
        }
    }
}
