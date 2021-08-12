using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace SistemaTaller.Models
{
    public partial class Vehiculo
    {
        public Vehiculo()
        {
            Trabajos = new HashSet<Trabajo>();
        }
        [Key]
        public int IdVehiculo { get; set; }
        [Required(ErrorMessage = "Ingrese la marca")]
        public string Marca { get; set; }
        [Required(ErrorMessage = "Ingrese el Modelo")]

        public string Modelo { get; set; }
        [Required(ErrorMessage = "Ingrese el Color")]

        public string Color { get; set; }
        [Required(ErrorMessage = "Ingrese el año")]
        [DisplayName("Año")]
        public int? Annio { get; set; }
        [Required(ErrorMessage = "Ingrese la Matricula")]

        public string Matricula { get; set; }
        [DisplayName("Dueño")]

        public int? IdCliente { get; set; }

        [DisplayName("Dueño")]
        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual ICollection<Trabajo> Trabajos { get; set; }
    }
}
