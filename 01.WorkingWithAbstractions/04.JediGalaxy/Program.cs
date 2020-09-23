namespace P03_JediGalaxy
{
    using System;
    using System.Linq;

    /// <summary>
    /// The entry point of the program.
    /// </summary>
    public class Program
    {
        public static void Main()
        {
            int[] dimension = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                                                .Select(int.Parse)
                                                .ToArray();
            int galaxyRows = dimension[0];
            int galaxyCols = dimension[1];

            int[,] galaxy = new int[galaxyRows, galaxyCols];

            int starValue = 0;
            for (int row = 0; row < galaxyRows; row++)
            {
                for (int col = 0; col < galaxyCols; col++)
                {
                    galaxy[row, col] = starValue++;
                }
            }

            string command = Console.ReadLine();
            long collectedStarPower = 0;
            while (command != "Let the Force be with you")
            {
                int[] ivoCoordinates = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int[] evilCoordinates = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                ChangeGalaxy(galaxyRows, galaxyCols, galaxy, evilCoordinates);
                collectedStarPower = AddStarPower(galaxyRows, galaxyCols, galaxy, collectedStarPower, ivoCoordinates);
                command = Console.ReadLine();
            }

            Console.WriteLine(collectedStarPower);
        }

        private static long AddStarPower(int galaxyRows, int galaxyCols, int[,] galaxy, long collectedStarPower, int[] ivoCoordinates)
        {
            int ivoRow = ivoCoordinates[0];
            int ivoCol = ivoCoordinates[1];

            while (ivoRow >= 0 && ivoCol < galaxyCols)
            {
                if (ivoRow >= 0 && ivoRow < galaxyRows && ivoCol >= 0 && ivoCol < galaxyCols)
                {
                    collectedStarPower += galaxy[ivoRow, ivoCol];
                }

                ivoCol++;
                ivoRow--;
            }

            return collectedStarPower;
        }

        private static void ChangeGalaxy(int galaxyRows, int galaxyCols, int[,] galaxy, int[] evilCoordinates)
        {
            int evilRow = evilCoordinates[0];
            int evilCol = evilCoordinates[1];

            while (evilRow >= 0 && evilCol >= 0)
            {
                if (evilRow >= 0 && evilRow < galaxyRows && evilCol >= 0 && evilCol < galaxyCols)
                {
                    galaxy[evilRow, evilCol] = 0;
                }

                evilRow--;
                evilCol--;
            }
        }
    }
}
