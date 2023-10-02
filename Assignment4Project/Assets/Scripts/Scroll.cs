using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    public float Speed = 5f;
    public float LoopPoint = 0f;
    private Vector3 StartingPosition;
    // Start is called before the first frame update
    void Start()
    {
        StartingPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.transform.position.x <= LoopPoint)
        {
            gameObject.transform.position = StartingPosition;
        }
            gameObject.transform.position += Vector3.left * Time.deltaTime * Speed;
        
    }
}
