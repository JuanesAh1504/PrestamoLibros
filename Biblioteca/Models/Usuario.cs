using System;
using System.Collections.Generic;

namespace Biblioteca.Models
{
    public partial class Usuario
    {
        public Usuario()
        {
            Prestamos = new HashSet<Prestamo>();
        }

        public int IdUsuario { get; set; }
        public string? Nombre { get; set; }
        public string? Apellido { get; set; }
        public string? Identificacion { get; set; }

        public virtual ICollection<Prestamo> Prestamos { get; set; }
    }
}
