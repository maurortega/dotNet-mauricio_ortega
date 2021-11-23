using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi.Models
{
    public partial class TbTipoDocumentoIdent
    {
        public TbTipoDocumentoIdent()
        {
            MaEmpleados = new HashSet<MaEmpleado>();
        }

        public string Simbolo { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaIns { get; set; }

        public virtual ICollection<MaEmpleado> MaEmpleados { get; set; }
    }
}
