using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    // No magic numbers and no public fields to make something visible in the inspector.
    [SerializeField] GameObject ball;
    [SerializeField] float shootForce = 10f;
    [SerializeField] float shotsPerSecond = 5;
    [SerializeField] float upwardAngleRotation = 15;
    bool canShoot = false;

    private void Start()
    {

    }

    void Update()
    {
        if (canShoot && Input.GetMouseButtonDown(0))
        {
            MakeShot();
        }
    }

    private void MakeShot()
    {
        Instantiate(ball, transform.position, Quaternion.identity, transform);
        Rigidbody ballRigidbody = ball.GetComponent<Rigidbody>();
        float angle = upwardAngleRotation * Mathf.Rad2Deg;
        Vector3 shootDirection = Vector3.RotateTowards(transform.forward, Vector3.up, angle, 0);
        ballRigidbody.AddForce(shootDirection * shootForce, ForceMode.Impulse);
        canShoot = false;
        Invoke("EnableShooing", 1 / shotsPerSecond);
    }

    void EnableShooting()
    {
        canShoot = true;
    }
}
