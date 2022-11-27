using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaMaipoGrande.Datos
{
    public class VentaDAO
    {
        DBApi dbapi = new DBApi();
        private int id, total, id_user, id_tipo_venta;
        private string fecha, estado, descripcion;

        public VentaDAO(int id, int total, int id_user, int id_tipo_venta, string fecha, string estado, string descripcion)
        {
            //Id = id;
            Total = total;
            Id_user = id_user;
            Id_tipo_venta = id_tipo_venta;
            Fecha = fecha;
            Estado = estado;
            Descripcion = descripcion;
        }

        public VentaDAO()
        {
        }
        [JsonProperty("descripcion")]
        public string Descripcion { get => descripcion; set => descripcion = value; }
        [JsonProperty("total_venta")]
        public int Total { get => total; set => total = value; }
        [JsonProperty("id_tipo_venta")]
        public int Id_tipo_venta { get => id_tipo_venta; set => id_tipo_venta = value; }
        [JsonProperty("id_usuario")]
        public int Id_user { get => id_user; set => id_user = value; }
        [JsonProperty("fecha_venta")]
        public string Fecha { get => fecha; set => fecha = value; }
        [JsonProperty("estado")]
        public string Estado { get => estado; set => estado = value; }

        public dynamic listarVentaDAO()
        {
            dynamic datos = dbapi.GetVentas();

            return datos;
        }

        public async void eliminarVentaDAO(string id_venta)
        {
            await dbapi.DeleteVentaAsync("ventas/", id_venta);
        }

        public async void crearVentaDAO(VentaDAO venta)
        {
            await dbapi.CrearVentaAsync("ventas/", venta);
        }

        public async void actualizarVentaDAO(string id_venta, VentaDAO venta)
        {
            await dbapi.ActualizarVentaAsync("ventas/", id_venta, venta);
        }



    }
}

