using UnityEngine;

namespace Minecraft
{
    public class MapGenerator : MonoBehaviour
    {
        [SerializeField] private ChunkRenderer rendererPrefab;

        public ChunkRenderer CreateChunkRenderer(Chunk chunk, Vector2Int position)
        {
            
            for (int x = 0; x < Chunk.ChunkSize; x++)
            {
                for (int z = 0; z < Chunk.ChunkSize; z++)
                {
                    for (int y = 0; y < Chunk.BuildHeight; y++)
                    {
                        if (y <= 60)
                            chunk.SetBlock(new Vector3Int(x, y, z), 3);
                        else if (y == 61)
                            chunk.SetBlock(new Vector3Int(x, y, z), 2);
                    }
                }
            }
            
            ChunkRenderer newChunk = Instantiate(rendererPrefab, transform);
            newChunk.Setup(chunk);
            
            return newChunk;
        }
    }
}