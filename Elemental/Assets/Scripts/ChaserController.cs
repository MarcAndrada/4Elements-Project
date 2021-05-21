using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public GameObject player;
    private Animator animator;


    float speed;
    private int upId;
    private int downId;
    private int leftId;
    private int rightId;

    // Start is called before the first frame update
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
    }

    void Start()
    {
        speed = 0.001f;
        upId = Animator.StringToHash("Up");
        downId = Animator.StringToHash("Down");
        leftId = Animator.StringToHash("Left");
        rightId = Animator.StringToHash("Right");
    }

    // Update is called once per frame
    void Update()
    {
       
        float delta = Time.deltaTime * 1000;
        if (player.transform.position.x > this.transform.position.x)
        {
            animator.SetBool(leftId, false);
            animator.SetBool(rightId, true);
            animator.SetBool(upId, false);
            animator.SetBool(downId, false);
        }
        else if (player.transform.position.x < this.transform.position.x)
        {
            animator.SetBool(leftId, true);
            animator.SetBool(rightId, false);
            animator.SetBool(upId, false);
            animator.SetBool(downId, false);
        }
         if (player.transform.position.y > this.transform.position.y)
        {
            animator.SetBool(leftId, false);
            animator.SetBool(rightId, false);
            animator.SetBool(upId, true);
            animator.SetBool(downId, false);
        }
        else if (player.transform.position.y < this.transform.position.y)
        {
            animator.SetBool(leftId, false);
            animator.SetBool(rightId, false);
            animator.SetBool(upId, false);
            animator.SetBool(downId, true);
        }

        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed*delta);


    }

    void FixedUpdate()
    {
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tornado")
        {
            rb2d.velocity = Vector2.zero;
        }
    }
}
