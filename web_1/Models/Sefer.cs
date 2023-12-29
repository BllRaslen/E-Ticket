using web_1.Models;

namespace web_1.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public class Sefer
    {
        [Key]
        [Display(Name = "Sefer_SeferId")]
        public int sefer_id { get; set; }
        [Display(Name = "Sefer_KalkisTarihi")]
        public string kalkis_tarihi { get; set; }
        [Display(Name = "Sefer_VarisTarihi")]
        public string varis_tarihi { get; set; }
        [Display(Name = "Sefer_KalkisSaati")]
        public string kalkis_saati { get; set; }
        [Display(Name = "Sefer_VarisSaati")]
        public string varis_saati { get; set; }
   

        
        public ICollection<airline.Models.Rezervasyon> Rezervasyons { get; set; }


        [ForeignKey("KalkisHavalimani")]
        [Display(Name = "Sefer_KalkisHavalimaniId")]
        public int kalkis_havalimani_id { get; set; }
        public Havalimani KalkisHavalimani { get; set; }

        [ForeignKey("VarisHavalimani")]
        [Display(Name = "Sefer_VarisHavalimaniId")]
        public int varis_havalimani_id { get; set; }
        public Havalimani VarisHavalimani { get; set; }



        [ForeignKey("Firma")]
        [Display(Name = "Sefer_FirmaId")]
        public int firma_id { get; set; }
        public Firma Firma { get; set; }


    }
}