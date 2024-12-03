using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Propiedades
{
    public class PropiedadesMacroProceso
    {
        public int IdMacroproceso { get; set; }
        public string NombreMacroproceso { get; set; }

        public PropiedadesMacroProceso(int idMacroproceso, string nombreMacroproceso)
        {
            IdMacroproceso = idMacroproceso;
            NombreMacroproceso = nombreMacroproceso;
        }


        public PropiedadesMacroProceso()
        {
        }
    }
}