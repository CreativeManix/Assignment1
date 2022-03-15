using CodingAssignment.Definitions;
using System.Collections.Generic;
using System.Linq;

namespace CodingAssignment.Implementations
{
    public class OptimisedIntervalFinder : IInteravalFinder
    {
        public List<int> Store { get; set; }
        public OptimisedIntervalFinder()
        {
            Store = new List<int>();
        }
        public void Add(int[] values)
        {
            Store.AddRange(values);
        }

        public List<IntervalResult> GetResult(int interval)
        {
            /*Implementation details
             * Cursur based implementation using C#
             * Iterates the store only once, not using any inbuilt find methods from C#
             * Question describes "sequence of values" so assuming values are in order
             * For unordered support please look at SimpleIntervalFinder
            */
            _lastIndex = 0;
            var result = new List<IntervalResult>();
            if (Store.Count == 0) return result;

            for (var i = interval; i <= Store[Store.Count - 1] + interval; i += interval)
            {
                var numbersInRange = _FindNumbersInRange(i).ToList();
                if (numbersInRange.Count > 0)
                {
                    result.Add(new IntervalResult() { Numbers = numbersInRange, Frequency = numbersInRange.Count });
                }
            }

            return result;
        }

        private int _lastIndex = 0;

     

        private IEnumerable<int> _FindNumbersInRange(int max)
        {
            while (_lastIndex <= Store.Count - 1 && Store[_lastIndex] <= max)
            {
                yield return Store[_lastIndex];
                _lastIndex++;
            }
        }
    }
}
