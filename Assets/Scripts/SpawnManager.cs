using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    public PlayerController playerController;
    private float spawnRange = 8.0f;
    private int waveNumber = 1;

    private void Start() {
        InitializeComponents();
        SpawnEnemyWave(waveNumber);
    }

    private void Update() {
        int enemyCount = GameObject.FindObjectsOfType<EnemyController>().Length;
        if (enemyCount == 0) {
            waveNumber++;
            SpawnEnemyWave(waveNumber);
        }
    }

    private void InitializeComponents() {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void SpawnEnemyWave(int enemiesToSpawn) {
        if (playerController.isGameOver != true) {
            Debug.Log($"Spawning new enemy wave with {enemiesToSpawn}");
            Instantiate(powerupPrefab, RandomSpawnPosition(), powerupPrefab.transform.rotation);
            for (int i = 0; i < enemiesToSpawn; i++) {
                Instantiate(enemyPrefab, RandomSpawnPosition(), enemyPrefab.transform.rotation);
            }
        }
    }

    private Vector3 RandomSpawnPosition() {
        float xPosition = Random.Range(-spawnRange, spawnRange);
        float zPosition = Random.Range(-spawnRange, spawnRange);

        return new Vector3(xPosition, 0, zPosition);
    }
}
