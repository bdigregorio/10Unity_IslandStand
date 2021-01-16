using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {
    private GameObject player;
    private Rigidbody thisRigidBody;
    public float speed;

    void Start() {
        InitializeComponents();
    }

    void Update() {
        MoveTowardPlayer();
    }

    private void InitializeComponents() {
        player = GameObject.Find("Player");
        thisRigidBody = GetComponent<Rigidbody>();
    }

    private void MoveTowardPlayer() {
        Vector3 towardPlayer = (player.transform.position - transform.position).normalized;
        thisRigidBody.AddForce(towardPlayer * speed);
    }
}
