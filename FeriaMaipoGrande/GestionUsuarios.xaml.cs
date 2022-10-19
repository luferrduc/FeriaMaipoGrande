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
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


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
            listarPersonas();
            listarUsuarios();
            cargarCombo();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (dgListaUsuarios.SelectedIndex == -1 || dgListaUsuarios.SelectedItem.ToString().Equals("{NewItemPlaceholder}"))
            {
                if (!String.IsNullOrEmpty(txtUsername.Text) && !String.IsNullOrEmpty(txtID.Text) && !String.IsNullOrEmpty(txtEmail.Text) &&
                    !String.IsNullOrEmpty(passPassword.Password) && !String.IsNullOrEmpty(passPassword2.Password))
                {
                    string username, id, password, password2, email;
                    Usuario user = new Usuario();
                    id = txtID.Text;
                    username = txtUsername.Text;
                    password = passPassword.Password;
                    password2 = passPassword2.Password;
                    email = txtEmail.Text;
                    dynamic userrr = JObject.Parse(cbRol.SelectedItem.ToString());
                    string rol = userrr["id_rol"];
                    user.UserID = int.Parse(id);
                    user.Password = password;
                    user.Username = username;
                    user.Rol = int.Parse(rol);
                    user.Email = email;
                    JsonConvert.SerializeObject(user);
                    if (password != password2)
                    {
                        MessageBox.Show("Las contraseñas deben coincidir");
                    }
                    else
                    {
                        user.crearUsuario();
                        MessageBox.Show("Se ha creado el usuario correctamente", "Tarea completada", MessageBoxButton.OK, MessageBoxImage.Information);
                        LimpiarCampos();
                        listarPersonas();
                    }
                }
                else
                {
                    MessageBox.Show("Debe completar los campos para añadir un usuario", "Datos faltantes", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                listarUsuarios();
            }
            else
            {
                ModificarUsuario();
                LimpiarCampos();
            }
            
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (dgListaUsuarios.SelectedIndex == -1 || dgListaUsuarios.SelectedItem.ToString().Equals("{NewItemPlaceholder}"))
            {
                MessageBox.Show("No hay datos seleccionados, por favor seleccione.", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBoxResult resultado = MessageBox.Show("Está seguro que desea eliminar a esta persona?", "Alerta", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (resultado == MessageBoxResult.Yes)
                {
                    dynamic usuario = JObject.Parse(dgListaUsuarios.SelectedItem.ToString());
                    string username = usuario["nombre_usuario"].ToString();
                    Usuario pers = new Usuario();
                    pers.eliminarUsuario(username);
                    MessageBox.Show("Persona eliminada correctamente.", "Registro modificado", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                
                listarPersonas();
            }
            listarUsuarios();
        }

        private void btnCargaDatos_Click(object sender, RoutedEventArgs e)
        {
            if (dgListaUsuarios.SelectedIndex == -1 || dgListaUsuarios.SelectedItem.ToString().Equals("{NewItemPlaceholder}"))
            {
                MessageBox.Show("No hay datos seleccionados, por favor seleccione.", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                dynamic user = JObject.Parse(dgListaUsuarios.SelectedItem.ToString());
                txtEmail.Text = user["email"].ToString();
                txtUsername.Text = user["nombre_usuario"].ToString();
                passPassword.Password = user["password"].ToString();
                passPassword2.Password = user["password"].ToString();
                cbRol.SelectedItem = user["rol_usuario"];
                txtUsername.IsEnabled = false;
            } 
        }

        private void listarPersonas()
        {
            Persona persona = new Persona();
            dynamic listaPersonas = persona.listarPersonas();
            dgListaPersonas.ItemsSource = listaPersonas;
        }

        private void listarUsuarios()
        {
            Usuario user = new Usuario();
            dynamic listaPersonas = user.listarUsuarios();
            dgListaUsuarios.ItemsSource = listaPersonas;
        }

        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }

        private void LimpiarCampos()
        {
            txtEmail.Text = string.Empty;
            txtID.Text = string.Empty;
            txtUsername.Text = string.Empty;
            passPassword.Password = string.Empty;
            passPassword2.Password = string.Empty;
            txtUsername.IsEnabled = true;
        }

        private void cargarCombo()
        {
            Usuario user = new Usuario();
            dynamic lista = user.listarRoles();
            cbRol.ItemsSource = lista;
            cbRol.DisplayMemberPath = "descripcion";
            cbRol.SelectedValuePath = "id_rol";
        }

        private void ModificarUsuario()
        {
            if (dgListaUsuarios.SelectedIndex == -1 || dgListaUsuarios.SelectedItem.ToString().Equals("{NewItemPlaceholder}"))
            {
                MessageBox.Show("Seleccione una persona.", "Información", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else 
            {
                if(!String.IsNullOrEmpty(txtEmail.Text) && !String.IsNullOrEmpty(txtID.Text) && !String.IsNullOrEmpty(passPassword.Password) &&
                    !String.IsNullOrEmpty(passPassword2.Password))
                {
                    try
                    {
                        dynamic user = JObject.Parse(dgListaUsuarios.SelectedItem.ToString());
                        string username = user["nombre_usuario"].ToString();

                        string  email, password1, password2, userId;

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

        public int obtenerIdRol()
        {
            try
            {
                dynamic userrr = JObject.Parse(cbRol.SelectedItem.ToString());
                string rol = userrr["id_rol"];
                return int.Parse(rol);
            }
            catch(Exception ex)
            {
                return -1;
            }
        }
    }
}
