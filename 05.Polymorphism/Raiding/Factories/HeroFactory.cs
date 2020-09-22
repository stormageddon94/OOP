using Raiding.Contracts;
using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Factories
{
    public abstract class HeroFactory
    {
        public HeroFactory(string name)
        {
            this.Name = name;
        }

        protected string Name { get; }

        public abstract IBaseHero CreateHero();
    }
}
