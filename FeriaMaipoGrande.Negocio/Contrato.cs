using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FeriaMaipoGrande.Datos;

namespace FeriaMaipoGrande.Negocio
{
    public class Contrato
    {
        string fec_ini, fec_ter, estado, observaciones, arch_cont;
        int id_tipo_contrato, id_persona;

        public Contrato(string fec_ini, string fec_ter, string estado, string observaciones, string arch_cont, int id_tipo_contrato, int id_persona)
        {
            Fec_ini = fec_ini;
            Fec_ter = fec_ter;
            Estado = estado;
            Observaciones = observaciones;
            Arch_cont = arch_cont;
            Id_tipo_contrato = id_tipo_contrato;
            Id_persona = id_persona;
        }

        public Contrato()
        {

        }

        public string Fec_ini { get => fec_ini; set => fec_ini = value; }
        public string Fec_ter { get => fec_ter; set => fec_ter = value; }
        public string Estado { get => estado; set => estado = value; }
        public string Observaciones { get => observaciones; set => observaciones = value; }
        public string Arch_cont { get => arch_cont; set => arch_cont = value; }
        public int Id_tipo_contrato { get => id_tipo_contrato; set => id_tipo_contrato = value; }
        public int Id_persona { get => id_persona; set => id_persona = value; }

        public dynamic listarContratos()
        {
            ContratoDAO contratoDAO = new ContratoDAO();
            dynamic listaContratos = contratoDAO.listarContratos();
            return listaContratos;
        }

        public void crearContrato()
        {
            ContratoDAO contratoDAO = new ContratoDAO();

            contratoDAO.Fec_ini = Fec_ini;
            contratoDAO.Estado = Estado;
            contratoDAO.Observaciones = Observaciones;
            contratoDAO.Arch_cont = Arch_cont;
            contratoDAO.Fec_ter = Fec_ter;
            contratoDAO.Id_tipo_contrato = Id_tipo_contrato;
            contratoDAO.Id_persona = Id_persona;

            contratoDAO.crearContratosDAO("contratos", contratoDAO);
        }

        public void actualizarContrato(string numContrato)
        {
            ContratoDAO contratoDAO = new ContratoDAO();
            contratoDAO.Fec_ini = Fec_ini;
            contratoDAO.Estado = Estado;
            contratoDAO.Observaciones = Observaciones;
            contratoDAO.Arch_cont = Arch_cont;
            contratoDAO.Fec_ter = Fec_ter;
            contratoDAO.Id_tipo_contrato = Id_tipo_contrato;
            contratoDAO.Id_persona = Id_persona;

            contratoDAO.actualizarContratoDAO(numContrato, contratoDAO);
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
    }
}
