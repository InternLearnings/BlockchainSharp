namespace BlockchainSharp.Core.Types
{
    using BlockchainSharp.Encoding;
    using Org.BouncyCastle.Crypto.Digests;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class BlockHash : Hash
    {
        public BlockHash(BlockHeader header)
            : base(CalculateHash(header))
        {
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
