using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using Task;

namespace TaskSearchingTest.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckingTheException()
        {
            _ = Assert.ThrowsException<ArgumentNullException>(() =>
            {
                new TaskSearching().FindElementsForSum(null, 0, out _, out _);
            });
        }

        [TestMethod]
        public void CheckEmptyList()
        {
            var list = new List<uint>();
            ulong sum = 13;

            new TaskSearching().FindElementsForSum(list, sum, out int start, out int end);

            Assert.AreEqual(0, start, "Start is 0");
            Assert.AreEqual(0, end, "End is 0");
        }

        [TestMethod]
        public void SumIsBigger()
        {
            var list = new List<uint> { 2, 14, 67, 95, 4, 0, 34 };
            ulong sum = 1432;

            new TaskSearching().FindElementsForSum(list, sum, out int start, out int end);

            Assert.AreEqual(0, start, "Start is 0");
            Assert.AreEqual(0, end, "End is 0");
        }

        [TestMethod]
        public void SumIsLess()
        {
            var list = new List<uint> { 13, 4, 75, 9, 0, 143, 534, 31 };
            ulong sum = 12;

            new TaskSearching().FindElementsForSum(list, sum, out int start, out int end);

            Assert.AreEqual(0, start, "Start is 0");
            Assert.AreEqual(0, end, "End is 0");
        }

        [TestMethod]
        public void SearchFromBeginningToMiddle()
        {
            var list = new List<uint> { 4, 12, 17, 30, 5, 76, 90, 0, 5, 62 };
            ulong sum = 144;

            new TaskSearching().FindElementsForSum(list, sum, out int start, out int end);

            Assert.AreEqual(0, start, "Start is 0");
            Assert.AreEqual(6, end, "End is 0");
        }

        [TestMethod]
        public void TwoStepsSearching()
        {
            var list = new List<uint> { 23, 12, 4, 35, 243, 102, 56, 23, 0 };
            ulong sum = 158;

            new TaskSearching().FindElementsForSum(list, sum, out int start, out int end);

            Assert.AreEqual(5, start, "Start is 5");
            Assert.AreEqual(7, end, "End is 7");
        }

        [TestMethod]
        public void FirstSimpleTest()
        {
            var list = new List<uint> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            ulong sum = 28;

            new TaskSearching().FindElementsForSum(list, sum, out int start, out int end);

            Assert.AreEqual(0, start, "must be 0");
            Assert.AreEqual(7, end, "must be 7"); 
            /*
             * end is equal to 7, cause when the iteration is going and on the step when "nowSum" is equal
             * to "sum", the variable end is iterated (list[end++]).
             */

        }

        //[TestMethod]
        //public void SumIsNullException()
        //{
        //    var list = new List<uint> { 1, 3, 4, 8, 4, 1, 0, 5, 7 };
        //    ulong sum = 0;

        //    Assert.ThrowsException<ArgumentException>(() =>
        //    {
        //        new TaskSearching().FindElementsForSum(list, sum, out int start, out int end);
        //    });
        //}

        [TestMethod]
        public void SumZeroIn1Million()
        {
            int length = 1000000;
            var list = new List<uint>(length);
            Random millionRandom = new Random();
            for (int count = length; count > 0; count--)
            {
                list.Add((uint)millionRandom.Next(1, int.MaxValue));
            }

            ulong sum = 0;

            new TaskSearching().FindElementsForSum(list, sum, out int start, out int end);

            Assert.AreEqual(0, start, "must be 0");
            Assert.AreEqual(0, end, "must be 0");
        }

        [TestMethod]
        public void SearchingIn3Million()
        {
            int length = 3000000;
            var list = new List<uint>(length);
            Random millionRandom = new Random();
            for(int i = 0; i < length; i++)
            {
                list.Add((uint)millionRandom.Next(1, int.MaxValue));
            }

            ulong sum = 0;

            new TaskSearching().FindElementsForSum(list, sum, out int start, out int end);

            Assert.AreEqual(0, start, "must be 0");
            Assert.AreEqual(0, end, "must be 0");
        }

        [TestMethod]
        public void SearchingIn6Million()
        {
            int length = 6000000;
            var list = new List<uint>(length);
            Random millionRandom = new Random();
            for (int i = 0; i < length; i++)
            {
                list.Add((uint)millionRandom.Next(1, int.MaxValue));
            }

            ulong sum = 0;

           new TaskSearching().FindElementsForSum(list, sum, out int start, out int end);

            Assert.AreEqual(0, start, "must be 0");
            Assert.AreEqual(0, end, "must be 0");
        }

        [TestMethod]
        public void SearchingIn10Million()
        {
            int length = 10000000;
            var list = new List<uint>(length);
            Random millionRandom = new Random();
            for (int count = length; count > 0; --count)
            {
                list.Add((uint)millionRandom.Next(1, int.MaxValue));
            }

            ulong sum = 0;

            new TaskSearching().FindElementsForSum(list, sum, out int start, out int end);

            Assert.AreEqual(0, start, "must be 0");
            Assert.AreEqual(0, end, "must be 0");
        }
    }

    
}

