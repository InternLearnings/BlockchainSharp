namespace BlockchainSharp.Vm
{
    using BlockchainSharp.Core.Types;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ProgramEnvironment
    {
        private Address address;
        private Address origin;
        private Address caller;
        private Address coinbase;

        public static ProgramEnvironmentBuilder Builder()
        {
            return new ProgramEnvironmentBuilder();
        }

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

        public Address Coinbase { get { return this.Coinbase; } }
    }

    public class ProgramEnvironmentBuilder 
    {
        private Address address;
        private Address origin;
        private Address caller;
        private Address coinbase;

        public ProgramEnvironmentBuilder Address(Address address)
        {
            this.address = address;

            return this;
        }

        public ProgramEnvironmentBuilder Origin(Address origin)
        {
            this.origin = origin;

            return this;
        }

        public ProgramEnvironmentBuilder Caller(Address caller)
        {
            this.caller = caller;

            return this;
        }

        public ProgramEnvironmentBuilder Coinbase(Address coinbase)
        {
            this.coinbase = coinbase;

            return this;
        }

        public ProgramEnvironment Build()
        {
            return new ProgramEnvironment(
                this.address, 
                this.origin, 
                this.caller, 
                this.coinbase
            );
        }
    }
}

