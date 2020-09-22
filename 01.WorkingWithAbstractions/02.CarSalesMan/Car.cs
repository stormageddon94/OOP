using System;
using System.Collections.Generic;
using System.Text;

namespace _02.CarSalesMan
{
    public class Car
    {
        public Car(string model, Engine engine, int weight = 0, string color = "n/a")
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = weight;
            this.Color = color;
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.Model}:");
            sb.Append(this.Engine.ToString());
            var weightResult = this.Weight == 0 ? "n/a" : this.Weight.ToString();
            sb.AppendLine($"  Weight: {weightResult}");
            sb.AppendLine($"  Color: {this.Color}");

            return sb.ToString();
        }
    }
}
