using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workers
{
    public class WorkersCollection : ICollection<Worker>
    {
        private Worker[] _array;
        private int count;

        public WorkersCollection()
        {
            count = 0;
            _array = new Worker[count];
        }

        public WorkersCollection(int length)
        {
            count = length;
            _array = new Worker[count];
        }

        public void Add(Worker item)
        {
            Worker[] newArray = new Worker[++count];
            for (int i = 0; i < count - 1; i++)
            {
                newArray[i] = _array[i];
            }
            newArray[count - 1] = item;
            _array = new Worker[count];
            _array = newArray;
        }

        public void Clear()
        {
            _array = new Worker[0];
        }

        public bool Contains(Worker item)
        {
            for (int i = 0; i < count; i++)
            {
                if (_array[i] == item)
                    return true;
            }
            return false;
        }

        public void CopyTo(Worker[] array, int arrayIndex)
        {
            if (array.Length < count - arrayIndex)
                throw new Exception(String.Format("The target array should contain at least {0} elements to be able to receive the copy", count - arrayIndex));

            for (int i = arrayIndex; i < count; i++)
            {
                _array[i] = array[i - arrayIndex];
            }
        }

        public int Count
        {
            get
            {
                return count;
            }
        }

        public bool IsReadOnly
        {
            get { return false; }
        }

        public bool Remove(Worker item)
        {
            if (!this.Contains(item))
                return false;

            int itemsToRemove = CountNumberOf(item);
            Worker[] newArray = new Worker[count - itemsToRemove];
            count -= itemsToRemove;

            var arrayEnumerator = _array.GetEnumerator();
            
            bool abilityToMoveNext = true;
            int i = 0;
            do
            {
                if (arrayEnumerator.Current as Worker != item)
                {
                    newArray[i] = arrayEnumerator.Current as Worker;
                    i++;
                }
                abilityToMoveNext = arrayEnumerator.MoveNext();
            } while (abilityToMoveNext);

            _array = new Worker[count];
            _array = newArray;
            return true;
        }

        public IEnumerator<Worker> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return _array[i];
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int CountNumberOf(Worker worker)
        {
            int c = 0;
            for (int i = 0; i < count; i++)
            {
                if (_array[i] == worker)
                    c++;
            }
            return c;
        }

        public WorkersCollection SortByAverageMonthlySalaryDescending()
        {
            WorkersCollection sortedCollection = new WorkersCollection(this.count);
            sortedCollection._array = this.OrderByDescending(x => x.CountAverageMonthlySalary()).ThenBy(x=>x.LastName).ToArray<Worker>();
            return sortedCollection;
        }
    }
}
