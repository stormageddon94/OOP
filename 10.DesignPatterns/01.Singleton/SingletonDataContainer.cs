using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace _01.Singleton
{
    public class SingletonDataContainer : ISingletonContainer
    {
        private Dictionary<string, int> capitals = new Dictionary<string, int>();

        private SingletonDataContainer()
        {
            Console.WriteLine("Intializing singleton object.");

            var elements = File.ReadAllLines("capitals.txt");
            for (int i = 0; i < elements.Length; i+=2)
            {
                capitals.Add(elements[i], int.Parse(elements[i++]));
            }
        }

        public static SingletonDataContainer Instance { get; } = new SingletonDataContainer();

        public int GetPopulation(string name)
        {
            return capitals[name];
        }

       
    }
}
