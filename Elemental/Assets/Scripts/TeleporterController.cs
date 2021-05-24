using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public GameObject player;
    public GameObject bullet;
    private Animator animator;
    private Renderer rend;

    public float timerTeleport;
    public float timerShoot;
    public float bulletSpeed;
    private bool toTeleport;
    private float timer;


    private bool stun;
    private float stuntimer;
    private bool onfire;
    private float onfiretimer;
    private float life;
    private int firecounter;
    private bool winded;
    private float windedtimer;

    private Color burning = Color.red;
    private Color slow = Color.blue;
    private Color stuned = Color.green;


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
        rend = GetComponent<Renderer>();
    }

    void Start()
    {
        timerTeleport = 0;
        timerShoot = 3000;
        toTeleport = true;
        bulletSpeed = 1f;
        windedtimer = 0;
        winded = false;
       
        timer = 0;
        life = 8;
        stuntimer = 0;
        stun = false;
        onfiretimer = 0;
        onfire = false;
       
        upId = Animator.StringToHash("Up");
        downId = Animator.StringToHash("Down");
        leftId = Animator.StringToHash("Left");
        rightId = Animator.StringToHash("Right");
    }

    // Update is called once per frame
    void Update()
    {
        float delta = Time.deltaTime * 1000;

        if(player.transform.position.x  > this.transform.position.x +2)
        {
            animator.SetTrigger(rightId);
        }

        if (player.transform.position.x < this.transform.position.x - 2)
        {
            animator.SetTrigger(leftId);
        }

         if (player.transform.position.y < this.transform.position.y)
        {
            animator.SetTrigger(downId);
        }

        if (player.transform.position.y > this.transform.position.y)
        {
            animator.SetTrigger(upId);
        }


        if (winded)
        {
            if (windedtimer <= 1500)
            {
                windedtimer += delta;
            }
            else
            {
                rb2d.velocity = Vector2.zero;
                windedtimer = 0;
                winded = false;
            }
        }
        if (life <= 0)
        {

            Destroy(gameObject);
        }



        if (onfire)
        {
            rend.material.color = burning;
            onfiretimer += delta;
            if (firecounter <= 3)
            {
                if (onfiretimer >= 1000)
                {
                    firecounter++;
                    life--;
                    onfiretimer = 0;
                }
            }
            else
            {
                rend.material.color = Color.white;
                firecounter = 0;
                onfire = false;
            }

        }
        if (!stun)
        {
            if (toTeleport)
            {
                timerTeleport -= delta;
                if (timerTeleport <= 0)
                {
                    rb2d.transform.position = new Vector2(player.transform.position.x - 1, player.transform.position.y);
                    toTeleport = false;
                    timerTeleport = 5000;
                }
            }
            else
            {
                timerShoot -= delta;
                if (timerShoot <= 0)
                {
                    timerShoot = 3000;
                    shootToPosition(player.transform.position);
                    toTeleport = true;

                }
            }
        }
        else
        {
            stuntimer += delta;
            if (stuntimer >= 3000)
            {
                stun = false;
                stuntimer = 0;
                rend.material.color = Color.white;
            }
        }
    }
    private void shootToPosition(Vector2 target)
    {
        Vector2 v = target - (Vector2)this.transform.position;

        GameObject inst = Instantiate(bullet, this.transform.position, bullet.transform.rotation);
        DarkBulletController bc = inst.GetComponent<DarkBulletController>();
        bc.setVelocity(v.normalized * this.bulletSpeed);
        SoundManager.PlaySound("Teleporter");
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Water")
        {
            
            rend.material.color = slow;
        }
        if (collision.gameObject.tag == "QuickSand")
        {
            
            rend.material.color = slow;
        }
        if (collision.gameObject.tag == "Steam")
        {
            
            onfire = true;
            rend.material.color = slow;

        }
        if (collision.gameObject.tag == "Tornado")
        {
            onfire = true;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bubbles")
        {
            stun = true;
            rend.material.color = stuned;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Lava")
        {

            life = 0;
        }
        if (collision.gameObject.tag == "Fire")
        {
            onfire = true;

        }

        if (collision.gameObject.tag == "Earth")
        {

            life = life - 2;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "WindUp")
        {
            winded = true;
            Vector2 damagedirection = this.transform.position - collision.transform.position;
            if (damagedirection.y > 0)
            {
                rb2d.velocity = new Vector2(0, 0);
                rb2d.AddForce(new Vector2(0, 300), ForceMode2D.Impulse);
            }
            else
            {
                rb2d.velocity = new Vector2(0, 0);
                rb2d.AddForce(new Vector2(0, -300), ForceMode2D.Impulse);
            }
        }
        if (collision.gameObject.tag == "Wind")
        {
            winded = true;

            Vector2 damagedirection = this.transform.position - collision.transform.position;
            if (damagedirection.x > 0)
            {
                rb2d.velocity = new Vector2(0, 0);
                rb2d.AddForce(new Vector2(300, 0), ForceMode2D.Impulse);
            }
            else
            {
                rb2d.velocity = new Vector2(0, 0);
                rb2d.AddForce(new Vector2(-300, 0), ForceMode2D.Impulse);
            }
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Tornado")
        {
            rb2d.velocity = Vector2.zero;
        }
        if (collision.gameObject.tag == "Water")
        {
            
            rend.material.color = Color.white;
        }
        if (collision.gameObject.tag == "QuickSand")
        {
            
            rend.material.color = Color.white;
        }
        if (collision.gameObject.tag == "Steam")
        {
            
            rend.material.color = Color.white;
        }
    }
}
