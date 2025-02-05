using UnityEngine;

public class playermotion : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float walkSpeed;
    private float xAxis;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        GetInputs();
        Move();
    }

    void GetInputs()
    {
        xAxis = Input.GetAxis("Horizontal");
    }

    void Move()
    {
        rb.linearVelocity = new Vector2(walkSpeed * xAxis, rb.linearVelocity.y);
    }
}
