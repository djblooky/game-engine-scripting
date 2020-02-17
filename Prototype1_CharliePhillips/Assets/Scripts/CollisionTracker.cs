using UnityEngine;

public class CollisionTracker : MonoBehaviour
{



    private void Start()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision");
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log($"Hit obstacle {gameObject.name}");
        }
    }
}
