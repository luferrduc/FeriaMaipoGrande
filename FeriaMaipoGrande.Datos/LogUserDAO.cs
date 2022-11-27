using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeriaMaipoGrande.Datos
{
    public class LogUserDAO
    {
        private dynamic user;

        public dynamic User { get => user; set => user = value; }

        public LogUserDAO(dynamic user)
        {
            User = user;
        }
        public LogUserDAO()
        {
        }

    }
}
