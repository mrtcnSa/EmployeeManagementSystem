using EmployeeManagementSystem.Concrete;
using EmployeeManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeManagementSystem.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeEntities db = new EmployeeEntities();
        GenericRepository<TblEmployee> gr = new GenericRepository<TblEmployee>();
        GenericRepository<TblJobPosition> job = new GenericRepository<TblJobPosition>();
        GenericRepository<TblDepartment> dep = new GenericRepository<TblDepartment>();
        public ActionResult Index()
        {
            var values = gr.List();
            return View(values);
        }
        [HttpGet]
        public ActionResult AddEmployee()
        {

            List<SelectListItem> valueDep = (from x in dep.List()
                                                select new SelectListItem
                                                {
                                                    Text = x.DepartmentName,
                                                    Value = x.IDDepartment.ToString()
                                                }).ToList();

             
            ViewBag.valueDep = valueDep;

            List<SelectListItem> valueJob = (from x in job.List()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.JobPosition,
                                                      Value = x.IDJobPosition.ToString()
                                                  }).ToList();
            ViewBag.valueJob = valueJob;
            
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(TblEmployee e)
        {

            gr.Insert(e);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditEmployee(int id)
        {
            List<SelectListItem> valueDep = (from x in dep.List()
                                             select new SelectListItem
                                             {
                                                 Text = x.DepartmentName,
                                                 Value = x.IDDepartment.ToString()
                                             }).ToList();


            ViewBag.valueDep = valueDep;

            List<SelectListItem> valueJob = (from x in job.List()
                                             select new SelectListItem
                                             {
                                                 Text = x.JobPosition,
                                                 Value = x.IDJobPosition.ToString()
                                             }).ToList();
            ViewBag.valueJob = valueJob;
            var value = gr.Get(x => x.IDEmployee == id);
            return View(value);
        }
        [HttpPost]
        public ActionResult EditEmployee(TblEmployee e)
        {
            gr.Update(e);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteEmployee(int id)
        {
            var value = gr.Get(x => x.IDEmployee == id); 
            
            gr.Delete(value);
            return RedirectToAction("Index");
        }
    }
}