using web_1.Models;
using web_1.Models.airline.Models;

namespace web_1.ViewModels
{
    public class RezervarsyonAndSeferModels
    {

        public int sefer_id { get; set; }
        public Rezervasyon rezervasyons { get; set; }
        public List<Sefer> sefers { get; set; }

    }
}
