using UnityEngine;

public class DestoryOutOfBounds : MonoBehaviour
{
    private float topBound = 30;
    private float lowerBound = -10;

    private void Update()
    {
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < lowerBound)
        {
            Debug.Log("Game Over!");
            Destroy(gameObject);
        }
    }
}
