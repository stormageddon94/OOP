using System;
using System.Collections.Generic;

namespace Football_Team_Generator
{
    class Program
    {
        static void Main(string[] args)
        {

            var teams = new List<Team>();
            while (true)
            {
                var commandData = Console.ReadLine().Split(';');
                var command = commandData[0];

                if (command == "END")
                {
                    break;
                }
                else if (command == "Team")
                {
                    var team = new Team(commandData[1]);
                    teams.Add(team);
                }
                else if (command == "Add")
                {

                    var teamName = commandData[1];
                    var playerName = commandData[2];
                    var endurance = int.Parse(commandData[3]);
                    var sprint = int.Parse(commandData[4]);
                    var dribble = int.Parse(commandData[5]);
                    var passing = int.Parse(commandData[6]);
                    var shooting = int.Parse(commandData[7]);
                    try
                    {
                        var player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                        var indexOfTeam = teams.FindIndex(x => x.Name == teamName);
                        teams[indexOfTeam].AddPlayer(player);

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (command == "Remove")
                {
                    try
                    {
                        var teamName = commandData[1];
                        var playerName = commandData[2];
                        var indexOfTeam = teams.FindIndex(x => x.Name == teamName);
                        teams[indexOfTeam].RemovePlayer(playerName);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else if (command == "Rating")
                {
                    var teamName = commandData[1];
                    var indexOfTeam = teams.FindIndex(x => x.Name == teamName);
                    var raiting = Math.Ceiling(teams[indexOfTeam].CalculateRaiting());
                    var result = double.IsNaN(raiting) ? 0 : raiting;
                    Console.WriteLine($"{teamName} - {result}");
                }
            }

        }
    }
}
