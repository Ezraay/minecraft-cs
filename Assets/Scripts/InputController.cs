using System;
using UnityEngine;

namespace Minecraft
{
    public class InputController : MonoBehaviour
    {
        [SerializeField] private CameraController cameraController;
        [SerializeField] private Player player;
        [SerializeField] private float mouseSensitivity = 1f;

        public static void HideCursor()
        {
            Cursor.visible = false;
        }
        
        private void Start()
        {
            HideCursor();
        }

        private void Update()
        {
            player.moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
            player.mouseHorizontal = Input.GetAxisRaw("Mouse X") * mouseSensitivity;
            player.jumping = Input.GetKey(KeyCode.Space);
            cameraController.mouseVertical = -Input.GetAxisRaw("Mouse Y") * mouseSensitivity;
        }
    }
}