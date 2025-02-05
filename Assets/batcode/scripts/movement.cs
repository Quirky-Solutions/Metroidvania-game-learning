using UnityEngine;

public class movement : MonoBehaviour
{
    public float speed = 5f; // Speed of movement
    private Rigidbody2D rb;
    private float moveInput;

    void Start()
    {
       rb = GetComponent<Rigidbody2D>(); // Get Rigidbody2D component
    }

    void Update()
    {
        moveInput = Input.GetAxis("Horizontal"); // Get input (A/D or Left/Right Arrow)

        // Flip character based on direction
        if (moveInput > 0)
            transform.localScale = new Vector3(1, 1, 1); // Face Right
        else if (moveInput < 0)
            transform.localScale = new Vector3(-1, 1, 1); // Face Left
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(moveInput * speed, rb.linearVelocity.y); // Apply movement
    }
}
