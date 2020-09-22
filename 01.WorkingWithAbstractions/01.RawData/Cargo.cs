namespace _01.RawData
{
    public class Cargo
    {
        public Cargo(CargoType cargoType, int cargoWeight)
        {
            this.CargoType = cargoType;
            this.CargoWeight = cargoWeight;
        }
        public CargoType CargoType { get; set; }

        public int CargoWeight { get; set; }
    }
}
