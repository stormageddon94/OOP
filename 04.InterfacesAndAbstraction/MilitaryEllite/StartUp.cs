using MilitaryElite.Interfaces;
using MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MilitaryElite
{
    public class Startup
    {
        private static List<ISoldier> soldiers = new List<ISoldier>();

        public static void Main()
        {
            ParseInput();
            PrintSoldiers();
        }

        private static void PrintSoldiers()
        {
            foreach (ISoldier soldier in soldiers)
            {
                Console.WriteLine(soldier);
            }
        }

        private static void ParseInput()
        {
            string input = Console.ReadLine();
            while (input != "End")
            {
                string[] inputParts = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                string type = inputParts[0];
                switch (type)
                {
                    case "Private":
                        SavePrivate(inputParts);
                        break;
                    case "Spy":
                        SaveSpy(inputParts);
                        break;
                    case "LieutenantGeneral":
                        SaveLeutenantGeneral(inputParts);
                        break;
                    case "Engineer":
                        SaveEngineer(inputParts);
                        break;
                    case "Commando":
                        SaveCommando(inputParts);
                        break;
                }
                input = Console.ReadLine();
            }
        }

        private static void SaveCommando(string[] inputParts)
        {
            try
            {
                string corp = inputParts[5];
                List<IMission> missions = SaveMissions(inputParts);
                ICommando commando = new Commando(int.Parse(inputParts[1]), inputParts[2], inputParts[3], double.Parse(inputParts[4]), corp, missions);
                soldiers.Add(commando);
            }
            catch (Exception ex)
            {
                // Log exception
                return;
            }
        }

        private static List<IMission> SaveMissions(string[] inputParts)
        {
            List<IMission> missions = new List<IMission>();
            for (int i = 6; i < inputParts.Length - 1; i += 2)
            {
                string state = inputParts[i + 1];
                if (state != "inProgress" && state != "Finished")
                {
                    continue;
                }
                IMission mission = new Mission(inputParts[i], inputParts[i + 1]);
                missions.Add(mission);
            }
            return missions;
        }

        private static void SaveEngineer(string[] inputParts)
        {
            try
            {
                string corp = inputParts[5];
                List<IRepair> repairs = SaveRepairs(inputParts);
                IEngineer engineer = new Engineer(int.Parse(inputParts[1]), inputParts[2], inputParts[3], double.Parse(inputParts[4]), corp, repairs);
                soldiers.Add(engineer);
            }
            catch (Exception ex)
            {
                // Log exception
                return;
            }
        }

        private static List<IRepair> SaveRepairs(string[] inputParts)
        {
            List<IRepair> repairs = new List<IRepair>();
            for (int i = 6; i < inputParts.Length - 1; i += 2)
            {
                IRepair repair = new Repair(inputParts[i], int.Parse(inputParts[i + 1]));
                repairs.Add(repair);
            }
            return repairs;
        }

        private static void SaveLeutenantGeneral(string[] inputParts)
        {
            List<int> ids = inputParts.Skip(5).Select(int.Parse).ToList();
            List<ISoldier> privates = new List<ISoldier>();
            foreach (int id in ids)
            {
                privates.Add(soldiers.FirstOrDefault(s => s.Id == id));
            }

            ILieutenantGeneral leutenantGeneral = new LeutenantGeneral(int.Parse(inputParts[1]), inputParts[2], inputParts[3], double.Parse(inputParts[4]), privates);
            soldiers.Add(leutenantGeneral);
        }

        private static void SaveSpy(string[] inputParts)
        {
            ISpy spy = new Spy(int.Parse(inputParts[1]), inputParts[2], inputParts[3], int.Parse(inputParts[4]));
            soldiers.Add(spy);
        }

        private static void SavePrivate(string[] inputParts)
        {
            IPrivate newPrivate = new Private(int.Parse(inputParts[1]), inputParts[2], inputParts[3], double.Parse(inputParts[4]));
            soldiers.Add(newPrivate);
        }
    }
}
