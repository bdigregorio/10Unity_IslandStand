using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour {
    private float horizontalInput;
    private float rotationSpeed = 45;

    private void Update() {
        horizontalInput = Input.GetAxis("Horizontal");
        float yRotation = horizontalInput * rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, yRotation);
    }
}