namespace BlockchainSharp.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using BlockchainSharp.Stores;
    using BlockchainSharp.Core.Types;

    public class BlockChain
    {
        private IBlockStore blockStore;
        private Block bestBlock;

        public BlockChain(IBlockStore blockStore, Block bestBlock)
        {
            this.blockStore = blockStore;
            this.bestBlock = bestBlock;
        }

        public long BestBlockNumber { get { return this.bestBlock.Number; } }

        public Block BestBlock { get { return this.bestBlock; } }

        public bool TryToAdd(Block block)
        {
            Hash blockHash = block.Hash;

            if (this.blockStore.GetByHash(blockHash) != null)
                return false;


            if (block.Number > 0) {
                Block parent = this.blockStore.GetByHash(block.ParentHash);
                
                if (parent == null)
                    return false;

                if (parent.Number + 1 != block.Number)
                    return false;
            }

            this.blockStore.Save(block);

            if (this.bestBlock == null || this.bestBlock.Number < block.Number)
                this.bestBlock = block;

            return true;
        }

        public bool HasBlock(Hash hash)
        {
            return blockStore.GetByHash(hash) != null;
        }

        public Block GetBlock(long n)
        {
            if (n < 0 || this.bestBlock == null || n > this.bestBlock.Number)
                return null;

            Block block = bestBlock;

            while (n != block.Number)
                block = this.blockStore.GetByHash(block.ParentHash);

            return block;
        }
    }
}
