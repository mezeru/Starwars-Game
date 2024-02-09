using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    public int count = 0;  // The counter variable
    public Text counterText;  // Reference to a UI Text component for displaying the counter

    void Start()
    {
        UpdateCounter();
    }

    void UpdateCounter()
    {
        counterText.text = "Count: " + count.ToString();
    }

    // Call this method whenever you want to increment the counter
    public void IncrementCounter()
    {
        count++;
        UpdateCounter();
    }

    // Call this method whenever you want to reset the counter
    public void ResetCounter()
    {
        count = 0;
        UpdateCounter();
    }
}
