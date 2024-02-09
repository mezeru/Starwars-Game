using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Electricity : MonoBehaviour
{
    public ParticleSystem particleSystem;
    private float effectDuration = 5f;
    private bool isEffectPlaying = false;
    private Collider particleCollider; // Reference to the collider component

    void Start()
    {
        particleSystem.Stop();
        particleCollider = particleSystem.GetComponent<Collider>(); // Get the collider component
        if (particleCollider != null)
        {
            particleCollider.enabled = false; // Disable the collider initially
        }
    }

    private void Update()
    {
        // Check if the E key is pressed
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Start the particle effect if it's not already playing
            if (!isEffectPlaying)
            {
                StartParticleEffect();
            }
        }

        // Check if the particle effect is playing
        if (isEffectPlaying)
        {
            // Decrease the timer
            effectDuration -= Time.deltaTime;

            // Check if the timer has elapsed
            if (effectDuration <= 0f)
            {
                // Turn off the particle effect
                StopParticleEffect();
            }
        }
    }

    private void StartParticleEffect()
    {
        // Start the particle effect
        particleSystem.Play();

        // Enable the collider
        if (particleCollider != null)
        {
            particleCollider.enabled = true;
        }

        // Set isEffectPlaying to true
        isEffectPlaying = true;

        // Reset effect duration
        effectDuration = 5f;
    }

    private void StopParticleEffect()
    {
        // Stop the particle effect
        particleSystem.Stop();

        // Disable the collider
        if (particleCollider != null)
        {
            particleCollider.enabled = false;
        }

        // Reset isEffectPlaying to false
        isEffectPlaying = false;
    }
}
