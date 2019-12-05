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
    public float distToGround;
    // Use this for initialization
    void Start()
    {
        Debug.Log("Hola");
        distToGround = PlayerCollider.bounds.extents.y;
    }
    void fixedUpdate()
    {

    }
    // Update is called once per frame

    /*
        void OnCollisionStay(Collision collision)
        {
            Debug.Log("Touching a thing");
            if (collision.gameObject.tag == "ground")
            {
                grounded = true;
                Debug.Log("touching ground");
            }
        }

        public bool IsGrounded()
        {
            return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
        }
        */
    void OnCollisionStay2D(Collision2D collider)
    {
        CheckIfGrounded();
    }

    void OnCollisionExit2D(Collision2D collider)
    {
        grounded = false;
    }

    private void CheckIfGrounded()
    {
        RaycastHit2D[] hits;

        //We raycast down 1 pixel from this position to check for a collider
        Vector2 positionToCheck = transform.position;
        hits = Physics2D.RaycastAll(positionToCheck, new Vector2(0, -1), 0.01f);

        //if a collider was hit, we are grounded
        if (hits.Length > 0)
        {
            grounded = true;
        }
    }

    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.W) && grounded == true)
        {
            Debug.Log("jump");
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
        }
        if (Input.GetKey(KeyCode.D))
        {
            Debug.Log(grounded);
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