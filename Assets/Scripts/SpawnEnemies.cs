using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform playerCameraTransform; // Drag and drop the player camera in the inspector
    public float moveSpeed = 3.0f;
    public float spawnInterval = 2.0f; // Adjust the interval between spawns
    public float minDistanceToPlayer = 5.0f; // Adjust the minimum distance to spawn enemies

    private float lastSpawnedTime = 0;

    private void Update()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        if (Time.time - lastSpawnedTime > spawnInterval)
        {
            lastSpawnedTime = Time.time;

            // Calculate a random spawn position within a range
            Vector3 spawnPosition = new Vector3(Random.Range(-15, 15), Random.Range(3, 13), Random.Range(-15, 15));

            // Check the distance to the player before spawning
            float distanceToPlayer = Vector3.Distance(spawnPosition, playerCameraTransform.position);
            if (distanceToPlayer > minDistanceToPlayer)
            {
                // Instantiate the enemy at the spawn position
                GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);

                // Calculate the direction towards the player
                Vector3 directionToPlayer = (playerCameraTransform.position - spawnPosition).normalized;

                // Set the enemy's rotation to look at the player
                enemy.transform.LookAt(playerCameraTransform);

                // Move the enemy towards the player
                enemy.GetComponent<Rigidbody>().velocity = directionToPlayer * moveSpeed;
            }
        }
    }
}
