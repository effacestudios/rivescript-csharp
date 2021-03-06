﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using RiveScript.Exceptions;

namespace RiveScript.Tests
{
    [TestClass]
    public class DocumentVersionTest
    {
        [TestMethod]
        public void Load_Older_Version_File()
        {
            var rs = new RiveScriptEngine(Config.Debug);

            var result = rs.stream("! version = 1.8");
            Assert.IsTrue(result);
        }


        [TestMethod]
        public void Load_Same_Version_File()
        {
            var rs = new RiveScriptEngine(Config.Debug);

            var result = rs.stream("! version = 2.0");
            Assert.IsTrue(result);
        }


        [TestMethod]
        public void Load_Newer_Version_File()
        {
            var rs = new RiveScriptEngine(Config.Debug);

            try
            {
                var result = rs.stream("! version = 2.1");
                Assert.IsFalse(result);
            }
            catch (ParserException ex)
            {
                return;
            }

            Assert.Fail();
        }

    }
}
