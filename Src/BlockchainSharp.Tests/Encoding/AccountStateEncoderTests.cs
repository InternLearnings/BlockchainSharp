﻿namespace BlockchainSharp.Tests.Encoding
{
    using System;
    using System.Numerics;
    using BlockchainSharp.Core;
    using BlockchainSharp.Encoding;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AccountStateEncoderTests
    {
        [TestMethod]
        public void EncodeDecodeAccountStateWithBalanceOne()
        {
            AccountStateEncoder encoder = new AccountStateEncoder();

            byte[] bytes = encoder.Encode(new AccountState(BigInteger.One, 0));

            Assert.IsNotNull(bytes);
            Assert.AreNotEqual(0, bytes.Length);

            AccountState result = encoder.Decode(bytes);

            Assert.IsNotNull(result);
            Assert.AreEqual(BigInteger.One, result.Balance);
        }

        [TestMethod]
        public void EncodeDecodeAccountStateWithNonce()
        {
            AccountStateEncoder encoder = new AccountStateEncoder();

            byte[] bytes = encoder.Encode(new AccountState(BigInteger.Zero, 42));

            Assert.IsNotNull(bytes);
            Assert.AreNotEqual(0, bytes.Length);

            AccountState result = encoder.Decode(bytes);

            Assert.IsNotNull(result);
            Assert.AreEqual(BigInteger.Zero, result.Balance);
            Assert.AreEqual(42ul, result.Nonce);
        }
    }
}
