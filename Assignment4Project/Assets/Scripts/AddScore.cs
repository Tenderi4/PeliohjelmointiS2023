using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScore : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerController playerController;
    public int scoreValue = 1;
    void Awake()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
     
    }

    private void OnTriggerEnter(Collider other)
    {
        playerController.AddScore(scoreValue); 
    }
}
