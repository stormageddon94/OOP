using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public class Rogue : BaseHero
    {
        public Rogue(string name) : base(name)
        {
            this.Power = 80;
        }

        public override string CastAbility()
        {
            return base.CastAbility() + $"hit for {Power} damage";
        }
    }
}
