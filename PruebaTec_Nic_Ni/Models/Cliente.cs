using System;
using System.Collections.Generic;

namespace PruebaTec_Nic_Ni.Models
{
    public partial class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Apellidos { get; set; } = null!;
        public string Correo { get; set; } = null!;
        public string? Contacto { get; set; }
    }
}
