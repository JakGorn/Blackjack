using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        class Card
        {
            
            public string cardId;
            public int value;
        }

        List<Card> deck= new List<Card>();
        int win = 0;
        int lose = 0;
        int totalplayer = 0;
        int totaldealer = 0;
        int NumberOfClick = 0;
        int NumberOfClick2 = 0;
        int NumberOfClick3 = 0;
       
        

        private void generateCards()
        {
            deck.Clear();
            string[] colors = { "C", "D", "H", "S" };
            string[] figures = { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
            int[] value = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 10, 10, 10, 1 };

            foreach (string c in colors)
            {
                for (int i = 0; i < figures.Length; i++)
                {
                    Card card = new Card();
                    if (i < 9)
                    {
                        card.cardId = "_" + figures[i] + c;
                    }
                    else
                    {
                        card.cardId = figures[i] + c;
                    }
                    card.value = value[i];
                    deck.Add(card);
                }
            }
        }

        private void shuffle()
        {
            Random rand = new Random();
            int a = rand.Next(10) + 100;
            for (int i=0;i<a;i++)
            {

                int i0 = rand.Next(deck.Count);
                int i1 = rand.Next(deck.Count);
                Card c1 = deck[i0];
                deck[i0] = deck[i1];
                deck[i1] = c1;
            }
        }

        private Card popcard()
        {
            Card c = deck[0];
            deck.RemoveAt(0);
            return c;
        }
        private bool iswinner()
        {
            return totalplayer == 21;
        }
        private bool iswinner2()
        {
            return totalplayer > totaldealer;
        }

        private bool islooser()
        {
            return totalplayer > 21;
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void hit_Click(object sender, EventArgs e)
        {
            
            ResourceManager rm = Properties.Resources.ResourceManager;
            Card c = popcard();
            totalplayer += c.value;
            total1.Text = totalplayer.ToString();
            ++NumberOfClick;
            switch (NumberOfClick)
            {
                case 1:
                    player3.Image = (Bitmap)rm.GetObject(c.cardId);
                    break;
                case 2:
                    player4.Image = (Bitmap)rm.GetObject(c.cardId);
                    break;
                case 3:
                    player5.Image = (Bitmap)rm.GetObject(c.cardId);
                    break;
                case 4:
                    player6.Image = (Bitmap)rm.GetObject(c.cardId);
                    break;
                case 5:
                    player7.Image = (Bitmap)rm.GetObject(c.cardId);
                    break;
                case 6:
                    player8.Image = (Bitmap)rm.GetObject(c.cardId);
                    break;
                case 7:
                    player9.Image = (Bitmap)rm.GetObject(c.cardId);
                    break;
                case 8:
                    player10.Image = (Bitmap)rm.GetObject(c.cardId);
                    break;

            }
            if(islooser() == true)
            {
                lose++;
                loses.Text = lose.ToString();
                DialogResult result1 = MessageBox.Show("BUST You LOSE." + " " + "Do you want to play again?", " ", MessageBoxButtons.YesNo);
                if(result1==DialogResult.Yes)
                {
                    deck.Clear();
                    totalplayer = 0;
                    totaldealer = 0;
                    NumberOfClick = 0;
                    NumberOfClick2 = 0;
                    NumberOfClick3 = 0;
                    total1.Text = null;
                    total2.Text = null;
                    player1.Image = null;
                    player2.Image = null;
                    player3.Image = null;
                    player4.Image = null;
                    player5.Image = null;
                    player6.Image = null;
                    player7.Image = null;
                    player8.Image = null;
                    player9.Image = null;
                    player10.Image = null;
                    dealer1.Image = null;
                    dealer2.Image = null;
                    dealer3.Image = null;
                    dealer4.Image = null;
                    dealer5.Image = null;
                    dealer6.Image = null;
                    dealer7.Image = null;
                    dealer8.Image = null;
                    dealer9.Image = null;
                    dealer10.Image = null;

                }
                if(result1 == DialogResult.No)
                {
                    Application.Exit();
                }
            }
            if(iswinner()==true)
            {
                c = popcard();
                totaldealer += c.value;
                total2.Text = totaldealer.ToString();
                dealer1.Image = (Bitmap)rm.GetObject(c.cardId);
                win++;
                wins.Text = win.ToString();
                DialogResult result1 = MessageBox.Show("You got 21 you WIN!!!" + " " + "Do you want to play again?", " ", MessageBoxButtons.YesNo);
                if (result1 == DialogResult.Yes)
                {
                    deck.Clear();
                    totalplayer = 0;
                    totaldealer = 0;
                    NumberOfClick = 0;
                    NumberOfClick2 = 0;
                    NumberOfClick3 = 0;
                    total1.Text = null;
                    total2.Text = null;
                    player1.Image = null;
                    player2.Image = null;
                    player3.Image = null;
                    player4.Image = null;
                    player5.Image = null;
                    player6.Image = null;
                    player7.Image = null;
                    player8.Image = null;
                    player9.Image = null;
                    player10.Image = null;
                    dealer1.Image = null;
                    dealer2.Image = null;
                    dealer3.Image = null;
                    dealer4.Image = null;
                    dealer5.Image = null;
                    dealer6.Image = null;
                    dealer7.Image = null;
                    dealer8.Image = null;
                    dealer9.Image = null;
                    dealer10.Image = null;
                }
                if (result1 == DialogResult.No)
                {
                    Application.Exit();
                }
            }
            
        }

        private void stand_Click(object sender, EventArgs e)
        {
            ResourceManager rm = Properties.Resources.ResourceManager;

            Card c = popcard();
            totaldealer += c.value;
            total2.Text = totaldealer.ToString();
            dealer1.Image = (Bitmap)rm.GetObject(c.cardId);
            while((totaldealer<17) && (totaldealer<totalplayer))
            {
                NumberOfClick2++;
                switch (NumberOfClick2)
                {
                    case 1:
                        c = popcard();
                        totaldealer += c.value;
                        total2.Text = totaldealer.ToString();
                        dealer3.Image = (Bitmap)rm.GetObject(c.cardId);
                        break;
                    case 2:
                        c = popcard();
                        totaldealer += c.value;
                        total2.Text = totaldealer.ToString();
                        dealer4.Image = (Bitmap)rm.GetObject(c.cardId);
                        break;
                    case 3:
                        c = popcard();
                        totaldealer += c.value;
                        total2.Text = totaldealer.ToString();
                        dealer5.Image = (Bitmap)rm.GetObject(c.cardId);
                        break;
                    case 4:
                        c = popcard();
                        totaldealer += c.value;
                        total2.Text = totaldealer.ToString();
                        dealer6.Image = (Bitmap)rm.GetObject(c.cardId);
                        break;
                    case 5:
                        c = popcard();
                        totaldealer += c.value;
                        total2.Text = totaldealer.ToString();
                        dealer7.Image = (Bitmap)rm.GetObject(c.cardId);
                        break;
                    case 6:
                        c = popcard();
                        totaldealer += c.value;
                        total2.Text = totaldealer.ToString();
                        dealer8.Image = (Bitmap)rm.GetObject(c.cardId);
                        break;
                    case 7:
                        c = popcard();
                        totaldealer += c.value;
                        total2.Text = totaldealer.ToString();
                        dealer9.Image = (Bitmap)rm.GetObject(c.cardId);
                        break;
                    case 8:
                        c = popcard();
                        totaldealer += c.value;
                        total2.Text = totaldealer.ToString();
                        dealer10.Image = (Bitmap)rm.GetObject(c.cardId);
                        break;

                }
                
            }
            if (totaldealer == totalplayer)
            {
                DialogResult result1 = MessageBox.Show("TIE" + " " + "Do you want to play again?", " ", MessageBoxButtons.YesNo);
                if (result1 == DialogResult.Yes)
                {
                    deck.Clear();
                    totalplayer = 0;
                    totaldealer = 0;
                    NumberOfClick = 0;
                    NumberOfClick2 = 0;
                    NumberOfClick3 = 0;
                    total1.Text = null;
                    total2.Text = null;
                    player1.Image = null;
                    player2.Image = null;
                    player3.Image = null;
                    player4.Image = null;
                    player5.Image = null;
                    player6.Image = null;
                    player7.Image = null;
                    player8.Image = null;
                    player9.Image = null;
                    player10.Image = null;
                    dealer1.Image = null;
                    dealer2.Image = null;
                    dealer3.Image = null;
                    dealer4.Image = null;
                    dealer5.Image = null;
                    dealer6.Image = null;
                    dealer7.Image = null;
                    dealer8.Image = null;
                    dealer9.Image = null;
                    dealer10.Image = null;
                }
                if (result1 == DialogResult.No)
                {
                    Application.Exit();
                }
            }
            if (totaldealer>21)
            {
                win++;
                wins.Text = win.ToString();
                DialogResult result1 = MessageBox.Show("Croupiers BUST you WIN!!!" + " " + "Do you want to play again?", " ", MessageBoxButtons.YesNo);
                if (result1 == DialogResult.Yes)
                {
                    deck.Clear();
                    totalplayer = 0;
                    totaldealer = 0;
                    NumberOfClick = 0;
                    NumberOfClick2 = 0;
                    NumberOfClick3 = 0;
                    total1.Text = null;
                    total2.Text = null;
                    player1.Image = null;
                    player2.Image = null;
                    player3.Image = null;
                    player4.Image = null;
                    player5.Image = null;
                    player6.Image = null;
                    player7.Image = null;
                    player8.Image = null;
                    player9.Image = null;
                    player10.Image = null;
                    dealer1.Image = null;
                    dealer2.Image = null;
                    dealer3.Image = null;
                    dealer4.Image = null;
                    dealer5.Image = null;
                    dealer6.Image = null;
                    dealer7.Image = null;
                    dealer8.Image = null;
                    dealer9.Image = null;
                    dealer10.Image = null;
                }
                if (result1 == DialogResult.No)
                {
                    Application.Exit();
                }
            }
            if(totaldealer==21 || (totaldealer>totalplayer))
            {
                lose++;
                loses.Text = lose.ToString();
                DialogResult result1 = MessageBox.Show("You LOSE." + " " + "Do you want to play again?", " ", MessageBoxButtons.YesNo);
                if (result1 == DialogResult.Yes)
                {
                    deck.Clear();
                    totalplayer = 0;
                    totaldealer = 0;
                    NumberOfClick = 0;
                    NumberOfClick2 = 0;
                    NumberOfClick3 = 0;
                    total1.Text = null;
                    total2.Text = null;
                    player1.Image = null;
                    player2.Image = null;
                    player3.Image = null;
                    player4.Image = null;
                    player5.Image = null;
                    player6.Image = null;
                    player7.Image = null;
                    player8.Image = null;
                    player9.Image = null;
                    player10.Image = null;
                    dealer1.Image = null;
                    dealer2.Image = null;
                    dealer3.Image = null;
                    dealer4.Image = null;
                    dealer5.Image = null;
                    dealer6.Image = null;
                    dealer7.Image = null;
                    dealer8.Image = null;
                    dealer9.Image = null;
                    dealer10.Image = null;
                }
                if (result1 == DialogResult.No)
                {
                    Application.Exit();
                }
            }
            if(totaldealer<totalplayer)
            {
                win++;
                wins.Text = win.ToString();
                DialogResult result1 = MessageBox.Show("You WIN!!!" + " " + "Do you want to play again?", " ", MessageBoxButtons.YesNo);
                if (result1 == DialogResult.Yes)
                {
                    deck.Clear();
                    totalplayer = 0;
                    totaldealer = 0;
                    NumberOfClick = 0;
                    NumberOfClick2 = 0;
                    NumberOfClick3 = 0;
                    total1.Text = null;
                    total2.Text = null;
                    player1.Image = null;
                    player2.Image = null;
                    player3.Image = null;
                    player4.Image = null;
                    player5.Image = null;
                    player6.Image = null;
                    player7.Image = null;
                    player8.Image = null;
                    player9.Image = null;
                    player10.Image = null;
                    dealer1.Image = null;
                    dealer2.Image = null;
                    dealer3.Image = null;
                    dealer4.Image = null;
                    dealer5.Image = null;
                    dealer6.Image = null;
                    dealer7.Image = null;
                    dealer8.Image = null;
                    dealer9.Image = null;
                    dealer10.Image = null;
                }
                if (result1 == DialogResult.No)
                {
                    Application.Exit();
                }
            }
            

        }

        private void deal_Click(object sender, EventArgs e)
        {
            NumberOfClick3++;
            switch (NumberOfClick3)
            {
                case 1:
                    totalplayer = 0;
                    totaldealer = 0;

                    ResourceManager rm = Properties.Resources.ResourceManager;

                    generateCards();
                    shuffle();

                    Card c = popcard();
                    totalplayer += c.value;
                    player1.Image = (Bitmap)rm.GetObject(c.cardId);

                    c = popcard();
                    totalplayer += c.value;
                    player2.Image = (Bitmap)rm.GetObject(c.cardId);


                    total1.Text = totalplayer.ToString();
                    dealer1.Image = (Bitmap)rm.GetObject("card_back_red");
                    c = popcard();
                    dealer2.Image = (Bitmap)rm.GetObject(c.cardId);
                    totaldealer += c.value;
                    total2.Text = totaldealer.ToString();
                    break;
                default:
                    break;
            } 
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            deck.Clear();
            win = 0;
            lose = 0;
            totalplayer = 0;
            totaldealer = 0;
            NumberOfClick = 0;
            NumberOfClick2 = 0;
            NumberOfClick3 = 0;
            total1.Text = "0";
            total2.Text = "0";
            wins.Text = "0";
            loses.Text = "0";
            player1.Image = null;
            player2.Image = null;
            player3.Image = null;
            player4.Image = null;
            player5.Image = null;
            player6.Image = null;
            player7.Image = null;
            player8.Image = null;
            player9.Image = null;
            player10.Image = null;
            dealer1.Image = null;
            dealer2.Image = null;
            dealer3.Image = null;
            dealer4.Image = null;
            dealer5.Image = null;
            dealer6.Image = null;
            dealer7.Image = null;
            dealer8.Image = null;
            dealer9.Image = null;
            dealer10.Image = null;
        }

        private void authorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "Author - Jakub Górniak class 3B";
            string caption = "Author";
            MessageBoxButtons buttons = MessageBoxButtons.OK;

            MessageBox.Show(message, caption, buttons);
        }

        private void infoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "Simple blackjack game with one simplification (aces equals just 1 not 1 and 11)";
            string caption = "Info";
            MessageBoxButtons buttons = MessageBoxButtons.OK;

            MessageBox.Show(message, caption, buttons);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
