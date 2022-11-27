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
using System.Windows.Navigation;
using System.Windows.Shapes;
using FeriaMaipoGrande.Negocio;


namespace FeriaMaipoGrande
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow: Window
    {
        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

        }

        private void btnPersonas_Click(object sender, RoutedEventArgs e)
        {
            GestionPersonas gestionP = new GestionPersonas();
            gestionP.Show();
            this.Close();
        }

        private void btnUsuarios_Click(object sender, RoutedEventArgs e)
        {
            GestionUsuarios gestionU = new GestionUsuarios();
            gestionU.Show();
            this.Close();
        }

        private void btnVentas_Click(object sender, RoutedEventArgs e)
        {
            MenuPrincipal gestionV = new MenuPrincipal();
            gestionV.Show();
            this.Close();
        }

        private void btnSubastas_Click(object sender, RoutedEventArgs e)
        {
            GestionSubasta subasta = new GestionSubasta();
            subasta.Show();
            this.Close();
        }

        private void btnContratos_Click(object sender, RoutedEventArgs e)
        {
            GestionContratos contratos = new GestionContratos();   
            contratos.Show();
            this.Close();
        }
    }
}
