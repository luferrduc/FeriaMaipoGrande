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

namespace FeriaMaipoGrande
{
    /// <summary>
    /// Lógica de interacción para MenuVentas.xaml
    /// </summary>
    public partial class MenuVentas : Window
    {
        public MenuVentas()
        {
            InitializeComponent();
        }

        private void btnVentaLocal_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnVentaExtranjera_Click(object sender, RoutedEventArgs e)
        {
            VentaExtranjera ventaE = new VentaExtranjera();
            ventaE.Show();
            this.Close();
        }
    }
}
