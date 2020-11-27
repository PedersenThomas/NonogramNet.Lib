using System;
using System.Collections.Generic;
using System.Text;

namespace NonogramNet.Lib.Test
{
    using System.Linq;
    using Model;
    using Xunit;

    public class TestUtilities
    {
        public static void VerifyChanges(IEnumerable<BoardChange> expected, IEnumerable<BoardChange> actual)
        {
            Assert.True(expected != null && actual != null);

            var expectedList = expected.ToList();
            var actualList = actual.ToList();

            if (expectedList.Count != actualList.Count)
            {
                Assert.True(false, 
                    $"Expected: {String.Join("\n", expectedList.Select(c => c.ToString())) } \nActual: {String.Join("\n", actualList.Select(c => c.ToString())) }");
            }

            for (int i = 0; i < expectedList.Count; i++)
            {
                var e = expectedList[i];
                var a = actualList[i];
                if (!e.Equals(a))
                {

                    Assert.True(false,
                        $"Difference at Index {i} {e}<>{a}\nExpected: {String.Join("\n", expectedList.Select(c => c.ToString())) } \nActual: {String.Join("\n", actualList.Select(c => c.ToString())) }");
                }
            }

        }
    }
}
