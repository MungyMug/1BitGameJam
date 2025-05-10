using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawn Settings")]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform player;
    [SerializeField] private float minSpawnDistance = 5f;
    [SerializeField] private float maxSpawnDistance = 10f;
    [SerializeField] private int enemiesPerWave = 5;

    void Start()
    {
        SpawnEnemies();
    }

    public void SpawnEnemies()
    {
        for (int i = 0; i < enemiesPerWave; i++)
        {
            Vector2 spawnPos = GetRandomSpawnPositionAroundPlayer();
            Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
        }
    }

    Vector2 GetRandomSpawnPositionAroundPlayer()
    {
        float angle = Random.Range(0f, Mathf.PI * 2f);
        float distance = Random.Range(minSpawnDistance, maxSpawnDistance);

        Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
        Vector2 spawnPos = (Vector2)player.position + direction * distance;

        return spawnPos;
    }
}
