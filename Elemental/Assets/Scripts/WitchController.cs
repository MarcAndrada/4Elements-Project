using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public GameObject player;
    public GameObject bullet;
    private Animator animator;
    private Renderer rend;

    private float speed;
    public float radius;
    public float timer;
    public float bulletSpeed;


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
    private int idleId;


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
        windedtimer = 0;
        winded = false;
        speed = 0.001f;
        timer = 0;
        life = 8;
        stuntimer = 0;
        stun = false;
        onfiretimer = 0;
        onfire = false;
        speed = 0.001f;
        upId = Animator.StringToHash("Up");
        downId = Animator.StringToHash("Down");
        idleId = Animator.StringToHash("Idle");

    }

    // Update is called once per frame
    void Update()
    {
     
          

        if (player.transform.position.y < this.transform.position.y)
        {
            animator.SetBool(downId, true);
            animator.SetBool(upId, false);
            animator.SetBool(idleId, false);
        }
        if (player.transform.position.y > this.transform.position.y)
        {
            animator.SetBool(downId, false);
            animator.SetBool(upId, true);
            animator.SetBool(idleId, false);
        }
 
        float delta = Time.deltaTime * 1000;
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
            if (timer >= 0)
            {
                timer -= delta;
            }
                if (!checkPlayerPosition())
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * delta);

            else
            {
                animator.SetBool(downId, false);
                animator.SetBool(upId, false);
                animator.SetBool(idleId, true);
                if (timer <= 0)
                {
                
                    shootToPosition(player.transform.position);
                    timer = 5000;
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

    private bool checkPlayerPosition()
    {

        return Vector2.Distance(this.transform.position, player.transform.position) <= this.radius;


    }

    private void shootToPosition(Vector2 target)
    {
        Vector2 v = target - (Vector2)this.transform.position;

        GameObject inst = Instantiate(bullet, this.transform.position , bullet.transform.rotation);
        BulletController bc = inst.GetComponent<BulletController>();
        bc.setVelocity(v.normalized * this.bulletSpeed);
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, radius);
    }


    void FixedUpdate()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Water")
        {
            speed = 0.0005f;
            rend.material.color = slow;
        }
        if (collision.gameObject.tag == "QuickSand")
        {
            speed = 0.0001f;
            rend.material.color = slow;
        }
        if (collision.gameObject.tag == "Steam")
        {
            speed = 0.0005f;
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
            speed = 0.001f;
            rend.material.color = Color.white;
        }
        if (collision.gameObject.tag == "QuickSand")
        {
            speed = 0.001f;
            rend.material.color = Color.white;
        }
        if (collision.gameObject.tag == "Steam")
        {
            speed = 0.001f;
            rend.material.color = Color.white;
        }
    }
}

