using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaTaller.Models
{
    public class DetalleTrabajo
    {
        [Key]
        public int IdDetalleTrabajo { get; set; }
        public int IdServicio { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public int Id_Trabajo { get; set; }
        public string Observaciones { get; set; }
        public virtual Servicio IdServicioNavigation { get; set; }
        public virtual Trabajo IdTrabajoNavigation { get; set; }



    }
}
