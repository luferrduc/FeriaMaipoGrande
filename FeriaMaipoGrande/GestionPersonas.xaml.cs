using FeriaMaipoGrande.Negocio;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
    /// Lógica de interacción para GestionPersonas.xaml
    /// </summary>
    public partial class GestionPersonas : Window
    {
        
        public GestionPersonas()
        {
            InitializeComponent();
            listarPersonas();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            
        }

       
        private void btnRegresar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            Close();
        }


        private void listarPersonas()
        {
            Persona persona = new Persona();
            dynamic listaPersonas = persona.listarPersonas();
            dgListaPersonas.ItemsSource = listaPersonas;

        }

        

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            // OJO. Hay que modificar las acciones del botón guardar.

            if (dgListaPersonas.SelectedIndex == -1){
                if(!String.IsNullOrEmpty(txtApellidoM.Text) && !String.IsNullOrEmpty(txtDireccion.Text) &&
                    !String.IsNullOrEmpty(txtApellidoP.Text) && !String.IsNullOrEmpty(txtID.Text) &&
                    !String.IsNullOrEmpty(txtCiudad.Text) && !String.IsNullOrEmpty(txtNombre.Text) && !String.IsNullOrEmpty(txtPais.Text))
                {
                    string id, nombre, apellidoP, apellidoM, direccion, ciudad, pais;
                    id = txtID.Text;
                    nombre = txtNombre.Text;
                    apellidoP = txtApellidoP.Text;
                    apellidoM = txtApellidoM.Text;
                    direccion = txtDireccion.Text;
                    ciudad = txtCiudad.Text;
                    pais = txtPais.Text;
                    Persona persona = new Persona();
                    persona.NumIdentificador = id;
                    persona.Nombre = nombre;
                    persona.ApellidoPaterno = apellidoP;
                    persona.ApellidoMaterno = apellidoM;
                    persona.Ciudad = ciudad;
                    persona.Pais = pais;
                    persona.Direccion = direccion;
                    JsonConvert.SerializeObject(persona);
                    persona.crearPersona();
                    MessageBox.Show("Persona agregada correctamente.");
                    LimpiarCampos();
                    listarPersonas();
                }
                else
                {
                    MessageBox.Show("Debe completar los campos para añadir una persona", "Datos faltantes", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                
            }
            else{
                ModificarPersona();
            }
            LimpiarCampos();
            listarPersonas();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (dgListaPersonas.SelectedIndex == -1 || dgListaPersonas.SelectedItem.ToString().Equals("{NewItemPlaceholder}"))
            {
                MessageBox.Show("No hay datos seleccionados, por favor seleccione.","Infromación", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBoxResult resutlado = MessageBox.Show("Está seguro que desea eliminar a esta persona?", "Alerta", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if(resutlado == MessageBoxResult.Yes)
                {
                    dynamic persona = JObject.Parse(dgListaPersonas.SelectedItem.ToString());
                    string numID = persona["num_identificador"].ToString();
                    Persona pers = new Persona();
                    pers.eliminarPersona(numID);
                    MessageBox.Show("Persona eliminada correctamente.", "Registro modificado", MessageBoxButton.OK, MessageBoxImage.Information);
                    listarPersonas();
                }

            }
            listarPersonas();
        }

        private void ModificarPersona()
        {
            if (dgListaPersonas.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una persona.", "Información", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                
                if (!String.IsNullOrEmpty(txtApellidoM.Text) && !String.IsNullOrEmpty(txtDireccion.Text) &&
                    !String.IsNullOrEmpty(txtApellidoP.Text) && !String.IsNullOrEmpty(txtID.Text) &&
                    !String.IsNullOrEmpty(txtCiudad.Text) && !String.IsNullOrEmpty(txtNombre.Text) && !String.IsNullOrEmpty(txtPais.Text))
                { 
                    try{
                        dynamic per = JObject.Parse(dgListaPersonas.SelectedItem.ToString());
                        string numID = per["num_identificador"].ToString();

                        string id, nombre, apellidoP, apellidoM, direccion, ciudad, pais;
                        id = txtID.Text;
                        nombre = txtNombre.Text;
                        apellidoP = txtApellidoP.Text;
                        apellidoM = txtApellidoM.Text;
                        direccion = txtDireccion.Text;
                        ciudad = txtCiudad.Text;
                        pais = txtPais.Text;
                        Persona persona = new Persona();
                        persona.NumIdentificador = id;
                        persona.Nombre = nombre;
                        persona.ApellidoPaterno = apellidoP;
                        persona.ApellidoMaterno = apellidoM;
                        persona.Ciudad = ciudad;
                        persona.Pais = pais;
                        persona.Direccion = direccion;
                        JsonConvert.SerializeObject(persona);
                        persona.actualizarPersona(numID);
                        MessageBox.Show("Cliente actualizado exitosamente", "Información", MessageBoxButton.OK);
                    }catch (Exception ex){
                        MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Existen campos sin rellenar", "Error al modificar", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            listarPersonas();
            }

        private void btnCargaDatos_Click(object sender, RoutedEventArgs e)
        {
            if (dgListaPersonas.SelectedIndex == -1 || dgListaPersonas.SelectedItem.ToString().Equals("{NewItemPlaceholder}"))
            {
                MessageBox.Show("No hay datos seleccionados, por favor seleccione.");
            }
            else
            {

                dynamic perso = JObject.Parse(dgListaPersonas.SelectedItem.ToString());
                txtApellidoM.Text = perso["apellido_m"].ToString();
                txtApellidoP.Text = perso["apellido_p"].ToString();
                txtCiudad.Text = perso["ciudad"].ToString();
                txtDireccion.Text = perso["direccion"].ToString();
                txtID.Text = perso["num_identificador"].ToString();
                txtNombre.Text = perso["nombre"].ToString();
                txtPais.Text = perso["pais"].ToString();
            }
            
        }

        private void LimpiarCampos()
        {
            txtApellidoM.Text = string.Empty;
            txtApellidoP.Text = string.Empty;
            txtCiudad.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtID.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtPais.Text = string.Empty;
        }
    }
    }

