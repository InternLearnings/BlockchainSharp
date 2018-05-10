﻿namespace BlockchainSharp.Encoding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Text;
    using BlockchainSharp.Core;
    using BlockchainSharp.Core.Types;

    public class BlockEncoder
    {
        private static BigIntegerEncoder bigIntegerEncoder = new BigIntegerEncoder();
        private static HashEncoder hashEncoder = new HashEncoder();
        private static BlockEncoder instance = new BlockEncoder();

        public static BlockEncoder Instance { get { return instance; } }

        public byte[] Encode(Block block)
        {
            byte[] number = bigIntegerEncoder.Encode(new BigInteger(block.Number));
            byte[] hash = hashEncoder.Encode(block.ParentHash);
            int ntxs = block.Transactions.Count();
            byte[][] txs = new byte[ntxs][];

            for (int k = 0; k < ntxs; k++)
                txs[k] = TransactionEncoder.Instance.Encode(block.Transactions[k]);

            return Rlp.EncodeList(number, hash, TransactionEncoder.Instance.Encode(block.Transactions));
        }

        public Block Decode(byte[] bytes)
        {
            IList<byte[]> list = Rlp.DecodeList(bytes);

            long number = (long)bigIntegerEncoder.Decode(list[0]);
            Hash hash = hashEncoder.Decode(list[1]);
            IList<byte[]> btxs = Rlp.DecodeList(Rlp.Decode(list[2]));

            IList<Transaction> txs = new List<Transaction>();

            for (int k = 0; k < btxs.Count; k++)
                txs.Add(TransactionEncoder.Instance.Decode(btxs[k]));

            return new Block(number, hash, txs);
        }
    }
}
