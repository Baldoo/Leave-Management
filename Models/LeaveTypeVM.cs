﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_Management.Models
{
    public class LeaveTypeVM
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Default Number Of Days")]
        [Range(1, 25, ErrorMessage = "Please Enter A Valid Number")] //Rango de datos 
        public int DefaultDays { get; set; }
        [Display(Name="Data Created")]
        public DateTime? DateCreated { get; set; }
    }

}
