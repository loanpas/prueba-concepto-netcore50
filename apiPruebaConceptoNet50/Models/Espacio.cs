using System;
using System.Collections.Generic;

#nullable disable

namespace apiPruebaConceptoNet50.Models
{
    public partial class Espacio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Descripcion { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
    }
}
