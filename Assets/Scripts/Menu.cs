using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
     
        // Check if the collision is from the player
        if(collision.gameObject.CompareTag("Train")){
            Invoke("ChangeSceneTrain", 1f);
        }

        if(collision.gameObject.CompareTag("Attack")){
            Invoke("ChangeSceneAttack", 1f);
        }
    }

    private void ChangeSceneTrain()
    {
        // Change the scene to your desired scene
        SceneManager.LoadScene(0);
    }

    private void ChangeSceneAttack()
    {
        // Change the scene to your desired scene
        SceneManager.LoadScene(1);
    }
}
