using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterReposition : MonoBehaviour
{
    public Transform targetObject; // Reference to the target game object

    private Vector3 originalOffset; // Offset from the target object to the character

    private void Start()
    {
        if (targetObject != null)
        {
            // Calculate the initial offset from the target object to the character
            originalOffset = transform.position - targetObject.position;
        }
        else
        {
            Debug.LogError("Target object not assigned. Please assign a target object in the Inspector.");
        }
    }

    // You can call this function to reposition the character to the target object's origin
    public void RepositionToTargetObjectOrigin()
    {
        if (targetObject != null)
        {
            // Calculate the new position based on the target object's current position and the original offset
            Vector3 newPosition = targetObject.position + originalOffset;

            // Set the character's position to the new calculated position
            transform.position = newPosition;

            // Optionally, you can also set the character's rotation to match the target object's rotation
            transform.rotation = targetObject.rotation;
        }
        else
        {
            Debug.LogError("Target object not assigned. Please assign a target object in the Inspector.");
        }
    }
}
