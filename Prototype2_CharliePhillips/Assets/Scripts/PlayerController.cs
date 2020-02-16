using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    [SerializeField] private readonly float speed = 10f;
    [SerializeField] private readonly float xRange = 10f;

    [SerializeField] private GameObject projectilePrefab;

    private void Update()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //launch projectile from the player
            Instantiate(projectilePrefab, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z), projectilePrefab.transform.rotation);
        }
    }
}
