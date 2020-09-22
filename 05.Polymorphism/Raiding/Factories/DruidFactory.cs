using Raiding.Contracts;
using Raiding.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Factories
{
    public class DruidFactory : HeroFactory
    {
        public DruidFactory(string name) : base(name)
        {
        }

        public override IBaseHero CreateHero()
        {
            return new Druid(this.Name);
        }
    }
}
