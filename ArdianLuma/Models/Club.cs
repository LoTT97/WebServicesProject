using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace luma.Models
{
    [Table("Club")] 
    public class Club
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ClubId { get; set; }

        [Required]
        [Display(Name = "Club Name")]
        [StringLength(255)]
        public string ClubName { get; set; }

        [Display(Name = "Location")]
        [StringLength(255)]
        public string Location { get; set; }

        [Display(Name = "Motto")]
        [StringLength(255)]
        public string Motto { get; set; }

        [Required]
        [Display(Name = "Establised Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public string EstablishedDate { get; set; }

        
        public virtual List<Member> Members { get; set; }
    }
}