using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi.Models
{
    public partial class TbSubarea
    {
        public TbSubarea()
        {
            InverseIdAreaNavigation = new HashSet<TbSubarea>();
            MaEmpleados = new HashSet<MaEmpleado>();
        }

        public int Id { get; set; }
        public int IdArea { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaIns { get; set; }

        public virtual TbSubarea IdAreaNavigation { get; set; }
        public virtual ICollection<TbSubarea> InverseIdAreaNavigation { get; set; }
        public virtual ICollection<MaEmpleado> MaEmpleados { get; set; }
    }
}
