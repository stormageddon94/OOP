using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;

namespace Football_Team_Generator
{
    public class Player
    {
        private const int MinStatusPoints = 1;
        private const int MaxStatusPoints = 100;

        private string name;
        private double endurance;
        private double sprint;
        private double dribble;
        private double passing;
        private double shooting;

        public Player(string name, double endurance, double sprint, double dribble, double passing, double shooting)
        {
            this.Name = name;
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
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

        public double Endurance 
        {
            get => this.endurance;
            private set
            {
                if (value < MinStatusPoints || value > MaxStatusPoints)
                {
                    throw new ArgumentException($"Endurance should be between 0 and 100.");
                }

                this.endurance = value;
            }
        }

        public double Sprint 
        {
            get => this.sprint;
            private set
            {
                if (value < MinStatusPoints || value > MaxStatusPoints)
                {
                    throw new ArgumentException($"Sprint should be between 0 and 100.");
                }

                this.sprint = value;
            }
        }

        public double Dribble
        {
            get => this.dribble;
            private set
            {
                if (value < MinStatusPoints || value > MaxStatusPoints)
                {
                    throw new ArgumentException($"Dribble should be between 0 and 100.");
                }

                this.dribble = value;
            }
        }

        public double Passing
        {
            get => this.passing;
            private set
            {
                if (value < MinStatusPoints || value > MaxStatusPoints)
                {
                    throw new ArgumentException($"Passing should be between 0 and 100.");
                }

                this.passing = value;
            }
        }

        public double Shooting
        {
            get => this.shooting;
            private set
            {
                if (value < MinStatusPoints || value > MaxStatusPoints)
                {
                    throw new ArgumentException($"Shooting should be between 0 and 100.");
                }

                this.shooting = value;
            }
        }

        public double OverallSkillLevel()
        {
            double result = (this.endurance + this.sprint + this.dribble + this.passing + this.shooting) / 5;
            return result;
        }
    }
}
