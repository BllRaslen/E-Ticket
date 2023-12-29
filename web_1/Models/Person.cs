using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using web_1.Models;
using Microsoft.AspNetCore.Mvc;

namespace web_1.Models
{

    public class Person
    {
        [Key]
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Person_ID")]
        public int person_id { get; set; }
        [Display(Name = "Person_Ad")]
        public String ad { get; set; }
        [Display(Name = "Person_Telefon")]
        public String telefon { get; set; }
        [Display(Name = "Person_Soyad")]
        public String soyad { get; set; }
        [Display(Name = "Person_Doğum_Tarihi")]
        public string dogum_tarihi { get; set; }
        [Required(ErrorMessage = "gmail zorunlu")]
        [Display(Name = "Person_Gmail")]
        public string gmail { get; set; }
        [Required(ErrorMessage = "Password zorunlu")]
        [DataType(DataType.Password)]
        [Display(Name = "Person_Şifre")]
        public string sifre { get; set; }
        [Display(Name = "Person_Tipi")]
        public string tipi { get; set; }
        [Display(Name = "Person_Hatırla")]
        public bool KeepLoggedIn { get; set; }

    }
}
