using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TechJobsPersistentAutograded.Models;

namespace TechJobsPersistentAutograded.ViewModels
{
    public class AddJobViewModel
    {
       // [Required(ErrorMessage = "Job name is required.")]
       
        public string Name { get; set; }

       // [Required(ErrorMessage = "Location is required.")]
       
        //public string Location { get; set; }
        
        public int EmployerId { get; set; }

        public int SkillId { get; set; }

        public List<SelectListItem> Employers { get; set; }

        public List<Skill> Skills { get; set; }

        public AddJobViewModel()
        {
        }

        public AddJobViewModel(List<Employer> employers, List<Skill> skills)
        {
            Employers = new List<SelectListItem>();
            this.Skills = new List<Skill>();
            //this.Skills = null;

            foreach (var employer in employers)
            {
                Employers.Add(new SelectListItem
                {
                    Value = employer.Id.ToString(),
                    Text = employer.Name
                });
                if (skills != null)
                {
                    this.Skills = skills;
                }

                
                    
                   /* new List<SelectListItem>();

                foreach (var skill in skills)
                {
                    Employers.Add(new SelectListItem
                    {
                        Value = skill.Id.ToString(),
                        Text = skill.Name

                    });*/
                }
            }
        }
    }
