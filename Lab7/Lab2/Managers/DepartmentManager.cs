using Lab2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab2.Managers
{
    public class DepartmentManager
    {
        ModelContext ctx = new ModelContext();

        public List<Department> getAll()
        {
            return ctx.Departments.ToList();
        }
    }
}