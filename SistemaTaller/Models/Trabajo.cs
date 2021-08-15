using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SistemaTaller.Models
{
    public partial class Trabajo
    {
        public Trabajo()
        {
            Detalles = new HashSet<DetalleTrabajo>();
        }
        [Key]
        public int IdTrabajo { get; set; }
        [DisplayName("Dueño")]
        public int IdCliente { get; set; }
        [DisplayName("Mecánico")]
        public int IdUsuario { get; set; }
        [Required(ErrorMessage ="Ingrese la Fecha")]
        [DisplayName("Fecha de Entrada")]
        public DateTime? FechaInicio { get; set; }
        [DisplayName("Fecha de Salida")]
        [Required(ErrorMessage = "Por favor ingrese la fecha de salida")]
        public DateTime? Fecha_Salida { get; set; }
        [DisplayName("Vehículo")]
        [Required(ErrorMessage = "Por favor seleccione un Vehículo")]
        public int? IdVehiculo { get; set; }
        [DisplayName("Status")]
        [Required(ErrorMessage = "Ingrese el status")]
        public string Status { get; set; }
        [DisplayName("Observaciones")]
        public string  Observaciones { get; set; }
        [DisplayName("Cliente")]
        public virtual Cliente IdClienteNavigation { get; set; }
        [DisplayName("Mecánico")]
        public virtual Usuario IdUsuarioNavigation { get; set; }
        [DisplayName("Vehículo")]
        public virtual Vehiculo IdVehiculoNavigation { get; set; }
        public virtual ICollection<DetalleTrabajo> Detalles { get; set; }

    }
}
