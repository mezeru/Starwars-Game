using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    public Image healthBar; // Reference to the UI Image

    void Start()
    {
        currentHealth = maxHealth;

        // Ensure healthBar is assigned in the Unity Editor
        if (healthBar == null)
        {
            Debug.LogError("HealthBar UI Image is not assigned!");
        }

        // Initialize UI
        UpdateHealthUI();
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is from the player
        if(collision.gameObject.CompareTag("LaserBullet")){
            TakeDamage(1);
        }
    }

    private void UpdateHealthUI()
    {
        // Update the UI based on the current health
        if (healthBar != null)
        {
            healthBar.fillAmount = (float)currentHealth / maxHealth; // Set fill amount directly to represent health
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        // Ensure health doesn't go below zero

        if (currentHealth < 0)
        {
            Die();
        }

        // Update the UI
        UpdateHealthUI();

        // Check if the player is dead
        
    }

    private void Die()
    {
        // Add code to handle player death (e.g., show game over screen, restart level, etc.)
        Debug.Log("Player has died!");

        // Invoke the ChangeScene method after 10 seconds
        Invoke("ChangeScene",0.1f);
    }

    private void ChangeScene()
    {
 
        SceneManager.LoadScene(3);
        
    }
}
