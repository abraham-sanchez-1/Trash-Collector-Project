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
        public string FirstName{ get; set; }
        public string LastName{ get; set; }
        public int ZipCode{ get; set; }
        //[ForeignKey (User)]
        //public User UserId { get; set; }
    }
}
