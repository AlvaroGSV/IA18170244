using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB
{
    class Arbol
    {
        List<Nodo> elements = new List<Nodo>();
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

        public void Insert (int num, string nom)
        {
            Nodo n = new Nodo(num, nom);
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
        public List<Nodo> printTree()
        {
            elements.Clear();
            inOrder(this.raiz);
            return elements;
        }
        public List<Nodo> inOrder(Nodo nodo)
        {
            if (nodo != null)
            {
                inOrder(nodo.hIzq);
                elements.Add(nodo);
                inOrder(nodo.hDer);
            }
            return elements;
        }
        public Boolean searchInOrder(Nodo nodo, int num, string nom)
        {
            Boolean encontrado = false;
            
            if (nodo != null)
            {
                searchInOrder(nodo.hIzq,num,nom);
                elements.Add(nodo);
                searchInOrder(nodo.hDer,num,nom);
            }
            for(int i = 0; i < elements.Count; i++)
            {
                if(elements[i].Nom==nom && elements[i].Num == num)
                {
                    encontrado = true;
                }
            }
            return encontrado;
        }
        public string search(int num, string nom)
        {
            elements.Clear();
            string res = "";
            Boolean encontrado = false;
            encontrado = searchInOrder(this.raiz, num, nom);
            Nodo nodo = this.raiz;
            //List<Nodo> contenido = searchInOrder(this.raiz);
            
            if (isEmpty() != true)
            {
                if(raiz.Num==num && raiz.Nom == nom)
                {
                    res = raiz.Nom + " FUE ENONCOTRADO EN LA RAIZ";
                }
                else
                {
                    if (encontrado == true)
                    {
                        res = nom + " FUE ENCONTRADO";
                    }
                    else
                    {
                        res = "NO ESTA REGISTRADO";
                    }
                }
            }
            else
            {
                res = "EL ARBOL ESTA VACIO";
            }
            elements.Clear();
            return res;
        }
    }
}
