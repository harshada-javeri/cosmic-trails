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