
namespace _01.RawData
{
    public class Tyre
    {
        public Tyre(int tyreAge, double tyrePressure)
        {
            this.TyreAge = tyreAge;
            this.TyrePressure = tyrePressure;
        }
        public int TyreAge { get; set; }
        
        public double TyrePressure { get; set; }
    }
}
