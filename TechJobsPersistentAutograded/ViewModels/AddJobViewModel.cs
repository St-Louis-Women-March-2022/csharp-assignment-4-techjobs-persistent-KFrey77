using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using TechJobsPersistentAutograded.Models;

namespace TechJobsPersistentAutograded.ViewModels
{
    public class AddJobViewModel
    {
        
        public string Name { get; set; }
        public int EmployerId { get; set; }

        public List<SelectListItem> Employers { get; set; }


        public AddJobViewModel(List<Employer> employers)
        {
            Employers = new List<SelectListItem>();

            foreach (var employer in employers)
            {
                Employers.Add(new SelectListItem
                {
                    Value = employer.Id.ToString(),
                    Text = employer.Name
                });
            }
        }
    }

        }
}
