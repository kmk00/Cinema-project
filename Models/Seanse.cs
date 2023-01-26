using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Kino.Models
{
    public class Seanse

    {
        [Key]
        public int Id_seansu { get; set; }
        [Display(Name = "Start Seansu")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:f}", ApplyFormatInEditMode = true)]
        public DateTime Start { get; set; }
        [Display(Name = "Cena")]

        public int Cena { get; set; }


        public Filmy Film { get; set; }
        public Kina kino { get; set; }
       
    }
}

