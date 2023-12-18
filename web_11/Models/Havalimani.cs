namespace EfCore2C.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public class Havalimani
    {
        [Key]
        public int havalimani_id { get; set; }
        public string havalimani_adi { get; set; }
        


        [ForeignKey("Sehir")]
        public int sehir_id { get; set; }
        public Sehir Sehir { get; set; }



       [NotMapped]
        public List<Sefer> KalkiSefers { get; set; } = new List<Sefer>();
        [NotMapped]
        public List<Sefer> VarisSefers { get; set; } = new List<Sefer>();



    }
}
