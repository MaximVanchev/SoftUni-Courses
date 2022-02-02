using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _3.Stack
{
    class Stack<T> : IEnumerable<T>
    {
        private List<T> stack = new List<T>();
        public Stack(List<T> stack)
        {
            this.stack = stack;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in stack)
            {
                yield return item;
            }
        }

        public void Pop()
        {
            if (stack.Count > 0)
            {
                stack.RemoveAt(stack.Count - 1); 
            }
            else
            {
                Console.WriteLine($"No elements");
            }
        }
        public void Push(T currentDigit)
        {
            stack.Add(currentDigit);
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
