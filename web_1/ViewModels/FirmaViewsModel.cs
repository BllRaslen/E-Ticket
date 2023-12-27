using System.ComponentModel.DataAnnotations;
using web_1.Models;

namespace web_1.ViewModels
{
    public class FirmaViewsModel
    {
        [Key]
        [Display(Name = "Firma_FirmaId")]

        public int firma_id { get; set; }
        [Display(Name = "Firma_FirmaAdi")]


        public string firma_adi { get; set; }
        public IFormFile logo { get; set; }

        public List<Sefer> Seferler { get; set; } = new List<Sefer>();
    }
}
