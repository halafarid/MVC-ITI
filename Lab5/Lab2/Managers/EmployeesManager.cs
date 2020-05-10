using Lab2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lab2.Managers
{
    public class EmployeesManager
    {
        ModelContext ctx = new ModelContext();

        public List<Employee> GetAll()
        {
            return ctx.Employees.ToList();
        }

        public Employee GetById(int id)
        {
            return ctx.Employees.Find(id);
        }

        public Employee Post(Employee employee)
        {
            ctx.Employees.Add(employee);
            ctx.SaveChanges();
            return employee;
        }

        public Employee Update(Employee employee)
        {
            ctx.Employees.Attach(employee);
            ctx.Entry(employee).State = EntityState.Modified;
            ctx.SaveChanges();
            return employee;
        }

        public Employee Delete(int id)
        {
            Employee emp = ctx.Employees.Find(id);
            ctx.Employees.Remove(emp);
            ctx.SaveChanges();
            return emp;
        }
    }
}