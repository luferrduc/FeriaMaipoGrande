using FeriaMaipoGrande.Datos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FeriaMaipoGrande.Negocio
{
    public class Venta
    {
        private int id, total, id_user, id_tipo_venta;
        private string fecha, estado, descripcion;

        public Venta(int id, int total, int id_user, int id_tipo_venta, string fecha, string estado, string descripcion)
        {
            //Id = id;
            Total = total;
            Id_user = id_user;
            Id_tipo_venta = id_tipo_venta;
            Fecha = fecha;
            Estado = estado;
            Descripcion = descripcion;
        }

        public Venta()
        {
        }

        //public int Id { get => id; set => id = value; }

        public int Total { get => total; set => total = value; }

        public int Id_user { get => id_user; set => id_user = value; }

        public int Id_tipo_venta { get => id_tipo_venta; set => id_tipo_venta = value; }

        public string Fecha { get => fecha; set => fecha = value; }

        public string Estado { get => estado; set => estado = value; }

        public string Descripcion { get => descripcion; set => descripcion = value; }

        public dynamic listarVentas()
        {
            VentaDAO venta = new VentaDAO();
            dynamic listaVentas = venta.listarVentaDAO();
            return listaVentas;
        }

        public dynamic listarUsuarios()
        {
            UsuarioDAO user = new UsuarioDAO();
            dynamic listarUser = user.listarUsuariosDAO();
            return listarUser;
        }

        public void crearVenta()
        {
            VentaDAO venta = new VentaDAO();
            venta.Descripcion = Descripcion;
            venta.Estado = estado;
            venta.Id_tipo_venta = Id_tipo_venta;
            venta.Total = Total;
            venta.Fecha = Fecha;
            venta.Id_user = Id_user;
            //venta.Id = Id;

            venta.crearVentaDAO(venta);
        }

        public void eliminarVenta(string id_venta)
        {
            VentaDAO venta = new VentaDAO();
            venta.eliminarVentaDAO(id_venta);
        }

        public void actualizarVenta(string id_venta)
        {
            VentaDAO venta = new VentaDAO();
            venta.Descripcion = Descripcion;
            venta.Estado = estado;
            venta.Id_tipo_venta = Id_tipo_venta;
            venta.Total = Total;
            venta.Fecha = Fecha;
            venta.Id_user = Id_user;
            //venta.Id = Id;

            venta.actualizarVentaDAO(id_venta, venta);
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

    }
}
