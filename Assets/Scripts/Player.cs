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

            if (characterController.isGrounded)
            {
                verticalVelocity = 0;
                if (jumping)
                {
                    // v² = u² + 2as
                    //
                    //     v = current vertical velocity
                    //     u = initial velocity (jump velocity)
                    // a = acceleration (gravity)
                    // s = distance
                    //
                    // Say (as an example) gravity is -9.8ms² and the required jump height is 2 metres.
                    //
                    //     v²=u²+2as
                    // 0 = u² + 2as
                    // -2as = u²
                    // u² = -2as
                    //
                    //     u² = -2 * -9.8 * 2
                    // u² = 39.2
                    // u = 1.788854381999832
                    
                    // u2 = -2as
                    // u = sqrt(-2as)
                    verticalVelocity = Mathf.Sqrt(-2 * Physics.gravity.y * jumpHeight);
                }
            }
            else
            {
                verticalVelocity += Physics.gravity.y * Time.deltaTime;
                // verticalVelocity -= 0.08f;
                // verticalVelocity *= 0.98f;
            }
            
            Vector3 velocity = new Vector3(lateralMovement.x, verticalVelocity, lateralMovement.z);
            
            characterController.Move(transform.rotation * velocity * Time.deltaTime);
        }
    }
}
