using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _4.Froggy
{
    class Lake : IEnumerable
    {
        private List<int> path;
        private List<int> crossPath;
        private List<int> returnPath;
        private List<int> resultPath;
        public Lake(List<int> path)
        {
            this.path = path;
        }
        private List<int> crossPathMethod(List<int> path)
        {
            return path.Where((c, i) => i % 2 == 0).ToList();
        }
        private List<int> returnPathMethod(List<int> path)
        {
            List<int> result = path.Where((c, i) => i % 2 != 0).ToList();
            result.Reverse();
            return result;
        }
        public IEnumerator GetEnumerator()
        {
            crossPath = crossPathMethod(path);
            returnPath = returnPathMethod(path);
            crossPath.AddRange(returnPath);
            resultPath = crossPath;
            foreach (var item in resultPath)
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
