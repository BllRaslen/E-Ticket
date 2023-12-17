namespace EfCore2C.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    namespace airline.Models
    {
        public class Rezervasyon
        {
           
                [Key]
                public int rezervasyon_id { get; set; }

                [ForeignKey("Sefer")]
                public int sefer_id { get; set; }
                public Sefer Sefer { get; set; }

                public string rezervasyonTipi { get; set; }
                public int koltuk_sayisi { get; set; }
            

        }
    }
}
