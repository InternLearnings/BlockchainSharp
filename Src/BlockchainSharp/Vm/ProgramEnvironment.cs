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

        public ProgramEnvironment(Address address, Address origin)
        {
            this.address = address;
            this.origin = origin;
        }

        public Address Address { get { return this.address; } }

        public Address Origin { get { return this.origin; } }
    }
}
