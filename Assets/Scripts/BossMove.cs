using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMove : MonoBehaviour
{
    public float moveSpeed = 3f;      // Adjust the speed as needed
    public float lerpSpeed = 0.5f;    // Adjust the lerping speed as needed
    public float maxDistance = 10f;   // Maximum distance from the player
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 10f;
    public float fireRate = 1f;       // Adjust the fire rate as needed

    public Transform playerTransform;
    private Vector3 targetPosition;
    private float nextFireTime;

    public float constantBulletZRotation = 90f;
    public float constantBulletXRotation = 0f;
    public float constantBulletyRotation = 0f;
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        ShootBullets();
        
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
}
