using ASPDotNetCoreWebApp2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPDotNetCoreWebApp2.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: EmployeeController
        public ActionResult Index()
        {
            return View(Repository.AllEmployees);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(string name)
        {
            Employee employee = Repository.AllEmployees.Where(e => e.Name == name).FirstOrDefault();
            return View(employee);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            try
            {
                Repository.Create(employee);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(string name)
        {
            if (ModelState.IsValid)
            {
                Employee employee = Repository.AllEmployees.Where(e => e.Name == name).FirstOrDefault();
                return View(employee);
            }
            else
            {
                return View();
            }
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string name, Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    Repository.AllEmployees.Where(e => e.Name == name).FirstOrDefault().Age = employee.Age;
                    Repository.AllEmployees.Where(e => e.Name == name).FirstOrDefault().Salary = employee.Salary;
                    Repository.AllEmployees.Where(e => e.Name == name).FirstOrDefault().Department = employee.Department;
                    Repository.AllEmployees.Where(e => e.Name == name).FirstOrDefault().Sex = employee.Sex;
                    Repository.AllEmployees.Where(e => e.Name == name).FirstOrDefault().Name = employee.Name;

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(string name)
        {
            Employee employee = Repository.AllEmployees.Where(e => e.Name == name).FirstOrDefault();
            Repository.Delete(employee);
            return View(employee);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string name, Employee employee)
        {
            try
            {
                Repository.Delete(employee);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(employee);
            }
        }
    }
}
