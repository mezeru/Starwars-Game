using UnityEngine;

public class DroneShooting : MonoBehaviour
{
    public float moveSpeed = 3f;      // Adjust the speed as needed
    public float lerpSpeed = 0.5f;    // Adjust the lerping speed as needed
    public float maxDistance = 10f;   // Maximum distance from the player
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 10f;
    public float fireRate = 1f;       // Adjust the fire rate as needed

    private Transform playerTransform;
    private Vector3 targetPosition;
    private float nextFireTime;

    public float constantBulletZRotation = 90f;
    public float constantBulletXRotation = 0f;

    void Start()
    {
        playerTransform = Camera.main.transform; // Assuming the main camera is the player's viewpoint
        SetRandomTarget();
    }

    void Update()
    {
        MoveDroneSmoothly();
        ShootBullets();
    }

    void MoveDroneSmoothly()
    {
        // Lerp towards the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, lerpSpeed * Time.deltaTime);

        // Make the drone always look at the player
        transform.LookAt(playerTransform);

        // Check if the drone is close to the target position, then set a new target
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            SetRandomTarget();
        }
    }

    void ShootBullets()
    {
        // Check if it's time to fire
        if (Time.time > nextFireTime)
        {
            // Instantiate a bullet
            GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);

             bullet.transform.LookAt(playerTransform.position);
            bullet.transform.eulerAngles = new Vector3(0f, bullet.transform.eulerAngles.z, constantBulletZRotation);

            // Calculate the direction towards the player
            Vector3 directionToPlayer = (playerTransform.position - bullet.transform.position).normalized;

            // Set the bullet's initial velocity
            bullet.GetComponent<Rigidbody>().velocity = directionToPlayer * bulletSpeed;

            // Set the next fire time
            nextFireTime = Time.time + 1f / fireRate;  // 1f divided by fireRate gives the time between shots
        }
    }

    void SetRandomTarget()
    {
        // Generate a new random position within the specified bounds
        float randomX = Random.Range(-maxDistance, maxDistance);
        float randomZ = Random.Range(-maxDistance, maxDistance);

        // Apply bounds to keep the drone within the maximum distance from the player
        Vector3 offset = new Vector3(randomX, 0f, randomZ);
        targetPosition = playerTransform.position + offset;
    }
}
