using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using EfCore2C.Models;
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

        public string gmail { get; set; }
        [Required(ErrorMessage = "Password zorunlu")]
        [DataType(DataType.Password)]
        public string sifre { get; set; }
        public string tipi { get; set; }
        public bool KeepLoggedIn { get; set; }

    }
}
