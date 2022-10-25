using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField] float speed = 1200;
    [SerializeField] float jumpForce = 10;
    [SerializeField] Rigidbody rb;

    void Start()
    {
        
    }

    
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }

        float x = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(x * speed, rb.velocity.y, 0);
    }
}
