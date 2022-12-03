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

            IEnumerable<Employers> employers = _repo.GetAllEmployers();

            return View(employers);

            //return View();
        }

        public IActionResult Add(AddEmployerViewModel addEmployerViewModel)
        {
            //AddEmployerViewModel addEmployerViewModel = new AddEmployerViewModel(name, location);


            Name name = new Name();
            Location location = new Location();

            return View(name, location);



            Location = addEmployerViewModel.Location;

            return View();
        }

        public IActionResult ProcessAddEmployerForm(AddEmployerViewModel addEmployerViewModel)
        {

            if (ModelState.IsValid)
            {
                Employer employer = new Employer
                {
                    Name = addEmployerViewModel.Name;
                Location = addEmployerViewModel.Location;
            }
        
            return View("Add");
        }

        public IActionResult About(int id)
        {
            Employer theEmployer = _repo.FindEmployerById(id);


            AddEmployerViewModel viewModel = new AddEmployerViewModel(theEmployer);
            return View(viewModel);


            //return View();
        }
    }
}

