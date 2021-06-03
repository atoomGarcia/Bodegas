using System;
using System.Collections.Generic;

#nullable disable

namespace Bodegas.Models
{
    public partial class Articulo
    {
        public Articulo()
        {
            Ubicaciones = new HashSet<Ubicacione>();
        }

        public int ClaveArticulo { get; set; }
        public string DescripcionCorta { get; set; }
        public string Descripcion { get; set; }
        public string CodigoBarras { get; set; }

        public virtual ICollection<Ubicacione> Ubicaciones { get; set; }
    }
}
