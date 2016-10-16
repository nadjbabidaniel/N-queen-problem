using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace ORI_Projekat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        
        List<Point> resenje = new List<Point>();

        
        private void button1_Click(object sender, EventArgs e)
        {
            userControl11.BrojPolja = int.Parse(textBox1.Text);
            lblStatus.Text = "";
            if (int.Parse(textBox1.Text) > 3 || int.Parse(textBox1.Text) == 1)
            {
                List<State> zaObradu = new List<State>();
                for (int i = 0; i < userControl11.BrojPolja; i++)
                {
                    State start = new State();
                    start.x = 0;
                    start.y = i;
                    start.parent = null;
                    start.nivo = 1;
                    zaObradu.Add(start);


                }



                while (zaObradu.Count != 0)
                {

                    List<State> mogucaStanja = new List<State>();
                    if (zaObradu[0].nivo == userControl11.BrojPolja)
                        break;
                    mogucaStanja = zaObradu[0].MogucaStanja(userControl11.BrojPolja);
                    zaObradu.RemoveAt(0);

                    foreach (State p in mogucaStanja)
                        zaObradu.Insert(0, p);

                }
              
                    Point[] lokacije = new Point[userControl11.BrojPolja];
                    State temp = zaObradu[0];
                    int gi = 0;
                    while (temp != null)
                    {
                        lokacije[gi].X = temp.x;
                        lokacije[gi].Y = temp.y;
                        gi++;
                        temp = temp.parent;
                    }

                    lblStatus.Text = "Solution is successfully found";
                    userControl11.Pozicije = lokacije;

                
            }
            else
                lblStatus.Text = "There is no solution!";

            Invalidate();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
                button1.Enabled = true;
            else
                button1.Enabled = false;
        }
        private bool nonNumberEntered = false;
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (nonNumberEntered == true)
            {
                e.Handled = true;
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            nonNumberEntered = false;
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    if (e.KeyCode != Keys.Back)
                    {
                        nonNumberEntered = true;
                    }
                }
            }
        }
    }
}
