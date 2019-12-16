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
<<<<<<< Updated upstream
=======
    public Rigidbody2D rb;
    public int clickForce = 500;
    public float coolDown;
    public float speedLimit;
>>>>>>> Stashed changes
    // Use this for initialization
    void Start()
    {
        grounded = true;
        distToGround = PlayerCollider.bounds.extents.y;
    }
    void fixedUpdate()
    {

    }
    // Update is called once per frame

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
            Debug.Log("Grounded");
            grounded = true;
        }
        else
        {
            grounded = false;
        }
    }

    void Update()
    {
<<<<<<< Updated upstream
        
=======
        if(coolDown > 0)
        {
            coolDown = coolDown - 1*Time.deltaTime;
        }
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var mouseDir = mousePos - gameObject.transform.position;
        mouseDir.z = 0.0f;
        mouseDir = mouseDir.normalized;

        if (Input.GetMouseButtonDown(0)&&coolDown <= 0)
        {
            rb.AddForce(mouseDir * -clickForce);
            coolDown = 1.3f;
        }

>>>>>>> Stashed changes
        if (Input.GetKeyDown(KeyCode.W) && grounded == true)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, jumpHeight);
        }
        if (Input.GetKey(KeyCode.D))
        {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(moveSpeed, GetComponent<Rigidbody2D>().velocity.y);    
            rb.AddForce(new Vector2(moveSpeed, 0), ForceMode2D.Impulse);
        }
        if (Input.GetKey(KeyCode.A))
        {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
            rb.AddForce(new Vector2(-moveSpeed, 0), ForceMode2D.Impulse);
        }
        rb.velocity = Vector2.ClampMagnitude(rb.velocity, speedLimit);
    }
}