using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FeriaMaipoGrande.Datos
{
    public class ProductoDAO
    {
        private int idProducto, precio;
        private string nombre, calidad, observaciones;
        private IList<ProductoDAO> listaProductosDAO;

        public ProductoDAO()
        {
        }

        public ProductoDAO(int idProducto, int precio, string nombre, string calidad, string observaciones)
        {
            IdProducto = idProducto;
            Precio = precio;
            Nombre = nombre;
            Calidad = calidad;
            Observaciones = observaciones;
        }
        // Comentario de prueba 2
        public int IdProducto { get => idProducto; set => idProducto = value; }
        public int Precio { get => precio; set => precio = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Calidad { get => calidad; set => calidad = value; }
        public string Observaciones { get => observaciones; set => observaciones = value; }
        
        public void PostProductDAO()
        {

        }

        public dynamic GetAllProducts()
        {
            // Aquí llamar a la api y usar el método get con la url necesaria
            string url = "http://localhost:3001/";
            
            //DBApi request = new DBApi();

            return "request";
        }

        public void DeleteOneProduct(int idProducto)
        {

        }
    }

 
}
