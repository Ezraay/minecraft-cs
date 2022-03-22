using UnityEngine;

namespace Minecraft
{
    public class MapGenerator : MonoBehaviour
    {
        [SerializeField] private ChunkRenderer rendererPrefab;

        public ChunkRenderer CreateChunkRenderer(Vector2Int position)
        {
            Chunk chunk = new Chunk(position);
            for (int x = 0; x < Chunk.ChunkSize; x++)
            {
                for (int z = 0; z < Chunk.ChunkSize; z++)
                {
                    for (int y = 0; y < Chunk.BuildHeight; y++)
                    {
                        if (y <= 4)
                            chunk.SetBlock(new Vector3Int(x, y, z), 3);
                        else if (y == 5)
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