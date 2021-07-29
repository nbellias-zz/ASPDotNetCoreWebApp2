using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPDotNetCoreWebApp2.Models
{
    public class Repository
    {
        private static List<Employee> allEmployees = new List<Employee>();
        public static IEnumerable<Employee> AllEmployees
        {
            get { return allEmployees; }
        }
        public static void Create(Employee employee)
        {
            allEmployees.Add(employee);
        }

        public static void Delete(Employee employee)
        {
            allEmployees.Remove(employee);
        }
    }
}
