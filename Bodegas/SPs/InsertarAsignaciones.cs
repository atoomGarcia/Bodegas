using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bodegas.SPs
{
    public class InsertarAsignaciones
    {
        public int ClaveUbicacion { get; set; }
        public int  ClaveArticulo { get; set; }
        public int Piezas { get; set; }
        public string NombreUbicacion { get; set; }

        public int PiezasMaximas { get; set; }

        public int ClaveBodega { get; set; }
    }
}
