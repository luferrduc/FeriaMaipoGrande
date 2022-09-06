using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaMaipoGrande.Negocio
{
    class Subasta
    {
        private int _idSubasta;
        private String _ganador;
        private DateTime _fechaIni; 
        private DateTime _fechaTer;
        private String _cargo;
        private int  _precio; 
        private String  _estado;


        public int IdSubasta { get => _idSubasta;}
        public String Ganador { get => _ganador; set => _ganador = value; }
        public DateTime FechaIni { get => _fechaIni; set => _fechaIni = value; }
        public DateTime FechaTer { get => _fechaTer; set => _fechaTer = value; }
        public String Cargo { get => _cargo; set => _cargo = value; }
        public int Precio { get => _precio;  set => _precio = value; }
        public int Estado { get => _estado;  set =>  _estado = value; }
         
        public String InformarGanador(String Ganador)
        {
            return "El ganador es " + Ganador;
        }
    }
}
