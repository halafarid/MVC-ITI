using Lab2.Models;
using System;
using System.Collections.Generic;
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
            Employee emp = GetById(employee.Id);
            emp.Name = employee.Name;
            emp.Email = employee.Email;
            emp.Address = employee.Address;
            emp.Salary = employee.Salary;
            ctx.SaveChanges();
            return emp;
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