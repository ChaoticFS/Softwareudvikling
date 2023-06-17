using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SearchMethods.Tests
{
    [TestClass]
    public class SearchMethods_Tests
    {
        [TestMethod]
        public void TestFindNumberLinear()
        {
            var array = new int[] { 5, 12, 14, 20, 26, 36, 37, 43, 44, 46, 47, 50, 51, 53, 57, 78, 80, 92, 93, 95 };

            int res = Search.FindNumberLinear(array, array[0]);
            Assert.AreEqual(0, res);

            res = Search.FindNumberLinear(array, array[6]);
            Assert.AreEqual(6, res);

            res = Search.FindNumberLinear(array, array[array.Length - 1]);
            Assert.AreEqual(array.Length - 1, res);

            res = Search.FindNumberLinear(array, 91);
            Assert.AreEqual(-1, res);
        }

        [TestMethod]
        public void TestFindNumberBinary()
        {
            var array = new int[] { 5, 12, 14, 20, 26, 36, 37, 43, 44, 46, 47, 50, 51, 53, 57, 78, 80, 92, 93, 95 };

            int res = Search.FindNumberBinary(array, array[0]);
            Assert.AreEqual(0, res);

            res = Search.FindNumberBinary(array, array[6]);
            Assert.AreEqual(6, res);

            res = Search.FindNumberBinary(array, array[array.Length - 1]);
            Assert.AreEqual(array.Length - 1, res);

            res = Search.FindNumberBinary(array, 91);
            Assert.AreEqual(-1, res);
        }


        [TestMethod]
        public void TestInsertSorted()
        {
            int[] newArray = new int[] { 2, 4, 8, 10, 15, 17, -1, -1, -1, -1 };

            Search.InsertSorted(newArray, 11);
            foreach (var item in newArray)
            {
                Console.WriteLine(item);
            }
            CollectionAssert.AreEqual(
                new int[] { 2, 4, 8, 10, 11, 15, 17, -1, -1, -1 },
                newArray
            );

            Search.InsertSorted(newArray, 19);
            CollectionAssert.AreEqual(
                new int[] { 2, 4, 8, 10, 11, 15, 17, 19, -1, -1 },
                newArray
            );

            Search.InsertSorted(newArray, 1);
            CollectionAssert.AreEqual(
                new int[] { 1, 2, 4, 8, 10, 11, 15, 17, 19, -1 },
                newArray
            );

            Search.InsertSorted(newArray, 20);
            CollectionAssert.AreEqual(
                new int[] { 1, 2, 4, 8, 10, 11, 15, 17, 19, 20 },
                newArray
            );

            Console.WriteLine("[{0}]", string.Join(", ", newArray));
        }

        [TestMethod]
        public void TestInsertSortedFull()
        {
            int[] array = new int[] { 1, 2, 4, 8, 10, 11, 15, 17, 19, 20 };

            int[] newArray = array;

            Search.InsertSorted(newArray, 14);

            CollectionAssert.AreEqual(array, newArray);
        }
    }
}