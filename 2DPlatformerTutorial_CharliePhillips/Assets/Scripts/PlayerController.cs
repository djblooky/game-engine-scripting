using UnityEngine;

[DisallowMultipleComponent]
[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Ground Movement")]
    [Tooltip("Movement speed in tiles per second (1 tile = 1 meter)")]
    [SerializeField]
    private float speed;

    [Header("Air Movement")]
    [Tooltip("The upward force applied when player jumps")]
    [Range(0f, 10f)]
    [SerializeField]
    private float jumpForce;

    private Rigidbody2D playerRB;
    private bool isJumping;
    private bool isFacingRight = true;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal"); //num between -1,1 (-1=left key, 1=right key)
        float xVelocity = horizontalInput * speed;
        playerRB.velocity = new Vector2(xVelocity, playerRB.velocity.y);

        if((!isFacingRight && horizontalInput > 0) || (isFacingRight && horizontalInput < 0))
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        //put physics code in here!
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;

        Vector3 scale = transform.localScale;
        scale.x = isFacingRight ? 1 : -1;
        transform.localScale = scale;

    }
}
