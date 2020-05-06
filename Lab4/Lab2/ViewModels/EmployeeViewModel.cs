using Lab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2.ViewModels
{
    public class EmployeeViewModel
    {
        public List<Employee> Employees { get; set; }
        public Employee Employee { get; set; }
    }
}