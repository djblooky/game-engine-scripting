using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    [SerializeField] private GameObject projectile;
    [SerializeField] private float throwStrength = 20;
    [SerializeField] private float upwardArcInDegrees = 30;

    void Update()
    {
       if( Input.GetMouseButtonDown(0))
        {
            Debug.Log("Throwing!");
            Quaternion randomRotation = Random.rotationUniform;
            Vector3 spawnPosition = transform.position + transform.forward * 0.5f;
            GameObject projectileInstance = Instantiate(projectile, spawnPosition, randomRotation); //instatiates projectile 

            Rigidbody rb = projectileInstance.GetComponent<Rigidbody>(); //gets rigidboy, assigns to rb

            float upwardArcAngle = Mathf.Deg2Rad * upwardArcInDegrees;
            Vector3 direction = Vector3.RotateTowards(transform.forward, Vector3.up, upwardArcAngle, 0); //assign an arc curve direction

            rb.AddForce(direction * throwStrength, ForceMode.Impulse); //forces projectile away from player
        }
    }
}
