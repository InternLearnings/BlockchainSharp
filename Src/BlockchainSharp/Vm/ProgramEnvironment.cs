namespace BlockchainSharp.Vm
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using BlockchainSharp.Core.Types;

    public class ProgramEnvironment
    {
        private Address address;
        private Address origin;
        private Address caller;
        private Address coinbase;

        internal ProgramEnvironment(Address address, Address origin, Address caller, Address coinbase)
        {
            this.address = address;
            this.origin = origin;
            this.caller = caller;
            this.coinbase = coinbase;
        }

        public Address Address { get { return this.address; } }

        public Address Origin { get { return this.origin; } }

        public Address Caller { get { return this.caller; } }

        public Address Coinbase { get { return this.coinbase; } }

        public static ProgramEnvironmentBuilder Builder()
        {
            return new ProgramEnvironmentBuilder();
        }
    }
}

