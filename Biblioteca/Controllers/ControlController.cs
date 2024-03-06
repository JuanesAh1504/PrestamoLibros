using Biblioteca.Models;
using Biblioteca.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Biblioteca.Controllers
{
    public class ControlController : Controller
    {
        private readonly BibliotecaContext _DBContext;

        public ControlController(BibliotecaContext context)
        {
            _DBContext = context;
        }

        public IActionResult Usuario_Guardar(int IdUsuario)
        {
            Usuario usuario = IdUsuario == 0 ? new Usuario() : _DBContext.Usuarios.Find(IdUsuario);
            return View(usuario);
        }
        [HttpPost]
        public IActionResult Usuario_Guardar(Usuario oUsuario)
        {
            if(oUsuario.IdUsuario == 0)
            {
                _DBContext.Usuarios.Add(oUsuario);
            }
            else
            {
                _DBContext.Usuarios.Update(oUsuario);
            }
            _DBContext.SaveChanges();
            return RedirectToAction("Usuario_Listar", "Control");
        }
        public IActionResult Usuario_Listar()
        {
            List<Usuario> lista = _DBContext.Usuarios.ToList();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Usuario_Eliminar(int IdUsuario)
        {
            Usuario oUsuario = _DBContext.Usuarios.Where(e => e.IdUsuario == IdUsuario).FirstOrDefault();

            return View(oUsuario);
        }
        [HttpPost]
        public IActionResult Usuario_Eliminar(Usuario oUsuario)
        {
            _DBContext.Usuarios.Remove(oUsuario);
            _DBContext.SaveChanges();

            return RedirectToAction("Usuario_Listar", "Control");
           }

        public IActionResult Libro_Guardar(int IdLibro)
        {
            Libro libro = IdLibro == 0 ? new Libro() : _DBContext.Libros.Find(IdLibro);

            return View(libro);
        }
        [HttpPost]
        public IActionResult Libro_Guardar(Libro oLibro)
        {
            if (oLibro.IdLibro == 0)
            {
                _DBContext.Libros.Add(oLibro);
            }
            else
            {
                _DBContext.Libros.Update(oLibro);
            }
            _DBContext.SaveChanges();
            return RedirectToAction("Libros_Listar", "Control");
        }
        public IActionResult Libros_Listar()
        {
            List<Libro> lista = _DBContext.Libros.ToList();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Libro_Eliminar(int IdLibro)
        {
            Libro oLibro = _DBContext.Libros.Where(e => e.IdLibro == IdLibro).FirstOrDefault();

            return View(oLibro);
        }
        [HttpPost]
        public IActionResult Libro_Eliminar(Libro oLibro)
        {
            _DBContext.Libros.Remove(oLibro);
            _DBContext.SaveChanges();

            return RedirectToAction("Libros_Listar", "Control");
        }
        public IActionResult Prestamos_Guardar(int IdPrestamo)
        {
            PrestamosVM oPrestamosVM = new PrestamosVM()
            {
                oPrestamos = new Prestamo(),
                oListaUsuario = _DBContext.Usuarios.Select(usuarios => new SelectListItem()
                {
                    Text = usuarios.Nombre,
                    Value = usuarios.IdUsuario.ToString()
                }).ToList(),
                oListaLibros = _DBContext.Libros.Select(libros => new SelectListItem()
                {
                    Text = libros.NombreLibro,
                    Value = libros.IdLibro.ToString()
                }).ToList()
            };
            if (IdPrestamo != 0)
            {
                oPrestamosVM.oPrestamos = _DBContext.Prestamos.Find(IdPrestamo);
            }
            return View(oPrestamosVM);
        }
        [HttpPost]
        public IActionResult Prestamos_Guardar(PrestamosVM oPrestamoVM)
        {
            if (oPrestamoVM.oPrestamos.IdPrestamo == 0)
            {
                _DBContext.Prestamos.Add(oPrestamoVM.oPrestamos);
            }
            else
            {
                _DBContext.Prestamos.Update(oPrestamoVM.oPrestamos);
            }
            _DBContext.SaveChanges();
            return RedirectToAction("Prestamos_Listar", "Control");
        }
        public IActionResult Prestamos_Listar()
        {
            List<Prestamo> lista = _DBContext.Prestamos.Include(p => p.oUsuario).Include(p => p.oLibro).ToList();
            return View(lista);
        }

        [HttpGet]
        public IActionResult Prestamo_Eliminar(int IdPrestamo)
        {
            Prestamo oPrestamo = _DBContext.Prestamos
                .Include(p => p.oUsuario)
                .Include(p => p.oLibro)
                .FirstOrDefault(p => p.IdPrestamo == IdPrestamo);

            return View(oPrestamo);
        }

        [HttpPost]
        public IActionResult Prestamo_Eliminar(Prestamo oPrestamo)
        {
            _DBContext.Prestamos.Remove(oPrestamo);
            _DBContext.SaveChanges();

            return RedirectToAction("Prestamos_Listar", "Control");
        }

    }
}
