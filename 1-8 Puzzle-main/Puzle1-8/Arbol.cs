using System;
using System.Collections.Generic;
using System.Text;

namespace Puzle1_8
{
    class Arbol
    {
        Nodo raiz;
        public Arbol()
        {
            raiz = null;
        }
        public bool isEmpty()
        {
            bool empty = true;
            if (raiz != null)
            {
                empty = false;
            }
            return empty;
        }

        public void Insert(int num)
        {
            Nodo n = new Nodo(num);
            if (raiz == null)
            {
                raiz = n;
            }
            else
            {
                Nodo aux = raiz;
                Nodo padre;
                while (true)
                {
                    padre = aux;
                    if (num < aux.Num)
                    {
                        aux = aux.hIzq;
                        if (aux == null)
                        {
                            padre.hIzq = n;
                            return;
                        }
                    }
                    else
                    {
                        aux = aux.hDer;
                        if (aux == null)
                        {
                            padre.hDer = n;
                            return;
                        }
                    }
                }
            }
        }

    }
}
