using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    private Animator animator;
    static readonly int speedParameterHash = Animator.StringToHash("Speed_f");

    public float Speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>(); 
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"));
        Vector3 motion = move * Time.deltaTime * Speed;
        characterController.Move(motion);
        animator.SetFloat(speedParameterHash,characterController.velocity.magnitude);
    }
}
