using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//code by Alex, Mark and Cade
//checked by ryan
public class newplayercontroll : MonoBehaviour
{
    //alex's code
    //speed contorl in the unity panle
    public float speed;
    //call of rigidbody for the player and shortens it to rb
    private Rigidbody2D rb;
    //psh data from x
    private Vector2 MoveVelocity;

    public int clickForce = 500;

    //press play 
    void Start()
    {

        //calls for Rigidbody
        rb = GetComponent<Rigidbody2D>();

    }
    //update once per pixle
    void Update()
    {

        //press a = -1 press d =1
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxis("Vertical"));
        //multiplying x with speed
        MoveVelocity = moveInput.normalized * speed;


        //cade's code

        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var mouseDir = mousePos - gameObject.transform.position;
        mouseDir.z = 0.0f;
        mouseDir = mouseDir.normalized;

        if (Input.GetMouseButtonDown(0))
        {
            rb.AddForce(mouseDir * -clickForce);

        }

        //alex's code
        //pyisics check
        void FixedUpdate()
        {
            //delta time
            rb.MovePosition(rb.position + MoveVelocity * Time.fixedDeltaTime);

        }
    }
}
