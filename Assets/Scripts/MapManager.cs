using System;
using System.Collections.Generic;
using UnityEngine;

namespace Minecraft
{
    public class MapManager : MonoBehaviour
    {
        [SerializeField] private MapGenerator mapGenerator;
        [SerializeField] private Vector2Int mapSize = Vector2Int.one;
        [SerializeField] private Block[] blocks;

        private Dictionary<Vector2Int, Chunk> chunks = new Dictionary<Vector2Int, Chunk>();

        private void Start()
        {
            foreach (Block block in blocks)
            {
                ChunkRenderer.BlockData.Add(block.BlockID, block);
            }
            
            for (int x = 0; x < mapSize.x; x++)
            {
                for (int y = 0; y < mapSize.y; y++)
                {
                    Vector2Int chunkPosition = new Vector2Int(x, y);
                    Chunk chunk = new Chunk(chunkPosition);
                    ChunkRenderer newChunk = mapGenerator.CreateChunkRenderer(chunk, chunkPosition);
                    
                    chunks.Add(chunkPosition, chunk);
                }
            }
        }
    }
}