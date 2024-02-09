using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Future : MonoBehaviour
{

    public GameObject Audio;
    public float incC = 5f;

    // Update is called once per frame
    private void Update()
    {
        // Check if the E key is pressed
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SeeFuture();
        }

    }

    void SeeFuture(){

        Vector3 currentPosition = Audio.transform.position;
            
            // Increase the z-coordinate by 1 unit
        currentPosition.z += incC;
        
        // Assign the updated position back to the target object
        Audio.transform.position = currentPosition;
    
    }
}
