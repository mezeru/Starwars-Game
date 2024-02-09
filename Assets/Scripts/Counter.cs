using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

using UnityEngine.SceneManagement;

public class Wave : MonoBehaviour
{
    public TextMeshProUGUI enemyCountText; // Reference to the UI Text element to display enemy count
    private int enemiesKilled = 0; // Variable to store the count of enemies killed

    // This method will be called whenever an enemy is killed
    public void EnemyKilled()
    {
        enemiesKilled++; // Increment the count of enemies killed
        UpdateUI(); // Update the UI to reflect the new count
    }

    void OnCollisionEnter(Collision other){

        if(other.gameObject.CompareTag("Enemy")){
            EnemyKilled();
        }

    }

    // This method updates the UI text to display the current count of enemies killed
    private void UpdateUI()
    {
        if(enemiesKilled <= 10 ){
            enemyCountText.text =  "Wave 1 : "+ enemiesKilled.ToString() + "/10";
        }

        if(enemiesKilled <= 25 && enemiesKilled > 10 ){
            enemyCountText.text =  "Wave 2 : "+ enemiesKilled.ToString() + "/25";
        }


        if(enemiesKilled >= 25){
             SceneManager.LoadScene(4);
        }
        
    }
}