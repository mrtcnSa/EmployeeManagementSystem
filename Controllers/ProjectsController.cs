using EmployeeManagementSystem.Concrete;
using EmployeeManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    public class ProjectsController : Controller
    {
        EmployeeEntities db = new EmployeeEntities();
        GenericRepository<TblEmployee> gr = new GenericRepository<TblEmployee>();
        GenericRepository<TblJobPosition> job = new GenericRepository<TblJobPosition>();
        GenericRepository<TblDepartment> dep = new GenericRepository<TblDepartment>();
        GenericRepository<TblProject> pro = new GenericRepository<TblProject>();
        public ActionResult Index()
        {
            var values = pro.List();
            return View(values);
            
        }
        [HttpGet]
        public ActionResult AddProjectAssignEmployee()
        {
            List<SelectListItem> valueEmp = (from x in gr.List()
                                             select new SelectListItem
                                             {
                                                 Text = x.FirstName + " " + x.MiddleName + " " + x.LastName,
                                                 Value = x.IDEmployee.ToString()
                                             }).ToList();


            ViewBag.valueEmp = valueEmp;
            return View();
        }
        [HttpPost]
        public ActionResult AddProjectAssignEmployee(TblProject p)
        {

            pro.Insert(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditProject(int id)
        {
            List<SelectListItem> valueEmp = (from x in gr.List()
                                             select new SelectListItem
                                             {
                                                 Text = x.FirstName+" " + x.MiddleName + " " + x.LastName,
                                                 Value = x.IDEmployee.ToString()
                                             }).ToList();


            ViewBag.valueEmp = valueEmp;

           
            var value = pro.Get(x => x.IDProject == id);
            return View(value);
        }
        [HttpPost]
        public ActionResult EditProject(TblProject p)
        {
            pro.Update(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteProject(int id)
        {
            var value = pro.Get(x => x.IDProject == id);

            pro.Delete(value);
            return RedirectToAction("Index");
        }
    }
}
 