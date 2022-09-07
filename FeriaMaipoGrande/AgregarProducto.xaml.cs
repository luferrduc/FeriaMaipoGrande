using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using FeriaMaipoGrande.Negocio;

namespace FeriaMaipoGrande
{
    /// <summary>
    /// Lógica de interacción para AgregarProducto.xaml
    /// </summary>
    public partial class AgregarProducto : Window
    {
        public AgregarProducto()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            string nombre = txtNombre.Text, calidad = txtCalidad.Text;
            int precio = Int32.Parse(txtPrecio.Text);
          
            Producto producto = new Producto()
            {
                Nombre = nombre,
                Precio = precio,
                Calidad = calidad
            };





        }
    }
}
