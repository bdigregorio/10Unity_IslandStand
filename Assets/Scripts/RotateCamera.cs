using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour {
    private float horizontalInput;
    public float rotationSpeed;

    private void Update() {
        FollowHorizontalInput();
    }

    private void FollowHorizontalInput() {
        horizontalInput = Input.GetAxis("Horizontal");
        float yRotation = horizontalInput * rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, yRotation);
    }
}