using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Football_Team_Generator
{
    public class Team
    {
        private string name;
        private List<Player> players = new List<Player>();

        public Team(string name, int rating = 0)
        {
            this.Name = name;
            this.Rating = rating;
        }
    
        public string Name
        {
            get => this.name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("A name should not be empty.");
                }

                this.name = value;
            }
        }

        public int Rating { get; private set; } 
        
        public void AddPlayer(Player player)
        {
            players.Add(player);
        }

        public void RemovePlayer(string playerName)
        {
            var indexOfPlayer = players.FindIndex(x => x.Name == playerName);
            if (indexOfPlayer == -1)
            {
                throw new ArgumentException($"Player {playerName} is not in {this.name} team.");
            }
            players.RemoveAt(indexOfPlayer);
        }

        public double CalculateRaiting()
        {
            var playersOverallRating = this.players.Select(x => x.OverallSkillLevel()).Sum();
            var result = playersOverallRating / this.players.Count;
            return result;
        }

    }
}
