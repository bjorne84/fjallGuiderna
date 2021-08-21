using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace fjallGuiderna.Models
{
    public class Location
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Bild URL")]
        public string PictureUrl { get; set; }
        [Display(Name = "Plats")]
        public string Name { get; set; }
        [Display(Name = "Beskrivning")]
        public string Description { get; set; }
        // Navigation properties (Relationsship between models)
        public List<NatureActivity> Activities { get; set; }
    }
}
