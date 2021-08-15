using Microsoft.AspNetCore.Mvc;
using SistemaTaller.Models;
using System.Linq;


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
                    Global.CARGO = usuario.Cargo;
                    Global.ID_USER = usuario.IdUsuarios;
                    return Json(new { status = true, message = "Bienvenido", cargo= usuario.Cargo, id = usuario.IdUsuarios, pass = usuario.Clave });
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
