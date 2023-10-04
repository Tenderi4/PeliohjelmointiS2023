using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck3D : MonoBehaviour
{
    public float distanceToCheck = 2f;
    public bool isGrounded;
    public RaycastHit hit;
    private BoxCollider collider;
    void Start()
    {
        collider = GetComponent<BoxCollider>();   
    }
    void Update()
    {
        //Ray ray = new Ray(transform.position, Vector3.down);
        //isGrounded = Physics.Raycast(ray, out hit, distanceToCheck);
    }

    void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }
    void OnCollisionExit(Collision collision)
    {
        isGrounded = false;
    }
}
