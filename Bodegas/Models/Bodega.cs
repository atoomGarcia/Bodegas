using System;
using System.Collections.Generic;

#nullable disable

namespace Bodegas.Models
{
    public partial class Bodega
    {
        public Bodega()
        {
            Ubicaciones = new HashSet<Ubicacione>();
        }

        public int ClaveBodega { get; set; }
        public string NombreBodega { get; set; }

        public virtual ICollection<Ubicacione> Ubicaciones { get; set; }
    }
}
