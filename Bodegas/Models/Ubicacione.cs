using System;
using System.Collections.Generic;

#nullable disable

namespace Bodegas.Models
{
    public partial class Ubicacione
    {
        public int ClaveUbicacion { get; set; }
        public int ClaveArticulo { get; set; }
        public int? Piezas { get; set; }
        public string NombreUbicacion { get; set; }
        public int PiezasMaximas { get; set; }
        public int ClaveBodega { get; set; }

        public virtual Articulo ClaveArticuloNavigation { get; set; }
        public virtual Bodega ClaveBodegaNavigation { get; set; }
    }
}
