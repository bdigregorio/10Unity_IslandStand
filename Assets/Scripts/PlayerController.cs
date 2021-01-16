using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody thisRigidBody;
    private GameObject focalPointObject;
    public float speed;

    void Start() {
        InitializeComponents();
    }

    void Update() {
        ApplyInputForce();
    }

    private void InitializeComponents() {
        thisRigidBody = GetComponent<Rigidbody>();
        focalPointObject = GameObject.Find("Focal Point");
    }

    private void ApplyInputForce() {
        // input value is between 0 and 1 
        float verticalInputMagnitude = Input.GetAxis("Vertical");
        thisRigidBody.AddForce(focalPointObject.transform.forward * verticalInputMagnitude * speed);
    }
}
