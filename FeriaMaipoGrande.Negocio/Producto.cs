using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeriaMaipoGrande.Datos;
using System.IO;
using System.Windows;

namespace FeriaMaipoGrande.Negocio
{
    public class Producto
    {
        private int idProducto, precio;
        private string nombre, calidad, observaciones;

        public Producto()
        {
        }

        public Producto(int precio, string nombre, string calidad)
        {
            Precio = precio;
            Nombre = nombre;
            Calidad = calidad;

        }

        public Producto(int idProducto, int precio, string nombre, string calidad, string observaciones)
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


        public bool PostProduct()
        {
            ProductoDAO productoDAO = new ProductoDAO();

            productoDAO.Nombre = nombre;
            productoDAO.Precio = precio;
            productoDAO.Calidad = calidad;
  
            if (!Nombre.Equals(string.Empty) && !Precio.Equals(string.Empty) && !Calidad.Equals(string.Empty))
            {
                try
                {
                    productoDAO.PostProductDAO();
                    return true;
                }
                catch (Exception ex)
                {                   
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK);
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        public void GetAllProducts()
        {
            ProductoDAO productoDAO = new ProductoDAO();

            productoDAO.GetAllProducts();
        }

        public void DeleteOneProduct(int idProducto)
        {

        }


    }
}
