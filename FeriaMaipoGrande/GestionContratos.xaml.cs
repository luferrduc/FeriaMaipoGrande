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
    /// Lógica de interacción para GestionContratos.xaml
    /// </summary>
    public partial class GestionContratos : Window
    {
        public GestionContratos()
        {
            InitializeComponent();
            listarContratos();
            DatosCombo();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void listarContratos()
        {
            Contrato contrato = new Contrato();
            dynamic listarContratos = contrato.listarContratos();
            try
            {
                dgListaContratos.ItemsSource = listarContratos;
            }
            catch(Exception e)
            {
                MessageBox.Show("No se ha podido establecer una conexión con el servidor.", "Error de conexión al servidor.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
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

        

        public void DatosCombo()
        {
            cbTipoContrato.Items.Add("Contrato Interno");
            cbTipoContrato.Items.Add("Contrato Externo");
        }

        private void btnPublicar_Click(object sender, RoutedEventArgs e)
        {
            if (dgListaContratos.SelectedIndex == -1)
            {
                if (!String.IsNullOrEmpty(txtEstado.Text) && !String.IsNullOrEmpty(txtObservacion.Text) &&
                    !String.IsNullOrEmpty(txtID.Text) && !String.IsNullOrEmpty(txtIdPersona.Text) && !String.IsNullOrEmpty(txtArchivo.Text)
                    && !String.IsNullOrEmpty(dtInicio.Text) && !String.IsNullOrEmpty(dtTermino.Text))
                {
                    string fec_ini, fec_ter, estado, id_persona, archivo, observacion, tipo_contrato;
                    bool parseo;
                    id_persona = txtIdPersona.Text;
                    archivo = txtArchivo.Text;
                    fec_ini = dtInicio.Text;
                    fec_ter = dtTermino.Text;
                    string fecha_inicio = setFechasDateTimeCrear(fec_ini);
                    string fecha_termino = setFechasDateTimeCrear(fec_ter);
                    estado = txtEstado.Text;
                    observacion = txtObservacion.Text;
                    if (cbTipoContrato.Text == "Contrato Externo")
                    {
                        tipo_contrato = "1";
                    }
                    else
                    {
                        tipo_contrato = "2";
                    }
                    Contrato contrato = new Contrato();
                    parseo = int.TryParse(id_persona, out int idPersonaNumero);
                    if(parseo == true)
                    {
                        
                        contrato.Id_persona = idPersonaNumero;
                        contrato.Fec_ini = fecha_inicio;
                        contrato.Fec_ter = fecha_termino;
                        contrato.Estado = estado;
                        contrato.Observaciones = observacion;
                        contrato.Arch_cont = archivo;
                        contrato.Id_tipo_contrato = int.Parse(tipo_contrato);
                        JsonConvert.SerializeObject(contrato);
                        contrato.crearContrato();
                        listarContratos();
                        MessageBox.Show("Se ha creado la persona correctamente", "Tarea completada", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Numero de persona no numerico, intente nuevamente.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    
                }
                else
                {
                    MessageBox.Show("Debe completar los campos para añadir un contrato", "Datos faltantes", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                ModificarContrato();
            }
            LimpiarCampos();
            listarContratos();
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mw = new MainWindow();
            mw.Show();
            this.Close();
        }

        private string getFechasLista(string fecha)
        {
            string fechaLista, mm, dd, yy;
            mm = fecha.Substring(0, 2);
            dd = fecha.Substring(3, 2);
            yy = fecha.Substring(6, 4);
            fechaLista = String.Concat(dd,"/",mm,"/",yy);
            return fechaLista;
        }

        private void CargarDatos()
        {
            if (dgListaContratos.SelectedIndex == -1 || dgListaContratos.SelectedItem.ToString().Equals("{NewItemPlaceholder}"))
            {
                MessageBox.Show("Seleccione un contrato.", "Información", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else
            {
                txtID.IsEnabled = false;
                string fec_ini, fec_ter, estado, id_persona, archivo, observacion, tipo_contrato, id_contrato,fec_iniLista, fec_terLista;
                dynamic listaContratos = JObject.Parse(dgListaContratos.SelectedItem.ToString());
                id_contrato = listaContratos["id_contrato"];
                fec_iniLista = listaContratos["fecha_inicio"];
                fec_terLista = listaContratos["fecha_termino"];
                fec_ini = getFechasLista(fec_iniLista);
                fec_ter = getFechasLista(fec_terLista);
                estado = listaContratos["estado"];
                observacion = listaContratos["observaciones"];
                id_persona = listaContratos["id_persona"];
                archivo = listaContratos["arch_cont"];
                tipo_contrato = listaContratos["id_tipo_contrato"];

                txtArchivo.Text = archivo;
                txtEstado.Text = estado;
                txtID.Text = id_contrato;
                txtIdPersona.Text = id_persona;
                txtObservacion.Text = observacion;
                dtInicio.Text = fec_ini;
                dtTermino.Text = fec_ter;
                if (listaContratos["id_tipo_contrato"] == 1)
                {
                    cbTipoContrato.Text = "Contrato Interno";
                }
                else
                {
                    cbTipoContrato.Text = "Contrato Externo";
                }
            }
        }

        private void ModificarContrato()
        {
            if (dgListaContratos.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un contrato.", "Información", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
            else
            {
                if (!String.IsNullOrEmpty(txtEstado.Text) && !String.IsNullOrEmpty(txtObservacion.Text) &&
                    !String.IsNullOrEmpty(txtID.Text) && !String.IsNullOrEmpty(txtIdPersona.Text) && !String.IsNullOrEmpty(txtArchivo.Text)
                    && !String.IsNullOrEmpty(dtInicio.Text) && !String.IsNullOrEmpty(dtTermino.Text))
                {
                    try
                    {
                        dynamic cont = JObject.Parse(dgListaContratos.SelectedItem.ToString());
                        string numContrato = cont["id_contrato"].ToString();

                        string fec_ini, fec_ter, estado, id_persona, archivo, observacion, tipo_contrato;
                        bool parseo;
                        id_persona = txtIdPersona.Text;
                        archivo = txtArchivo.Text;
                        fec_ini = dtInicio.Text;
                        fec_ter = dtTermino.Text;
                        string fecha_inicio = setFechasDateTimeModificar(fec_ini);
                        string fecha_termino = setFechasDateTimeModificar(fec_ter);
                        estado = txtEstado.Text;
                        observacion = txtObservacion.Text;
                        if (cbTipoContrato.Text == "Contrato Externo")
                        {
                            tipo_contrato = "1";
                        }
                        else
                        {
                            tipo_contrato = "2";
                        }
                        Contrato contrato = new Contrato();
                        parseo = int.TryParse(id_persona, out int idPersonaNumero);
                        if (parseo)
                        {
                            contrato.Id_persona = idPersonaNumero;
                            contrato.Fec_ini = fecha_inicio;
                            contrato.Fec_ter = fecha_termino;
                            contrato.Estado = estado;
                            contrato.Observaciones = observacion;
                            contrato.Arch_cont = archivo;
                            contrato.Id_tipo_contrato = int.Parse(tipo_contrato);
                            JsonConvert.SerializeObject(contrato);
                            contrato.actualizarContrato(numContrato);
                            MessageBox.Show("Se ha actualizado el contrato correctamente", "Tarea completada", MessageBoxButton.OK, MessageBoxImage.Information);
                            LimpiarCampos();
                        }
                        else
                        {
                            MessageBox.Show("Numero de contrato no numerico, intente nuevamente.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    catch
                    {

                    }
                    

                }
                else
                {
                    MessageBox.Show("Debe completar los campos para añadir un contrato", "Datos faltantes", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        private void btnCargarDatos_Click(object sender, RoutedEventArgs e)
        {
            CargarDatos();
        }

        private void LimpiarCampos()
        {
            txtArchivo.Text = string.Empty;
            txtEstado.Text = string.Empty;
            txtID.Text = string.Empty;
            txtIdPersona.Text = string.Empty;
            txtObservacion.Text = string.Empty;
            dtInicio.Text = string.Empty;
            dtTermino.Text = string.Empty;
            cbTipoContrato.Text = string.Empty;
            txtID.IsEnabled = true;
        }

        public string setFechas(string fecha)
        {
            string mm, dd, yyyy, formato_fecha;
            //Se separa el formato de la fecha y luego se muestra
            //el formato el cual acepta la base de datos: YYYY/MM/DD
            dd = fecha.Substring(0, 2);
            mm = fecha.Substring(2, 2);
            yyyy = fecha.Substring(6, 4);

            formato_fecha = string.Concat(yyyy, "-", dd, "-", mm);
            return formato_fecha;
        }

        public string setFechasDateTimeModificar(string fecha)
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

        public string setFechaDateTimeTerminar(string fecha)
        {
            string mm, dd, yyyy, formato_fecha;
            //Se separa el formato de la fecha y luego se muestra
            //el formato el cual acepta la base de datos: YYYY/MM/DD
            dd = fecha.Substring(0, 2);
            mm = fecha.Substring(2, 2);
            yyyy = fecha.Substring(6, 4);

            formato_fecha = string.Concat(yyyy, "-", mm, "-", dd);
            return formato_fecha;
        }


        private void btnTerminarProceso_Click(object sender, RoutedEventArgs e)
        {
            if (dgListaContratos.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un contrato.", "Información", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
            else
            {
                Contrato contrato = new Contrato();
                dynamic cont = JObject.Parse(dgListaContratos.SelectedItem.ToString());
                string numContrato = cont["id_contrato"].ToString();

                string fec_ini, fec_ter, estado, id_persona, archivo, observacion, tipo_contrato, id_contrato, mantenedorFechaLista, fecha_inicio, fecha_termino;
                bool parseo;
                id_contrato = cont["id_contrato"];
                mantenedorFechaLista = cont["fecha_inicio"];
                fec_ini = contrato.getFechas(mantenedorFechaLista.ToString());
                fecha_inicio = setFechas(fec_ini);
                fec_ter = contrato.getFechas(DateTime.Now.ToString());
                fecha_termino = setFechaDateTimeTerminar(fec_ter);
                estado = "Finalizado";
                observacion = cont["observaciones"];
                id_persona = cont["id_persona"];
                archivo = cont["arch_cont"];
                if (cbTipoContrato.Text == "Contrato Externo")
                {
                    tipo_contrato = "1";
                }
                else
                {
                    tipo_contrato = "2";
                }
                parseo = int.TryParse(id_persona, out int idPersonaNumero);
                MessageBoxResult respuesta = MessageBox.Show("¿Está seguro de modificar el contrato?", "Alerta", MessageBoxButton.OKCancel, MessageBoxImage.Exclamation);
                if(respuesta == MessageBoxResult.OK)
                {
                    if (parseo)
                    {
                        contrato.Id_persona = idPersonaNumero;
                        contrato.Fec_ini = fecha_inicio;
                        contrato.Fec_ter = fecha_termino;
                        contrato.Estado = estado;
                        contrato.Observaciones = observacion;
                        contrato.Arch_cont = archivo;
                        contrato.Id_tipo_contrato = int.Parse(tipo_contrato);
                        JsonConvert.SerializeObject(contrato);
                        contrato.actualizarContrato(numContrato);
                        MessageBox.Show("El contrato se ha modificado correctamente", "Tarea completada", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("Numero de contrato no numerico, intente nuevamente.", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
                
            listarContratos();
        }
    }
}
