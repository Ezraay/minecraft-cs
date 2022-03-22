using UnityEngine;

namespace Minecraft
{
    [CreateAssetMenu(menuName = "Create Block", fileName = "New Block", order = 0)]
    public class Block : ScriptableObject
    {
        public byte BlockID => blockID;
        public Vector2Int TopTexture => topTexture;
        public Vector2Int SideTexture => sideTexture;
        public Vector2Int BottomTexture => bottomTexture;
    
        [Min(1)] [SerializeField] private byte blockID = 1;
        [SerializeField] private Vector2Int topTexture;
        [SerializeField] private Vector2Int sideTexture;
        [SerializeField] private Vector2Int bottomTexture;
    }
}