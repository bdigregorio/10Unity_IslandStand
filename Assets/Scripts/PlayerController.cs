using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody playerRigidBody;
    private GameObject focalPoint;
    private float speed = 8;
    private float verticalInput = 0;

    void Start() {
        playerRigidBody = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    void Update() {
        verticalInput = Input.GetAxis("Vertical");
        playerRigidBody.AddForce(focalPoint.transform.forward * speed * verticalInput);
    }
}
