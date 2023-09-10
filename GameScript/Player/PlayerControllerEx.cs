using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerEx : MonoBehaviour
{
    public float rotationSpeed = 5.0f;

    void Update()
    {
        // Get the mouse input values for horizontal movement
        float mouseX = Input.GetAxis("Mouse X");

        // Calculate the rotation angle based on mouse input
        float rotationAngle = mouseX * rotationSpeed;

        // Apply the rotation to the player around the Z-axis
        transform.Rotate(0f, rotationAngle, 0f);
    }
}
