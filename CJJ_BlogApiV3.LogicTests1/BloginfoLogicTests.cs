using Microsoft.VisualStudio.TestTools.UnitTesting;
using CJJ_BlogApiV3.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace CJJ_BlogApiV3.Logic.Tests
{
    [TestClass()]
    public class BloginfoLogicTests
    {
        [TestMethod()]
        public void BloginfoLogicTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetListBloginfoTest()
        {
            Assert.Fail();
        }
        [TestMethod()]
        public void TestAsync()
        {
            Action<string> action = DoSomething;
           var asyncresult= action.BeginInvoke("异步调用", callback, null);
            asyncresult.AsyncWaitHandle.WaitOne();//阻塞当前线程 直到收到完成的型号量，超时控制
        }
        public void DoSomething(string a)
        {
            Console.WriteLine($"cw {a}");
        }

        AsyncCallback callback = a =>
          {
              Console.WriteLine(a);
          };
    }
}