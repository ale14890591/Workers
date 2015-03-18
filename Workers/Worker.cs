using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers
{
    public abstract class Worker : IEqualityComparer<Worker>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Worker(int id, string firstName, string lastName)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
        }

        public abstract double CountAverageMonthlySalary();

        public bool Equals(Worker x, Worker y)
        {
            if (x.Id == y.Id && x.FirstName == y.FirstName && x.LastName == y.LastName)
                return true;
            else
                return false;
        }

        public int GetHashCode(Worker obj)
        {
            throw new NotImplementedException();
        }
    }
}
