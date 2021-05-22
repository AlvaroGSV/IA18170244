using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace Puzle1_8
{
    class Busquedas
    {
        public void BusquedaPrimeroAnchura()
        {
            Anchura anch = new Anchura();
            Console.WriteLine("Estado inicial ~ ANCHURA");
            anch.fillTree();
            anch.Print();
            Console.WriteLine("PASOS");
            anch.printAncho();
        }
        public void BusquedaPrimeroProfundidad()
        {
            Profundidad prof = new Profundidad();
            Console.WriteLine("Estado inicial ~ PROFUNDIDAD");
            prof.fillTree();
            prof.Print();
            Console.WriteLine("PASOS");
            prof.printProfundo();
        }
        public void BusquedaDijkstra()
        {
            Console.WriteLine("Estado inicial ~ DIJKSTRA");
            TableroDIjks dIjks = new TableroDIjks();
            dIjks.generateTab();

        }
        public void BusquedaAStar()
        {
            Console.WriteLine("Estado inicial ~ A*");
            Game game = new Game();
            game.generateGame();
           
            Aestrella A = new Aestrella();
            
        }
    }
}
