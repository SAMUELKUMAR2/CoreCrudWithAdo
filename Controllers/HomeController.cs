using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SamuelCoreAdo.Models;

namespace SamuelCoreAdo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        DataAccessLayer dal = new DataAccessLayer();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
           List<tblEmployee> emp = dal.getAllEmployee();
            return View(emp);
        }

        public IActionResult ShowEmployee()
        {
            List<tblEmployee> emp = dal.getAllEmployee();
            
            return View(emp);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult AddEmployee()
        {
            List<tblCountry> Country = dal.BindCountry();
            ViewBag.Country = Country;
            return View();
        }
        [HttpPost]
        public IActionResult AddEmployee(tblEmployee emp)
        {

            try
            {
                dal.insertEmployee(emp);
                return RedirectToAction("ShowEmployee");
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Edit(int id)
        {
            tblEmployee emp = dal.GetEmployeeById(id);
            List<tblCountry> Country = dal.BindCountry();
            ViewBag.Country = Country;
            var state = dal.BindState(Convert.ToInt32(emp.Country));
            ViewBag.State = state;
            return View(emp);
        }

        [HttpPost]
        public IActionResult Edit(tblEmployee emp)
        {
            try
            {
                dal.updateEmployee(emp);
                return RedirectToAction("ShowEmployee");
            }
            catch
            {
                return View();
            }
        }

        public IActionResult Delete(int id)
        {
            dal.deleteEmmployee(id);
            return RedirectToAction("ShowEmployee");
        }

        public JsonResult BindState(int cid)
        {
            var state = dal.BindState(cid);
            return Json(state);

        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
