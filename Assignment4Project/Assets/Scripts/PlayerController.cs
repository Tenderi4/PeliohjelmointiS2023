using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Animator animator;
    private Rigidbody rb;
    private GroundCheck3D check;

    public float gravity = -9.81f;
    public float gravityScale = 1;
    public float jumpForce = 5;

    private float velocity;

    // Start is called before the first frame update
    void Start()
    {
        
        animator = GetComponent<Animator>();
        animator.SetBool("Static_b", true);
        animator.SetFloat("Speed_f",1f);

        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        rb.useGravity = false;

        check = GetComponent<GroundCheck3D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && check.isGrounded)
        {
            animator.SetTrigger("Jump_trig");
            velocity = jumpForce;
            check.isGrounded = false;
        }

        if (check.isGrounded && velocity <= 0)
        {
            float offset = 1;
            velocity = 0;
            Vector3 closestPoint = check.hit.collider.ClosestPoint(transform.position);
            Vector3 snappedPosition = new Vector3(transform.position.x, closestPoint.y + offset, transform.position.z);

            transform.position = snappedPosition;
        }

    }


    void FixedUpdate()
    {
       velocity += (gravity * gravityScale) * Time.fixedDeltaTime;
       float vPos = rb.position.y + velocity * Time.fixedDeltaTime;
       rb.MovePosition(new Vector3(rb.position.x, vPos, rb.position.z));
    }
    void OnCollisionEnter(Collision collision)
    {
        check.isGrounded = true;
    }
    void OnCollisionExit(Collision collision)
    {
        check.isGrounded = false;
    }
}
