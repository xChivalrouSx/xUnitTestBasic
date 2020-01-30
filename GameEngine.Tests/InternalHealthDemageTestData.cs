using System;
using System.Collections.Generic;
using System.Text;

namespace GameEngine.Tests
{
    public class InternalHealthDemageTestData
    {
        //private static readonly List<object[]> Data = new List<object[]>
        //{
        //    new object[] {0, 100},
        //    new object[] {10, 90},
        //    new object[] {50, 50},
        //    new object[] {101, 1}
        //};

        //public static IEnumerable<object[]> TestData => Data;

        public static IEnumerable<object[]> TestData
        {
            get
            {
                yield return new object[] { 0, 100 };
                yield return new object[] { 10, 90 };
                yield return new object[] { 50, 50 };
                yield return new object[] { 101, 1 };
            }
        }
    }
}
