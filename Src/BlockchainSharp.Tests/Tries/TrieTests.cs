namespace BlockchainSharp.Tests.Tries
{
    using System;
    using System.Linq;
    using BlockchainSharp.Tests.TestUtils;
    using BlockchainSharp.Tries;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TrieTests
    {
        [TestMethod]
        public void GetUnknowKey()
        {
            Trie trie = new Trie();

            Assert.IsNull(trie.Get(HexUtils.StringToByteArray("0132")));
        }

        [TestMethod]
        public void NewTrieIsEmpty()
        {
            Trie trie = new Trie();

            Assert.IsTrue(trie.IsEmpty());
        }

        [TestMethod]
        public void PutAndGetKeyValue()
        {
            Trie trie = new Trie();
            byte[] key = HexUtils.StringToByteArray("0123");

            var trie2 = trie.Put(key, new byte[] { 1, 2, 3 });

            Assert.IsNotNull(trie2);
            Assert.AreNotSame(trie2, trie);
            Assert.IsNull(trie.Get(key));
            Assert.IsTrue((new byte[] { 1, 2, 3 }).SequenceEqual(trie2.Get(key)));
            Assert.IsFalse(trie2.IsEmpty());
        }

        [TestMethod]
        public void PutKeyValueTwice()
        {
            Trie trie = new Trie();
            byte[] key = HexUtils.StringToByteArray("0123");

            var trie2 = trie.Put(key, new byte[] { 1, 2, 3 });
            var trie3 = trie2.Put(key, new byte[] { 1, 2, 3 });

            Assert.IsNotNull(trie3);
            Assert.AreEqual(trie2, trie3);
        }

        [TestMethod]
        public void PutAndGetKeyValues()
        {
            Trie trie = new Trie();
            byte[] key1 = HexUtils.StringToByteArray("0123");
            byte[] key2 = HexUtils.StringToByteArray("abcd");

            var trie2 = trie.Put(key1, new byte[] { 1, 2, 3 });
            var trie3 = trie2.Put(key2, new byte[] { 4, 5, 6 });

            Assert.IsNotNull(trie2);
            Assert.AreNotSame(trie2, trie);
            Assert.IsNull(trie.Get(key1));
            Assert.IsNull(trie.Get(key2));
            Assert.IsTrue((new byte[] { 1, 2, 3 }).SequenceEqual(trie2.Get(key1)));
            Assert.IsNull(trie2.Get(key2));

            Assert.IsNotNull(trie3);
            Assert.AreNotSame(trie3, trie2);
            Assert.IsTrue((new byte[] { 1, 2, 3 }).SequenceEqual(trie3.Get(key1)));
            Assert.IsTrue((new byte[] { 4, 5, 6 }).SequenceEqual(trie3.Get(key2)));
        }

        [TestMethod]
        public void ReplaceValue()
        {
            Trie trie = new Trie();
            byte[] key = HexUtils.StringToByteArray("0123");

            var trie2 = trie.Put(key, new byte[] { 1, 2, 3 });
            var trie3 = trie2.Put(key, new byte[] { 4, 5, 6 });

            Assert.IsNotNull(trie2);
            Assert.AreNotSame(trie2, trie);
            Assert.IsNull(trie.Get(key));
            Assert.IsTrue((new byte[] { 1, 2, 3 }).SequenceEqual(trie2.Get(key)));

            Assert.IsNotNull(trie3);
            Assert.AreNotSame(trie3, trie2);
            Assert.IsTrue((new byte[] { 4, 5, 6 }).SequenceEqual(trie3.Get(key)));
            Assert.IsFalse(trie3.IsEmpty());
        }

        [Ignore]
        [TestMethod]
        public void RemoveValue()
        {
            Trie trie = new Trie();
            byte[] key = HexUtils.StringToByteArray("0123");

            var trie2 = trie.Put(key, new byte[] { 1, 2, 3 });
            var trie3 = trie2.Remove(key);

            Assert.IsNotNull(trie2);
            Assert.AreNotSame(trie2, trie);
            Assert.IsNull(trie.Get(key));
            Assert.IsTrue((new byte[] { 1, 2, 3 }).SequenceEqual(trie2.Get(key)));

            Assert.IsNotNull(trie3);
            Assert.AreNotSame(trie3, trie2);
            Assert.IsNull(trie3.Get(key));
            Assert.IsTrue(trie3.IsEmpty());
        }
    }
}

