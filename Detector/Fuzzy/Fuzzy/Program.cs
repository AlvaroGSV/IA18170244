using System;
using Accord;
using Accord.Fuzzy;

namespace Fuzzy
{
    class Program
    {
        static void Main(string[] args)
        {
            InferenceSystem IS;
            //VARIABLES LINGUISTICAS
            //ESTATURA (basado en '1.70' sin decimal, parametros variados para estar abiertos mas posibilidades segun las busquedas).
            FuzzySet fsEstaturaBaja = new FuzzySet("EstaturaBaja", new TrapezoidalFunction(92, 110, 140, 166));
            FuzzySet fsEstaturaMedia = new FuzzySet("EstaturaMedia", new TrapezoidalFunction(167, 170, 175, 179));
            FuzzySet fsEstaturaAlta = new FuzzySet("EstaturaAlta", new TrapezoidalFunction(180, 190, 205, 220));
            //PESO (parametros variados segun los las busquedas)
            FuzzySet fsLowPeso = new FuzzySet("PesoBajo", new TrapezoidalFunction(35, 40, 45, 59));
            FuzzySet fsMedPeso = new FuzzySet("PesoMedio", new TrapezoidalFunction(60, 65, 70, 78));
            FuzzySet fsHighPeso = new FuzzySet("PesoAlto", new TrapezoidalFunction(80, 90, 100, 120));
            //TEZ (un numero estadar tipo entero para diferenciar los tipos de tonos de piel)
            FuzzySet fsTezBlanca = new FuzzySet("Blanca", new TrapezoidalFunction(2, 2, 2, 2));
            FuzzySet fsTezOscura = new FuzzySet("Oscura", new TrapezoidalFunction(4, 4, 4, 4));
            FuzzySet fsTezMorena = new FuzzySet("Morena", new TrapezoidalFunction(3, 3, 3, 3));
            FuzzySet fsTezAmarilla = new FuzzySet("Amarilla", new TrapezoidalFunction(5, 5, 5, 5));
            FuzzySet fsTezPalida = new FuzzySet("Palida", new TrapezoidalFunction(1, 1, 1, 1));

            //COMPLEXION (un numero estadar tipo entero para diferenciar los tipos de cuerpos)
            FuzzySet fsFlaco = new FuzzySet("Flaco", new TrapezoidalFunction(1, 1, 1, 1));
            FuzzySet fsDelgado = new FuzzySet("Delgado", new TrapezoidalFunction(2, 2, 2, 2));
            FuzzySet fsNormal = new FuzzySet("Normal", new TrapezoidalFunction(3, 3, 3, 3));
            FuzzySet fsRobusto = new FuzzySet("Robsuto", new TrapezoidalFunction(4, 4, 4, 4));
            FuzzySet fsFornido = new FuzzySet("Fornido", new TrapezoidalFunction(5, 5, 5, 5));
            FuzzySet fsObeso = new FuzzySet("Obeso", new TrapezoidalFunction(6, 6, 6, 6));

            //Alguien feo
            FuzzySet fsUgly = new FuzzySet("Ugly", new TrapezoidalFunction(0, 10, 20, 30));
            //Alguien promedio
            FuzzySet fsPromedio = new FuzzySet("Promedio", new TrapezoidalFunction(25, 25, 45, 65));
            //Alguien sabros@ 
            FuzzySet fsBeauty = new FuzzySet("Beauty", new TrapezoidalFunction(50, 70, 90, 100));

            //PERSONA
            LinguisticVariable lvPerson = new LinguisticVariable("Person", 0, 100);
            //VALORES QUE PUEDE OBTENER UNA PERSONA
            lvPerson.AddLabel(fsUgly);
            lvPerson.AddLabel(fsPromedio);
            lvPerson.AddLabel(fsBeauty);

            //ESTATURA
            LinguisticVariable lvEstatura = new LinguisticVariable("Estatura", 92, 220);
            //LOS VALORES DE LA ESTATURA
            lvEstatura.AddLabel(fsEstaturaBaja);
            lvEstatura.AddLabel(fsEstaturaMedia);
            lvEstatura.AddLabel(fsEstaturaAlta);

            //PESO
            LinguisticVariable lvPeso = new LinguisticVariable("Peso", 35, 120);
            //LOS VALORES DE LA ESTATURA
            lvPeso.AddLabel(fsLowPeso);
            lvPeso.AddLabel(fsMedPeso);
            lvPeso.AddLabel(fsHighPeso);

            //TEZ
            LinguisticVariable lvTez = new LinguisticVariable("Tez", 1, 5);
            //LOS VALORES DE LA TEZ
            lvTez.AddLabel(fsTezBlanca);
            lvTez.AddLabel(fsTezOscura);
            lvTez.AddLabel(fsTezMorena);
            lvTez.AddLabel(fsTezAmarilla);
            lvTez.AddLabel(fsTezPalida);

            //COMPLEXION
            LinguisticVariable lvComplexion = new LinguisticVariable("Complexion", 1, 6);
            //LOS VALORES DE LA COMPLEXION
            lvComplexion.AddLabel(fsFlaco);
            lvComplexion.AddLabel(fsDelgado);
            lvComplexion.AddLabel(fsNormal);
            lvComplexion.AddLabel(fsRobusto);
            lvComplexion.AddLabel(fsFornido);
            lvComplexion.AddLabel(fsObeso);

            //BASE DE DATOS
            Database fuzzyDB = new Database();
            fuzzyDB.AddVariable(lvPerson);
            fuzzyDB.AddVariable(lvEstatura);
            fuzzyDB.AddVariable(lvPeso);
            fuzzyDB.AddVariable(lvTez);
            fuzzyDB.AddVariable(lvComplexion);
            // Creating the inference system
            IS = new InferenceSystem(fuzzyDB, new CentroidDefuzzifier(1000));
            //REGLAS DEL SISTEMA
            IS.NewRule("Rule 1", "IF Estatura IS EstaturaBaja THEN Person IS Promedio");
            IS.NewRule("Rule 2", "IF Estatura IS EstaturaMedia THEN Person IS Promedio");
            IS.NewRule("Rule 3", "IF Estatura IS EstaturaAlta THEN Person IS Beauty");

            IS.NewRule("Rule 4", "IF Peso IS PesoBajo THEN Person IS Beauty");
            IS.NewRule("Rule 5", "IF Peso IS PesoMedio THEN Person IS Promedio");
            IS.NewRule("Rule 6", "IF Peso IS PesoAlto THEN Person IS Ugly");

            IS.NewRule("Rule 7", "IF Estatura IS EstaturaAlta AND IF Peso IS PesoBajo THEN Person IS Beauty");
            IS.NewRule("Rule 8", "IF Estatura IS EstaturaMedia AND IF Peso IS PesoMedio THEN Person IS Promedio");
            IS.NewRule("Rule 9", "IF Estatura IS EstaturaBaja AND IF Peso IS PesoAlto THEN Person IS Ugly");

            IS.NewRule("Rule 10", "IF Tez IS Blanca THEN Person IS Promedio");
            IS.NewRule("Rule 11", "IF Tez IS Oscura THEN Person IS Promedio");
            IS.NewRule("Rule 12", "IF Tez IS Morena THEN Person IS Beauty");
            IS.NewRule("Rule 13", "IF Tez IS Amarilla THEN Person IS Ugly");
            IS.NewRule("Rule 14", "IF Tez IS Palida THEN Person IS Beauty");

            IS.NewRule("Rule 15", "IF Estatura IS EstaturaAlta AND IF Peso IS PesoBajo AND IF Tez IS Palida THEN Person IS Beauty");
            IS.NewRule("Rule 16", "IF Estatura IS EstaturaBaja AND IF Peso IS PesoAlto AND IF Tez IS Oscura THEN Person IS Ugly");
            IS.NewRule("Rule 17", "IF Estatura IS EstaturaBaja AND IF Peso IS PesoAlto AND IF Tez IS Blanca THEN Person IS Ugly");
            IS.NewRule("Rule 18", "IF Estatura IS EstaturaAlta AND IF Peso IS PesoMedio AND IF Tez IS Morena THEN Person IS Beauty");

            IS.NewRule("Rule 19", "IF Tez IS Blanca AND IF Peso IS PesoAlto THEN Person IS Ugly");
            IS.NewRule("Rule 20", "IF Tez IS Oscura AND IF Peso IS PesoAlto THEN Person IS Ugly");
            IS.NewRule("Rule 21", "IF Tez IS Morena AND IF Peso IS PesoAlto THEN Person IS Ugly");
            IS.NewRule("Rule 22", "IF Tez IS Amarilla AND IF Peso IS PesoAlto THEN Person IS Ugly");
            IS.NewRule("Rule 23", "IF Tez IS Palida AND IF Peso IS PesoAlto THEN Person IS Ugly");

            IS.NewRule("Rule 24", "IF Complexion IS Flaco THEN Person IS Promedio");
            IS.NewRule("Rule 25", "IF Complexion IS Delgado THEN Person IS Beauty");
            IS.NewRule("Rule 26", "IF Complexion IS Normal THEN Person IS Promedio");
            IS.NewRule("Rule 27", "IF Complexion IS Robsuto THEN Person IS Promedio");
            IS.NewRule("Rule 28", "IF Complexion IS Fornido THEN Person IS Beauty");
            IS.NewRule("Rule 29", "IF Complexion IS Obeso THEN Person IS Ugly");

            IS.NewRule("Rule 30", "IF Estatura IS EstaturaAlta AND IF Peso IS PesoBajo AND IF Tez IS Palida AND IF Complexion IS Delgado THEN Person IS Beauty");
            IS.NewRule("Rule 31", "IF Estatura IS EstaturaAlta AND IF Peso IS PesoBajo AND IF Tez IS Palida AND IF Complexion IS Fornido THEN Person IS Beauty");
            IS.NewRule("Rule 32", "IF Estatura IS EstaturaAlta AND IF Peso IS PesoMedio AND IF Tez IS Morena AND IF Complexion IS Fornido THEN Person IS Beauty");
            IS.NewRule("Rule 33", "IF Estatura IS EstaturaAlta AND IF Peso IS PesoBajo AND IF Tez IS Blanca AND IF Complexion IS Flaco THEN Person IS Beauty");
            IS.NewRule("Rule 34", "IF Estatura IS EstaturaAlta AND IF Peso IS PesoMedio AND IF Tez IS Oscura AND IF Complexion IS Fornido THEN Person IS Beauty");


            int altura = 0, tez = 0, complex = 0;
            float peso = 0;
            float res = 0;
            string b = "";

            Console.WriteLine("DIME, QUE TAN ALTO ERES");
            Console.WriteLine("POR FAVOR, NO USES DECIMALES. SI MIDES 1.76 ESCRIBE '176'");
            altura = int.Parse(Console.ReadLine());
            //lvEstatura.NumericInput = altura;

            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("DIME, CUANTO PESAS");
            peso = float.Parse(Console.ReadLine());
            //lvPeso.NumericInput = peso;

            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("DIME, DE QUE COLOR ES TU TEZ");
            Console.WriteLine("1.- Palida");
            Console.WriteLine("2.- Blanca");
            Console.WriteLine("3.- Morena");
            Console.WriteLine("4.- Oscura");
            Console.WriteLine("5.- Amarilla");
            tez = int.Parse(Console.ReadLine());
            //lvTez.NumericInput = tez;

            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("DIME, CUAL ES TU COMPLEXION");
            Console.WriteLine("1.- Flaco");
            Console.WriteLine("2.- Delgado");
            Console.WriteLine("3.- Normal");
            Console.WriteLine("4.- Robsuto");
            Console.WriteLine("5.- Fornido");
            Console.WriteLine("6.- Obeso");
            complex = int.Parse(Console.ReadLine());
            //lvComplexion.NumericInput = complex;

            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            IS.SetInput("Estatura", altura);
            IS.SetInput("Peso", peso);
            IS.SetInput("Tez", tez);
            IS.SetInput("Complexion", complex);
            res = IS.Evaluate("Person");
            if(res < 31)
            {
                Console.WriteLine("TIENES UN PUNTAJE DE {0} POR LO QUE TIENES EL SIGUIENTE RESULTADO", res);
                Console.WriteLine(IS.ExecuteInference("Person").OutputVariable.GetLabel("Ugly").Name.ToString());
            }
            else if (res > 49)
            {
                Console.WriteLine("TIENES UN PUNTAJE DE {0} POR LO QUE TIENES EL SIGUIENTE RESULTADO", res);
                Console.WriteLine(IS.ExecuteInference("Person").OutputVariable.GetLabel("Beauty").Name.ToString());
            }
            else
            {
                Console.WriteLine("TIENES UN PUNTAJE DE {0} POR LO QUE TIENES EL SIGUIENTE RESULTADO", res);
                Console.WriteLine(IS.ExecuteInference("Person").OutputVariable.GetLabel("Promedio").Name.ToString());
            }
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        }
    }
}
