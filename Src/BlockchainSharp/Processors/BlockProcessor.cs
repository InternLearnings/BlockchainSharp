namespace BlockchainSharp.Processors
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using BlockchainSharp.Core;
    using BlockchainSharp.Core.Types;
    using BlockchainSharp.Stores;

    public class BlockProcessor
    {
        private BlockChain chain;
        private IBlockStore store;

        public BlockProcessor(BlockChain chain, IBlockStore store)
        {
            this.chain = chain;
            this.store = store;
        }

        public BlockChain BlockChain { get { return this.chain; } }

        public BlockProcess ProcessBlock(Block block)
        {
            if (this.chain.HasBlock(block.Hash))
                return BlockProcess.Known;

            if (this.store.GetByHash(block.Hash) != null)
                return BlockProcess.MissingAncestor;

            if (block.ParentHash != null && !this.chain.HasBlock(block.ParentHash))
            {
                this.store.Save(block);
                return BlockProcess.MissingAncestor;
            }

            if (this.chain.TryToAdd(block))
            {
                this.TryConnectChildren(block);
                return BlockProcess.Imported;
            }

            return BlockProcess.NotImported;
        }

        private void TryConnectChildren(Block block) 
        {
            IList<Block> toremove = new List<Block>();

            foreach (var child in this.store.GetByParentHash(block.Hash))
                if (this.chain.TryToAdd(child))
                {
                    toremove.Add(child);
                    this.TryConnectChildren(child);
                }

            foreach (var removed in toremove)
                this.store.Remove(removed.Hash);
        }
    }
}
