using CodingAssignment.Definitions;
using System.Collections.Generic;


namespace CodingAssignment.Implementations
{
    public class SimpleIntervalFinder : IInteravalFinder
    {
        public List<int> Store { get; set; }
        public SimpleIntervalFinder()
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
             * Simplest implementation using C#’s inbuilt findAll
             * This is not the efficient one, as it has to lookup the storage array from start to end due to findAll
             * I have created another implementation without this lookup issue 
             * Items in the input array not need to be in the sequence
            */

            var result = new List<IntervalResult>();
            if (Store.Count == 0) return result;

            var numbersFound = new List<int>();
            var maxNumberInPreviousResultSet = 0;
            for (var i = interval; i <= Store[Store.Count-1]+interval; i+=interval)
            {
                var numbersInRange = Store.FindAll(x => x>maxNumberInPreviousResultSet && x<= i);
                if (numbersInRange.Count > 0)
                {
                    result.Add(new IntervalResult() { Numbers = numbersInRange, Frequency = numbersInRange.Count });
                    maxNumberInPreviousResultSet = numbersInRange[numbersInRange.Count - 1];
                }
            }

            return result;
        }
    }
}
