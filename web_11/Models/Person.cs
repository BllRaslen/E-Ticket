using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc;

namespace web_1.Models
{

    public class Person
    {
        [Key]
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int person_id { get; set; }
        public String ad { get; set; }
        public String telefon { get; set; }
        public String soyad { get; set; }
        public string dogum_tarihi { get; set; }
        [Required(ErrorMessage = "gmail zorunlu")]
        [Display(Name = "Gmail")]
        public string gmail { get; set; }
        [Required(ErrorMessage = "Password zorunlu")]
        [DataType(DataType.Password)]
        public string sifre { get; set; }
}
}
