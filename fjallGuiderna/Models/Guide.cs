using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace fjallGuiderna.Models
{
    public class Guide
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Bild URL")]
        public string ProfilePictureUrl { get; set; }
        [Display(Name = "Namn")]
        public string FullName { get; set; }
        [Display(Name = "Ålder")]
        public int Age { get; set; }
        [Display(Name = "Presentation")]
        public string GuideDescription { get; set; }

        // Navigation properties (Relationsship between models)
        public List<NatureActivity> Activities { get; set; }
    }
}
