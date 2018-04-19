namespace BlockchainSharp.Processors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public enum BlockProcess
    {
        Imported,
        Known,
        MissingAncestor
    }
}
