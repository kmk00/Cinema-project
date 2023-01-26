using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Kino.Models
{
    public class Gatunki
    {
        [Key]
        public int Id_gatunku { get; set; }
        [Display(Name = "Gatunek")]
        public String Gatunek { get; set; }
        public ICollection<Filmy> Film { get; set; }
    }
}
