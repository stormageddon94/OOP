
using System.Collections.Generic;

namespace _03.Hospital
{
     public class Doctor
    {
        public Doctor(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public List<Patient> Patients { get; set; } = new List<Patient>();
    }
}
