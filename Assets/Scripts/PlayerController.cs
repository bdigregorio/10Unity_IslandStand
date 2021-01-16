using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody thisRigidBody;
    private GameObject focalPointObject;
    public float speed;
    public bool isPoweredUp = false;

    private void Start() {
        InitializeComponents();
    }

    private void Update() {
        ApplyInputForce();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("PowerUp")) {
            ConsumePowerUp(other.gameObject);
        }
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

    private void ConsumePowerUp(GameObject powerUp) {
            isPoweredUp = true;
            Destroy(powerUp);
    }
}
