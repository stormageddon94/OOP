using Raiding.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Models
{
    public abstract class BaseHero : IBaseHero
    {
        public BaseHero(string name)
        {
            this.Name = name;
        }
        public string Name { get; private set; }

        public int Power { get; protected set; }

        public virtual string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} ";
        }
        
    }
}
