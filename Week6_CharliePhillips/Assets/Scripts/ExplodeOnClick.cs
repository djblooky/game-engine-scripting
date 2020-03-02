using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeOnClick : MonoBehaviour
{
    [SerializeField] GameObject particles;

    private void OnMouseDown()
    {
        Destroy(gameObject);
        Instantiate(particles, transform.position, particles.transform.rotation);
    }
}
