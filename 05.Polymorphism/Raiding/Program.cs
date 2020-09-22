using Raiding.Contracts;
using Raiding.Factories;
using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace Raiding
{
    class Program
    {
        static void Main(string[] args)
        {
            var heroes = new List<IBaseHero>();

            var count = int.Parse(Console.ReadLine());

            HeroFactory factory;

            while (heroes.Count != count)
            {
                var name = Console.ReadLine();
                var type = Console.ReadLine();

                var heroType = Type.GetType($"Raiding.Models.{type}");
                //var heroType = typeof(Program).Assembly.GetType(type);

                if (heroType != null)
                {
                    var newHero = Activator.CreateInstance(heroType, name) as IBaseHero;
                    heroes.Add(newHero);
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                }

                //if (type == "Druid")
                //{
                //    factory = new DruidFactory(name);
                //    heroes.Add(factory.CreateHero());
                //}
                //else if (type == "Paladin")
                //{
                //    var paladin = new Paladin(name);
                //    heroes.Add(paladin);
                //}
                //else if (type == "Rogue")
                //{
                //    var rogue = new Rogue(name);
                //    heroes.Add(rogue);
                //}
                //else if (type == "Warrior")
                //{
                //    var warrior = new Warrior(name);
                //    heroes.Add(warrior);
                //}
                //else
                //{
                //    Console.WriteLine("Invalid hero!");
                //}
            }

            var bossPower = int.Parse(Console.ReadLine());
            FightBoss(bossPower, heroes);
            
        }

        public static void FightBoss(int bossPower, List<IBaseHero> heroes)
        {
            heroes.ForEach(x => Console.WriteLine(x.CastAbility()));
            var totalHeroePower = heroes.Select(x => x.Power).Sum();

            if (totalHeroePower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}
