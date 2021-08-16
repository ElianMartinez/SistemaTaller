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
               Servicio servicio = _context.Servicios.Where(s => s.IdServicio == i.IdServicio).First();
                personalizacionDetalle p = new personalizacionDetalle(i.IdDetalleTrabajo, servicio.Descripcion, i.Observaciones, servicio.Nombre, i.Precio, i.Stock, servicio.IdServicio);
                lista.Add(p);
            }
            var json = JsonConvert.SerializeObject(lista);
            return Json(new { status = true, data = json });
        }

        public async Task<IActionResult> Create(int IdServicio, decimal precio, int stock, int idTrabajo, string observaciones)
        {
            try
            {
                DetalleTrabajo newDetalle = new DetalleTrabajo
                {
                    Id_Trabajo = idTrabajo,
                    IdServicio = IdServicio,
                    Precio = precio,
                    Stock = stock,
                    Observaciones = observaciones,
                };
                _context.DetalleTrabajos.Add(newDetalle);
               await _context.SaveChangesAsync();
                return Json(new { status = true });
            }
            catch(Exception err)
            {
                return Json(new { status = false, message = err.Message });

            }


        }

        public async Task<IActionResult> Edit(int IdServicio, decimal precio, int stock, int idTrabajo, string observaciones, int IdDetalle)
        {
            try{
            DetalleTrabajo newDetalle = new DetalleTrabajo
            {
                IdDetalleTrabajo = IdDetalle,
                Id_Trabajo = idTrabajo,
                IdServicio = IdServicio,
                Precio = precio,
                Stock = stock,
                Observaciones = observaciones,
            };
            _context.DetalleTrabajos.Update(newDetalle);
            await _context.SaveChangesAsync();
                return Json(new { status = true });

            }
            catch (Exception err)
            {
                return Json(new { status = false, message = err.Message });

            }

        }

        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var detalle = await _context.DetalleTrabajos.FindAsync(id);
                _context.DetalleTrabajos.Remove(detalle);
                await _context.SaveChangesAsync();
                return Json(new { status = true});

            }
            catch (Exception err)
            {
                return Json(new { status = false, message = err.Message });

            }

        }

        public IActionResult GetDataSelect(int tipo)
        {
            if (tipo == 2)
            {
              var users =  _context.Usuarios.Where(s => s.Cargo == "Mecánico").ToList();
                var json = JsonConvert.SerializeObject(users);
                return Json(new { status = true, data = json });
            }
            else
            {
                var clients =  _context.Clientes.ToList();
                var json = JsonConvert.SerializeObject(clients);
                return Json(new { status = true, data = json });
            }
        }
       
    }

    class personalizacionDetalle
    {
        public int Id_Detalle  {get; set;}
       public string descripcion { get; set; }
        public string observaciones { get; set; }
       public string Servicio { get; set; }
        public int IdServicio { get; set; }
        public decimal Precio { get; set; }
       public int Stock { get; set; }
       public decimal Total { get; set; }

        public personalizacionDetalle(int Id, string des, string obs, string serv, decimal pre, int sto, int idser)
        {
            Id_Detalle = Id;
            descripcion = des;
            observaciones = obs;
            Servicio = serv;
            Precio = pre;
            Stock = sto;
            IdServicio = idser;

    Total = sto * pre;
        }

    }
}
