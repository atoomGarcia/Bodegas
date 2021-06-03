using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bodegas.SPs
{
    public class ExtraeUbicaciones
    {   
        public int ClaveArticulo { get; set; }
        public string NombreBodega { get; set; }
        public string DescripcionCorta { get; set; }
        public string NombreUbicacion { get; set; }
        public int Piezas { get; set; }
        public int PiezasMaximas { get; set; }

    }
}
