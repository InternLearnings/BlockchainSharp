namespace BlockchainSharp.Tests.Core
{
    using System;
    using BlockchainSharp.Core;
    using BlockchainSharp.Core.Types;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class StatusTests
    {
        [TestMethod]
        public void CreateStatus()
        {
            ulong height = 42;
            BlockHash hash = new BlockHash(new byte[] { 1, 2, 4 });

            Status status = new Status(height, hash);

            Assert.AreEqual(height, status.Height);
            Assert.AreEqual(hash, status.Hash);
        }
    }
}
