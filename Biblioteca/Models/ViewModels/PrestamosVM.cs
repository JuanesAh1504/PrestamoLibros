using Microsoft.AspNetCore.Mvc.Rendering;
namespace Biblioteca.Models.ViewModels
{
    public class PrestamosVM
    {   
        public Prestamo oPrestamos { get; set; }
        public List<SelectListItem> oListaUsuario { get; set; }
        public List<SelectListItem> oListaLibros { get; set; }
    }
}
