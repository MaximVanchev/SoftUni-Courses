using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1._ListyIterator
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> items;
        private int index;
        public ListyIterator(List<T> input)
        {
            items = input;
            index = 0;
        }
        public ListyIterator(params T[] input)
        {
            items = input.ToList();
            index = 0;
        }
        public bool Move()
        {
            bool currentBool = HasNext();
            if (currentBool)
            {
                index++;
            }
            return currentBool;
        }
        public bool HasNext() => index < items.Count - 1;
        public void Print()
        {
            if (items.Count != 0)
            {
                Console.WriteLine(items[index]); 
            }
            else
            {
                Console.WriteLine($"Invalid Operation!");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in items)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
