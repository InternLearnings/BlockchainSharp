namespace BlockchainSharp.Encoding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Text;
    using BlockchainSharp.Core;
    using BlockchainSharp.Core.Types;

    public class TransactionEncoder
    {
        private static TransactionEncoder instance = new TransactionEncoder();

        private AddressEncoder addressEncoder = new AddressEncoder();

        public static TransactionEncoder Instance { get { return instance; } }

        public byte[] Encode(Transaction tx)
        {
            byte[] sender = AddressEncoder.Instance.Encode(tx.Sender);
            byte[] receiver = AddressEncoder.Instance.Encode(tx.Receiver);
            byte[] value = BigIntegerEncoder.Instance.Encode(tx.Value);
                
            return Rlp.EncodeList(sender, receiver, value);
        }

        public byte[] Encode(IList<Transaction> txs)
        {
            int ntxs = txs.Count();
            byte[][] btxs = new byte[ntxs][];

            for (int k = 0; k < ntxs; k++)
                btxs[k] = this.Encode(txs[k]);

            return Rlp.Encode(Rlp.EncodeList(btxs));
        }

        public Transaction Decode(byte[] bytes)
        {
            IList<byte[]> items = Rlp.DecodeList(bytes);

            Address sender = AddressEncoder.Instance.Decode(items[0]);
            Address receiver = AddressEncoder.Instance.Decode(items[1]);
            BigInteger value = BigIntegerEncoder.Instance.Decode(items[2]);

            return new Transaction(sender, receiver, value);
        }
    }
}
