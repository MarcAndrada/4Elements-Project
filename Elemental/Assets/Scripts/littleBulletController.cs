using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class littleBulletController : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private float thurst = 5;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.velocity = transform.up * thurst;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
