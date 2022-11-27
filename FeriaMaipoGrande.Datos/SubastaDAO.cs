using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaMaipoGrande.Datos
{
    public class SubastaDAO
    {
        DBApi dbapi = new DBApi();

        private int  carga, total, id_venta;
        private string ganador, estado, fecha_ini, fecha_ter, observaciones;

        public SubastaDAO()
        {
        }

        public SubastaDAO(string ganador, string fecha_ter, string fecha_ini, int carga, int total, string estado, int id_venta, string observaciones)
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

        [JsonProperty("ganador")]
        public string Ganador { get => ganador; set => ganador = value; }
        [JsonProperty("fecha_ter")]
        public string Fecha_ter { get => fecha_ter; set => fecha_ter = value; }
        [JsonProperty("fecha_inicio")]
        public string Fecha_ini { get => fecha_ini; set => fecha_ini = value; }
        [JsonProperty("cargo")]
        public int Carga { get => carga; set => carga = value; }
        [JsonProperty("total")]
        public int Total { get => total; set => total = value; }
        [JsonProperty("estado")]
        public string Estado { get => estado; set => estado = value; }
        [JsonProperty("id_venta")]
        public int Id_venta { get => id_venta; set => id_venta = value; }
        [JsonProperty("observaciones")]
        public string Observaciones { get => observaciones; set => observaciones = value; }

        public dynamic listarSubastasDAO()
        {
            dynamic datos = dbapi.GetSubastas();

            return datos;
        }

        public async void crearSubastasDAO(SubastaDAO subasta)
        {
            await dbapi.CrearSubastaAsync("subastas", subasta);
        }

        public async void actualizarSubastaDAO(string id_subasta, SubastaDAO subasta)
        {
            await dbapi.ActualizarSubastaAsync("subastas/", id_subasta, subasta);
        }

    }
}
