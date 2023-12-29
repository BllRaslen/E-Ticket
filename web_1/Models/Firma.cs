namespace web_1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Diagnostics.CodeAnalysis;

    public class Firma
    {
        [Key]
        [Display(Name = "Firma_FirmaId")]
        public int firma_id { get; set; }
        [Display(Name = "Firma_FirmaAdi")]
        public string firma_adi { get; set; }
        public string logo {  get; set; }

        public List<Sefer> Seferler { get; set; } = new List<Sefer>();
    }
} 
