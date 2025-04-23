using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 12f;
    public Animator animator;
    public Rigidbody2D rb;
    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;
    public GameObject playerSprite;

    private bool isGrounded = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>(); 
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetBool("isJumping", true);
        }

        animator.SetBool("isJumping", !isGrounded);

        float move = Input.GetAxis("Horizontal");

        
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);

       
        animator.SetFloat("Speed", Mathf.Abs(move));

        
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetBool("isJumping", true);
            isGrounded = false;
        }

        
        if (move != 0)
        {
            Vector3 scale = playerSprite.transform.localScale;
            scale.x = move > 0 ? 1 : -1;
            playerSprite.transform.localScale = scale;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("isJumping", false);
        }
    }
}
