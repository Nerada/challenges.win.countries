// -----------------------------------------------
//     Author: Ramon Bollen
//      File: Countries.tests.RunnableT.cs
// Created on: 20201207
// -----------------------------------------------

using System;
using Countries.Support;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Countries.tests
{
    [TestClass]
    public class RunnableT
    {
        private Runnable _run = new Runnable();

        [TestInitialize]
        public void Initializer() => _run = new Runnable();

        /// <summary>
        ///     Integration Test, check valid output based on specified region.
        /// </summary>
        [TestMethod]
        public void Has_Valid_Solution() => Assert.AreEqual(8, _run.Solution(TestData.GetSpecificLayout()));

        [TestMethod]
        public void Valid_Output_On_Empty_Input() => Assert.AreEqual(0, _run.Solution(Array.Empty<int[]>()));

        [TestMethod]
        public void Valid_Output_On_Single_Value_Input()
        {
            int[][] testArray = CreateInitialArray(1, 1);

            foreach (int[] y in testArray)
            {
                foreach (int x in y)
                {
                    y[x] = 1;
                }
            }

            Assert.AreEqual(1, _run.Solution(testArray));
        }

        private static int[][] CreateInitialArray(int x, int y)
        {
            var array = new int[x][];

            for (var i = 0; i < array.Length; i++)
            {
                array[i] = new int[y];
            }

            return array;
        }
    }
}