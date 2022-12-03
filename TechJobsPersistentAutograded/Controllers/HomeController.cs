﻿using System;
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
        public IActionResult AddJob (AddJobViewModel addJobViewModel, List<Employer> employers, List<Skill> skills)
        {
           

            AddJobViewModel addJobViewModel = new AddJobViewModel(employers, skills);

            /*return View(addJobViewModel);*/

            //Employer employer = DbContext.Employer.Find(addJobViewModel.EmployerId);
            //Employer newEmployer = new Employer

            {
                Name = addJobViewModel.Name;
                Employer = addJobViewModel.EmployerId;
                Skill = addJobViewModel.Skills;
                //Employer = employers
            };
           
            //return View();
            return View(addJobViewModel);

        }


        public IActionResult ProcessAddJobForm(AddJobViewModel addJobViewModel, string[] selectedSkills)
        {
            if (ModelState.IsValid)
            {
                Job job = new Job
                {
                    Name = addJobViewModel.Name,
                    EmployerId = addJobViewModel.EmployerId,
                };
            }

            return View("Add");
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


