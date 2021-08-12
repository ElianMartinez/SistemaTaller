using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SistemaTaller.Models;

namespace SistemaTaller.Controllers
{
    public class TrabajosController : Controller
    {
        private readonly TallerContext _context;

        public TrabajosController(TallerContext context)
        {
            _context = context;
        }

        // GET: Trabajos
        public async Task<IActionResult> Index()
        {
            var tallerContext = _context.Trabajos.Include(t => t.IdClienteNavigation).Include(t => t.IdUsuarioNavigation).Include(t => t.IdVehiculoNavigation);
            return View(await tallerContext.ToListAsync());
        }

        // GET: Trabajos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trabajo = await _context.Trabajos
                .Include(t => t.IdClienteNavigation)
                .Include(t => t.IdUsuarioNavigation)
                .Include(t => t.IdVehiculoNavigation)
                .FirstOrDefaultAsync(m => m.IdTrabajo == id);
            if (trabajo == null)
            {
                return NotFound();
            }

            return View(trabajo);
        }

        // GET: Trabajos/Create
        public IActionResult Create()
        {
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdClientes", "Nombre");
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuarios", "IdUsuarios");
            ViewData["IdVehiculo"] = new SelectList(_context.Vehiculos, "IdVehiculo", "IdVehiculo");
            return View();
        }

        // POST: Trabajos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTrabajo,IdCliente,IdUsuario,FechaInicio,IdVehiculo,Status")] Trabajo trabajo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(trabajo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdClientes", "Nombre", trabajo.IdCliente);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuarios", "IdUsuarios", trabajo.IdUsuario);
            ViewData["IdVehiculo"] = new SelectList(_context.Vehiculos, "IdVehiculo", "IdVehiculo", trabajo.IdVehiculo);
            return View(trabajo);
        }

        // GET: Trabajos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trabajo = await _context.Trabajos.FindAsync(id);
            if (trabajo == null)
            {
                return NotFound();
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdClientes", "Nombre", trabajo.IdCliente);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuarios", "IdUsuarios", trabajo.IdUsuario);
            ViewData["IdVehiculo"] = new SelectList(_context.Vehiculos, "IdVehiculo", "IdVehiculo", trabajo.IdVehiculo);
            return View(trabajo);
        }

        // POST: Trabajos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTrabajo,IdCliente,IdUsuario,FechaInicio,IdVehiculo,Status")] Trabajo trabajo)
        {
            if (id != trabajo.IdTrabajo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(trabajo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TrabajoExists(trabajo.IdTrabajo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCliente"] = new SelectList(_context.Clientes, "IdClientes", "Nombre", trabajo.IdCliente);
            ViewData["IdUsuario"] = new SelectList(_context.Usuarios, "IdUsuarios", "IdUsuarios", trabajo.IdUsuario);
            ViewData["IdVehiculo"] = new SelectList(_context.Vehiculos, "IdVehiculo", "IdVehiculo", trabajo.IdVehiculo);
            return View(trabajo);
        }

        // GET: Trabajos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var trabajo = await _context.Trabajos
                .Include(t => t.IdClienteNavigation)
                .Include(t => t.IdUsuarioNavigation)
                .Include(t => t.IdVehiculoNavigation)
                .FirstOrDefaultAsync(m => m.IdTrabajo == id);
            if (trabajo == null)
            {
                return NotFound();
            }

            return View(trabajo);
        }

        // POST: Trabajos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var trabajo = await _context.Trabajos.FindAsync(id);
            _context.Trabajos.Remove(trabajo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TrabajoExists(int id)
        {
            return _context.Trabajos.Any(e => e.IdTrabajo == id);
        }
    }
}
