namespace BlockchainSharp.Stores
{
    using System;
    using System.Collections.Generic;
    using BlockchainSharp.Core;
    using BlockchainSharp.Core.Types;

    public interface IBlockStore
    {
        Block GetByBlockHash(BlockHash hash);

        IEnumerable<Block> GetByNumber(ulong number);

        IEnumerable<Block> GetByParentHash(BlockHash hash);

        void Save(Block block);

        void Remove(BlockHash hash);
    }
}
