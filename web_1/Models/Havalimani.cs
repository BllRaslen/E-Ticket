
namespace web_1.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public class Havalimani
    {
        [Key]
        [Display(Name = "Havalimani_HavalimaniId")]
        public int havalimani_id { get; set; }
        [Display(Name = "Havalimani_HavalimaniAdi")]
        public string havalimani_adi { get; set; }
        


        [ForeignKey("Sehir")]
        [Display(Name = "Havalimani_SehirId")]
        public int sehir_id { get; set; }
        public Sehir Sehir { get; set; }



       [NotMapped]
        public List<Sefer> KalkiSefers { get; set; } = new List<Sefer>();
        [NotMapped]
        public List<Sefer> VarisSefers { get; set; } = new List<Sefer>();



    }
}
