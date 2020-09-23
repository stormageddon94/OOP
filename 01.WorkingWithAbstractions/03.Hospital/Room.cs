using System.Collections.Generic;

namespace P04_Hospital
{
    public class Room
    {

        public int Name { get; set; }

        public List<Patient> Patients { get; set; } = new List<Patient>();
    }
}
