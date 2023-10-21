using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Animator animator;
    private Rigidbody rb;
    private ParticleSystem part;
    private SkinnedMeshRenderer render;
    private GameManager gameManager;
    private HeartCounter hearts;
    private bool isGrounded;

    public float gravity = -9.81f;
    public float gravityScale = 1;
    public float jumpForce = 5;
    public int Health = 3;
    public int Score = 0;

    public AudioSource deathSFX;
    public AudioSource music;
    public AudioSource jumpSFX;
    public AudioSource hitSFX;

    // private float velocity;

    // Start is called before the first frame update
    void Start()
    {
        
        animator = GetComponent<Animator>();
        animator.SetBool("Static_b", true);
        animator.SetFloat("Speed_f",1f);

        rb = GetComponent<Rigidbody>();
        //rb.isKinematic = true;
        //rb.useGravity = true;

        // collider = GetComponent<BoxCollider>();
       
        part = GetComponentInChildren<ParticleSystem>();
        render = GetComponentInChildren<SkinnedMeshRenderer>();
        gameManager = FindObjectOfType<GameManager>();
        hearts = FindObjectOfType<HeartCounter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            animator.SetTrigger("Jump_trig");
            rb.AddForce(Vector3.up * jumpForce,ForceMode.Impulse);
            isGrounded = false;
            jumpSFX.Play();
        }
        if (!isGrounded && Time.timeScale != 0.0f) 
        { 
            rb.AddForce(Vector3.up * gravity * gravityScale, ForceMode.Force); 
        }
        

        //if (check.isGrounded && velocity <= 0)
        //{
        //    float offset = 1;
        //    velocity = 0;
        //    Vector3 closestPoint = check.hit.collider.ClosestPoint(transform.position);
        //    Vector3 snappedPosition = new Vector3(transform.position.x, closestPoint.y + offset, transform.position.z);

        // //   transform.position = snappedPosition;
        //}

    }


    void FixedUpdate()
    {
        //velocity += (gravity * gravityScale) * Time.fixedDeltaTime;
        //float vPos = rb.position.y + velocity * Time.fixedDeltaTime;
        //rb.MovePosition(new Vector3(rb.position.x, vPos, rb.position.z));
    }
    void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }
    void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        hitSFX.Play();
        if (Health <= 0)
        {
            part.Play();
            deathSFX.Play();
            music.Pause();
            render.transform.gameObject.SetActive(false);
            gameManager.GameOver();
        }
    }

    public void AddScore(int score)
    {
        Score += score;
    }
}
