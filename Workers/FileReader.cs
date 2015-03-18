using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Workers
{
    public static class FileReader
    {
        public static WorkersCollection GetWorkersFromFile(string path)
        {
            WorkersCollection workers = new WorkersCollection();
            using(FileStream fs = new FileStream(path, FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(fs))
                {
                    while (!reader.EndOfStream)
                    {
                        string[] line = reader.ReadLine().Split(',');
                        switch (line[0])
                        {
                            case "t":
                                workers.Add(new WorkerWithTimeDependentSalary(Convert.ToInt32(line[1]), line[2], line[3], Convert.ToDouble(line[4])));
                                break;
                            case "f":
                                workers.Add(new WorkerWithFixedSalary(Convert.ToInt32(line[1]), line[2], line[3], Convert.ToDouble(line[4])));
                                break;
                        }
                    }
                }
            }
            return workers;
        }
    }
}
