using System;
using System.Collections.Generic;

namespace PruebaTec_Nic_Ni.Models
{
    public partial class Libros
    {
        public int Id { get; set; }
        public string NomLib { get; set; } = null!;
        public int Cantidad { get; set; }
        public int Precio { get; set; }
    }
}
