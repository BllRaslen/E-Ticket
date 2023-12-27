using web_1.Models.airline.Models;
using web_1.Models;
namespace web_1.ViewModels
{
   
public class kartlarModels
{
    public int SeferId { get; set; }
    public string KalkisSaati { get; set; }
    public string VarisSaati { get; set; }
    public string FirmaAdi { get; set; }
    public string HavalimaniAdi { get; set; }
    public List<Rezervasyon> rezervasyons { get; set; }
    public string KalkisTarihi { get; set; }
    public string VarisTarihi { get; set; }
        public string logo { get; set; }

        // public List<Rezervasyon> RezervasyonModels { get; set; }

    }
}