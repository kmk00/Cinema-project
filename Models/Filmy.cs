using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Kino.Models
{
    public class Filmy
    {

        [Key]
        public int Id_filmu { get; set; }
        [Display(Name = "Tytuł")]
        public String Tytul { get; set; }
        public int Czas_trwania { get; set; }
        [Display(Name = "Rok produkcji")]

        public int Rok { get; set; }

        public string Plakat { get; set; }

        public Gatunki Gatunek { get; set; }
        [Display(Name = "Reżyser")]

        public Rezyserzy Rezyser { get; set; }
        [Display(Name = "Seans")]
        public ICollection<Seanse> Seans { get; set; }


    }
}
