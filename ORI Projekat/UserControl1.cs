using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ORI_Projekat
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        private int n=8;
        private Point[] pozicije;

        public Point[] Pozicije
        {
            get { return pozicije; }
            set {
                pozicije = value;
                Invalidate();
                }
        }

        public int BrojPolja
        {
            get { return n; }
            set { n = value; }
        }

        private void UserControl1_Paint(object sender, PaintEventArgs e)
        {

            
            int size = Width / n;

            for (int i = 0; i < n; i++)
            {
                for (int a=0; a <n ;a++)
                if((a+i)%2==0)
                    e.Graphics.FillRectangle(Brushes.Black, i * size, a * size, size, size);
                else
                    e.Graphics.FillRectangle(Brushes.White, i * size, a * size, size, size);

            }

            Image img = ORI_Projekat.Properties.Resources.Dragon_Ball_icon;
            if (pozicije != null)
            {
                foreach (Point p in pozicije)
                {
                    e.Graphics.DrawImage(img, p.X*size, p.Y*size,size,size );
                }
            }
            
            
            

        }

      
    }
}
