using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private float baseMoveSpeed; // Base move speed without considering character size
    [SerializeField] private Transform arCameraTransform; // Reference to the AR Camera's transform
    [SerializeField] private Animator animator;

    private void FixedUpdate()
    {
        // Get the camera's forward and right directions in world space
        Vector3 cameraForward = arCameraTransform.forward;
        Vector3 cameraRight = arCameraTransform.right;
        cameraForward.y = 0; // Ensure the movement is on the horizontal plane (no vertical component).
        cameraRight.y = 0;

        // Normalize the directions to ensure consistent speed
        cameraForward.Normalize();
        cameraRight.Normalize();

        // Calculate the movement direction relative to the camera
        Vector3 moveDirection = (cameraForward * joystick.Vertical + cameraRight * joystick.Horizontal).normalized;

        // Calculate the scale factor based on the character's size
        Vector3 characterScale = transform.localScale;
        float sizeFactor = Mathf.Max(characterScale.x, characterScale.y, characterScale.z);

        // Adjust the move speed based on the character's size
        float adjustedMoveSpeed = baseMoveSpeed * sizeFactor;

        // Set the character's velocity based on the move direction and adjusted move speed
        rb.velocity = moveDirection * adjustedMoveSpeed;

        // Rotate the character to face the movement direction
        if (moveDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveDirection);
            animator.SetBool("IsWalking", true);
        }
        else
        {
            animator.SetBool("IsWalking", false);
        }
    }
}
