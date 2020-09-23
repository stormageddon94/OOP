using System.Collections.Generic;

namespace P04_Hospital
{
    public class Doctor
    {
        public Doctor(string name, string familyName)
        {
            this.Name = name;
            this.FamilyName = familyName;
        }
        public string Name { get; set; }

        public string FamilyName { get; set; }

        public List<Patient> Patients { get; set; } = new List<Patient>();
    }
}
