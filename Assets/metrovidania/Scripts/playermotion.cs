using UnityEngine;

public class playermotion : MonoBehaviour
{
    [Header("Horizontal Movement Settings")]
    [SerializeField] private float walkSpeed;

    [Header("Ground Check Settings")]
    [SerializeField] private float jumpForce = 45;
    [SerializeField] private Transform groundCheckPoint;
    [SerializeField] private float groundCheckY = 0.2f;// dist ray travels
    [SerializeField] private float groundCheckX = 0.2f;// using to raycast from edge also
    [SerializeField] private LayerMask whatIsGround;

    private Rigidbody2D rb;
    private float xAxis;

    Animator anim;

    public static playermotion Instance;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        anim = GetComponent<Animator>();
    }

    void Update()
    {
        GetInputs();
        Move();
        Jump();
        Flip();
    } 

    void GetInputs()
    {
        xAxis = Input.GetAxis("Horizontal");
    }

    void Move()
    {
        rb.linearVelocity = new Vector2(walkSpeed * xAxis, rb.linearVelocity.y);
        anim.SetBool("Walking", rb.linearVelocity.x !=0 && grounded());
    }

    public bool grounded()
    {
        if(Physics2D.Raycast(groundCheckPoint.position, Vector2.down, groundCheckY, whatIsGround) 
            || Physics2D.Raycast(groundCheckPoint.position + new Vector3(groundCheckX,0,0), Vector2.down, groundCheckY, whatIsGround)
            || Physics2D.Raycast(groundCheckPoint.position + new Vector3(-groundCheckX,0,0), Vector2.down, groundCheckY, whatIsGround)){
            return true;
        }
        else
        {
            return false;
        }
    }

    void Jump()
    {
        if (Input.GetButtonUp("Jump") && rb.linearVelocity.y>0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0);
        }
        if (Input.GetButtonDown("Jump") && grounded())
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce);
        }
        anim.SetBool("Jumping", !grounded());// syntax:: animator.SetBool("ParameterName", value);

    }

    void Flip()
    {
        if ( xAxis > 0)
        {
            transform.localScale = new Vector2(1*3, transform.localScale.y); 
        }
        else if ( xAxis < 0)
        {
            transform.localScale = new Vector2(-1*3, transform.localScale.y);
        }
    }
}
