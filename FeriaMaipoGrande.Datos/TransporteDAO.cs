using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaMaipoGrande.Datos
{
    public class TransporteDAO
    {
        private int idTransporte, capacidadCarga;
        private string patente, tamano, regrigeracion;

        public TransporteDAO(int idTransporte, int capacidadCarga, string patente, string tamano, string regrigeracion)
        {
            this.IdTransporte = idTransporte;
            this.CapacidadCarga = capacidadCarga;
            this.Patente = patente;
            this.Tamano = tamano;
            this.Regrigeracion = regrigeracion;
        }

        public int IdTransporte { get => idTransporte; set => idTransporte = value; }
        public int CapacidadCarga { get => capacidadCarga; set => capacidadCarga = value; }
        public string Patente { get => patente; set => patente = value; }
        public string Tamano { get => tamano; set => tamano = value; }
        public string Regrigeracion { get => regrigeracion; set => regrigeracion = value; }
    }
}
