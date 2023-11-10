
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1.0f;
    public float jumpForce = 5.0f;
    private bool isJumping = false;
    private bool isControlEnabled = true;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Check for left mouse click to disable movement
        if (Input.GetMouseButtonDown(0))
        {
            if( isControlEnabled ) {
                ToggleControl(false);                
            } else {
                ToggleControl(true);
            }
        }

        // Check for right mouse click to enable movement
        if (Input.GetMouseButtonDown(1))
        {
            ToggleControl(true);
        }

        if (isControlEnabled)
        {
            float horizontal = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);

            if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
            {
                rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                isJumping = true;
            }
        }
    }

    private void ToggleControl(bool enable)
    {
        // Perform a raycast to see if we hit this player
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null && hit.collider.gameObject == this.gameObject)
        {
            isControlEnabled = enable;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground") || collision.gameObject.CompareTag("PushableBox"))
        {
            isJumping = false;
        }
    }
}
