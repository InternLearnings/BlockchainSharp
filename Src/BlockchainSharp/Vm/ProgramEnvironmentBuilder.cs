namespace BlockchainSharp.Vm
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using BlockchainSharp.Core.Types;

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
                this.coinbase);
        }
    }
}
