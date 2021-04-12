using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceProjectAlpha
{
    public class Character
    {
        private int health;
        private string team;
        /// <summary>
        /// Health of the Character
        /// </summary>
        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                if (value > Maxhp)
                {
                    health = Maxhp;
                }
                else
                {
                    health = value;
                }
            }
        }
        public int Move { get; set; }
        public int Attack { get; set; }
        public int Range { get; set; }
        public int Maxhp { get; set; }
        public int Heal { get; set; }
        public bool IsAlive { get; set; }
        public virtual Image Portrait { get; set; }
        public string Team
        {
            get
            {
                return team;
            }
            set
            {
                team = value.ToLower();
            }
        }
        public Character()
        {
            Health = 0;
            Move = 0;
            Attack = 0;
            Range = 0;
            Maxhp = 0;
            Heal = 0;
            Team = "Grey";
            IsAlive = true;

        }
        public Character(int startingHealth) : this()
        {
            Health = startingHealth;

        }
        public void TakeDamage(int amount)
        {
            Health -= amount;
            if (Health < 1)
            {
                System.Windows.Forms.MessageBox.Show(this + "You dead son");
            }
        }
        public void DealDamage(Character target)
        {
            System.Windows.Forms.MessageBox.Show("Attacking with a damage of: " + Attack);
            target.TakeDamage(Attack);
        }
        public void Regen(int heal)
        {
            int NewValue = Health + heal;
            Health = NewValue;
        }
        public void GiveHeal(Character ally)
        {
            System.Windows.Forms.MessageBox.Show("Healing with a value of: " + Heal);

            if (ally.Team == Team)
            {
                ally.Health += Heal;
                System.Windows.Forms.MessageBox.Show(ally.Health.ToString());
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("IMMA BAD BITHC YOU CAN'T HEAL ME");
            }

        }
   
       
        
    }
}
