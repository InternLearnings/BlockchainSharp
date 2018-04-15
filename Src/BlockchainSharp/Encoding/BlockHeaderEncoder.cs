namespace BlockchainSharp.Encoding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Text;
    using BlockchainSharp.Core;
    using BlockchainSharp.Core.Types;

    public class BlockHeaderEncoder
    {
        private static BigIntegerEncoder bigIntegerEncoder = new BigIntegerEncoder();
        private static HashEncoder hashEncoder = new HashEncoder();
        private static BlockHeaderEncoder instance = new BlockHeaderEncoder();

        public static BlockHeaderEncoder Instance { get { return instance; } }

        public byte[] Encode(BlockHeader header)
        {
            byte[] number = bigIntegerEncoder.Encode(new BigInteger(header.Number));
            byte[] parentHash = hashEncoder.Encode(header.ParentHash);
            byte[] transactionsHash = hashEncoder.Encode(header.TransactionsHash);

            return Rlp.EncodeList(number, parentHash, transactionsHash);
        }

        public BlockHeader Decode(byte[] bytes)
        {
            IList<byte[]> list = Rlp.DecodeList(bytes);

            long number = (long)bigIntegerEncoder.Decode(list[0]);
            Hash parentHash = hashEncoder.Decode(list[1]);
            Hash transactionsHash = hashEncoder.Decode(list[2]);

            return new BlockHeader(number, parentHash, transactionsHash);
        }
    }
}
