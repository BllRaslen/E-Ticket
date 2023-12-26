namespace EfCore2C.Models
{
    using System.ComponentModel.DataAnnotations;


    public class Sehir
    {
        [Key]
        [Display(Name = "Sehir_SehirId")]
        public int sehir_id { get; set; }
        [Display(Name = "Sehir_SehirAdi")]
        public String sehir_adi { get; set; }

        //public List<Havalimani> Havalimanis { get; set; } = new List<Havalimani>();
        public List<Havalimani> Havalimanis { get; set; } = new List<Havalimani>();
    }
}
 