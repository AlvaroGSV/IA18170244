using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Nodo> show = new List<Nodo>();
            int op = 0, num;
            string nom;
            Arbol arbol = new Arbol();
            do
            {
                Console.WriteLine("1 ~ Esta vacio?");
                Console.WriteLine("2 ~ Insertar dato");
                Console.WriteLine("3 ~ Buscar Dato");
                Console.WriteLine("4 ~ Imprimir Arbol");
                Console.WriteLine("5 ~ Salir");
                Console.WriteLine("ESCOGE UNA OPCION");
                try
                {
                    op = int.Parse(Console.ReadLine());
                }
                catch
                {
                    Console.WriteLine("SOLO INGRESE NUMEROS");
                }
                switch (op)
                {
                    case 1:
                        if (arbol.isEmpty() == true)
                        {
                            Console.WriteLine("EL ARBOL ESTA VACIO");
                        }
                        else
                        {
                            Console.WriteLine("EL ARBOL NO ESTA VACIO");
                        }
                        break;
                    case 2:
                        Console.WriteLine("INGRESE EL NOMBRE A GUARAR");
                        nom = Console.ReadLine();
                        num = nom.Length;
                        arbol.Insert(num, nom);
                        break;
                    case 3:
                        string r;
                        //List<Nodo> nodos = arbol.searchInOrder(arbol);
                        Console.WriteLine("INGRESE EL NOMBRE A BUSCAR");
                        nom = Console.ReadLine();
                        num = nom.Length;
                        r = arbol.search(num, nom);
                        Console.WriteLine(r);
                        break;
                    case 4:
                        show = arbol.printTree();
                        for(int i=0; i < show.Count; i++)
                        {
                            Console.WriteLine(show[i].Nom);
                        }
                        break;
                    case 5:
                        Console.WriteLine("PRESIONE UALQUIER OTRA TECLA PARA SALIR");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("ESCOJA UNA DE LAS OPCIONES DISPONIBLES");
                        Console.ReadKey();
                        break;
                }
            } while (op != 5);
        }
    }
}
