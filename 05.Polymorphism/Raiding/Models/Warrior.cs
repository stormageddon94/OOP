using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public class Warrior : BaseHero
    {
        public Warrior(string name) : base(name)
        {
            this.Power = 100;
        }

        public override string CastAbility()
        {
            return base.CastAbility() + $"hit for {Power} damage";
        }
    }
}
