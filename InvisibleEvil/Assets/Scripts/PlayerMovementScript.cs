using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField] private float hp = 100;
    [SerializeField] private float speed = 1200;
    [SerializeField] private float jumpForce = 10;
    [SerializeField] private float groundDistance = 4.1f;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundMask;

    private float CandyCount;
    private bool touchingFloor;

    void Update()
    {
        touchingFloor = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (Input.GetButtonDown("Jump") && touchingFloor) 
        {
            rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        }

        float x = Input.GetAxis("Horizontal");
        rb.velocity = new Vector3(x * speed, rb.velocity.y, 0);

        if (x < 0)
        {
            transform.rotation = new Quaternion(0, 180, 0, 0);
        }
        else if(x>0)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            ModifyHp(-other.GetComponent<Enemy>().GetDamage());
        }
        if (other.tag == "Candy")
        {
            CandyCount += 1;
        }
    }

    private void ModifyHp(float value)
    {
        hp += value;
    }
}
