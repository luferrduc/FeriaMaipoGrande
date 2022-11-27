using FeriaMaipoGrande.Datos;
using FeriaMaipoGrande.Negocio;
using Hanssens.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Web;
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

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(txUsuario.Text) && String.IsNullOrEmpty(txPassword.Password))
            {
                MessageBox.Show("Debe completar los datos", "Datos faltantes", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                Login login = new Login();
                string username, contrasena;
                username = txUsuario.Text;
                contrasena = txPassword.Password;
                login.Usuario = username;
                login.Contrasena = contrasena;
                string logUser = await login.IniciarSesion();
                try
                {
                    dynamic userInfo = JObject.Parse(logUser);
                    if (userInfo["id_rol"] == 1)
                    {
                        MenuPrincipal mp = new MenuPrincipal();
                        mp.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Usuario no autorizado", "No tiene los permisos necesarios", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Usuario o contraseñas invalidos", "Datos Incorrectos", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                LimpiarCampos();

            }
        }

        private void LimpiarCampos()
        {
            txPassword.Password = String.Empty;
            txUsuario.Text = String.Empty;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
    }
}
