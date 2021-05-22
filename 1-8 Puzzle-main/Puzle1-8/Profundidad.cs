using System;
using System.Collections.Generic;
using System.Text;

namespace Puzle1_8
{
    class Profundidad
    {
        Arbol bAnch = new Arbol();
        static Game tablero = new Game();
        List<NodeNum> game = tablero.generateGame();
        List<Nodo> elements = new List<Nodo>();
        List<Nodo> anchura = new List<Nodo>();
        Nodo node = new Nodo();
        Nodo raiz;
        public Profundidad()
        {
            raiz = null;
        }
        public void fillTree()
        {
            int pos = 1;
            do
            {
                if (game[pos - 1].num != " ")
                {
                    bAnch.Insert(int.Parse(game[pos - 1].num));
                }
                else
                {
                    bAnch.Insert(0);
                }
                pos++;

            } while (pos != 10);
        }
        public List<Nodo> printTree()
        {
            profundidad(this.raiz);
            return elements;
        }
        public List<Nodo> profundidad(Nodo nodo)
        {
            if (nodo != null)
            {
                profundidad(nodo.hDer);
                profundidad(nodo.hIzq);
                elements.Add(nodo);
            }
            return elements;
        }
        public void Print()
        {
            elements.Clear();
            elements = printTree();
            for (int i = 0; i < elements.Count; i++)
            {
                Console.WriteLine(elements[i].Num + ", ");
            }
        }
        public void printProfundo()
        {
            elements.Clear();
            elements = printTree();
            for (int j = 0; j <= 9; j++)
            {
                for (int i = 0; i < elements.Count; i++)
                {
                    do
                    {
                        Console.WriteLine(elements[i].Num + " ");
                    } while (elements[i].Num == j);
                }
            }
        }
    }
}
