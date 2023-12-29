namespace web_1.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    namespace airline.Models
    {
        public class Rezervasyon
        {

            [Key]
            [Display(Name = "Rezervasyon_RezervasyonId")]
            public int rezervasyon_id { get; set; }

            [ForeignKey("Sefer")]
            [Display(Name = "Rezervasyon_SeferId")]
            public int sefer_id { get; set; }

            public Sefer Sefer { get; set; }
            [Display(Name = "Rezervasyon_RezervasyonTipi")]
            public string rezervasyonTipi { get; set; }
            [Display(Name = "Rezervasyon_KoltukSayisi")]
            public int koltuk_sayisi { get; set; }
            [Display(Name = "Sefer_SeferFiyati")]
            public double sefer_fiati { get; set; }
            [Display(Name = "Rezervasyon_KalanKoltukSayisi")]
            public int kalan_koltuk_sayisi { get; set; }


            public List<Koltuklar> Koltuklars { get; set; } = new List<Koltuklar>();


        }
    }
    
}
