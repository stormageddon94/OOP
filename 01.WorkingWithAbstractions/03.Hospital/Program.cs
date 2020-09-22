using System;
using System.Collections.Generic;
using System.Data;

namespace _03.Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            var doctors = new List<Doctor>();
            var departments = new List<Department>();

            var roomNumber = 1;

            while (true)
            {
                var input = Console.ReadLine();
                if (input == "Output")
                {
                    break;
                }

                var departmentData = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var departmentName = departmentData[0];
                var doctorFirstName = departmentData[1];
                var doctorLastName = departmentData[2];
                var patientName = departmentData[3];

                var department = new Department(departmentName);
                var patient = new Patient(patientName);
                var doctor = new Doctor(doctorFirstName, doctorLastName);

                var currentRoom = new Room(roomNumber);

                if (!doctors.Contains(doctor))
                {
                    doctor.Patients.Add(patient);
                    doctors.Add(doctor);
                }
                else
                {
                    var indexOfDoctor = doctors.IndexOf(doctor);
                    doctors[indexOfDoctor].Patients.Add(patient);
                }

                if (!departments.Contains(department))
                {
                    currentRoom.PatientsInRoom.Add(patient);
                    department.Rooms.Add(currentRoom);
                    departments.Add(department);
                }
                else
                {
                    var indexOfDepartment = departments.IndexOf(department);
                    var currentDepartment = departments[indexOfDepartment];
                    if (currentDepartment.Rooms.Count <= 20)
                    {
                        var roomIndex = currentDepartment.Rooms.IndexOf(currentRoom);
                        if (currentDepartment.Rooms[roomIndex].PatientsInRoom.Count >= 3)
                        {
                            roomNumber++;
                            var newRoom = new Room(roomNumber);
                            newRoom.PatientsInRoom.Add(patient);
                            currentDepartment.Rooms.Add(newRoom);
                        }
                        else
                        {
                            currentDepartment.Rooms[roomIndex].PatientsInRoom.Add(patient);
                        }
                    }
                }
            }

            var command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            while (true)
            {
                if (command[0] == "End")
                {
                    break;
                }

                if (command.Length == 1) //Department
                {
                    var departmentToFind = new Department(command[0]);
                    var departmentIndex = departments.IndexOf(departmentToFind);
                    var currentDepartment = departments[departmentIndex];
                    foreach (var room in currentDepartment.Rooms)
                    {
                        foreach (var patient in room.PatientsInRoom)
                        {
                            Console.WriteLine(patient.Name);
                        }
                    }
                }
                else if (command.Length == 2 && int.TryParse(command[1], out int number)) // Department and Room
                {
                    var departmentToFind = new Department(command[0]);
                    var deppartmentIndex = departments.IndexOf(departmentToFind);
                    var rooms = departments[deppartmentIndex].Rooms;
                    var roomToFind = new Room(number);
                    var indexOfRoom = rooms.IndexOf(roomToFind);
                    var patientsInRoom = rooms[indexOfRoom].PatientsInRoom;
                    foreach (var patient in patientsInRoom)
                    {
                        Console.WriteLine(patient.Name);
                    }
                }
                else // Doctor
                {
                    var doctorToFind = new Doctor(command[0], command[1]);
                    var indexOfDoctor = doctors.IndexOf(doctorToFind);
                    var patients = doctors[indexOfDoctor].Patients;

                    foreach (var patient in patients)
                    {
                        Console.WriteLine(patient.Name);
                    }
                }
            }
            
        }
    }
}
