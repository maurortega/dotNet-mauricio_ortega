using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi.Models
{
    public partial class TbArea
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime? FechaIns { get; set; }
    }
}
