using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace P04_Hospital
{
    public class Program
    {
        public static void Main()
        {
            List<Doctor> doctors = new List<Doctor>();
            List<Department> departments = new List<Department>();

            //var roomNumber = 1;

            string command = Console.ReadLine();
            while (command != "Output")
            {
                string[] commandData = command.Split();

                var departmentName = commandData[0];
                var name = commandData[1];
                var familyName = commandData[2];
                var doctor = new Doctor(name, familyName);

                var patient = new Patient(commandData[3]);

                var indexOfDoctor = doctors.FindIndex(x => x.Name == name && x.FamilyName == familyName);
                if (indexOfDoctor == -1)
                {
                    doctor.Patients.Add(patient);
                    doctors.Add(doctor);
                }
                else
                {
                    doctors[indexOfDoctor].Patients.Add(patient);
                }

                var indexOfDepartment = departments.FindIndex(x => x.Name == departmentName);
                if (indexOfDepartment == -1)
                {
                    var currentRoom = new Room()
                    {
                        Name = 1
                    };
                    currentRoom.Patients.Add(patient);

                    var departament = new Department(departmentName);
                    departament.Rooms.Add(currentRoom);
                    departments.Add(departament);
                }
                else
                {
                    var currentDepartment = departments[indexOfDepartment];
                    var currentRoomCount = currentDepartment.Rooms.Count();

                    if (currentDepartment.Rooms[currentRoomCount - 1].Patients.Count() < 3)
                    {
                        currentDepartment.Rooms[currentRoomCount - 1].Patients.Add(patient);
                    }
                    else
                    {
                        if (currentRoomCount < 20)
                        {
                            var newRoom = new Room()
                            {
                                Name = currentRoomCount + 1,
                                Patients = new List<Patient> { patient },
                            };

                            currentDepartment.Rooms.Add(newRoom);
                        }

                    }

                }


                command = Console.ReadLine();
            }

            command = Console.ReadLine();
            while (command != "End")
            {
                string[] commandData = command.Split();

                if (commandData.Length == 1)
                {
                    var department = departments.Where(x => x.Name == commandData[0]).FirstOrDefault();
                    var allDeaprtmentPatients = department.Rooms.SelectMany(x => x.Patients);

                    foreach (var patient in allDeaprtmentPatients)
                    {
                        Console.WriteLine(patient.Name);
                    }
                }
                else if (commandData.Length == 2 && int.TryParse(commandData[1], out int roomName))
                {
                    var department = departments.Where(x => x.Name == commandData[0]).FirstOrDefault();
                    var roomPatients = department.Rooms.Where(x => x.Name == roomName).FirstOrDefault().Patients;
                    var orderedPatients = roomPatients.OrderBy(x => x.Name);

                    foreach (var patient in orderedPatients)
                    {
                        Console.WriteLine(patient.Name);
                    }
                }
                else
                {
                    var doctor = doctors.Where(x => x.Name == commandData[0] && x.FamilyName == commandData[1]).FirstOrDefault();
                    var orderedPatients = doctor.Patients.OrderBy(x => x.Name);
                    foreach (var patient in orderedPatients)
                    {
                        Console.WriteLine(patient.Name);
                    }
                }
                command = Console.ReadLine();
            }
        }
    }
}


