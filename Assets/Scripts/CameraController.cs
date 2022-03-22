using System;
using UnityEngine;

namespace Minecraft
{
    public class CameraController : MonoBehaviour
    {
        private const int MinAngle = -90;
        private const int MaxAngle = 90;
        
        [SerializeField] private Player player;
        [HideInInspector] public float mouseVertical;
        private float viewAngle;
        private Vector3 offset;

        private void Start()
        {
            viewAngle = transform.eulerAngles.x;
            offset = transform.position - player.transform.position;
        }

        private void Update()
        {
            viewAngle = Mathf.Clamp(viewAngle + mouseVertical, MinAngle, MaxAngle);
            transform.rotation = Quaternion.Euler(viewAngle, player.transform.rotation.eulerAngles.y, 0);

            transform.position = player.transform.position + offset;
        }
    }
}