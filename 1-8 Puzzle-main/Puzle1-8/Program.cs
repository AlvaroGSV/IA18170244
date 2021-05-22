using System;

namespace Puzle1_8
{
    class Program
    {
        static void Main(string[] args)
        {
            //HELABORADO POR ALVARO GABRIEL SANCHES VILLARREAL Y JESSIEL ARMANDO DIAZ NORIEGA.
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            Busquedas search = new Busquedas();
            search.BusquedaPrimeroAnchura();
            search.BusquedaPrimeroProfundidad();
            search.BusquedaAStar();
            watch.Stop();
            Console.WriteLine("");
            Console.WriteLine("El tiempo de ejecucion es"+ watch.ElapsedMilliseconds +"ms");
           
        }
    }
}
