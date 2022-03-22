using System.Collections.Generic;
using UnityEngine;

namespace Minecraft
{
    public class Chunk
    {
        public const int ChunkSize = 16;
        public const int BuildHeight = 256;
        public readonly Vector2Int Position;
        public int BlockCount => blockCount;

        private int blockCount = 0;
        private Dictionary<Vector3Int, byte> blocks = new Dictionary<Vector3Int, byte>();

        public Chunk(Vector2Int position)
        {
            this.Position = position;
        }
        
        public void SetBlock(Vector3Int blockPosition, byte block)
        {
            if (blocks.ContainsKey(blockPosition) && blocks[blockPosition] != 0) blockCount--;
            blocks[blockPosition] = block;
            if (block != 0) blockCount++;
        }

        public byte GetBlock(Vector3Int blockPosition)
        {
            blocks.TryGetValue(blockPosition, out byte value);
            return value;
        }
    }
}