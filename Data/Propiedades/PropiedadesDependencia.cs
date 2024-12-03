using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Propiedades
{
    public class PropiedadesDependencia
    {
        public int idDependencia { get; set; }
        public string nombreDependencia { get; set; }

        public PropiedadesDependencia(int idDependencia, string nombreDependencia)
        {
            this.idDependencia = idDependencia;
            this.nombreDependencia = nombreDependencia;
        }

    }
}
