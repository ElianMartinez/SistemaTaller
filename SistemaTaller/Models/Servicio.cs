using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaTaller.Models
{
    public partial class Servicio
    {
        public Servicio()
        {
            DetalleTrabajos = new HashSet<DetalleTrabajo>();
        }

        public int IdServicio { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal? Precio { get; set; }

        public virtual ICollection<DetalleTrabajo> DetalleTrabajos { get; set; }
    }
}
