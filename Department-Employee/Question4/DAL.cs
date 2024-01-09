using Question4;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;  // needed for .Load() 

namespace Data
{
    class EF
    {
        private static EmpDeptEntities db = new EmpDeptEntities();

        private static ObservableCollection<Departments> OCDepartments = null;
        private static bool initDepartments = false;

        private static ObservableCollection<Employees> OCEmployees = null;
        private static bool initEmployees = false;

        internal static ObservableCollection<Departments> GetDepartments()
        {
            if (!initDepartments)
            {
                db.Departments.Load();
                OCDepartments = db.Departments.Local;
                initDepartments = true;
            }
            return OCDepartments;
        }

        internal static ObservableCollection<Employees> GetEmployees()
        {
            if (!initEmployees)
            {
                db.Employees.Load();
                OCEmployees = db.Employees.Local;
                initEmployees = true;
            }
            return OCEmployees;
        }

        internal static int SaveChanges()
        {
            try
            {
                db.SaveChanges();
                return 0;
            }
            catch (Exception)
            {
                Reload();
                return -1;
            }
        }

        internal static void Reload()
        {
            db = new EmpDeptEntities();
            initDepartments = false;
            initEmployees = false;
        }
    }
}
