using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Minecraft
{
    [RequireComponent(typeof(CharacterController))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private float movementSpeed = 4.317f; // Measured in blocks/s
        [SerializeField] private float jumpHeight = 1.2522f; // Measured in blocks
        
        [HideInInspector] public Vector2 moveInput;
        [HideInInspector] public float mouseHorizontal;
        [HideInInspector] public bool jumping;

        private float verticalVelocity;

        private CharacterController characterController;

        private void Start()
        {
            characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            // Rptatopm
            transform.Rotate(Vector3.up * mouseHorizontal);
            
            
            // Movement
            Vector3 lateralMovement = new Vector3(moveInput.x, 0, moveInput.y) * movementSpeed;
            
            Vector3 velocity = lateralMovement;
            
            characterController.Move(transform.rotation * lateralMovement * Time.deltaTime);
        }
    }
}
