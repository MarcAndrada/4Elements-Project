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
    private Animator animator;
    /*Atributos*/

    /*Animaciones*/
    private int upId;
    private int downId;
    private int leftId;
    private int rightId;
    private int idleId;
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update


    void Start()
    {
        speed = 5;
        life = 6;
        lastHP = life;
        upId = Animator.StringToHash("Up");
        downId = Animator.StringToHash("Down");
        leftId = Animator.StringToHash("Left");
        rightId = Animator.StringToHash("Right");
        idleId = Animator.StringToHash("Idle");

    }

    // Update is called once per frame
    void Update()
    {

        if (rb2d.velocity == Vector2.zero)
        {
            animator.SetBool(idleId, true);
            animator.SetBool(leftId, false);
            animator.SetBool(rightId, false);
            animator.SetBool(upId, false);
            animator.SetBool(downId, false);
        }
        else if (rb2d.velocity.x > 0 && rb2d.velocity.y == 0)
        {
            animator.SetBool(idleId, false);
            animator.SetBool(leftId, false);
            animator.SetBool(rightId, true);
            animator.SetBool(upId, false);
            animator.SetBool(downId, false);

        }
        else if (rb2d.velocity.x > 0 && rb2d.velocity.y > 0)
        {
            animator.SetBool(idleId, false);
            animator.SetBool(leftId, false);
            animator.SetBool(rightId, false);
            animator.SetBool(upId, true);
            animator.SetBool(downId, false);
        }
        else if (rb2d.velocity.x < 0 && rb2d.velocity.y < 0)
        {
            animator.SetBool(idleId, false);
            animator.SetBool(leftId, false);
            animator.SetBool(rightId, false);
            animator.SetBool(upId, false);
            animator.SetBool(downId, true);
        }
        else if (rb2d.velocity.x < 0 && rb2d.velocity.y == 0)
        {
            animator.SetBool(idleId, false);
            animator.SetBool(leftId, true);
            animator.SetBool(rightId, false);
            animator.SetBool(upId, false);
            animator.SetBool(downId, false);
        }


        float delta = Time.deltaTime * 1000;
        if (PlayerInput.Vertical > 0)
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
