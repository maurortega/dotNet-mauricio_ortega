using System;
using System.Collections.Generic;

#nullable disable

namespace WebApi.Models
{
    public partial class MaEmpleado
    {
        public int Id { get; set; }
        public string DocIdentTipo { get; set; }
        public long DocIdentNumero { get; set; }
        public string Nombre1 { get; set; }
        public string Nombre2 { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public int IdSubArea { get; set; }
        public DateTime? FechIns { get; set; }

        public virtual TbTipoDocumentoIdent DocIdentTipoNavigation { get; set; }
        public virtual TbSubarea IdSubAreaNavigation { get; set; }
    }
}
