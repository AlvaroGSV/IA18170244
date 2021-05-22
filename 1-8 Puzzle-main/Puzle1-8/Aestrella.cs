using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Puzle1_8
{
    class Aestrella
    {
        public List<Aia> AStarSearch(Aia root)
        {
            List<Aia> PathToSolution = new List<Aia>();
            Queue<int, Aia> FrontierList = new Queue<int, Aia>();
            List<Aia> ExploredList = new List<Aia>();
            int maxNumberOfFrontierList = 0;
            root.costHeuristic = getHeuristicCost(root);
            root.costTotalEstimated = root.costFromRoot + getHeuristicCost(root);
            FrontierList.Enqueue(getCostFromRoot(root) + root.costHeuristic, root);
            bool isGoalFound = false;
            while (FrontierList.Count() > 0 && !isGoalFound)
            {
                Aia currentNode = FrontierList.Peek().Value;
                if (currentNode.GoalTest())
                {
                    Console.WriteLine("Goal Found");
                    isGoalFound = true;
                    PathTrace(PathToSolution, currentNode);
                    Console.WriteLine("Expanded List's Count is " + ExploredList.Count());
                    Console.WriteLine("Maximum number stored in Frontier List is " + maxNumberOfFrontierList);
                    break;
                }
                ExploredList.Add(currentNode);
                if (maxNumberOfFrontierList < FrontierList.Count()) maxNumberOfFrontierList = FrontierList.Count();
                FrontierList.Dequeue();
                currentNode.ExpandNode();               
                for (int i = 0; i < currentNode.children.Count; i++)
                {
                    currentNode.children[i].costFromRoot = getCostFromRoot(currentNode.children[i]);
                    currentNode.children[i].costHeuristic = getHeuristicCost(currentNode.children[i]);
                    currentNode.children[i].costTotalEstimated = currentNode.children[i].costFromRoot + currentNode.children[i].costHeuristic;
                    if (!Contains(FrontierList, currentNode.children[i]) && !Contains(ExploredList, currentNode.children[i]))
                    {
                        FrontierList.Enqueue(currentNode.children[i].costTotalEstimated, currentNode.children[i]);
                    }
                    else if (Contains(FrontierList, currentNode.children[i]))
                    {
                        checkWhichHasHighCost(ref FrontierList, currentNode.children[i], "Heuristic");
                    }
                }
            }
            return PathToSolution;
        }

        public void PathTrace(List<Aia> path, Aia n)
        {
            Console.WriteLine("Tracing path..");
            Aia current = n;
            path.Add(current);

            while (current.parent != null)
            {
                current = current.parent;
                path.Add(current);
            }
        }

        public void checkWhichHasHighCost(ref Queue<int, Aia> FrontierList, Aia n, string nameOfCost)
        {
            int value = 0;

            if (nameOfCost.Equals("Uniform")) value = n.costFromRoot;
            else if (nameOfCost.Equals("Heuristic")) value = n.costHeuristic;

            Queue<int, Aia> templateList = new Queue<int, Aia>();
            List<Aia> nodeList = FrontierList.getHeapVariables();
            List<int> costList = FrontierList.getHeapCosts();
            int index = 0;
            bool willChange = false;

            for (int i = 0; i < nodeList.Count(); i++)
            {
                if (nodeList[i].isSamePuzzle(n.tab))
                {
                    if (value < costList[i])
                    {
                        willChange = true;
                        index = i;
                        break;
                    }
                }
            }
            if (willChange)
            {
                for (int i = 0; i < nodeList.Count(); i++)
                {
                    if (i != index) templateList.Enqueue(costList[i], nodeList[i]);
                }
                templateList.Enqueue(value, nodeList[nodeList.Count - 1]);

                FrontierList = templateList;
            }
        }
        public static bool Contains(List<Aia> list, Aia c)
        {
            bool contains = false;

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].isSamePuzzle(c.tab))
                    contains = true;
            }
            return contains;
        }
        public static bool Contains(Stack<Aia> stack, Aia c)
        {
            bool contains = false;
            Aia[] template = new Aia[stack.Count];

            stack.CopyTo(template, 0);

            for (int i = 0; i < stack.Count; i++)
            {
                if (template[i].isSamePuzzle(c.tab))
                    contains = true;
            }
            return contains;
        }
        public static bool Contains(Queue<int, Aia> list, Aia c)
        {
            bool contains = false;

            List<Aia> nodeList = list.getHeapVariables();

            for (int i = 0; i < list.Count(); i++)
            {
                if (nodeList[i].isSamePuzzle(c.tab))
                    contains = true;
            }
            return contains;
        }
        public static int getCostFromRoot(Aia n)
        {
            Aia current = n;
            List<Aia> listUC = new List<Aia>();
            listUC.Add(current);

            while (current.parent != null)
            {
                current = current.parent;
                listUC.Add(current);
            }
            return listUC.Count - 1;
        }
        public static int getHeuristicCost(Aia n)
        {
            int heuristicValue = 0;

            int[] rowIndexes = { 2, 0, 0, 0, 1, 1, 1, 2, 2 };
            int[] columnIndexes = { 2, 0, 1, 2, 0, 1, 2, 0, 1 };

            for (int number = 1; number <= 8; number++)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (n.tab[i, j] == number)
                        {
                            heuristicValue += ManhattanDistance(i, rowIndexes[number], j, columnIndexes[number]);
                            i = j = 3;
                            break;
                        }

                    }
                }
            }
            return heuristicValue;
        }

        public static int ManhattanDistance(int x1, int x2, int y1, int y2)
        {
            return Math.Abs(x1 - x2) + Math.Abs(y1 - y2);
        }
    }
}
