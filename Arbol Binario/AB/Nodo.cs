using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB
{
    class Nodo
    {
        int num;
        string nom;
        Nodo izq, der;

        public Nodo(int num, string nom)
        {
            this.nom = nom;
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
        public string Nom
        {
            get
            {
                return nom;
            }
            set
            {
                nom = value;
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
