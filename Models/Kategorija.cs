using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace WebAppOptika.Models
{
    public class Kategorija
    {
        [Required(ErrorMessage = "Polje {0} je obvezno.")]
        [Display(Name = "#")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }



        [Required(ErrorMessage = "Polje {0} je obvezno.")]
        public string VrstaNaocala { get; set; }


        public List<Naocale> Naocale_ { get; set; }

    }

}

