using System.Collections.Generic;
using UnityEngine;

namespace Minecraft
{
    [RequireComponent(typeof(MeshFilter))]
    [RequireComponent(typeof(MeshRenderer))]
    public class ChunkRenderer : MonoBehaviour
    {
        private const int TextureSize = 64;
        public static Dictionary<byte, Block> BlockData = new Dictionary<byte, Block>();

        [SerializeField] private Texture texture;

        private Chunk chunk;
        private MeshFilter meshFilter;


        public void Setup(Chunk chunk)
        {
            meshFilter = GetComponent<MeshFilter>();

            this.chunk = chunk;

            // Temporary, shoudl render when chunk changes
            Render();
        }

        public void Render()
        {
            Mesh mesh = CreateMesh();

            meshFilter.mesh = mesh;
        }

        private Mesh CreateMesh()
        {
            Mesh mesh = new Mesh();

            // int numberOfBlocks = Chunk.BuildHeight * Chunk.ChunkSize * Chunk.ChunkSize;
            int numberOfBlocks = chunk.BlockCount;
            // Debug.Log(numberOfBlocks);
            Vector3Int blockOffset =
                new Vector3Int(chunk.Position.x * Chunk.ChunkSize, 0, chunk.Position.y * Chunk.ChunkSize);

            // List<Vector3> vertices = new List<Vector3>();
            Vector3[] vertices = new Vector3[numberOfBlocks * 24];
            // List<Vector3> normals = new List<Vector3>();
            Vector3[] normals = new Vector3[numberOfBlocks * 24];
            // List<int> triangles = new List<int>();
            int[] triangles = new int[numberOfBlocks * 36];
            // List<Vector2> uv = new List<Vector2>();
            Vector2[] uv = new Vector2[numberOfBlocks * 24];

            for (int y = 0, i = 0; y < Chunk.BuildHeight; y++)
            {
                for (int x = 0; x < Chunk.ChunkSize; x++)
                {
                    for (int z = 0; z < Chunk.ChunkSize; z++)
                    {
                        Vector3Int position = new Vector3Int(x, y, z);
                        byte blockID = chunk.GetBlock(position + blockOffset);
                        if (blockID != 0)
                        {
                            Debug.Log(blockID);
                            Block block = BlockData[blockID];

                            #region Vertices

                            Vector3 v0 = new Vector3(x, y, z); // 0
                            Vector3 v1 = new Vector3(x, y, z + 1); // 1
                            Vector3 v2 = new Vector3(x + 1, y, z + 1); // 2
                            Vector3 v3 = new Vector3(x + 1, y, z); // 3
                            Vector3 v4 = new Vector3(x, y + 1, z); // 4
                            Vector3 v5 = new Vector3(x, y + 1, z + 1); // 5
                            Vector3 v6 = new Vector3(x + 1, y + 1, z + 1); // 6
                            Vector3 v7 = new Vector3(x + 1, y + 1, z); // 7

                            vertices[i * 24] = v0;
                            vertices[i * 24 + 1] = v1;
                            vertices[i * 24 + 2] = v2;
                            vertices[i * 24 + 3] = v3;
                            
                            vertices[i * 24 + 4] = v7;
                            vertices[i * 24 + 5] = v4;
                            vertices[i * 24 + 6] = v0;
                            vertices[i * 24 + 7] = v3;
                            
                            vertices[i * 24 + 8] = v4;
                            vertices[i * 24 + 9] = v5;
                            vertices[i * 24 + 10] = v1;
                            vertices[i * 24 + 11] = v0;
                            
                            vertices[i * 24 + 12] = v6;
                            vertices[i * 24 + 13] = v7;
                            vertices[i * 24 + 14] = v3;
                            vertices[i * 24 + 15] = v2;
                            
                            vertices[i * 24 + 16] = v5;
                            vertices[i * 24 + 17] = v6;
                            vertices[i * 24 + 18] = v2;
                            vertices[i * 24 + 19] = v1;
                            
                            vertices[i * 24 + 20] = v7;
                            vertices[i * 24 + 21] = v6;
                            vertices[i * 24 + 22] = v5;
                            vertices[i * 24 + 23] = v4;

                            #endregion

                            #region Triangles

//                             int[] triangles = newint[]
//                             {
// // Cube Bottom Side Triangles
//                                 3, 1, 0,
//                                 3, 2, 1,    
// // Cube Left Side Triangles
//                                 3 + 4 * 1, 1 + 4 * 1, 0 + 4 * 1,
//                                 3 + 4 * 1, 2 + 4 * 1, 1 + 4 * 1,
// // Cube Front Side Triangles
//                                 3 + 4 * 2, 1 + 4 * 2, 0 + 4 * 2,
//                                 3 + 4 * 2, 2 + 4 * 2, 1 + 4 * 2,
// // Cube Back Side Triangles
//                                 3 + 4 * 3, 1 + 4 * 3, 0 + 4 * 3,
//                                 3 + 4 * 3, 2 + 4 * 3, 1 + 4 * 3,
// // Cube Rigth Side Triangles
//                                 3 + 4 * 4, 1 + 4 * 4, 0 + 4 * 4,
//                                 3 + 4 * 4, 2 + 4 * 4, 1 + 4 * 4,
// // Cube Top Side Triangles
//                                 3 + 4 * 5, 1 + 4 * 5, 0 + 4 * 5,
//                                 3 + 4 * 5, 2 + 4 * 5, 1 + 4 * 5,
//                             } ;

                            triangles[i * 36] = i * 24 + 3;
                            triangles[i * 36 + 1] = i * 24 + 1;
                            triangles[i * 36 + 2] = i * 24 + 0;
                            triangles[i * 36 + 3] = i * 24 + 3;
                            triangles[i * 36 + 4] = i * 24 + 2;
                            triangles[i * 36 + 5] = i * 24 + 1;
                            
                            triangles[i * 36 + 6] = i * 24 + 7;
                            triangles[i * 36 + 7] = i * 24 + 5;
                            triangles[i * 36 + 8] = i * 24 + 4;
                            triangles[i * 36 + 9] = i * 24 + 7;
                            triangles[i * 36 + 10] = i * 24 + 6;
                            triangles[i * 36 + 11] = i * 24 + 5;
                            
                            triangles[i * 36 + 12] = i * 24 + 11;
                            triangles[i * 36 + 13] = i * 24 + 9;
                            triangles[i * 36 + 14] = i * 24 + 8;
                            triangles[i * 36 + 15] = i * 24 + 11;
                            triangles[i * 36 + 16] = i * 24 + 10;
                            triangles[i * 36 + 17] = i * 24 + 9;
                            
                            triangles[i * 36 + 18] = i * 24 + 15;
                            triangles[i * 36 + 19] = i * 24 + 13;
                            triangles[i * 36 + 20] = i * 24 + 12;
                            triangles[i * 36 + 21] = i * 24 + 15;
                            triangles[i * 36 + 22] = i * 24 + 14;
                            triangles[i * 36 + 23] = i * 24 + 13;
                            
                            triangles[i * 36 + 24] = i * 24 + 19;
                            triangles[i * 36 + 25] = i * 24 + 17;
                            triangles[i * 36 + 26] = i * 24 + 16;
                            triangles[i * 36 + 27] = i * 24 + 19;
                            triangles[i * 36 + 28] = i * 24 + 18;
                            triangles[i * 36 + 29] = i * 24 + 17;
                            
                            triangles[i * 36 + 30] = i * 24 + 23;
                            triangles[i * 36 + 31] = i * 24 + 21;
                            triangles[i * 36 + 32] = i * 24 + 20;
                            triangles[i * 36 + 33] = i * 24 + 23;
                            triangles[i * 36 + 34] = i * 24 + 22;
                            triangles[i * 36 + 35] = i * 24 + 21;

                            #endregion

                            #region UV's

                            const float tileSize = 1f / TextureSize;
                            Vector2 oneTile = new Vector2(tileSize, tileSize);
                            Vector2 topTile = block.TopTexture * oneTile;
                            Vector2 sideTile = block.SideTexture * oneTile;
                            Vector2 bottomTile = block.BottomTexture * oneTile;

                            uv[i * 24] = bottomTile + oneTile;
                            uv[i * 24 + 1] = bottomTile + Vector2.up * oneTile;
                            uv[i * 24 + 2] = bottomTile;
                            uv[i * 24 + 3] = bottomTile + Vector2.right * oneTile;

                            uv[i * 24 + 4] = sideTile + oneTile;
                            uv[i * 24 + 5] = sideTile + Vector2.up * oneTile;
                            uv[i * 24 + 6] = sideTile;
                            uv[i * 24 + 7] = sideTile + Vector2.right * oneTile;

                            uv[i * 24 + 8] = sideTile + oneTile;
                            uv[i * 24 + 9] = sideTile + Vector2.up * oneTile;
                            uv[i * 24 + 10] = sideTile;
                            uv[i * 24 + 11] = sideTile + Vector2.right * oneTile;

                            uv[i * 24 + 12] = sideTile + oneTile;
                            uv[i * 24 + 13] = sideTile + Vector2.up * oneTile;
                            uv[i * 24 + 14] = sideTile;
                            uv[i * 24 + 15] = sideTile + Vector2.right * oneTile;

                            uv[i * 24 + 16] = sideTile + oneTile;
                            uv[i * 24 + 17] = sideTile + Vector2.up * oneTile;
                            uv[i * 24 + 18] = sideTile;
                            uv[i * 24 + 19] = sideTile + Vector2.right * oneTile;

                            uv[i * 24 + 20] = topTile + oneTile;
                            uv[i * 24 + 21] = topTile + Vector2.up * oneTile;
                            uv[i * 24 + 22] = topTile;
                            uv[i * 24 + 23] = topTile + Vector2.right * oneTile;

                            #endregion

                            #region Normals

                            normals[i * 24] = Vector3.down;
                            normals[i * 24 + 1] = Vector3.down;
                            normals[i * 24 + 2] = Vector3.down;
                            normals[i * 24 + 3] = Vector3.down;

                            normals[i * 24 + 4] = Vector3.left;
                            normals[i * 24 + 5] = Vector3.left;
                            normals[i * 24 + 6] = Vector3.left;
                            normals[i * 24 + 7] = Vector3.left;

                            normals[i * 24 + 8] = Vector3.forward;
                            normals[i * 24 + 9] = Vector3.forward;
                            normals[i * 24 + 10] = Vector3.forward;
                            normals[i * 24 + 11] = Vector3.forward;

                            normals[i * 24 + 12] = Vector3.back;
                            normals[i * 24 + 13] = Vector3.back;
                            normals[i * 24 + 14] = Vector3.back;
                            normals[i * 24 + 15] = Vector3.back;

                            normals[i * 24 + 16] = Vector3.right;
                            normals[i * 24 + 17] = Vector3.right;
                            normals[i * 24 + 18] = Vector3.right;
                            normals[i * 24 + 19] = Vector3.right;

                            normals[i * 24 + 20] = Vector3.up;
                            normals[i * 24 + 21] = Vector3.up;
                            normals[i * 24 + 22] = Vector3.up;
                            normals[i * 24 + 23] = Vector3.up;

                            #endregion
                            
                            i++;
                        }
                    }
                }
            }

            mesh.SetVertices(vertices);
            mesh.SetTriangles(triangles, 0);
            mesh.SetUVs(0, uv);
            mesh.SetNormals(normals);

            mesh.name = $"Chunk {chunk.Position}";
            mesh.Optimize();

            return mesh;
        }
    }
}