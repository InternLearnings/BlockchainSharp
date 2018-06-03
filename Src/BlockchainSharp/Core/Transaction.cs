namespace BlockchainSharp.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;
    using System.Text;
    using BlockchainSharp.Core.Types;
    using BlockchainSharp.Encoding;
    using BlockchainSharp.Stores;
    using Org.BouncyCastle.Crypto.Digests;

    public class Transaction
    {
        private Address sender;
        private Address receiver;
        private BigInteger value;

        private Hash hash;

        public Transaction(Address sender, Address receiver, BigInteger value)
        {
            if (value.CompareTo(BigInteger.Zero) < 0)
                throw new InvalidOperationException("Transaction value is negative");

            this.sender = sender;
            this.receiver = receiver;
            this.value = value;
        }

        public Address Sender { get { return this.sender; } }

        public BigInteger Value { get { return this.value; } }

        public Address Receiver { get { return this.receiver; } }

        public Hash Hash
        {
            get
            {
                if (this.hash != null)
                    return this.hash;

                this.hash = this.CalculateHash();

                return this.hash;
            }
        }

        private Hash CalculateHash()
        {
            Sha3Digest digest = new Sha3Digest(256);
            byte[] bytes = TransactionEncoder.Instance.Encode(this);
            digest.BlockUpdate(bytes, 0, bytes.Length);
            byte[] result = new byte[32];
            digest.DoFinal(result, 0);

            return new Hash(result);
        }
    }
}
