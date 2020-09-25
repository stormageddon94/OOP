using System;

namespace _01.Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new SingletonDataContainer.Instance;

        }
    }
}
