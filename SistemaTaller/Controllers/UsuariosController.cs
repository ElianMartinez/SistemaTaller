using Microsoft.AspNetCore.Mvc;
using SistemaTaller.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaTaller.Controllers
{
    public class UsuariosController : Controller
    {
        public TallerContext tallerContext;

        public UsuariosController(TallerContext a)
        {
            tallerContext = a; 
        }
        [HttpPost]
        public IActionResult GetCreUsuarios(string Nombre, string Clave)
        {
            var usuarios = tallerContext.Usuarios.Where(s => s.Nombre == Nombre && s.Clave == Clave);
            if (usuarios.Any())
            {
                if (usuarios.Where(s => s.Nombre == Nombre && s.Clave == Clave).Any())
                {
            var usuario = tallerContext.Usuarios.First(a => a.Nombre == Nombre && a.Clave == Clave);
                    return Json(new { status = true, message = "Bienvenido", cargo= usuario.Cargo });
                }
                else
                {
                    return Json(new { status = false, message = "Credenciales Incorrecta" });

                }
            }
            else
            {
                return Json(new { status = false, message = "Credenciales Incorrecta" });
            }
        }
    }
}
