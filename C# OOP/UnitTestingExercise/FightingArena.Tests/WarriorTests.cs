using System;
using FightingArena;
using NUnit.Framework;

namespace Tests
{
    public class WarriorTests
    {
        private Warrior warrior;

        [SetUp]
        public void Setup()
        {
            warrior = new Warrior("Ivan", 10, 100);
        }

        [Test]
        public void WarriorShouldNotBeNull()
        {
            Assert.NotNull(warrior);
        }

        [Test]
        public void CtorShouldSetTheName()
        {
            var actualResult = warrior.Name;
            var expectedResult = "Ivan";

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void NameShouldNotBeWhitespace()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("   ", 10, 100), "Name should not be empty or whitespace!");
        }

        [Test]
        public void NameShouldNotBeNullOrWhitespace()
        {
            Assert.Throws<ArgumentException>(() => new Warrior(null, 10, 100), "Name should not be empty or whitespace!");
        }

        [Test]
        public void CtorShouldSetTheDamage()
        {
            var actualResult = warrior.Damage;
            var expectedResult = 10;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void DamageValueShouldBePositive()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Ivan", 0, 100), "Damage value should be positive!");
        }
        [Test]
        public void DamageValueShouldBePositiveTwo()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Ivan", -12, 100), "Damage value should be positive!");
        }


        [Test]
        public void CtorShouldSetTheHP()
        {
            var actualResult = warrior.HP;
            var expectedResult = 100;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void HPValueShouldBePositive()
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Ivan", 10, -100), "HP should not be negative!");
        }


        [Test]
        public void CanNotAttackIfHPIsUnderMinAttackHP()
        {
            Warrior warrior = new Warrior("Ivan", 20, 1);
            Warrior secondWarrior = new Warrior("Pesho", 20, 100);

            Assert.Throws<InvalidOperationException>(() => warrior.Attack(secondWarrior),
                "Your HP is too low in order to attack other warriors!");
        }
        [Test]
        public void CanNotAttackIfHPIsEqualMinAttackHP()
        {
            Warrior warrior = new Warrior("Ivan", 20, 30);
            Warrior secondWarrior = new Warrior("Pesho", 20, 100);

            Assert.Throws<InvalidOperationException>(() => warrior.Attack(secondWarrior),
                "Your HP is too low in order to attack other warriors!");
        }

        [Test]
        public void EnemyHPCanNotAttackIfHPIsUnderMinAttackHP()
        {
            Warrior warrior = new Warrior("Ivan", 50, 100);
            Warrior secondWarrior = new Warrior("Pesho", 20, 1);

            Assert.Throws<InvalidOperationException>(() => warrior.Attack(secondWarrior));
            //throw new InvalidOperationException($"Enemy HP must be greater than {MIN_ATTACK_HP} in order to attack him!");
        }

        [Test]
        public void EnemyHPCanNotAttackIfHPIsEqualMinAttackHP()
        {
            Warrior warrior = new Warrior("Ivan", 50, 100);
            Warrior secondWarrior = new Warrior("Pesho", 20, 30);

            Assert.Throws<InvalidOperationException>(() => warrior.Attack(secondWarrior));
            //throw new InvalidOperationException($"Enemy HP must be greater than {MIN_ATTACK_HP} in order to attack him!");
        }

        [Test]
        public void WarriorShouldNotAttackToStrongEnemy()
        {
            Warrior warrior = new Warrior("Ivan", 50, 50);
            Warrior secondWarrior = new Warrior("Pesho", 60, 100);

            Assert.Throws<InvalidOperationException>(() => warrior.Attack(secondWarrior), "You are trying to attack too strong enemy");
    
        }

        [Test]
        public void HPShouldBeReduceWithTheWarriorDamage()
        {
            Warrior warrior = new Warrior("Ivan", 20, 100);
            Warrior secondWarrior = new Warrior("Pesho", 30, 100);

            warrior.Attack(secondWarrior);

            var actualResult = warrior.HP;
            var expectedResult = 70;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void WarriorShouldLoseHpByAttack()
        {
            Warrior warrior = new Warrior("Ivan", 20, 100);
            Warrior secondWarrior = new Warrior("Pesho", 30, 100);

            warrior.Attack(secondWarrior);

            var actualResult = secondWarrior.HP;
            var expectedResult = 80;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void WarriorShouldLoseAllHpByAttack()
        {
            Warrior warrior = new Warrior("Ivan", 50, 100);
            Warrior secondWarrior = new Warrior("Pesho", 30, 40);

            warrior.Attack(secondWarrior);

            var actualResult = secondWarrior.HP;
            var expectedResult = 0;

            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}