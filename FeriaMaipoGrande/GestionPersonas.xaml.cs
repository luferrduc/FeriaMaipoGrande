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

            /*dgListaPersonas.Columns[0].Header = "ID";
            dgListaPersonas.Columns[0].Header = "Nombre";
            dgListaPersonas.Columns[2].Header = "Apellido P";
            dgListaPersonas.Columns[3].Header = "Apellido M";
            dgListaPersonas.Columns[4].Header = "Dirección";
            dgListaPersonas.Columns[5].Header = "País";
            dgListaPersonas.Columns[6].Header = "Ciudad";
            dgListaPersonas.Columns[7].Header = "Num ID";*/
            dgListaPersonas.ItemsSource = listaPersonas;

        }

        

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (dgListaPersonas.SelectedIndex == -1){
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
                MessageBox.Show("No hay datos seleccionados, por favor seleccione.");
            }
            else
            {
                dynamic persona = JObject.Parse(dgListaPersonas.SelectedItem.ToString());
                string numID = persona["num_identificador"].ToString();
                Persona pers = new Persona();
                pers.eliminarPersona(numID);
                MessageBox.Show("Persona eliminada correctamente.");
                listarPersonas();
            }
            listarPersonas();
        }

        private void ModificarPersona()
        {
            if (dgListaPersonas.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione una persona.");
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

