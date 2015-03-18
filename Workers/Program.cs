using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers
{
    class Program
    {
        static void Main(string[] args)
        {
            WorkersCollection workers = FileReader.GetWorkersFromFile(@"Workers.txt");
            foreach (Worker w in workers)
            {
                Console.WriteLine("ID {0}, {1} {2}, salary {3}", w.Id, w.FirstName, w.LastName, w.CountAverageMonthlySalary());
            }
            Console.WriteLine();
            var sorted = workers.SortByAverageMonthlySalaryDescending();
            foreach (Worker w in sorted)
            {
                Console.WriteLine("ID {0}, {1} {2}, salary {3}", w.Id, w.FirstName, w.LastName, w.CountAverageMonthlySalary());
            }

            Console.ReadKey();
        }
    }
}
