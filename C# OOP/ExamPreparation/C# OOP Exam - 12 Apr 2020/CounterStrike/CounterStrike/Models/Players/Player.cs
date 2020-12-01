using System;
using System.Collections.Generic;
using System.Text;
using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Utilities.Messages;

namespace CounterStrike.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string username;
        private int health;
        private int armor;
        private IGun gun;

        public Player(string username, int health, int armor, IGun gun)
        {
            Username = username;
            Health = health;
            Armor = armor;
            Gun = gun;
        }


        public string Username
        {
            get => username;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerName);
                }

                username = value;
            }
        }

        public int Health
        {
            get => health;
            private set
            {
                if (value < 0)          // "Player health cannot be below or equal to 0."  ?!?!??!?!??!
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerHealth);
                }

                health = value;
            }
        }

        public int Armor
        {
            get => armor;
            private set
            {
                if (value < 0)        
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerArmor);
                }

                armor = value;
            }
        }

        public IGun Gun
        {
            get => gun;
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGun);
                }

                gun = value;
            }
        }


        public bool IsAlive => Health > 0;
     
        public void TakeDamage(int points)
        {
            //If the health points are less than or equal to zero, the player is dead. 

            int damaged = Math.Abs(Armor - points);

            if (Armor - points >= 0)
            {
                Armor -= points;
            }

            else
            {
                Armor = 0;

                if (Health - damaged > 0)
                {
                    Health -= damaged;
                }

                else
                {
                    Health = 0;
                }
            }
        }


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"{this.GetType().Name}: {Username}");
            sb.AppendLine($"--Health: {Health}");
            sb.AppendLine($"--Armor: {Armor}");
            sb.AppendLine($"--Gun: {Gun.Name}");

            return sb.ToString().TrimEnd();
        }
    }
}
