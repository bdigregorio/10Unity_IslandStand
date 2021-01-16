using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    private GameObject player;
    private Rigidbody thisRigidBody;
    public float speed;
    private float verticalBounds = -5.0f;

    private void Start() {
        InitializeComponents();
    }

    private void Update() {
        MoveTowardPlayer();
        RemoveIfOutOfBounds();
    }

    private void InitializeComponents() {
        player = GameObject.Find("Player");
        thisRigidBody = GetComponent<Rigidbody>();
    }

    private void MoveTowardPlayer() {
        Vector3 towardPlayer = (player.transform.position - transform.position).normalized;
        thisRigidBody.AddForce(towardPlayer * speed);
    }

    private void RemoveIfOutOfBounds() {
        if (transform.position.y < verticalBounds) {
            Debug.Log("Destroying enemy game object");
            Destroy(gameObject);
        }
    }
}
