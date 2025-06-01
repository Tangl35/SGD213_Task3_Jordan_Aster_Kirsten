using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    // Spawn Locations
    public Transform[] spawnPoints;

    public int maxEnemies = 5;

    private int currentEnemyCount = 0;

    void Start()
    {
        // Spawn the initial batch of enemies
        for (int i = 0; i < maxEnemies; i++)
        {
            SpawnEnemy();
        }
    }

    //Called by EnemyHealth when an enemy dies.
    public void OnEnemyDeath()
    {
        currentEnemyCount--;

        // Delay before respawning
        Invoke(nameof(SpawnEnemy), 2f);
    }

    // Spawns a single enemy at spawn points
    void SpawnEnemy()
    {
        if (currentEnemyCount >= maxEnemies)
        {
            return;
        }

        // Pick random spawn point
        int index = Random.Range(0, spawnPoints.Length);

        Transform spawnPoint = spawnPoints[index];

        GameObject newEnemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

        // Assign spawner reference so it cna notify on death.
        EnemyHealth health = newEnemy.GetComponent<EnemyHealth>();
        if (health != null)
        {
            health.spawner = this;
        }

        currentEnemyCount++;
    }
}
