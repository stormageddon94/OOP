using System.Collections.Generic;

namespace _03.Hospital
{
    public class Department
    {
        public Department(string name)
        {
            this.Name = name;
        }
        public string Name { get; set; }

        public List<Room> Rooms { get; set; } = new List<Room>();

    }
}
