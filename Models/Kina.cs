using System.ComponentModel.DataAnnotations;

namespace Kino.Models
{
    public class Kina
    {
        [Key]
        public int Id_kina { get; set; }
        public string Nazwa_Kina { get; set; }
        public string Adres { get; set; }

        public ICollection<Seanse> seans { get; set; }

    }
}
