using System;
using System.Collections.Generic;
using System.Text;

namespace Puzle1_8
{
    class Aia
    {
        public List<Aia> children = new List<Aia>();
        public Aia parent;
        public int[,] tab = new int[3, 3];
        public int i = 0, j = 0;
        public static int[,] goalState = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 0 } };
        public int costFromRoot = 0;
        public int costHeuristic = 0;
        public int costTotalEstimated = 0;
        
        
        public Aia(int[,] p)
        {
            SetPuzzle(p);
        }

        public void SetPuzzle(int[,] p)
        {
            for (int i = 0; i < tab.GetLength(0); i++)
            {
                for (int j = 0; j < tab.GetLength(1); j++)
                {
                    this.tab[i, j] = p[i, j];
                }
            }
        }

        public void ExpandNode()
        {
            for (int i = 0; i < tab.GetLength(0); i++)
            {
                for (int j = 0; j < tab.GetLength(1); j++)
                {
                    if (tab[i, j] == 0)
                    {
                        this.i = i;
                        this.j = j;
                    }
                }
            }
            izquierda(tab, i, j);
            Arriba(tab, i, j);
            derecha(tab, i, j);
            Abajo(tab, i, j);
        }

        public void derecha(int[,] p, int i, int j)
        {
            if (j < 2)
            {
                int[,] newPuzzle = CopyPuzzle(p);

                int temp = newPuzzle[i, j + 1];
                newPuzzle[i, j + 1] = newPuzzle[i, j];
                newPuzzle[i, j] = temp;

                Aia child = new Aia(newPuzzle);
                children.Add(child);
                child.parent = this;

            }
        }

        public void izquierda(int[,] p, int i, int j)
        {
            if (j > 0)
            {
                int[,] newPuzzle = CopyPuzzle(p);

                int temp = newPuzzle[i, j - 1];
                newPuzzle[i, j - 1] = newPuzzle[i, j];
                newPuzzle[i, j] = temp;

                Aia child = new Aia(newPuzzle);
                children.Add(child);
                child.parent = this;

            }
        }

        public void Arriba(int[,] p, int i, int j)
        {
            if (i > 0)
            {
                int[,] newPuzzle = CopyPuzzle(p);

                int temp = newPuzzle[i - 1, j];
                newPuzzle[i - 1, j] = newPuzzle[i, j];
                newPuzzle[i, j] = temp;

                Aia child = new Aia(newPuzzle);
                children.Add(child);
                child.parent = this;

            }
        }

        public void Abajo(int[,] p, int i, int j)
        {
            if (i < 2)
            {
                int[,] newPuzzle = CopyPuzzle(p);

                int temp = newPuzzle[i + 1, j];
                newPuzzle[i + 1, j] = newPuzzle[i, j];
                newPuzzle[i, j] = temp;

                Aia child = new Aia(newPuzzle);
                children.Add(child);
                child.parent = this;

            }
        }
        
        public bool isSamePuzzle(int[,] p)
        {
            bool isSamePuzzle = true;

            for (int i = 0; i < tab.GetLength(0); i++)
            {
                for (int j = 0; j < tab.GetLength(1); j++)
                {
                    if (tab[i, j] != p[i, j]) isSamePuzzle = false;
                }
            }
            return isSamePuzzle;
        }

        public static int[,] CopyPuzzle(int[,] p)
        {
            int[,] copy = new int[3, 3];

            for (int i = 0; i < p.GetLength(0); i++)
            {
                for (int j = 0; j < p.GetLength(1); j++)
                {
                    copy[i, j] = p[i, j];
                }
            }
            return copy;
        }

        public static Aia CopyNode(Aia n)
        {
            Aia copy = new Aia(n.tab);
            return copy;
        }

        public bool GoalTest()
        {
            bool isGoal = true;

            for (int i = 0; i < tab.GetLength(0); i++)
            {
                for (int j = 0; j < tab.GetLength(1); j++)
                {
                    if (tab[i, j] != goalState[i, j]) isGoal = false;
                }
            }
            return isGoal;
        }

    }
}
