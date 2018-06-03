namespace BlockchainSharp.Core.Types
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using BlockchainSharp.Encoding;
    using Org.BouncyCastle.Crypto.Digests;

    public class BlockHash : Hash
    {
        public BlockHash(byte[] bytes)
            : base(bytes)
        {
        }

        public static BlockHash Calculate(BlockHeader header)
        {
            return new BlockHash(CalculateHash(header));
        }

        private static byte[] CalculateHash(BlockHeader header)
        {
            Sha3Digest digest = new Sha3Digest(256);
            byte[] bytes = BlockHeaderEncoder.Instance.Encode(header);
            digest.BlockUpdate(bytes, 0, bytes.Length);
            byte[] result = new byte[32];
            digest.DoFinal(result, 0);

            return result;
        }
    }
}
