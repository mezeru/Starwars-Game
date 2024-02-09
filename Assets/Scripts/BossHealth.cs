using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossHealth : MonoBehaviour
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
        if(collision.gameObject.CompareTag("Sword")){
            TakeDamage(10);
        }

        if(collision.gameObject.CompareTag("Player")){
            
            PlayerController playerC = collision.gameObject.GetComponent<PlayerController>();

            // If the collided object has a PlayerController script, damage the player
            if (playerC != null)
            {
                playerC.TakeDamage(10);
            }
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
        if (currentHealth <= 0)
        {
            Die();
        }

        // Update the UI
        UpdateHealthUI();
    }

    private void Die()
    {
        // Add code to handle boss death
        Debug.Log("Boss has died!");

        // Invoke the ChangeScene method after a delay
        Invoke("ChangeScene", 2f);
    }

    private void ChangeScene()
    {
        // Change the scene to your desired scene
        //SceneManager.LoadScene("NextSceneName");
    }
}
