using Lab2.Views.Employees.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Lab2.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        //[UIHint("CustomName")]
        public string Name { get; set; }

        [Required]
        [MaxLength(128)]
        [EmailAddress]
        public string Email { get; set; }

        [Range(1200, 5000)]
        [DataType(DataType.Currency)]
        public int Salary { get; set; }

        public Gender Gender { get; set; }

        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [ForeignKey("Department")]
        [Display(Name = "Department")]
        public int FK_DepartmentId { get; set; }
        public Department Department { get; set; }

    }
}