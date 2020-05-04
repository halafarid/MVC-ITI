using Lab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2.Managers
{
    public class EmployeeManager
    {
        ModelContext ctx = new ModelContext();
        public Employee Post(Employee employee)
        {
            ctx.Employees.Add(employee);
            ctx.SaveChanges();
            return employee;
        }
    }
}