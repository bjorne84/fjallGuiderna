using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace fjallGuiderna.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string SurName { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        public string Phone { get; set; }
        




        // Location one-to-many
        [ForeignKey("NatureActivityId")]
        public int NatureActivityId { get; set; }
        public NatureActivity NatureActivity { get; set; }
    }
}
