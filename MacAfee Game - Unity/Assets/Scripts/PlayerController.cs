using UnityEngine;
using System.Collections;
public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpHeight;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;
    public Collider2D PlayerCollider;
    // Use this for initialization
    void Start()
    {
        Debug.Log("Hola");
    }
    void fixedUpdate()
    {
        //grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
    // Update is called once per frame

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Touching a thing");
        if (collision.gameObject.tag == "ground")
        {
            grounded = true;
            Debug.Log("touching ground");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (grounded == true)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            } else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed/5, GetComponent<Rigidbody2D>().velocity.y);
            }
            

        }
        if (Input.GetKey(KeyCode.A))
        {
            if (grounded == true)
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed / 5, GetComponent<Rigidbody2D>().velocity.y);
            }
        }
        grounded = false;
    }
}