using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput;
    [SerializeField] private float speed = 20f;
    [SerializeField] private float xRange = 20f;

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
            Instantiate(projectilePrefab, new Vector3(transform.position.x, transform.position.y + 1, transform.position.z), projectilePrefab.transform.rotation);
        }
    }
}
