using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int scoreValue = 10;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.instance.AddScore(scoreValue);
            Destroy(gameObject);
        }
    }
}
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int scoreValue = 10;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Take a screenshot when player collects the item
            ScreenCapture.CaptureScreenshot($"Collectible_{System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")}.png");
            
            GameManager.instance.AddScore(scoreValue);
            Destroy(gameObject);
        }
    }
}