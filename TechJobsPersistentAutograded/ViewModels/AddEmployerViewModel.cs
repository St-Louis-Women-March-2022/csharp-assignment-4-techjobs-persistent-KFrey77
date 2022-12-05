using System.Collections.Generic;
using TechJobsPersistentAutograded.Models;

namespace TechJobsPersistentAutograded.ViewModels
{
    public class AddEmployerViewModel
    {
        public string Name { get; set; }
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
    



