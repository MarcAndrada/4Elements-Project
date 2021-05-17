using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public GameObject player;

    float speed;
    // Start is called before the first frame update
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        speed = 0.001f;
    }

    // Update is called once per frame
    void Update()
    {
        float delta = Time.deltaTime * 1000;

        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed*delta);
    }

    void FixedUpdate()
    {
        
    }
}
