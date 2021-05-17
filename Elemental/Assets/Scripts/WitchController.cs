using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public GameObject player;
    public GameObject bullet;


    private float speed;
    public float radius;
    private float timer;
    public float bulletSpeed;
    // Start is called before the first frame update
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        speed = 0.001f;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float delta = Time.deltaTime * 1000;
        if(timer > 0)
        {
            timer=timer - delta;
        }
        if(!checkPlayerPosition())
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * delta);

        else
        {
            if (timer <= 0)
            {
                shootToPosition(player.transform.position);
                timer = 5000;
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
}