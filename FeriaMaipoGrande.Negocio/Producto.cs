using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaMaipoGrande.Negocio
{
    public class Producto
    {
        private int idProducto, precio;
        private string nombre, calidad, observaciones;

        public Producto(int idProducto, int precio, string nombre, string calidad, string observaciones)
        {
            this.IdProducto = idProducto;
            this.Precio = precio;
            this.Nombre = nombre;
            this.Calidad = calidad;
            this.Observaciones = observaciones;
        }
        // Comentario de prueba  
        public int IdProducto { get => idProducto; set => idProducto = value; }
        public int Precio { get => precio; set => precio = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Calidad { get => calidad; set => calidad = value; }
        public string Observaciones { get => observaciones; set => observaciones = value; }
    }
}
