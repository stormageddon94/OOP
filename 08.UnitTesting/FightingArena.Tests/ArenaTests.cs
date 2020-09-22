using FightingArena;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Tests
{
    public class ArenaTests
    {
        private List<Warrior> warriors;
        private Warrior firstWarrior;
        private Warrior secondWarrior;
        private Warrior thirdWarrior;
        private Warrior fourthWarrior;
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            this.arena = new Arena();
            this.warriors = new List<Warrior>();
            this.firstWarrior = new Warrior("Kari", 1000, 1000);
            this.secondWarrior = new Warrior("Vesko", 200, 200);
            this.thirdWarrior = new Warrior("TheFallen", 300, 300);
            this.fourthWarrior = new Warrior("Diablo", 400, 400);

            warriors.Add(this.firstWarrior);
            warriors.Add(this.secondWarrior);
            warriors.Add(this.thirdWarrior);
            warriors.Add(this.fourthWarrior);

            arena.Enroll(firstWarrior);
            arena.Enroll(secondWarrior);
            arena.Enroll(thirdWarrior);
            arena.Enroll(fourthWarrior);

        }

        [Test]
        public void NewlyCreatedArenaShouldHaveWarriorList()
        {
            
            Assert.IsNotNull(arena);
        }

        [Test]
        public void TestCountOfWarriorsInArenaShouldEqualArenaCount()
        {
            Assert.That(arena.Count, Is.EqualTo(arena.Warriors.Count));
        }

        [Test]
        public void AddWarriorWichAlreadyExsistsThrows()
        {
            var existingWarrior = new Warrior("Kari", 1000, 1000);
            Assert.That(() => arena.Enroll(existingWarrior),
                Throws.InvalidOperationException.With.Message.EqualTo("Warrior is already enrolled for the fights!"));

        }

        [Test]
        public void EnrollNewWarriorShouldAddWarrior()
        {
            var fifthWarrior = new Warrior("Morgana", 500, 500);
            arena.Enroll(fifthWarrior);
            Assert.That(arena.Count, Is.EqualTo(5));
        }

        [Test]
        public void FightWithNonExisitingAttackerShouldThrow()
        {
            var attackingWarriorName = "D";
            var attackedWarriorName = "Kari";
            Assert.That(() => arena.Fight(attackingWarriorName, attackedWarriorName), 
                Throws.InvalidOperationException
                      .With
                      .Message
                      .EqualTo($"There is no fighter with name {attackingWarriorName} enrolled for the fights!"));
        }

        [Test]
        public void FightWithNonExistingAttackedWarriorShouldThrow()
        {
            var attackingWarriorName = "Kari";
            var attackedWarriorName = "D";
            Assert.That(() => arena.Fight(attackingWarriorName, attackedWarriorName),
                Throws.InvalidOperationException
                      .With
                      .Message
                      .EqualTo($"There is no fighter with name {attackedWarriorName} enrolled for the fights!"));
        }

        [Test]
        public void FightWithExistingWarriorsShouldChangeHP()
        {
            var attackingWarriorName = "Kari";
            var attackedWarriorName = "Vesko";

            arena.Fight(attackingWarriorName, attackedWarriorName);

            var weakerWarrior = arena.Warriors.FirstOrDefault(n => n.Name.Equals("Vesko"));
            Assert.That(weakerWarrior.HP, Is.EqualTo(0));
        }

    }
}
