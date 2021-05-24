using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    /*Referencias*/
    private Rigidbody2D rb2d;
    public Image Heart1;
    public Image Heart2;
    public Image Heart3;
    public GameObject HUDTimer;
    private Renderer rend;


    /*Atributos*/
    private float speed;
    [SerializeField]
    private int life;
    private float HeartFill1 = 1;
    private float HeartFill2 = 1;
    private float HeartFill3 = 1;
    private int lastHP;
    private Animator animator;
    private bool inmortal;
    private float inmortaltimer;
    private Color inmortalColor = Color.gray;
    private bool dead;
    private float deadtimer;
    private float gametimer;
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
        rend = GetComponent<Renderer>();
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
        gametimer = 0;
        inmortaltimer = 0;
        inmortal = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (life > 0)
        {
            gametimer += Time.deltaTime;
        }
        //float TimeResult = Mathf.Round(gametimer,2);



        HUDTimer.GetComponent<Text>().text = gametimer.ToString("F2"); ;
        if (life <= 0)
        {
            Destroy(rb2d);
            Destroy(rend);
            dead = true;
            TimeManager.Instance.setNewtime(gametimer);
           
           
        }
        if (dead)
        {
            deadtimer += Time.deltaTime*1000;
            if (deadtimer >= 2000)
            {
                SceneManager.LoadScene("End");
            }

        }

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
        else if (rb2d.velocity.x == 0 && rb2d.velocity.y < 0)
        {
            animator.SetBool(idleId, false);
            animator.SetBool(leftId, false);
            animator.SetBool(rightId, false);
            animator.SetBool(upId, false);
            animator.SetBool(downId, true);
        }
        else if (rb2d.velocity.x == 0 && rb2d.velocity.y > 0)
        {
            animator.SetBool(idleId, false);
            animator.SetBool(leftId, false);
            animator.SetBool(rightId, false);
            animator.SetBool(upId, true);
            animator.SetBool(downId, false);
        }


        float delta = Time.deltaTime * 1000;

        if (inmortal == true)
        {
            gameObject.layer = 11;
            rend.material.color = inmortalColor;
            if (inmortaltimer <= 3000)
            {
                inmortaltimer += delta;
               
            }
            else
            {
                inmortal = false;
                gameObject.layer = 0;
                rend.material.color = Color.white;
                inmortaltimer = 0;
            }
        }
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
        else if (life <= 0)
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet" && !inmortal)
        {
            SoundManager.PlaySound("Damage");
            life--;
            inmortal = true;
            Destroy(collision.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Enemie" && !inmortal)
        {
            SoundManager.PlaySound("Damage");
            life--;
            inmortal = true;
        }
    }
}
