using EfCore2C.Models.airline.Models;

namespace EfCore2C.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public class Sefer
    {
        [Key]
        public int sefer_id { get; set; }
        public string kalkis_saati { get; set; }
        public string varis_saati { get; set; }
        public double sefer_fiati { get; set; }

        
        public ICollection<Rezervasyon> Rezervasyons { get; set; }


        [ForeignKey("KalkisHavalimani")]
        public int kalkis_havalimani_id { get; set; }
        public Havalimani KalkisHavalimani { get; set; }

        [ForeignKey("VarisHavalimani")]
        public int varis_havalimani_id { get; set; }
        public Havalimani VarisHavalimani { get; set; }



        [ForeignKey("Firma")]
        public int firma_id { get; set; }
        public Firma Firma { get; set; }


    }
}