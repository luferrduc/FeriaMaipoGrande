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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FeriaMaipoGrande
{
    /// <summary>
    /// Lógica de interacción para GestionSubastas.xaml
    /// </summary>
    public partial class GestionSubastas : UserControl
    {
        public GestionSubastas()
        {
            InitializeComponent();
            listarSubastas();
        }

        private void listarSubastas()
        {
            Subasta subasta = new Subasta();
            dynamic listaSubasta = subasta.listarSubastas();
            try
            {
                dgListaVentas.ItemsSource = listaSubasta;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No se puede listar las subastas, debido a problemas con el servidor.", "Problemas con el servidor.", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void btnPublicar_Click(object sender, RoutedEventArgs e)
        {
            if (dgListaVentas.SelectedIndex == -1 || dgListaVentas.SelectedItem.ToString().Equals("{NewItemPlaceholder}"))
            {
                //validacion para que ni un campo esté vacío
                if (!String.IsNullOrEmpty(txtID.Text) && !String.IsNullOrEmpty(txtCargo.Text) && !String.IsNullOrEmpty(dtTermino.Text)
                    && !String.IsNullOrEmpty(txtTotal.Text) && !String.IsNullOrEmpty(dtInicio.Text) && !String.IsNullOrEmpty(txtObservacion.Text))
                {
                    Subasta subasta = new Subasta();
                    if (subasta.esFecha(dtInicio.Text).Equals(true) || subasta.esFecha(dtTermino.Text).Equals(true))
                    {
                        string estado, fecha_termino, fecha_inicio, id_venta, cargo, total, ganador, observacion;

                        id_venta = txtID.Text;
                        estado = txtEstado.Text;
                        total = txtTotal.Text;
                        fecha_inicio = setFechas(dtInicio.Text);
                        ganador = txtGanador.Text;
                        fecha_termino = setFechas(dtTermino.Text);
                        cargo = txtCargo.Text;
                        observacion = txtObservacion.Text;

                        //Validacion en que sean valores numericos
                        bool resultado1 = int.TryParse(id_venta, out int result1);
                        bool resultado2 = int.TryParse(total, out int result2);
                        bool resultado3 = int.TryParse(cargo, out int result3);
                        if (resultado1)
                        {
                            if (resultado2)
                            {
                                if (resultado3)
                                {
                                    //Se envian los datos a la clase subasta
                                    subasta.Id_venta = result1;
                                    subasta.Carga = result3;
                                    subasta.Ganador = ganador;
                                    subasta.Fecha_ini = fecha_inicio;
                                    subasta.Fecha_ter = fecha_termino;
                                    subasta.Total = result2;
                                    subasta.Estado = estado;
                                    subasta.Observaciones = observacion;

                                    JsonConvert.SerializeObject(subasta);
                                    subasta.crearSubasta();
                                    listarSubastas();
                                    MessageBox.Show("Se ha creado la subasta correctamente", "Tarea completada", MessageBoxButton.OK, MessageBoxImage.Information);
                                }
                                else
                                {
                                    MessageBox.Show("El Id de venta debe ser numerico", "Datos incorrectos", MessageBoxButton.OK, MessageBoxImage.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show("El total debe ser numerico", "Datos incorrectos", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("El cargo debe ser numerico", "Datos incorrectos", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        //Se serializan y luego se invoca el metodo crear subasta.

                    }
                    else
                    {
                        MessageBox.Show("La fecha ingresada no es válida, ingresela nuevamente en formato DD/MM/AAAA", "Fecha incorrecta", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Debe completar los campos para añadir una subasta", "Datos faltantes", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                ModificarSubasta();
                LimpiarCampos();
                listarSubastas();
            }
            listarSubastas();
        }

        private void btnTerminarProceso_Click(object sender, RoutedEventArgs e)
        {
            if (dgListaVentas.SelectedIndex == -1 || dgListaVentas.SelectedItem.ToString().Equals("{NewItemPlaceholder}"))
            {
                MessageBox.Show("No hay datos seleccionados, por favor seleccione.", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBoxResult resultado = MessageBox.Show("¿Está seguro que desea finalizar esta subasta?", "Alerta", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                if (resultado == MessageBoxResult.Yes)
                {
                    Subasta subasta = new Subasta();
                    string estado, fecha_termino, fecha_inicio, id_venta, cargo, total, ganador, observacion, fec_ter, fec_ini, mantenedorFechaLista, id_subasta;
                    dynamic listaSubasta = JObject.Parse(dgListaVentas.SelectedItem.ToString());
                    id_subasta = listaSubasta["id_subasta"];
                    id_venta = listaSubasta["id_venta"];
                    cargo = listaSubasta["cargo"];
                    estado = "Finalizada";
                    observacion = listaSubasta["observaciones"];
                    ganador = listaSubasta["ganador"];
                    mantenedorFechaLista = listaSubasta["fecha_inicio"];
                    fec_ini = subasta.getFechas(mantenedorFechaLista.ToString());
                    fecha_inicio = setFechas(fec_ini);
                    fec_ter = subasta.getFechas(DateTime.Now.ToString());
                    fecha_termino = setFechasDateTime(fec_ter);
                    total = listaSubasta["total"];

                    subasta.Id_venta = int.Parse(id_venta);
                    subasta.Carga = int.Parse(cargo);
                    subasta.Fecha_ini = (fecha_inicio);
                    subasta.Fecha_ter = (fecha_termino);
                    subasta.Total = int.Parse(total);
                    subasta.Estado = estado;
                    subasta.Ganador = ganador;
                    subasta.Observaciones = observacion;
                    subasta.actualizarSubasta(id_subasta);
                    MessageBox.Show("Subasta finalizada correctamente.", "Registro modificado", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            listarSubastas();
        }

        public string setFechas(string fecha)
        {
            string mm, dd, yyyy, formato_fecha;
            //Se separa el formato de la fecha y luego se muestra
            //el formato el cual acepta la base de datos: YYYY/MM/DD
            dd = fecha.Substring(0, 2);
            mm = fecha.Substring(3, 2);
            yyyy = fecha.Substring(6, 4);

            formato_fecha = string.Concat(yyyy, "-", mm, "-", dd);
            return formato_fecha;
        }

        public string setFechasDateTime(string fecha)
        {
            string mm, dd, yyyy, formato_fecha;
            //Se separa el formato de la fecha y luego se muestra
            //el formato el cual acepta la base de datos: YYYY/DD/MM
            mm = fecha.Substring(0, 2);
            dd = fecha.Substring(3, 2);
            yyyy = fecha.Substring(6, 4);

            formato_fecha = string.Concat(yyyy, "-", mm, "-", dd);
            return formato_fecha;
        }


        private void ModificarSubasta()
        {
            if (dgListaVentas.SelectedIndex == -1 || dgListaVentas.SelectedItem.ToString().Equals("{NewItemPlaceholder}"))
            {
                MessageBox.Show("Seleccione una subasta.", "Información", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                //validacion para que ni un campo esté vacío
                if (!String.IsNullOrEmpty(txtID.Text) && !String.IsNullOrEmpty(txtGanador.Text) && !String.IsNullOrEmpty(txtCargo.Text) && !String.IsNullOrEmpty(dtTermino.Text)
                    && !String.IsNullOrEmpty(txtTotal.Text) && !String.IsNullOrEmpty(dtInicio.Text))
                {
                    try
                    {
                        dynamic subastaLista = JObject.Parse(dgListaVentas.SelectedItem.ToString());
                        string id_subasta = subastaLista["id_subasta"];

                        string estado, fecha_termino, fecha_inicio, id_venta, cargo, total, observacion, ganador;
                        Subasta subasta = new Subasta();

                        if (subasta.esFecha(dtInicio.Text).Equals(true))
                        {
                            id_venta = txtID.Text;
                            estado = txtEstado.Text;
                            total = txtTotal.Text;
                            fecha_inicio = setFechas(dtInicio.Text);
                            fecha_termino = setFechas(dtTermino.Text);
                            cargo = txtCargo.Text;
                            ganador = txtGanador.Text;
                            observacion = txtObservacion.Text;
                            //Validacion en que sean valores numericos
                            bool resultado1 = int.TryParse(id_venta, out int result1);
                            bool resultado2 = int.TryParse(total, out int result2);
                            bool resultado3 = int.TryParse(cargo, out int result3);
                            if (resultado1)
                            {
                                if (resultado2)
                                {
                                    if (resultado3)
                                    {
                                        //Se envian los datos a la clase subasta
                                        subasta.Id_venta = result1;
                                        subasta.Carga = result3;
                                        subasta.Fecha_ini = (fecha_inicio);
                                        subasta.Fecha_ter = (fecha_termino);
                                        subasta.Total = result2;
                                        subasta.Estado = estado;
                                        subasta.Ganador = ganador;
                                        subasta.Observaciones = observacion;
                                        //Se serializan y luego se invoca el metodo crear subasta.
                                        JsonConvert.SerializeObject(subasta);
                                        subasta.actualizarSubasta(id_subasta);

                                        MessageBox.Show("Se ha actualizado la subasta correctamente", "Tarea completada", MessageBoxButton.OK, MessageBoxImage.Information);
                                    }
                                    else
                                    {
                                        MessageBox.Show("El Id de venta debe ser numerico", "Datos incorrectos", MessageBoxButton.OK, MessageBoxImage.Information);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("El total debe ser numerico", "Datos incorrectos", MessageBoxButton.OK, MessageBoxImage.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show("El cargo debe ser numerico", "Datos incorrectos", MessageBoxButton.OK, MessageBoxImage.Information);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString(), "Error", MessageBoxButton.OK);
                    }
                }
                else
                {
                    MessageBox.Show("Debe completar los campos para añadir una subasta", "Datos faltantes", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void LimpiarCampos()
        {
            txtGanador.Text = string.Empty;
            txtCargo.Text = string.Empty;
            txtEstado.Text = string.Empty;
            txtID.Text = string.Empty;
            txtTotal.Text = string.Empty;
            dtInicio.Text = string.Empty;
            dtTermino.Text = string.Empty;
            txtObservacion.Text = string.Empty;
            txtID.IsEnabled = true;
        }

        private void btnCargarDatos_Click(object sender, RoutedEventArgs e)
        {
            if (dgListaVentas.SelectedIndex == -1 || dgListaVentas.SelectedItem.ToString().Equals("{NewItemPlaceholder}"))
            {
                MessageBox.Show("No hay datos seleccionados, por favor seleccione.", "Información", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                dynamic subasta = JObject.Parse(dgListaVentas.SelectedItem.ToString());
                txtCargo.Text = subasta["cargo"];
                txtEstado.Text = subasta["estado"];
                txtGanador.Text = subasta["ganador"];
                txtID.Text = subasta["id_venta"];
                txtTotal.Text = subasta["total"];
                txtID.IsEnabled = false;
                //Se separa la fecha, esto con el fin de poder dar un formato correcto
                //Formato: MM/DD/YYYY
                string fecha_inicio, fecha_termino;
                fecha_inicio = subasta["fecha_inicio"];
                fecha_termino = subasta["fecha_ter"];
                //Se quitan los valores de hora, debido a que no se trabaja con estos
                string resultado1 = fecha_inicio.Substring(0, 10);
                string resultado2 = fecha_termino.Substring(0, 10);
                //Se usa la función getFechas la cual devuelve la fecha en el formato local
                Subasta sub = new Subasta();
                dtInicio.Text = sub.getFechas(resultado1);
                dtTermino.Text = sub.getFechas(resultado2);
                txtObservacion.Text = subasta["observaciones"];
            }
        }
    }
}
