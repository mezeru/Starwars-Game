using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Sword"))
        {
            Destroy(gameObject);
        }
        // Check if the collision is with the player
        else if (other.gameObject.CompareTag("Player"))
        {

             PlayerController player = other.gameObject.GetComponent<PlayerController>();

            // If the collided object has a PlayerController script, damage the player
            if (player != null)
            {
                player.TakeDamage(5);
            }
            // Destroy the enemy upon collision with the player
            Destroy(gameObject);
        }
    }
}
