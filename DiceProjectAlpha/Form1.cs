using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DiceProjectAlpha
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            Dice MyDice = new Dice();
            MessageBox.Show(MyDice.Roll(pictureBox1).ToString());
            Dice MyDice2 = new Dice();
            MessageBox.Show(MyDice2.Roll(pictureBox1).ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Character joe = new Character(3);
            MessageBox.Show(joe.Health.ToString());
            joe.TakeDamage(2);
            MessageBox.Show(joe.Health.ToString());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Character bob = new Character();
            bob.Attack = 1;
            Character karen = new Character();
            karen.Attack = 3;
            MessageBox.Show("Bob's attack: "+ bob.Attack);
            MessageBox.Show("Karen's attack: " + karen.Attack + " boooooo");
            bob.Health = 10;
            karen.Health = 3;
            karen.DealDamage(bob);
            MessageBox.Show("Karen attacked bob. Bob's remaining life: "+bob.Health);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Character Juanita = new Character();
            Juanita.Maxhp = 11;
            Juanita.Health = 5;
            MessageBox.Show(Juanita.Health.ToString());
            Juanita.Regen(40);
            MessageBox.Show(Juanita.Health.ToString());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Character Carlos = new Character();
            Character John = new Character();
            Carlos.Team = "Red";
            John.Team = "Blue";
            Carlos.Heal = 2;
            John.Maxhp = 5;
            John.Health = 4;
            Carlos.GiveHeal(John);
            

        }

        private void button5_Click(object sender, EventArgs e)
        {
            List<Character> deck = new List<Character>();
            Random r = new Random();
            for (int i = 0; i < 5; i++)
            {
                Character peepeepoopoo = new Character();
                peepeepoopoo.Maxhp = r.Next(1, 11);
                deck.Add(peepeepoopoo);
            }
            
        }
    }
}
