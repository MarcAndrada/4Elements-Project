using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /*Referencias*/
    private Rigidbody2D rb2d;
    private Animator animator;
    /*Atributos*/
    float speed;
    float life;
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
