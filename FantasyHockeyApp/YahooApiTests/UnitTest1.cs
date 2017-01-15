using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using YahooApi;

namespace YahooApiTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var yahoo = new Yahoo();
            Debug.WriteLine(yahoo.GetLeague(22381).Name);
        }
    }
}
