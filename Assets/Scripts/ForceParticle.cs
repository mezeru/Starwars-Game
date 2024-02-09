using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceParticle : MonoBehaviour
{
    public ParticleSystem particleSystem;
    public float duration = 5f;

    private float initialEmissionRate;
    private float timer = 0f;

    void Start()
    {
        // Store the initial emission rate of the particle system
        initialEmissionRate = particleSystem.emission.rateOverTime.constant;
    }

    void Update()
    {
        // Increment the timer
        timer += Time.deltaTime;

        // Calculate the new emission rate based on time
        float newEmissionRate = Mathf.Lerp(initialEmissionRate, 0f, timer / duration);

        // Set the particle system's emission rate
        var emission = particleSystem.emission;
        var rateOverTime = emission.rateOverTime;
        rateOverTime.constant = newEmissionRate;
        emission.rateOverTime = rateOverTime;

        // If the duration has passed, stop the script
        if (timer >= duration)
        {
            enabled = false;
        }
    }
}