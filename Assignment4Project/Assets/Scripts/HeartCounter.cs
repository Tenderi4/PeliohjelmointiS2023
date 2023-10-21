using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartCounter : MonoBehaviour
{
    // Start is called before the first frame update
    private PlayerController playerController;
    public GameObject HeartSprite;
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
        for (int i = 0; i < playerController.Health; i++)
        {
            GameObject obj = Instantiate(HeartSprite);
            obj.transform.SetParent(transform, false);
            obj.transform.position = transform.position;
            if (i > 0)
            {
                obj.transform.position = transform.GetChild(i-1).transform.position + Vector3.right * 50;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount > playerController.Health)
        {
            for (int i = transform.childCount - 1;i >= playerController.Health ;i--)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
    }

}
