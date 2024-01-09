using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    class Departments
    {
        static internal int UpdateDepartments()
        {
            return Data.EF.SaveChanges();
        }
    }

    class Employees
    {
        static internal int UpdateEmployees()
        {
            return Data.EF.SaveChanges();
        }
    }
}
