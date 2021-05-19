using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public GameObject player;
    public GameObject bullet;

    public float timerTeleport;
    public float timerShoot;
    public float bulletSpeed;
    private bool toTeleport;
    // Start is called before the first frame update
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Start()
    {
        timerTeleport = 0;
        timerShoot = 3000;
        toTeleport = true;
        bulletSpeed = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        float delta = Time.deltaTime * 1000;
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
    private void shootToPosition(Vector2 target)
    {
        Vector2 v = target - (Vector2)this.transform.position;

        GameObject inst = Instantiate(bullet, this.transform.position, bullet.transform.rotation);
        DarkBulletController bc = inst.GetComponent<DarkBulletController>();
        bc.setVelocity(v.normalized * this.bulletSpeed);
    }
}
