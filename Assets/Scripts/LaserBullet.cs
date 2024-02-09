using UnityEngine;

public class LaserBullet : MonoBehaviour
{
    private GameObject sword;
    public float deflectionAngle;
    public GameObject deflectionParticlePrefab;

    private void Start()
    {
        sword = GameObject.FindWithTag("Sword");

        if (sword == null)
        {
            Debug.LogError("Sword GameObject not found. Make sure to set the correct tag.");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("LaserBullet"))
        {
            // Calculate deflection direction based on sword's rotation
            Vector3 deflectionDirection = Quaternion.Euler(0, deflectionAngle, 0) * sword.transform.forward;

            // Reflect the bullet in the deflection direction
            collision.transform.forward = deflectionDirection;

            Rigidbody bulletRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            if (bulletRigidbody != null)
            {
                bulletRigidbody.velocity *= 2f;
            }

            // Check if the sword has a collider (to avoid null reference)
            Collider swordCollider = sword.GetComponent<Collider>();
            if (swordCollider != null)
            {
                // Calculate collision point
                Vector3 collisionPoint = collision.contacts[0].point;

                // Instantiate particle effect at collision point
                GameObject particle = Instantiate(deflectionParticlePrefab, collisionPoint, Quaternion.identity);

                // Destroy the particle system after 0.05 seconds
                Destroy(particle, 0.1f);
            }

            // Destroy the bullet after 1 second
            Destroy(collision.gameObject, 0.01f);
        }
    }
}