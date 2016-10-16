using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ORI_Projekat
{
    public class State
    {
        #region Informacioni deo
        public int x;
        public int y;
        #endregion

        #region deo za stablo pretrazivanja
        public State parent;
        public int nivo = 0;
        #endregion

        public List<State> MogucaStanja(int n)
        {
            List<State> zauzete = new List<State>();
            List<State> svaMoguca = new List<State>();

            State temp = this;
            //foreach (Point d in resenje)
            while (temp!=null)
            {
                for (int i = 0; i < n; i++)
                {
                    State zauzeto = new State();
                    zauzeto.x = temp.x;
                    zauzeto.y = i;
                    zauzete.Add(zauzeto);
                    zauzeto.x = i;
                    zauzeto.y = temp.y;
                    zauzete.Add(zauzeto);
                }
                for (int i = 0; i < n; i++)
                {
                    int x = temp.x;
                    int y = temp.y;

                    x = x - i;
                    y = y - i;

                    if (x < 0 || y < 0)
                        break;
                    else
                    {

                        State zauzeto = new State();
                        zauzeto.x = x;
                        zauzeto.y = y;
                        zauzete.Add(zauzeto);
                    }
                }
                for (int i = 0; i < n; i++)
                {
                    int x = temp.x;
                    int y = temp.y;

                    x = x - i;
                    y = y + i;

                    if (x < 0 || y > (n - 1))
                        break;
                    else
                    {

                        State zauzeto = new State();
                        zauzeto.x = x;
                        zauzeto.y = y;
                        zauzete.Add(zauzeto);
                    }
                }
                for (int i = 0; i < n; i++)
                {
                    int x = temp.x;
                    int y = temp.y;

                    x = x + i;
                    y = y - i;

                    if (x > (n - 1) || y < 0)
                        break;
                    else
                    {

                        State zauzeto = new State();
                        zauzeto.x = x;
                        zauzeto.y = y;
                        zauzete.Add(zauzeto);
                    }
                }
                for (int i = 0; i < n; i++)
                {
                    int x = temp.x;
                    int y = temp.y;

                    x = x + i;
                    y = y + i;

                    if (x > (n - 1) || y > (n - 1))
                        break;
                    else
                    {

                        State zauzeto = new State();
                        zauzeto.x = x;
                        zauzeto.y = y;
                        zauzete.Add(zauzeto);
                    }
                }
                temp = temp.parent;
            }
            //pravi listu svih mogucih stanja
            State novi = new State();
            novi = this;
            for (int i = 0; i < n; i++)
            {
                int x = this.x + 1;
                State moguce = new State();
                moguce.x = x;
                moguce.y = i;
                moguce.parent = this;
                moguce.nivo = this.nivo + 1;
                svaMoguca.Add(moguce);
            }
            //pravi listu slobodnih stanja,polja koja nisu zauzeta
            foreach (State d in zauzete)
            {
                for (int i = 0; i < svaMoguca.Count; i++)
                {
                    if (d.x == svaMoguca[i].x && d.y == svaMoguca[i].y)
                        svaMoguca.RemoveAt(i);

                }
            }
            
         return svaMoguca;
        }
    }
}
