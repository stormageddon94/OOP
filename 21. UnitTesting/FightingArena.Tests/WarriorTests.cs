using FightingArena;
using NUnit.Framework;

namespace Tests
{
    public class WarriorTests
    {
        private string name;
        private int damage;
        private int hp;

        [SetUp]
        public void Setup()
        {
            this.name = "TheFallen";
            this.damage = 1000;
            this.hp = 1000;
        }

        [Test]
        public void ConstructorWithProvidedParametersShouldCreateWarrior()
        {
            var warrior = new Warrior(name, damage, hp);
            Assert.IsNotNull(warrior);
        }

        [Test]
        public void EmptyNameThrowsException()
        {
            var emptyName = string.Empty;
            Assert.That(() => new Warrior(emptyName, damage, hp), 
                Throws.ArgumentException.With.Message.EqualTo("Name should not be empty or whitespace!"));
        }

        [Test]
        public void WhiteSpaceNameThrowsException()
        {
            var whiteSpaceName = " ";
            Assert.That(() => new Warrior(whiteSpaceName, damage, hp),
               Throws.ArgumentException.With.Message.EqualTo("Name should not be empty or whitespace!"));
        }

        [Test]
        public void NullNameThrowsException()
        {
            string nullName = null;
            Assert.That(() => new Warrior(nullName, damage, hp),
               Throws.ArgumentException.With.Message.EqualTo("Name should not be empty or whitespace!"));
        }

        [Test]
        public void NormalNameShouldSetUp()
        {
            var warrior = new Warrior(name, damage, hp);
            Assert.That(warrior.Name, Is.EqualTo(name));
        }

        [Test]
        public void ZeroDamageShouldThrow()
        {
            var zeroDamage = 0;
            Assert.That(() => new Warrior(name, zeroDamage, hp), 
                Throws.ArgumentException.With.Message.EqualTo("Damage value should be positive!"));
        }

        [Test]
        public void NegativeDamageShouldThrow()
        {
            var negativeDamage = -10;
            Assert.That(() => new Warrior(name, negativeDamage, hp),
                Throws.ArgumentException.With.Message.EqualTo("Damage value should be positive!"));
        }

        [Test]
        public void PositiveDamageShouldSetUp()
        {
            var warrior = new Warrior(name, damage, hp);
            Assert.That(warrior.Damage, Is.EqualTo(damage));
        }

        [Test]
        public void NegativeHPThrowsException()
        {
            var negativeHp = -10;
            Assert.That(() => new Warrior(name, damage, negativeHp), 
                Throws.ArgumentException.With.Message.EqualTo("HP should not be negative!"));
        }

        [Test]
        public void PositiveHPShouldSetUp()
        {
            var warrior = new Warrior(name, damage, hp);
            Assert.That(warrior.HP, Is.EqualTo(hp));
        }

        [Test]
        public void AttackWithWarriorWithHPLowerThanMinAttackHP()
        {
            var warriorWithLowerHP = new Warrior(name, damage, 20);
            var warriorToAttack = new Warrior("George", 100, 100);
            Assert.That(() => warriorWithLowerHP.Attack(warriorToAttack),
                Throws.InvalidOperationException.With.Message.EqualTo("Your HP is too low in order to attack other warriors!"));
        }

        [Test]
        public void AttackWariiroWithHPLowerThanMinAttackHPShouldThrow()
        {
            var attackingWarrior = new Warrior(name, damage, hp);
            
            var attackedWarrior = new Warrior("George", 100, 10);
            Assert.That(() => attackingWarrior.Attack(attackedWarrior),
                Throws.InvalidOperationException.With.Message.EqualTo("Enemy HP must be greater than 30 in order to attack him!"));
        }

        [Test]
        public void AttackStrongerEnemyShouldThrow()
        {
            var attackingWarrior = new Warrior(name, damage, hp);
            var attackedWarrior = new Warrior("George", 100000, 1000);
            Assert.That(() => attackingWarrior.Attack(attackedWarrior),
                Throws.InvalidOperationException.With.Message.EqualTo("You are trying to attack too strong enemy"));
        }

        [Test]
        public void AttackEnemyWithLowerHPShouldChangeHP()
        {
            var attackingWarrior = new Warrior(name, damage, hp);
            var attackedWarrior = new Warrior("George", 100, 100);
            var expectedHP = attackingWarrior.HP - attackedWarrior.Damage;
            attackingWarrior.Attack(attackedWarrior);

            Assert.That(attackingWarrior.HP, Is.EqualTo(expectedHP));
            Assert.That(attackedWarrior.HP, Is.EqualTo(0));
        }

        [Test]
        public void AttackEnemyWithHigherHPShouldChangeHp()
        {
            var attackingWarrior = new Warrior(name, damage, hp);
            var attackedWarrior = new Warrior("George", 100, 10000);
            var expectedAttackingWarriorHP = attackingWarrior.HP - attackedWarrior.Damage;
            var expectedAttatckedWarriorHP = attackedWarrior.HP - attackingWarrior.Damage;

            attackingWarrior.Attack(attackedWarrior);

            Assert.That(attackingWarrior.HP, Is.EqualTo(expectedAttackingWarriorHP));
            Assert.That(attackedWarrior.HP, Is.EqualTo(expectedAttatckedWarriorHP));
        }
    }
}