namespace EfCore2C.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Diagnostics.CodeAnalysis;

    public class Firma
    {
        [Key]
        public int firma_id { get; set; }

        public string firma_adi { get; set; }

        public List<Sefer> Seferler { get; set; } = new List<Sefer>();
    }
} 
