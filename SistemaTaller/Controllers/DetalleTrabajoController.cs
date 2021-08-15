using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SistemaTaller.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaTaller.Controllers
{
    public class DetalleTrabajoController : Controller
    {
        private readonly TallerContext _context;
        public DetalleTrabajoController(TallerContext context)
        {
            _context = context;
        }
        public IActionResult Index(int id)
        {
            var tallerContext = _context.DetalleTrabajos.Where(s => s.Id_Trabajo == id).Include(s => s.IdServicioNavigation).ToList();
            List<personalizacionDetalle> lista = new List<personalizacionDetalle>();
            foreach(var i in tallerContext)
            {
                personalizacionDetalle p = new personalizacionDetalle(i.IdDetalleTrabajo, i.IdServicioNavigation.Descripcion, i.Observaciones, i.IdServicioNavigation.Nombre, i.Precio, i.Stock);
                lista.Add(p);
            }
            var json = JsonConvert.SerializeObject(lista);
            return Json(new { status = true, data = json });
        }
    }

    class personalizacionDetalle
    {
        int Id_Detalle;
        string descripcion;
        string observaciones;
        string Servicio;
        decimal Precio;
        int Stock;
        decimal Total;
        
        public personalizacionDetalle(int Id, string des, string obs, string serv, decimal pre, int sto)
        {
            Id_Detalle = Id;
            descripcion = des;
            observaciones = obs;
            Servicio = serv;
            Precio = pre;
            Stock = sto;
            Total = sto * pre;
        }

    }
}
