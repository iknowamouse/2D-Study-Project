using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce = 220f;
    [Range(0, 1)] [SerializeField] private float crouchSpeed = .36f;
    [Range(0, .3f)] [SerializeField] private float movementSmoothing = .05f;
    [SerializeField] private bool airControl = false;
    [SerializeField] private LayerMask whatIsGround;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform ceilingCheck;
    [SerializeField] private Collider2D crouchDisableCollider;
    //[SerializeField] public Collider2D collisionDisableCollider;
    // public Transform life;

    

    const float groundedRadius = .2f;
    private bool grounded;
    const float ceilingRadius = .2f;
    private Rigidbody2D m_Rigidbody2D;
    private bool facingRight = true;
    private Vector3 velocity = Vector3.zero;

    public float playerLife;
    private bool dead = false;
    private bool hurt;

    [Header("Events")]
    [Space]

    public UnityEvent OnLandEvent;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    public BoolEvent OnCrouchEvent;
    private bool m_wasCrouching = false;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fall")
        {   playerLife--;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            
            
            Debug.Log(playerLife);
               
            
        }
    }

    private void Awake()
    {
        m_Rigidbody2D = GetComponent<Rigidbody2D>();

        if (OnLandEvent == null)
            OnLandEvent = new UnityEvent();

        if (OnCrouchEvent == null)
            OnCrouchEvent = new BoolEvent();
    }

    private void FixedUpdate()
    {
        bool wasGrounded = grounded;
        grounded = false;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.position, groundedRadius, whatIsGround);
        for (int i = 0; i < colliders.Length; i++)
        {
            if (colliders[i].gameObject != gameObject)
                grounded = true;
            if (!wasGrounded)
                OnLandEvent.Invoke();
        }

    }

    private void Update()
    {
        if (!hurt)
        {
            playerLife = 6;
        }

        if (playerLife <= 0)
        {
            dead = true;
            SceneManager.LoadScene(1);
        }
    }

    public void Move(float move, bool crouch, bool jump)
    {
        if (!crouch)
        {
            if (Physics2D.OverlapCircle(ceilingCheck.position, ceilingRadius, whatIsGround))
            {
                crouch = true;
            }
        }
      if (grounded || airControl)
        {
            if(crouch)
            {
                jump = false;

                if (!m_wasCrouching)
                {
                    
                    m_wasCrouching = true;
                    OnCrouchEvent.Invoke(true);
                }

                move *= crouchSpeed;

                if (crouchDisableCollider != null)
                    crouchDisableCollider.enabled = false;
            }
            else
            {
                if (crouchDisableCollider != null)
                    crouchDisableCollider.enabled = true;

                if (m_wasCrouching)
                {
                    m_wasCrouching = false;
                    OnCrouchEvent.Invoke(false);
                }
            }
       
        Vector3 targetVelocity = new Vector2(move * 19f, m_Rigidbody2D.velocity.y);

            m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref velocity, movementSmoothing);

        if (move > 0 && !facingRight)
        {
            Flip();
        }
        else if (move < 0 && facingRight)      
        {
            Flip();
        }
       }
      if (grounded && jump)
        {
            grounded = false;
            m_Rigidbody2D.AddForce(new Vector2(0f, jumpForce));
        }
       
        
    }

    private void Flip()
    {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

    }

    

}
