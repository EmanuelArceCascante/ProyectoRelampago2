using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Propiedades
{
    public class PropiedadesArea
    {
        public int idArea { get; set; }
        public string nombreArea { get; set; }

        public PropiedadesArea(int idArea, string nombreArea)
        {
            this.idArea = idArea;
            this.nombreArea = nombreArea;
        }
    }
}
