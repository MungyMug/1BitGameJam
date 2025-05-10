using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform player;
    [SerializeField] private float minSpawnDistance = 5f;
    [SerializeField] private float maxSpawnDistance = 10f;
    [SerializeField] private float spawnInterval = 2f;  // time between spawns
    [SerializeField] private int totalEnemiesToSpawn = 20;

    private int enemiesSpawned = 0;

    void Start()
    {
        StartCoroutine(SpawnEnemiesOverTime());
    }

    IEnumerator SpawnEnemiesOverTime()
    {
        while (enemiesSpawned < totalEnemiesToSpawn)
        {
            Vector2 spawnPos = GetRandomSpawnPositionAroundPlayer();
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
            enemiesSpawned++;

            yield return new WaitForSeconds(spawnInterval);
        }
    }

    Vector2 GetRandomSpawnPositionAroundPlayer()
    {
        float angle = Random.Range(0f, Mathf.PI * 2f);
        float distance = Random.Range(minSpawnDistance, maxSpawnDistance);
        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        return (Vector2)player.position + direction * distance;
    }
}
