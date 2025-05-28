using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float MoveSpeed; 
    public Transform Orientation;

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

    void Update()
    {
        PlayerInput(); 
    }

    private void PlayerInput()
    {
        HorizontalInput = Input.GetAxisRaw("Horizontal");
        VerticalInput = Input.GetAxisRaw("Vetrical");
    }

    private void MovePlayer()
    {
        //movement Direction
        MoveDirection = Orientation.forward * VerticalInput + Orientation.right * HorizontalInput;

        rb.AddForce(MoveDirection.normalized * MoveSpeed * 10f, ForceMode.Force); 
    }
}
