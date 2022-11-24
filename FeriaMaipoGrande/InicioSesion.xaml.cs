using FeriaMaipoGrande.Negocio;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
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
    /// Lógica de interacción para InicioSesion.xaml
    /// </summary>
    public partial class InicioSesion : Window
    {
        public InicioSesion()
        {
            InitializeComponent();
            
        }


        private void btnIniciar_Click(object sender, RoutedEventArgs e)
        {     
            if(String.IsNullOrEmpty(txUsuario.Text) && String.IsNullOrEmpty(txPassword.Text))
            {
                MessageBox.Show("Debe completar los datos", "Datos faltantes",MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                Login login = new Login();
                string username, contrasena;
                username = txUsuario.Text;
                contrasena = txPassword.Text;
                login.Usuario = username;
                login.Contrasena = contrasena;

                login.IniciarSesion();
            }
        }

        
    }
}
