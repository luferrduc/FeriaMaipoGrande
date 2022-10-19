using FeriaMaipoGrande.Negocio;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    /// Lógica de interacción para VentaExtranjera.xaml
    /// </summary>
    public partial class VentaExtranjera : Window
    {
        public VentaExtranjera()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Venta venta = new Venta();
            // OJO. Hay que modificar las acciones del botón guardar.

            if (dgListaVentas.SelectedIndex == -1)
            {
                
                if (!String.IsNullOrEmpty(txtIDUsuario.Text) &&
                    !String.IsNullOrEmpty(txtID.Text) && !String.IsNullOrEmpty(txtEstado.Text) &&
                    !String.IsNullOrEmpty(txtDescipcion.Text))
                {
                    int id, idintento;
                    string descripcion, id_usuario, estado;
                    id_usuario = txtID.Text;
                    bool resultado1 = Int32.TryParse(id_usuario, out idintento);
                    if (resultado1)
                    {
                        id = Int32.Parse(txtID.Text);
                        descripcion = txtDescipcion.Text;
                        id_usuario = txtIDUsuario.Text;
                        estado = txtEstado.Text;
                        // comienza a guardar los datos en Ventas
                        venta.Id = id;
                        venta.Fecha = DateTime.Now.ToString("dd-MM-yyyy");
                        venta.Estado = "Nuevo";
                        venta.Descripcion = descripcion;
                        venta.Id_tipo_venta = 2;
                        bool resultado2 = Int32.TryParse(id_usuario, out id);
                        if (resultado2)
                        {
                            venta.Id_user = id;
                            venta.Total = 0;
                            MessageBox.Show(JsonConvert.SerializeObject(venta));
                            //venta.crearVenta();
                            MessageBox.Show(venta.ToString(), "Tarea completada", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            MessageBox.Show("El Id de usuario debe ser numerico", "Datos incorrectos", MessageBoxButton.OK, MessageBoxImage.Information);
                        }

                    }
                    else
                    {
                        MessageBox.Show("El numero de venta debe ser numerico", "Datos incorrectos", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Debe completar los campos para añadir una persona", "Datos faltantes", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }
            else
            {
                //ModificarVenta();
            }
            //LimpiarCampos();
            //listarUsuarios();
            //listarVentas();
        }
        /*
        public void ModificarVenta()
        {
            if (dgListaVentas.SelectedIndex == -1 || dgListaVentas.SelectedItem.ToString().Equals("{NewItemPlaceholder}"))
            {
                MessageBox.Show("Seleccione una persona.", "Información", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                if (!String.IsNullOrEmpty(txtDescipcion.Text) && !String.IsNullOrEmpty(txtID.Text) && !String.IsNullOrEmpty(txtIDUsuario.Text) &&
                    !String.IsNullOrEmpty(txtEstado.Text))
                {
                    
                    try
                    {
                        dynamic user = JObject.Parse(dgListaVentas.SelectedItem.ToString());
                        string username = user["nombre_usuario"].ToString();

                        string email, password1, password2, userId;

                        email = txtEmail.Text;
                        username = txtUsername.Text;
                        userId = txtID.Text;
                        password1 = passPassword.Password;
                        password2 = passPassword2.Password;
                        int userRolID = obtenerIdRol();
                        //---------------------------------------------------------------//
                        Usuario usuario = new Usuario();
                        usuario.Email = email;
                        usuario.UserID = int.Parse(userId);
                        usuario.Username = username;
                        usuario.Password = password1;
                        usuario.Password = password2;
                        usuario.Rol = userRolID;
                        //---------------------------------------------------------------//
                        usuario.actualizarUsuario(username);
                        MessageBox.Show("Cliente actualizado exitosamente", "Información", MessageBoxButton.OK);
                    
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Existen campos sin rellenar", "Error al modificar", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            listarUsuarios();
        }
        */
    
        public dynamic listarUsuarios()
        {
            Venta venta = new Venta();
            dynamic usuarios = venta.listarUsuarios();
            return usuarios;
        }

        public dynamic listarVentas()
        {
            Venta venta = new Venta();
            dynamic lista = venta.listarVentas();
            return lista;
        }

        public void LimpiarCampos()
        {
            txtDescipcion.Text = string.Empty;
            txtEstado.Text = string.Empty;
            txtID.Text = string.Empty;
            txtIDUsuario.Text = string.Empty;
        }


    }

}
