using System;

namespace ClassBoxData
{
    class Program
    {
        static void Main(string[] args)
        {
            try

            {
                var length = double.Parse(Console.ReadLine());
                var width = double.Parse(Console.ReadLine());
                var heigth = double.Parse(Console.ReadLine());
                var box = new Box(length, width, heigth);
                var surfaceArea = box.GetSurfaceArea();
                var lateralSurfaceArea = box.GetLateralSurfaceArea();
                var volume = box.GetVolume();

                Console.WriteLine($"Surface Area - {surfaceArea:F2}");
                Console.WriteLine($"Lateral Surface Area - {lateralSurfaceArea:F2}");
                Console.WriteLine($"Volume - {volume:F2}");
            }
            catch (ArgumentException exception)
            {

                Console.WriteLine(exception.Message.ToString());
            }


        }
    }
}
