using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace TechJobsPersistentAutograded.Models
{
    public class Employer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public List<Job> Jobs { get; set; }

        public Employer()
        {
        }
     /*   public static void Add(Employer newEmployer)
        {
            Job.Employer.Add(newEmployer.Id, newEmployer);
        }*/
            public Employer(string name, string location)
        {
            Name = name;
            Location = location;
        }
    }
}

