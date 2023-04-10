using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentHW
{
    internal class StudentEnumarator : IEnumerator
    {
        Person[] array;
        int position = -1;
        public StudentEnumarator(List<Person> arr)
        {
            array = arr.ToArray();
        }
        public Person Current
        {
            get
            {
                if (position == -1 || position >= array.Length)
                    throw new ArgumentException();
                return array[position];
            }
        }
        object IEnumerator.Current => Current;
        public bool MoveNext()
        {
            if (position < array.Length - 1)
            {
                position++;
                return true;
            }
            else
                return false;
        }
        public void Reset() => position = -1;
        public void Dispose() { }
    }
}
