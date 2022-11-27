using FeriaMaipoGrande.Datos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FeriaMaipoGrande.Negocio
{
    public class Subasta
    {
        private int carga, total, id_venta;
        private string ganador,estado, fecha_ini, fecha_ter, observaciones;

        public Subasta()
        {
        }

        public Subasta(string ganador, string fecha_ter, string fecha_ini, int carga, int total, string estado, int id_venta, string observaciones)
        {
            Ganador = ganador;
            Fecha_ter = fecha_ter;
            Fecha_ini = fecha_ini;
            Carga = carga;
            Total = total;
            Estado = estado;
            Id_venta = id_venta;
            Observaciones = observaciones;
        }

        public int Carga { get => carga; set => carga = value; }
        public int Total { get => total; set => total = value; }
        public int Id_venta { get => id_venta; set => id_venta = value; }
        public string Ganador { get => ganador; set => ganador = value; }
        public string Estado { get => estado; set => estado = value; }
        public string Fecha_ini { get => fecha_ini; set => fecha_ini = value; }
        public string Fecha_ter { get => fecha_ter; set => fecha_ter = value; }
        public string Observaciones { get => observaciones; set => observaciones = value; }

        public dynamic listarSubastas()
        {
            SubastaDAO subastaDAO = new SubastaDAO();
            dynamic listaSubasta = subastaDAO.listarSubastasDAO();

            return listaSubasta;
        }

        public dynamic listarDetalleSubastas(int id)
        {
            SubastaDAO subastaDAO = new SubastaDAO();
            dynamic listaSubasta = subastaDAO.listarDetalleSubasta(id);

            return listaSubasta;
        }

        public void crearSubasta()
        {
            SubastaDAO subastaDAO = new SubastaDAO();
            subastaDAO.Carga = Carga;
            subastaDAO.Id_venta = Id_venta;
            subastaDAO.Estado = Estado;
            subastaDAO.Fecha_ini = Fecha_ini;
            subastaDAO.Fecha_ter = Fecha_ter;
            subastaDAO.Ganador = Ganador;
            subastaDAO.Total = Total;
            subastaDAO.Observaciones = Observaciones;

            subastaDAO.crearSubastasDAO(subastaDAO);
        }

        public void actualizarSubasta(string id_subasta)
        {
            SubastaDAO subastaDAO = new SubastaDAO();
            subastaDAO.Carga = Carga;
            subastaDAO.Id_venta = Id_venta;
            subastaDAO.Estado = Estado;
            subastaDAO.Fecha_ini = Fecha_ini;
            subastaDAO.Fecha_ter = Fecha_ter;
            subastaDAO.Ganador = Ganador;
            subastaDAO.Total = Total;
            subastaDAO.Observaciones = Observaciones;

            subastaDAO.actualizarSubastaDAO(id_subasta, subastaDAO);
        }

        public string getFechas(string fecha)
        {
            
            string dd, mm, yyyy, formato_fecha;

            //Se separa el formato de la fecha, y luego se muestra
            //el formato local: DD/MM/YYYY
            mm = fecha.Substring(0, 2);
            dd = fecha.Substring(3, 3);
            yyyy = fecha.Substring(5, 5);

            formato_fecha = string.Concat(dd, mm, yyyy);

            return formato_fecha;
        }


        public bool esFecha(string fecha)
        {
            try
            {
                int cantidad;
                cantidad = fecha.Count();
                if (cantidad == 10)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

    }
}
