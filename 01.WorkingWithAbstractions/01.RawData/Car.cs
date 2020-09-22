using System.Collections.Generic;

namespace _01.RawData
{
    class Car
    {
        public Car(Engine engine, Cargo cargo, List<Tyre> tyres)
        {
            this.Engine = engine;
            this.Cargo = cargo;
            this.Tyres = tyres;
        }

        public Engine Engine { get; set; }

        public Cargo Cargo { get; set; }

        public List<Tyre> Tyres { get; set; }
    }
}
