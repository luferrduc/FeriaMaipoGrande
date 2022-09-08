using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaMaipoGrande.Negocio
{
    public class Transporte
    {
        private int idTransporte, capacidadCarga;
        private string patente, tamano, regrigeracion;

        public Transporte(int idTransporte, int capacidadCarga, string patente, string tamano, string regrigeracion)
        {
            IdTransporte = idTransporte;
            CapacidadCarga = capacidadCarga;
            Patente = patente;
            Tamano = tamano;
            Regrigeracion = regrigeracion;
        }

        public Transporte(int capacidadCarga, string patente, string tamano, string regrigeracion)
        {
            CapacidadCarga = capacidadCarga;
            Patente = patente;
            Tamano = tamano;
            Regrigeracion = regrigeracion;
        }

        public int IdTransporte { get => idTransporte; set => idTransporte = value; }
        public int CapacidadCarga { get => capacidadCarga; set => capacidadCarga = value; }
        public string Patente { get => patente; set => patente = value; }
        public string Tamano { get => tamano; set => tamano = value; }
        public string Regrigeracion { get => regrigeracion; set => regrigeracion = value; }
    }
}
