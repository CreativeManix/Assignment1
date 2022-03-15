using CodingAssignment.Definitions;
using CodingAssignment.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CodingAssignment.Test
{
    public class IntervalFinderTest
    {
        [Theory]
        [MemberData(nameof(Finders))]
        public void IntervalFinder_ShouldStoreValues(IInteravalFinder finder)
        {
            var input = new[] { 1, 2, 3, 7, 9, 12 };
            finder.Add(input);
            var difference = finder.Store.Except(input);
            Assert.Empty(difference);
        }

        [Theory]
        [MemberData(nameof(FindersWithTestData))]
        public void IntervalFinder_ShouldReturnValues_AsExpected(IInteravalFinder finder, int[] input, int interval, int resultSetCount, params int[][] resultSets)
        {
            finder.Add(input);
            var result = finder.GetResult(interval);
            Assert.Equal(resultSetCount,result.Count);
            var index = 0;
            foreach (var r in resultSets)
            {
                Assert.Empty(result[index].Numbers.Except(r));
                index++;
            }
        }

        [Theory]
        [MemberData(nameof(Finders))]
        public void IntervalFinder_ShouldReturnEmptyResult_WhenNoInput(IInteravalFinder finder)
        {
            var input = new int[] { };
            finder.Add(input);
            var difference = finder.Store.Except(input);
            Assert.Empty(difference);
        }

        //Test data provider
        public static IEnumerable<object[]> Finders =>
        new List<object[]>
        {
            new object[] {new SimpleIntervalFinder() },
            new object[] {new OptimisedIntervalFinder() },
        };

        //Test data provider
        public static IEnumerable<object[]> FindersWithTestData =>
       new List<object[]>
       {
            new object[] {new SimpleIntervalFinder(),new[] {3,4,12,15,17,22,26,30},10,3,new[] {3,4},new[] { 12, 15,17 },new[] { 22, 26,30 } },
            new object[] {new OptimisedIntervalFinder(),new[] {3,4,12,15,17,22,26,30},10,3,new[] {3,4},new[] { 12, 15,17 },new[] { 22, 26,30 } },

            new object[] {new SimpleIntervalFinder(),new[] {10,45,66,113,125,170,199},100,2,new[] {10,45,66},new[] { 113, 125, 170, 199 } },
            new object[] {new OptimisedIntervalFinder(),new[] {10,45,66,113,125,170,199},100,2,new[] {10,45,66},new[] { 113, 125, 170, 199 } },
       };
    }
}
