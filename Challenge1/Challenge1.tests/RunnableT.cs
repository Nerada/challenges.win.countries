// -----------------------------------------------
//     Author: Ramon Bollen
//       File: Challenge1.tests.RunnableT.cs
// Created on: 20200215
// -----------------------------------------------

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge1.tests
{
    [TestClass]
    public class RunnableT
    {
        private Runnable _run;

        [TestInitialize]
        public void Initializer() { _run = new Runnable(); }

        /// <summary>
        ///     Integration Test, check valid output based on specified region.
        /// </summary>
        [TestMethod]
        public void Has_Valid_Solution() { Assert.AreEqual(8, _run.Solution(TestData.Get())); }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Exception_On_Null() { _run.Solution(null); }

        [TestMethod]
        public void Valid_Output_On_Empty_Input() { Assert.AreEqual(0, _run.Solution(Array.Empty<int[]>())); }
    }
}