using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace SistemaTaller.Models
{
    [Table("Usuarios", Schema = "dbo")]
    public partial class Usuario
    {
        public Usuario() => Trabajos = new HashSet<Trabajo>();
        [Key]
        public int IdUsuarios { get; set; }
        public string Nombre { get; set; }
        [DataType(DataType.Password)]
        public string Clave { get; set; }
        public string Cargo { get; set; }
        public byte? Status { get; set; }

        public virtual ICollection<Trabajo> Trabajos { get; set; }
    }
}
