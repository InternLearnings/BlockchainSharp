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

        public ProgramEnvironment(Address address, Address origin, Address caller)
        {
            this.address = address;
            this.origin = origin;
            this.caller = caller;
        }

        public Address Address { get { return this.address; } }

        public Address Origin { get { return this.origin; } }

        public Address Caller { get { return this.caller; } }
    }
}

