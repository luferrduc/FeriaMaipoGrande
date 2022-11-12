using FeriaMaipoGrande.Negocio;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
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
    /// Lógica de interacción para GestionVenta.xaml
    /// </summary>
    public partial class GestionVenta : Window
    {
        public GestionVenta()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            listarUsuarios();
            listarVentas();
            DatosCombo();
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
                    int id, idintento, idSalida;
                    string descripcion, id_usuario, estado;
                    id_usuario = txtID.Text;
                    bool resultado1 = Int32.TryParse(id_usuario, out idintento);
                    if (resultado1)
                    {
                        id = idintento;
                        descripcion = txtDescipcion.Text;
                        id_usuario = txtIDUsuario.Text;
                        estado = txtEstado.Text;
                        // comienza a guardar los datos en Ventas
                        //venta.Id = id;
                        venta.Fecha = setFechasDateTimeCrear(DateTime.Now.ToString());
                        venta.Estado = "activa";
                        venta.Descripcion = descripcion;
                        if (cbTipoVenta.Text == "Venta Externa")
                        {
                            venta.Id_tipo_venta = 2;
                        }
                        else
                        {
                            venta.Id_tipo_venta = 1;
                        }
                        bool resultado2 = Int32.TryParse(id_usuario, out idSalida);
                        if (resultado2)
                        {
                            venta.Id_user = idSalida;
                            venta.Total = 0;
                            venta.crearVenta();
                            MessageBox.Show("Venta creada con exito!", "Tarea completada", MessageBoxButton.OK, MessageBoxImage.Information);
                            listarVentas();
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
                ModificarVenta();
                listarVentas();
                listarUsuarios();
            }
            LimpiarCampos();
            listarUsuarios();
            listarVentas();
        }

        public void ModificarVenta()
        {
            if (dgListaVentas.SelectedIndex == -1 || dgListaVentas.SelectedItem.ToString().Equals("{NewItemPlaceholder}"))
            {
                MessageBox.Show("Seleccione una subasta.", "Información", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                //validacion para que ni un campo esté vacío
                if (!String.IsNullOrEmpty(txtID.Text) && !String.IsNullOrEmpty(txtEstado.Text) && !String.IsNullOrEmpty(txtID.Text) && !String.IsNullOrEmpty(txtIDUsuario.Text)
                    && !String.IsNullOrEmpty(cbTipoVenta.Text))
                {
                    try
                    {
                        dynamic ventasLista = JObject.Parse(dgListaVentas.SelectedItem.ToString());
                        string id_subasta = ventasLista["id_venta"];

                        string id_venta, estado, descripcion, id_usuario, tipoVenta;
                        Venta venta = new Venta();

                        id_usuario = txtIDUsuario.Text;
                        id_venta = txtID.Text;
                        estado = txtEstado.Text;
                        descripcion = txtDescipcion.Text;
                        if (cbTipoVenta.Text == "Venta Externa")
                        {
                            tipoVenta = "2";
                        }
                        else
                        {
                            tipoVenta = "1";
                        }
                        //Validacion en que sean valores numericos
                        bool resultado1 = int.TryParse(tipoVenta, out int result1);
                        bool resultado2 = int.TryParse(id_usuario, out int result2);
                        if (resultado1)
                        {
                            if (resultado2)
                            {
                                venta.Estado = estado;
                                venta.Descripcion = descripcion;
                                venta.Id_tipo_venta = result1;
                                venta.Id_user = result2;
                                string fecha = ventasLista["fecha_venta"];
                                venta.Fecha = setFechasDateTimeModificar(fecha);
                                venta.Total = ventasLista["total_venta"];

                                JsonConvert.SerializeObject(venta);
                                venta.actualizarVenta(id_subasta);
                                listarUsuarios();
                                listarVentas();
                                MessageBox.Show("Se ha actualizado la venta correctamente", "Tarea completada", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                            else
                            {
                                MessageBox.Show("El id de usuario debe ser numerico", "Datos incorrectos", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("El id de venta debe ser numerico", "Datos incorrectos", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        //Se serializan y luego se invoca el metodo crear subasta.
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Debe completar los campos para añadir una venta", "Datos faltantes", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }


        public void listarUsuarios()
        {
            Usuario user = new Usuario();
            dynamic usuarios = user.listarUsuarios();
            dgListaUsuarios.ItemsSource = usuarios;
        }

        public void listarVentas()
        {
            Venta venta = new Venta();
            dynamic lista = venta.listarVentas();
            dgListaVentas.ItemsSource = lista;
        }

        public void LimpiarCampos()
        {
            txtDescipcion.Text = string.Empty;
            txtEstado.Text = string.Empty;
            txtID.Text = string.Empty;
            txtIDUsuario.Text = string.Empty;
            cbTipoVenta.Text = string.Empty;
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        public string setFechasDateTimeModificar(string fecha)
        {
            string mm, dd, yyyy, formato_fecha;
            //Se separa el formato de la fecha y luego se muestra
            //el formato el cual acepta la base de datos: YYYY/DD/MM
            dd = fecha.Substring(0, 2);
            mm = fecha.Substring(3, 2);
            yyyy = fecha.Substring(6, 4);

            formato_fecha = string.Concat(yyyy, "-", dd, "-", mm);
            return formato_fecha;
        }

        public string setFechasDateTimeCrear(string fecha)
        {
            string mm, dd, yyyy, formato_fecha;
            //Se separa el formato de la fecha y luego se muestra
            //el formato el cual acepta la base de datos: YYYY/DD/MM
            dd = fecha.Substring(0, 2);
            mm = fecha.Substring(3, 2);
            yyyy = fecha.Substring(6, 4);

            formato_fecha = string.Concat(yyyy, "-", mm, "-", dd);
            return formato_fecha;
        }

        private void btnTerminarProceso_Click(object sender, RoutedEventArgs e)
        {
            Venta venta = new Venta();
            dynamic listaVentas = JObject.Parse(dgListaVentas.SelectedItem.ToString());
            if (dgListaVentas.SelectedIndex == -1 || dgListaVentas.SelectedItem.ToString().Equals("{NewItemPlaceholder}"))
            {
                MessageBox.Show("Seleccione una venta.", "Información", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                MessageBoxResult resultado = MessageBox.Show("¿Está seguro que desea finalizar esta venta?", "Alerta", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (resultado == MessageBoxResult.Yes)
                {

                    string descripcion, total_venta, id_tipo_venta, id_usuario, fecha_venta, estado, id_venta, fec_venta;
                    dynamic listaTotalVentas = JObject.Parse(dgListaVentas.SelectedItem.ToString());
                    id_venta = listaTotalVentas["id_venta"];
                    id_usuario = listaTotalVentas["id_usuario"];
                    estado = "Finalizada";
                    descripcion = listaTotalVentas["descripcion"];
                    fecha_venta = listaTotalVentas["fecha_venta"];
                    fec_venta = venta.setFechasDateTime(fecha_venta.ToString());
                    id_tipo_venta = listaTotalVentas["id_tipo_venta"];
                    total_venta = listaTotalVentas["total_venta"];

                    venta.Descripcion = descripcion;
                    venta.Estado = estado;
                    venta.Fecha = fec_venta;
                    venta.Id_tipo_venta = int.Parse(id_tipo_venta);
                    venta.Total = int.Parse(total_venta);
                    venta.Estado = estado;
                    venta.Id_user = int.Parse(id_usuario);

                    venta.actualizarVenta(id_venta);

                    MessageBox.Show("venta finalizada correctamente.", "Registro modificado", MessageBoxButton.OK, MessageBoxImage.Information);
                    listarVentas();
                }
            }
            listarVentas();
        }

        public void DatosCombo()
        {
            cbTipoVenta.Items.Add("Venta Interna");
            cbTipoVenta.Items.Add("Venta Externa");
        }

        private void btnCargarDatos_Click(object sender, RoutedEventArgs e)
        {
            dynamic listaVentas = JObject.Parse(dgListaVentas.SelectedItem.ToString());
            if (dgListaVentas.SelectedIndex == -1 || dgListaVentas.SelectedItem.ToString().Equals("{NewItemPlaceholder}"))
            {
                MessageBox.Show("Seleccione una venta.", "Información", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                string descripcion, id_usuario, estado, id_venta;
                dynamic listaTotalVentas = JObject.Parse(dgListaVentas.SelectedItem.ToString());
                id_venta = listaTotalVentas["id_venta"];
                id_usuario = listaTotalVentas["id_usuario"];
                estado = listaTotalVentas["estado"];
                descripcion = listaTotalVentas["descripcion"];

                txtDescipcion.Text = descripcion;
                txtEstado.Text = estado;
                txtID.Text = id_venta;
                txtIDUsuario.Text = id_usuario;
                if (listaTotalVentas["id_tipo_venta"] == 1)
                {
                    cbTipoVenta.Text = "Venta Interna";
                }
                else
                {
                    cbTipoVenta.Text = "Venta Externa";
                }
            }
        }

    }
}
