using System;
using System.Collections.Generic;
using System.Text;

namespace Puzle1_8
{
    public class TableroDIjks
    {
        static Game tablero = new Game();
        List<NodeNum> game = tablero.generateGame();
        public string[,] tab = new string[3, 3];
        public void generateTab()
        {
            int pos = 0;
            for(int i = 0; i <= 2; i++)
            {
                for(int j = 0; j <= 2; j++)
                {
                    tab[i, j] = game[pos].num;
                    pos++;
                }
            }
        }
        public int ubicaVacioX()
        {
            int x = 0;
            for (int i = 0; i <= 2; i++)
            {
                for (int j = 0; j <= 2; j++)
                {
                    if(tab[i,j]==" ")
                    {
                        x = i;
                    }
                }
            }
            return x;
        }
        public int ubicaVacioY()
        {
            int y = 0;
            for (int i = 0; i <= 2; i++)
            {
                for (int j = 0; j <= 2; j++)
                {
                    if (tab[i, j] == " ")
                    {
                        y = j;
                    }
                }
            }
            return y;
        }

        public bool endGame(List<NodeNum> actualGame)
        {
            bool itsOver = false;
            
            return itsOver;
        }

    }
}
