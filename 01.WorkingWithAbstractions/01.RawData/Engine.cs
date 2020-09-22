namespace _01.RawData
{
    public class Engine
    {
        public Engine(string model, int speed, int power)
        {
            this.Model = model;
            this.Speed = speed;
            this.Power = power;
        }
        public string Model { get; set; }

        public int Speed { get; set; }

        public int Power { get; set; }
    }
}
