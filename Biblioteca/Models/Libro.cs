using System;
using System.Collections.Generic;

namespace Biblioteca.Models
{
    public partial class Libro
    {
        public Libro()
        {
            Prestamos = new HashSet<Prestamo>();
        }

        public int IdLibro { get; set; }
        public string? NombreLibro { get; set; }
        public string? Autor { get; set; }

        public virtual ICollection<Prestamo> Prestamos { get; set; }
    }
}
