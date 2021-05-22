using System;
using System.Collections.Generic;
using System.Text;

namespace Puzle1_8
{
    class Nodo
    {
        int num;
        Nodo izq, der;
        public Nodo()
        {
        }
        public Nodo(int num)
        {
            this.num = num;
            this.izq = null;
            this.der = null;
        }
        public int Num
        {
            get
            {
                return num;
            }
            set
            {
                num = value;
            }
        }
        public Nodo hIzq
        {
            get
            {
                return izq;
            }
            set
            {
                izq = value;
            }
        }
        public Nodo hDer
        {
            get
            {
                return der;
            }
            set
            {
                der = value;
            }
        }
    }
}
