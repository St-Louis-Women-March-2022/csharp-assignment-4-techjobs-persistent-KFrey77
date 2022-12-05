using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc;
using TechJobsPersistentAutograded.Data;
using TechJobsPersistentAutograded.Models;
using TechJobsPersistentAutograded.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TechJobsPersistentAutograded.Controllers
{
    public class EmployerController : Controller
    {
        //[HttpGet("/Add")]
        // GET: /<controller>/

        private JobRepository _repo;

        public EmployerController(JobRepository repo)
        {
            _repo = repo;
        }


        public IActionResult Index()
        {

            IEnumerable<Employer> employers = _repo.GetAllEmployers();

            return View(employers);

            //return View();
        }

        public IActionResult Add()
        {
            AddEmployerViewModel addEmployerViewModel = new AddEmployerViewModel();


          /*  string name = "";
            string location = "";

            location = addEmployerViewModel.Location;*/

            return View(addEmployerViewModel);
        }

        public IActionResult ProcessAddEmployerForm(AddEmployerViewModel addEmployerViewModel)
        {

            if (ModelState.IsValid)
            {
                Employer employer = new Employer
                {
                    Name = addEmployerViewModel.Name,
                    Location = addEmployerViewModel.Location
                };
                return Redirect("/Employer");
            
            }

            Employers.Add(employer);
            employer.SaveChanges();
            
            return View("Add");
        }

        public IActionResult About(int id)
        {
            Employer theEmployer = _repo.FindEmployerById(id);



            AddEmployerViewModel viewModel = new AddEmployerViewModel(theEmployer.Name, theEmployer.Location);
            return View(viewModel);


            //return View();
        }
    }
}

