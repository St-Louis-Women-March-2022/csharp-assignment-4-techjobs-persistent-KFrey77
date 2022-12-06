using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using TechJobsPersistentAutograded.Models;

namespace TechJobsPersistentAutograded.ViewModels
{
    public class AddEmployerViewModel
    {
        [Required(ErrorMessage = "Employer name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Location is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Location must be between 3 and 50 characters.")]
        public string Location { get; set; }


        //public class AddEmployerViewModel

        public AddEmployerViewModel()
        {
            
        }

        public AddEmployerViewModel(string name, string location)
        {
            Name = name;
            Location = location;
        }
            //return View();
    }
}

    //(List<Employer> names, List<Skill> locations)
    



