using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Throw : MonoBehaviour
{
    [SerializeField] GameObject[] foodList;

    [SerializeField] private GameObject projectile;
    [SerializeField] private float throwStrength = 20;
    [SerializeField] private float upwardArcInDegrees = 30;
    [SerializeField] private int throwsLeft = 6;

    void Update()
    {
        if(throwsLeft > 0)
        {  
            CheckForThrow();
        }  
    }

    private void SetRandomFood()
    {
        projectile = foodList[Random.Range(0, foodList.Length)];
    }

    private void CheckForThrow()
    {
        if (Input.GetMouseButtonDown(0))
        {
            throwsLeft--;
            SetRandomFood();
            Debug.Log("Throwing!");
            Quaternion randomRotation = Random.rotationUniform;
            Vector3 spawnPosition = transform.position + transform.forward * 0.5f;
            GameObject projectileInstance = Instantiate(projectile, spawnPosition, randomRotation); //instatiates projectile 

            Rigidbody rb = projectileInstance.GetComponent<Rigidbody>(); //gets rigidboy, assigns to rb

            float upwardArcAngle = Mathf.Deg2Rad * upwardArcInDegrees;
            Vector3 direction = Vector3.RotateTowards(transform.forward, Vector3.up, upwardArcAngle, 0); //assign an arc curve direction

            rb.AddForce(direction * throwStrength, ForceMode.Impulse); //forces projectile away from player
            Destroy(projectileInstance.gameObject, 10); //destroy after 10sec
        }
    }
}
