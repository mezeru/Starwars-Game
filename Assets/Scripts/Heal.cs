using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour{

    public ParticleSystem particleSystem;
    private float effectDuration = 5f;
    private bool isEffectPlaying = false;
    public PlayerController player;

    public float increaseRate = 1f; // Health increase rate per second
    public float duration = 5f;

    void Start(){

        particleSystem.Stop();

    }

    private void Update()
    {
        // Check if the E key is pressed
        if (Input.GetKeyDown(KeyCode.P))
        {
            // Start the particle effect if it's not already playing
            if (!isEffectPlaying)
            {
                StartParticleEffect();
                AddHealth();
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


    private void AddHealth(){

        player.TakeDamage(-50);

    }

 

    

    private void StartParticleEffect()
    {
        // Start the particle effect
        particleSystem.Play();

        // Set isEffectPlaying to true
        isEffectPlaying = true;

        // Reset effect duration
        effectDuration = 5f;
    }

    private void StopParticleEffect()
    {
        // Stop the particle effect
        particleSystem.Stop();

        // Reset isEffectPlaying to false
        isEffectPlaying = false;
    }
}