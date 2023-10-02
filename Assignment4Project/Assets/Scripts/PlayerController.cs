using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Animator animator;
    private Rigidbody rb;
    public float JumpStrength = 25f;
    private bool isGrounded = true;

    // Start is called before the first frame update
    void Start()
    {
        
        animator = GetComponent<Animator>();
        animator.SetBool("Static_b", true);
        animator.SetFloat("Speed_f",1f);

        rb = GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.useGravity = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.1f);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(JumpStrength * Vector3.up,ForceMode.Impulse);
            animator.SetTrigger("Jump_trig");
        }
        if (!isGrounded)
        {
            rb.AddForce(Vector3.down * 9,ForceMode.Acceleration);
        }
    }
}
