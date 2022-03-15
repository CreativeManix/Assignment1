using System;
using System.Collections.Generic;
using System.Text;

namespace CodingAssignment.Definitions
{
    public interface IInteravalFinder
    {
        void Add(int[] values);
        List<IntervalResult> GetResult(int interval);

        List<int> Store { get; set; }
    }
}
