using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Propiedades
{
    public class PropiedadesEjeEstrategico
    {

        public string NombreEjeEstrategico { get; set; }

        public PropiedadesEjeEstrategico(string nombreEjeEstrategico)
        {

            NombreEjeEstrategico = nombreEjeEstrategico;
        }


        public PropiedadesEjeEstrategico()
        {
        }
    }
}