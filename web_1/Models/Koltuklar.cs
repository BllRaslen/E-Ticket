using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using web_1.Models.airline.Models;

namespace web_1.Models
{
    public class Koltuklar
    {

        public int Id { get; set; }
        public string Kod { get; set; }
        public bool durum { get; set; }
        public int rezervasyon_id { get; set; }

        [ForeignKey("rezervasyon_id")]
        public Rezervasyon rezervasyon { get; set; }
    }
}
