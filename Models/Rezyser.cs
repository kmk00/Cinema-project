using System.ComponentModel.DataAnnotations;

namespace Kino.Models
{
    public class Rezyserzy
    {
        [Key]
        public int Id_rezysera { get; set; }
        [Display(Name = "Imię")]
        public String Imie { get; set; }
        [Display(Name = "Imię")]
        public String Nazwisko { get; set; }
        public ICollection<Filmy> Filmy { get; set; }

    }
}
