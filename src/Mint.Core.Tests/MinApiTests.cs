﻿using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mint.Core.Tests
{
    [TestClass]
    public class MintApiTests
    {
        [TestMethod, TestCategory("Integration")]
        public void Login()
        {
            MintApi mintApi = new MintApi("chinarosesz@gmail.com", "Pa$$word123456");
        }

        [TestMethod, TestCategory("Integration")]
        public void GetAccountsSummary()
        {
            MintApi mintApi = new MintApi("chinarosesz@gmail.com", "Pa$$word123456");
            mintApi.GetAccountsSummary();
        }
    }
}
