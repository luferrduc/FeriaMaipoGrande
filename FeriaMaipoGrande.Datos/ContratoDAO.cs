using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaMaipoGrande.Datos
{
    public class ContratoDAO
    {
        DBApi dbapi = new DBApi();

        string fec_ini, fec_ter, estado, observaciones, arch_cont;
        int id_tipo_contrato, id_persona;

        public ContratoDAO(string fec_ini, string fec_ter, string estado, string observaciones, string arch_cont, int id_tipo_contrato, int id_persona)
        {
            Fec_ini = fec_ini;
            Fec_ter = fec_ter;
            Estado = estado;
            Observaciones = observaciones;
            Arch_cont = arch_cont;
            Id_tipo_contrato = id_tipo_contrato;
            Id_persona = id_persona;
        }

        public ContratoDAO()
        {

        }

        [JsonProperty("fecha_inicio")]
        public string Fec_ini { get => fec_ini; set => fec_ini = value; }
        [JsonProperty("fecha_termino")]
        public string Fec_ter { get => fec_ter; set => fec_ter = value; }
        [JsonProperty("estado")]
        public string Estado { get => estado; set => estado = value; }
        [JsonProperty("observaciones")]
        public string Observaciones { get => observaciones; set => observaciones = value; }
        [JsonProperty("id_tipo_contrato")]
        public int Id_tipo_contrato { get => id_tipo_contrato; set => id_tipo_contrato = value; }

        [JsonProperty("arch_cont")]
        public string Arch_cont { get => arch_cont; set => arch_cont = value; }

        [JsonProperty("id_persona")]
        public int Id_persona { get => id_persona; set => id_persona = value; }


        public dynamic listarContratos()
        {
            dynamic datos = dbapi.GetContratos();

            return datos;
        }

        public async void crearContratosDAO(string path, ContratoDAO contrato)
        {
            await dbapi.CrearContratoAsync(path, contrato);
        }

        public async void actualizarContratoDAO(string idContrato, ContratoDAO contrato)
        {
            await dbapi.ActualizarContratoAsync("contratos/", idContrato, contrato);
        }
    }
}
