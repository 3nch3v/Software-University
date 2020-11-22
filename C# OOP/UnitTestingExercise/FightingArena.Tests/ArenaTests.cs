using System;
using System.Linq;
using NUnit.Framework;
using FightingArena;

namespace Tests
{
    public class ArenaTests
    {
        private Arena arena;

        [SetUp]
        public void Setup()
        {
            arena = new Arena();
        }

        [Test]
        public void InstanceShouldNotBeNull()
        {
            Assert.NotNull(arena);
        }

        [Test]
        public void ConstuctorShouldCreatAListOfWarriors()
        {
            var listOfWoArenaWarriors = arena.Warriors;
            Assert.NotNull(listOfWoArenaWarriors);
        }

        [Test]
        public void CountMethodShouldReturnTheCountOfListOfWarriors()
        {
            var actualresult = arena.Count;
            var expectedResult = 0;

            Assert.AreEqual(expectedResult, actualresult);
        }

        [Test]
        public void CountMethodShouldReturnTheCountOfListOfWarriorsAfterAddANewWarrior()
        {
            Warrior warrior = new Warrior("Ivan", 100, 100);
            arena.Enroll(warrior);
            var actualresult = arena.Count;
            var expectedResult = 1;

            Assert.AreEqual(expectedResult, actualresult);
        }


        [Test]
        public void EnrollMethodShouldNotAddANewWarriorWithTheSameName()
        {
            Warrior warrior = new Warrior("Ivan", 100, 100);
            arena.Enroll(warrior);

            Assert.Throws<InvalidOperationException>(() => arena.Enroll(new Warrior("Ivan", 100, 100)));
        }



        [Test]
        public void FightwithValidInput()
        {
            Warrior firstWarrior = new Warrior("Ivan", 10, 100);
            Warrior secWarrior = new Warrior("Stamat", 10, 100);

            arena.Enroll(firstWarrior);
            arena.Enroll(secWarrior);

            arena.Fight("Ivan", "Stamat");

            var actualResult = secWarrior.HP;
            var expectedResult = 90;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        [TestCase("noName", "Stamat")]
        public void FightWitouthAttackerShouldthrowException(string missingName, string defenderName)
        {
            Warrior firstWarrior = new Warrior("Ivan", 10, 100);
            Warrior secWarrior = new Warrior("Stamat", 10, 100);

            arena.Enroll(firstWarrior);
            arena.Enroll(secWarrior);

           Assert.That(() => arena.Fight(missingName, defenderName), Throws.InvalidOperationException.With.Message.EqualTo($"There is no fighter with name {missingName} enrolled for the fights!"));
        }

        [Test]
        [TestCase("Stamat", "NoName")]
        public void FightWitouthDefenderShouldthrowException(string attackerName, string defenderName)
        {
            Warrior firstWarrior = new Warrior("Ivan", 10, 100);
            Warrior secondWarrior = new Warrior("Stamat", 10, 100);

            arena.Enroll(firstWarrior);
            arena.Enroll(secondWarrior);

            //Assert.That(() => arena.Fight(attackerName, defenderName),
            //    Throws.InvalidOperationException.With.Message.EqualTo(
            //        $"There is no fighter with name {defenderName} enrolled for the fights!"));

            Assert.Throws<InvalidOperationException>(() => arena.Fight(attackerName, defenderName),
                $"There is no fighter with name {defenderName} enrolled for the fights!");
        }


    }
}
