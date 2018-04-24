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

        public ProgramEnvironment(Address address)
        {
            this.address = address;
        }

        public Address Address { get { return this.address; } }
    }
}
