using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoopMover : MonoBehaviour
{
    [SerializeField] float speed = 1f;
    [SerializeField] float hoopMovementHalfRange = 2.5f;
    Vector3 target;    

    void Start()
    {
        SetNewTarget();
    }

    void Update()
    {
        // Take a small step from the current position to the target position each frame.
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (transform.position == target)
        {
            SetNewTarget();
        }
    }

    void SetNewTarget()
    {
        Vector3 pos = transform.position;
        pos.z = Random.Range(-hoopMovementHalfRange, hoopMovementHalfRange);
        target = pos;
    }
}
