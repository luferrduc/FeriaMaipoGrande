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
    /// Lógica de interacción para GestionUsuarios.xaml
    /// </summary>
    public partial class GestionUsuarios : Window
    {
        public GestionUsuarios()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCargaDatos_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
