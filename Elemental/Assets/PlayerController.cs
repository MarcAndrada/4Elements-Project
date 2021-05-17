using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /*Referencias*/
    private Rigidbody2D rb2d;

    /*Atributos*/
    float speed;


    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update


    void Start()
    {
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        float delta = Time.deltaTime*1000;
        if(PlayerInput.Vertical > 0)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, speed);
        }
        else if (PlayerInput.Vertical < 0)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, -speed);
        }
        else if (PlayerInput.Vertical == 0)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
        }
        if (PlayerInput.Horizontal > 0)
        {
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
        }
        else if (PlayerInput.Horizontal < 0)
        {
            rb2d.velocity = new Vector2(-speed, rb2d.velocity.y);
        }
        else if (PlayerInput.Horizontal == 0)
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }
    }
}
