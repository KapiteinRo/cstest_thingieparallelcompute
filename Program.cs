using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Text;
using System.IO;

namespace CSTestParallelComputeThingie
{
    class Program
    {
        static void Main(string[] args)
        {
            RangeItems ris = new RangeItems(14, 54); // create with range
            float fLimit = 96f; // let's test with 96%

            Parallel.For(0, ris.Count, i => { ris[i].Compute(fLimit); }); // compute them all

            // pump to CSV
            File.WriteAllText("results.csv", ris.BuildCSVHeader());
            foreach (RangeItem ri in ris)
                File.AppendAllText("results.csv", ri.ToCSVString());

            // the end
            Console.Write("Finished.. press enter: ");
            Console.ReadLine();
        }
    }
}
