using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollector.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName{ get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName{ get; set; }
        [Required]
        [Display(Name = "Zip Code Coverage")]
        [DataType(DataType.PostalCode)]
        public string ZipCode{ get; set; }
        [ForeignKey ("IdentityUser")]
        public string UserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }
}
