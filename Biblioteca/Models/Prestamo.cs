using System;
using System.Collections.Generic;

namespace Biblioteca.Models
{
    public partial class Prestamo
    {
        public int IdPrestamo { get; set; }
        public int? IdUsuario { get; set; }
        public int? IdLibro { get; set; }
        public string? Fecha { get; set; }
        public string? Regreso { get; set; }

        public virtual Libro? oLibro { get; set; }
        public virtual Usuario? oUsuario { get; set; }
    }
}
