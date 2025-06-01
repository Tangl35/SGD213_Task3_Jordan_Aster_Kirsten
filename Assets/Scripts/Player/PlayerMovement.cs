using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed; 
    public Transform Orientation;

    public float Drag;

    float VerticalInput;
    float HorizontalInput;

    Vector3 MoveDirection;

    Rigidbody rb; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void FixedUpdate()
    {
        MovePlayer(); 
    }
    void Update()
    { 
        SpeedControl();
        rb.drag = Drag;
    }

    private void MovePlayer()
    {
        //movement Direction
        MoveDirection = Orientation.forward * VerticalInput + Orientation.right * HorizontalInput;

        rb.AddForce(MoveDirection.normalized * MoveSpeed * 10f, ForceMode.Force); 
    }
    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //velocity limit
        if (flatVel.magnitude > MoveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * MoveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }

    }
 

}
