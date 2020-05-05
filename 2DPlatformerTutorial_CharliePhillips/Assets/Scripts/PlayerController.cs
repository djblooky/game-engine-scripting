using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;
using Vector3 = UnityEngine.Vector3;

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
    private bool isFacingRight = true;
    [SerializeField] bool isOnGround = false;

    new private Collider2D collider;
    private RaycastHit2D[] hits = new RaycastHit2D[16]; //can detect up to 16 things hit in one cast
    private float groundDistanceCheck = 0.05f;
    private Animator animator;

    private float horizontalInput = 0;
    private bool isJumpPressed = false;

    void Start()
    {
        playerRB = GetComponent<Rigidbody2D>();
        collider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //key inputs should go in update
        horizontalInput += Input.GetAxis("Horizontal"); //num between -1,1 (-1=left key, 1=right key)
        isJumpPressed = isJumpPressed || Input.GetButtonDown("Jump");
    }

    private void ClearInputs()
    {
        horizontalInput = 0;
        isJumpPressed = false;
    }

    private void FixedUpdate()
    {
        
        float xVelocity = horizontalInput * speed;
        playerRB.velocity = new Vector2(xVelocity, playerRB.velocity.y);

        if ((!isFacingRight && horizontalInput > 0) || (isFacingRight && horizontalInput < 0))
        {
            Flip();
        }

        //jump logic
        //check for landing on the ground
        int numHits = collider.Cast(Vector2.down, hits, groundDistanceCheck);
        isOnGround = numHits > 0; //if on the ground we hit something (more than 0 things)

        //debug
        Vector2 rayStart = new Vector2(collider.bounds.center.x, collider.bounds.min.y);
        Vector2 rayDirection = Vector2.down * groundDistanceCheck;
        Debug.DrawRay(rayStart, rayDirection, Color.red, 1f);

        //jump only if on the ground
        
        if (isJumpPressed && isOnGround)
        {
            playerRB.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        //link variables to the animator
        animator.SetFloat("xSpeed", Mathf.Abs(playerRB.velocity.x));
        animator.SetFloat("yVelocity", playerRB.velocity.y);
        animator.SetBool("isOnGround", isOnGround);

        ClearInputs();
    }

    private void Flip()
    {
        isFacingRight = !isFacingRight;

        Vector3 scale = transform.localScale;
        scale.x = isFacingRight ? 1 : -1;
        transform.localScale = scale;

    }
}
