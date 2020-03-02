using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalCannon : MonoBehaviour
{
    [SerializeField] GameObject[] animalPrefabs;
    [SerializeField] float cannonForce = 15;
    [SerializeField] float torqueForce = 50;

    private void Start()
    {
        InvokeRepeating("FireAnimal", 1f, 1f);
    }

    private void FireAnimal()
    {
        int i = Random.Range(0, animalPrefabs.Length);
        GameObject animal = Instantiate(animalPrefabs[i], transform.position, Random.rotationUniform);
        Vector3 direction = Quaternion.Euler(0, 0, Random.Range(-25, 25)) * Vector3.up;
        Rigidbody rb = animal.GetComponent<Rigidbody>();
        rb.AddForce(direction * cannonForce, ForceMode.Impulse);
        rb.AddTorque(Random.insideUnitSphere * torqueForce, ForceMode.Impulse);
    }
}
