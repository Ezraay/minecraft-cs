using System;
using UnityEngine;

namespace Minecraft
{
    public class MapManager : MonoBehaviour
    {
        [SerializeField] private MapGenerator mapGenerator;
        [SerializeField] private Vector2Int mapSize = Vector2Int.one;
        [SerializeField] private Block[] blocks;

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
                    ChunkRenderer newChunk = mapGenerator.CreateChunkRenderer(chunkPosition);
                }
            }
        }
    }
}