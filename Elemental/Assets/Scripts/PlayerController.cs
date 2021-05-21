using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    /*Referencias*/
    private Rigidbody2D rb2d;
    public Image Heart1;
    public Image Heart2;
    public Image Heart3;


    /*Atributos*/
    private float speed;
    private int life;
    private float HeartFill1 = 1;
    private float HeartFill2 = 1;
    private float HeartFill3 = 1;
    private int lastHP;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update


    void Start()
    {
        speed = 5;
        life = 6;
        lastHP = life;
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


        if (life >= 6)
        {
            HeartFill1 = 1;
            HeartFill2 = 1;
            HeartFill3 = 1;

        }
        else if (life == 5)
        {
            HeartFill1 = 0.5f;
            HeartFill2 = 1;
            HeartFill3 = 1;

        }
        else if (life == 4)
        {
            HeartFill1 = 0;
            HeartFill2 = 1;
            HeartFill3 = 1;

        }
        else if (life == 3)
        {
            HeartFill1 = 0;
            HeartFill2 = 0.5f;
            HeartFill3 = 1;
        }
        else if (life == 2)
        {
            HeartFill1 = 0;
            HeartFill2 = 0;
            HeartFill3 = 1;
        }
        else if (life == 1)
        {
            HeartFill1 = 0;
            HeartFill2 = 0;
            HeartFill3 = 0.5f;
        }
        else if (life == 0)
        {
            HeartFill1 = 0;
            HeartFill2 = 0;
            HeartFill3 = 0;
        }


        if (lastHP != life)
        {
            Heart1.GetComponent<Image>().fillAmount = HeartFill1;
            Heart2.GetComponent<Image>().fillAmount = HeartFill2;
            Heart3.GetComponent<Image>().fillAmount = HeartFill3;
            lastHP = life;
        }

    }
}
