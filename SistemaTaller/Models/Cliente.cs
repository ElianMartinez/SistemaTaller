using System;
using System.Collections.Generic;

#nullable disable

namespace SistemaTaller.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            Trabajos = new HashSet<Trabajo>();
            Vehiculos = new HashSet<Vehiculo>();
        }

        public int IdClientes { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }

        public virtual ICollection<Trabajo> Trabajos { get; set; }
        public virtual ICollection<Vehiculo> Vehiculos { get; set; }
    }
}
