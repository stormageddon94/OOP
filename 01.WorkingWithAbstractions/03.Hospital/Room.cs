using System.Collections.Generic;

namespace _03.Hospital
{
    public class Room
    {
        public Room(int name)
        {
            this.Name = name;
        }
        public int Name { get; set; }
        public List<Patient> PatientsInRoom { get; set; } = new List<Patient>();
    }
}
