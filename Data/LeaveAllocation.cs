﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_Management.Data
{
    public class LeaveAllocation
    {
        [Key] //Especifica que es la llave primaria de la tabla
        public int Id { get; set; }
        public int NumberOfDays { get; set; }
        public DateTime DateCreated { get; set; }

        //Dependencias Funcionales
        [ForeignKey("EmployeeId")] //Nombre de la llave foránea
        public Employee Employee { get; set; }
        public string EmployeeId { get; set; }
        [ForeignKey("LeaveTypeId")]
        public LeaveType LeaveType { get; set; }
        public int LeaveTypeId { get; set; }
    }
}