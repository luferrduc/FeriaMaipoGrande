using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        public Persona(int idPersona, string nombre, string apellidoPaterno, string apellidoMaterno, string direccion, string ciudad, string pais, string numIdentificador)
        {
            this.IdPersona = idPersona;
            this.Nombre = nombre;
            this.ApellidoPaterno = apellidoPaterno;
            this.ApellidoMaterno = apellidoMaterno;
            this.Direccion = direccion;
            this.Ciudad = ciudad;
            this.Pais = pais;
            this.NumIdentificador = numIdentificador;
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
    }
}
