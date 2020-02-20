﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TrashCollector.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        public double Balance { get; set; }
        [Display(Name = "Pick Up Day")]
        public DayOfWeek PickUpDay { get; set; }
        public DateTime SuspendStart { get; set; }
        public DateTime SuspendEnd { get; set; }
        [ForeignKey ("Address")]
        public int AddressId { get; set; }
        public Address Address { get; set; }
        [ForeignKey("IdentityUser")]
        [Display(Name ="Identity User")]
        public string UserId { get; set; }
        public IdentityUser IdentityUser { get; set; }





    }
}
