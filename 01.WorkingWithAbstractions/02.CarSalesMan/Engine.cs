using System;
using System.Collections.Generic;
using System.Text;

namespace _02.CarSalesMan
{
    public class Engine
    {
        public Engine(string model, int power, int displacement = 0, string efficiency = "n/a")
        {
            this.Model = model;
            this.Power = power;
            Displacement = displacement;
            Efficiency = efficiency;
        }

        public string Model { get; set; }

        public int Power { get; set; }

        public int Displacement { get; set; }

        public string Efficiency { get; set; }

        public override string ToString()
        {
            var displacement = this.Displacement == 0 ? "n/a" : this.Displacement.ToString();
            var result = new StringBuilder();
            result.AppendLine($"  {this.Model}:");
            result.AppendLine($"    Power: {this.Power}");
            result.AppendLine($"    Displacement: {displacement}");
            result.AppendLine($"    Efficiency: {this.Efficiency}");
            return result.ToString();
        }
    }
}
