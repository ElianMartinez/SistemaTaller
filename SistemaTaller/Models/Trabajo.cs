using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaTaller.Models
{
    public partial class Trabajo
    {
        public int IdTrabajo { get; set; }
        public int IdCliente { get; set; }
        public int IdUsuario { get; set; }
        public DateTime? FechaInicio { get; set; }
        public int? IdVehiculo { get; set; }
        public string Status { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual Vehiculo IdVehiculoNavigation { get; set; }
    }
}
