using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaTaller.Models
{
    public class DetalleTrabajo
    {
        public int IdDetalleTrabajo { get; set; }
        public int IdServicio { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public int IdTrabajo { get; set; }
        public string  Descripcion { get; set; }
        public string Observaciones { get; set; }
        public virtual Servicio IdServicioNavigation { get; set; }
    }
}
