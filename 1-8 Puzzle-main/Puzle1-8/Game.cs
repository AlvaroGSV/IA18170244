using System;
using System.Collections.Generic;
using System.Text;

namespace Puzle1_8
{
    class Game
    {
        public List<NodeNum> game = new List<NodeNum>();
        Random random = new Random();
        List<string> noUse = new List<string>();
        //public string[,] tablero = new string[3, 3]; matriz que decarte
        public string[] final = new string[9];
        int res = 0;

        public List<NodeNum> generateGame()
        {
            do
            {
                int randomNum = int.Parse(random.Next(1, 10).ToString());
                if (!noUse.Contains(randomNum.ToString()))
                {
                    NodeNum num = new NodeNum(randomNum.ToString());
                    game.Add(num);
                    noUse.Add(randomNum.ToString());
                }
            } while (game.Count != 9);
            do
            {
                res++;
                if (res == 9)
                {
                    final[res-1] = " ";
                }
                else
                {
                    final[res-1] = res.ToString();
                }
            } while (res != 9);
            for(int i = 0; i < game.Count; i++)
            {
                if (game[i].num == "9")
                {
                    game[i].num = "0";
                }
            }
            for(int i = 0; i < game.Count; i++)
            {
                Console.Write(game[i].num + " ");
            }
            return game;
        }

        public void Pasos()
        {

        }
    }
}
