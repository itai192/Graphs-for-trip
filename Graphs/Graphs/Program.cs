using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    class Program
    {
        static void Main(string[] args)
        {
            int i = 7;
            while (!Graph.CheckAllGraphsOfOrder(i, 3))
            {
                Console.WriteLine(i);
                i++;
            }
            Console.WriteLine("Finished");
            Console.ReadKey();
        }
    }
}
