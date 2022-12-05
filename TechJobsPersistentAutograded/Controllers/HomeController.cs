using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TechJobsPersistentAutograded.Models;
using TechJobsPersistentAutograded.ViewModels;
using TechJobsPersistentAutograded.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace TechJobsPersistentAutograded.Controllers
{

    public class HomeController : Controller
   /* public string Name { get; set; }
    public int EmployerId { get; set; }

    public List<SelectListItem> Employers { get; set; }

    public List<SelectListItem> Skills { get; set; }*/
   

    {
        private JobRepository _repo;

        public HomeController(JobRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()

        {
            IEnumerable<Job> jobs = _repo.GetAllJobs();

            return View(jobs);
        }


        [HttpGet("/Add")]
        public IActionResult AddJob ()
        {
            var employers = _repo.GetAllEmployers().ToList();
            var skills = _repo.GetAllSkills().ToList();

            var addJobViewModel = new AddJobViewModel(employers, skills);

            
            /*return View(addJobViewModel);*/

            //Employer employer = DbContext.Employer.Find(addJobViewModel.EmployerId);
            //Job newJob = new Job

            
               /* Name = addJobViewModel.Name,
                Employer = addJobViewModel.EmployerId,
                JobSkills = skills*/
                //Employer = employers
           
           
            //return View();
            return View(addJobViewModel);

        }


        public IActionResult ProcessAddJobForm(AddJobViewModel addJobViewModel, string[] selectedSkills)
        {
            if (ModelState.IsValid)
            {
                var jobCount = _repo.GetAllJobs().Count(); 
                Job job = new Job
                {
                    Id = jobCount + 1,
                    Name = addJobViewModel.Name,
                    EmployerId = addJobViewModel.EmployerId
                };
                var skillsTable = _repo.GetAllSkills();

                foreach (var skill in selectedSkills)
                {
                    var Id = Int32.Parse(skill);
                    var skillsTable2ElectricBoogaloo = skillsTable.Where(j => j.Id == Id).FirstOrDefault();
                    JobSkill jobSkill = new JobSkill
                    {
                        JobId = job.Id,
                        SkillId = skillsTable2ElectricBoogaloo.Id,
                        Skill = skillsTable2ElectricBoogaloo,
                        Job = job
                    };
                    _repo.AddNewJobSkill(jobSkill);
                }
                    _repo.AddNewJob(job);

                    _repo.SaveChanges();
                   
                return Redirect("Index");
            }   
                return View("AddJob", addJobViewModel);
        }


        public IActionResult Detail(int id)
        {
            Job theJob = _repo.FindJobById(id);

            List<JobSkill> jobSkills = _repo.FindSkillsForJob(id).ToList();

            JobDetailViewModel viewModel = new JobDetailViewModel(theJob, jobSkills);
            return View(viewModel);
        }

    }

}


