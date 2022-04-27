using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;

     Vector3 moveDirection;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked; 
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        float inputX = Input.GetAxisRaw("Vertical");
        float inputZ = Input.GetAxisRaw("Horizontal");

        moveDirection = transform.forward * inputX + transform.right * inputZ;

        rb.velocity = new Vector3(moveDirection.x * speed, rb.velocity.y, moveDirection.z * speed);
    }
}
