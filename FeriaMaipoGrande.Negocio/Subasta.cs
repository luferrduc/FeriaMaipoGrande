using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaMaipoGrande.Negocio
{
    class Subasta
    {
        private int idSubasta, precio;
        private string ganador, cargo, estado;
        private DateTime fechaIni, fechaTer; 


        //Constructor vacio
        public Subasta()
        {

        }

        //Constructor con datos
        public Subasta(int idSubasta, int precio, string ganador, string cargo, string estado, DateTime fechaIni, DateTime fechaTer)
        {
            this.IdSubasta = idSubasta;
            this.Precio = precio;
            this.Ganador = ganador;
            this.Cargo = cargo;
            this.Estado = estado;
            this.FechaIni = fechaIni;
            this.FechaTer = fechaTer;

        }

        //getters y setters
        public int IdSubasta { get => idSubasta;}
        public int Precio { get => precio;  set => precio = value; }
        public string Ganador { get => ganador; set => ganador = value; }
        public string Cargo { get => cargo; set => cargo = value; }
        public string Estado { get => estado;  set =>  estado = value; }
        public DateTime FechaIni { get => fechaIni; set => fechaIni = value; }
        public DateTime FechaTer { get => fechaTer; set => fechaTer = value; }
         
        public string InformarGanador(string Ganador)
        {
            return "El ganador es " + Ganador;
        }
    }
}
