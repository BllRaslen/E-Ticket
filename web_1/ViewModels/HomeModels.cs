using web_1.Models;

namespace web_1.ViewModels
{
    public class HomeModels
    {
        //public Sefer SeferModel { get; set; }
        public string selectedKalkisHavalimani {  get; set; }
        public string selectedvarisHavalimani {  get; set; }
        public string selectedTarihi{  get; set; }

        public List <Havalimani> HavalimaniModel { get; set; }
   
    }
}
