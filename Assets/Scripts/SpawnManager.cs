using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    public GameObject enemyPrefab;
    private float spawnRange = 8.0f;

    private void Start() {
        SpawnEnemyWave(3);
    }

    private void Update() {
        int enemyCount = GameObject.FindObjectsOfType<EnemyController>().Length;
        if (enemyCount == 0) {
            SpawnEnemyWave(1);
        }
    }

    private void SpawnEnemyWave(int enemiesToSpawn) {
        Debug.Log($"Spawning new enemy wave with {enemiesToSpawn}");
        for (int i = 0; i < enemiesToSpawn; i++) {
            Instantiate(enemyPrefab, RandomSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    private Vector3 RandomSpawnPosition() {
        float xPosition = Random.Range(-spawnRange, spawnRange);
        float zPosition = Random.Range(-spawnRange, spawnRange);

        return new Vector3(xPosition, 0, zPosition);
    }
}
