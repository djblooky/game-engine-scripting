using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTracker : MonoBehaviour
{
    [SerializeField] GameObject cloudParticles;
    private ScoreManager scoreManager;

    private void Start()
    {
        //look up the player
        //GameObject.Find("player"); //slow and fragile
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        //get the score manager
        scoreManager = player.GetComponent<ScoreManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {   
        GameObject other = collision.gameObject;

        if (other.CompareTag("Ground"))
        {
            Debug.Log($"{gameObject.name} just hit the ground.");
            ContactPoint contact = collision.GetContact(0);
            Instantiate(cloudParticles, contact.point, cloudParticles.transform.rotation);
            Destroy(gameObject);

            //call score manager to add to score
            scoreManager.IncrementScore();
        }

    }
}
