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

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            dynamic persona = JObject.Parse(dgListaPersonas.SelectedItem.ToString());
            string numID = persona["num_identificador"].ToString();
            Persona pers = new Persona();
            pers.eliminarPersona(numID);
            listarPersonas();
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
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
            string personaJson = JsonConvert.SerializeObject(persona);
            MessageBox.Show(personaJson);
            persona.crearPersona();
            listarPersonas();
        }
    }
}
