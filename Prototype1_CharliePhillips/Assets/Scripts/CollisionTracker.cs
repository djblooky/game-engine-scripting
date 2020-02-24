using UnityEngine;

public class CollisionTracker : MonoBehaviour
{
    private DamageManager damageManager;


    private void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        damageManager = player.GetComponent<DamageManager>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log($"Hit obstacle {collision.gameObject.name}");

            damageManager.IncrementDamage();
        }
    }
}
