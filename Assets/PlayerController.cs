using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float attackForce = 5f;
    private bool isGrounded;
    public GameObject groundCheck;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        
            Crouch();
        AirAttack();

        isGrounded = Physics.Raycast(transform.position, Vector3.down, transform.localScale.y * 0.2f);
        
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 NoMovement = new Vector2(0f, 0f);

        float moveHorizontal = Input.GetAxis("Horizontal");
        if (moveHorizontal > 0)
        {
            {
                rb.linearVelocity = new Vector2(moveSpeed, rb.linearVelocity.y);

            }
        }
        if (moveHorizontal < 0)
        {
            rb.linearVelocity = new Vector2(-moveSpeed, rb.linearVelocity.y);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded == true)
            {
                rb.AddForce(new Vector3(0, jumpForce, 0));
                Debug.Log("skok");
            }
        }
    }
 
    private void Crouch()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            gameObject.transform.localScale = new Vector3(0.87f, 0.87f, 0.87f);
        }
        else
        {
            gameObject.transform.localScale = Vector3.one;
        }
    }

    
    public void AirAttack()
    {
        if(!isGrounded && Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log("atak");
            rb.AddForce(new Vector3(0, -attackForce, 0));
        }
    }
}
