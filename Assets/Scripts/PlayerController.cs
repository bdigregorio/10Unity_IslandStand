using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private Rigidbody thisRigidBody;
    private GameObject focalPointObject;
    public GameObject powerupIndicator;
    public float speed;
    public float powerupStrength;
    private bool isPoweredUp = false;
    public float powerupDuration;
    public bool isGameOver = false;
    private float verticalBounds = -5.0f;

    private void Start() {
        InitializeComponents();
    }

    private void Update() {
        ApplyInputForce();
        CheckForGameOver();
    }

    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Powerup")) {
            ConsumePowerup(other.gameObject);
        }
    }

    private void OnCollisionEnter(Collision other) {
        if (isPoweredUp && other.gameObject.CompareTag("Enemy")) {
            PoweredUpEnemyCollision(other);
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
        powerupIndicator.transform.position = transform.position + new Vector3(0f, -0.25f, 0f);
    }

    private void ConsumePowerup(GameObject powerup) {
        isPoweredUp = true;
        powerupIndicator.SetActive(true);
        Destroy(powerup);
        StartCoroutine(PowerupCountdownRoutine());
    }

    IEnumerator PowerupCountdownRoutine() {
        yield return new WaitForSeconds(powerupDuration);
        isPoweredUp = false;
        powerupIndicator.SetActive(false);
        Debug.Log($"Powerup timer expired - isPoweredUp: {isPoweredUp}");
    }

    private void PoweredUpEnemyCollision(Collision enemyCollision) {
        GameObject enemy = enemyCollision.gameObject;
        Rigidbody enemyRigidbody = enemy.GetComponent<Rigidbody>();

        Debug.Log($"Player collided with ${enemy} with powerup set to ${isPoweredUp}");
        
        Vector3 awayFromPlayer = (enemy.transform.position - transform.position).normalized;
        enemyRigidbody.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse);
    }

    private void CheckForGameOver() {
        if (transform.position.y < verticalBounds) {
            isGameOver = true;
        }
    }
}