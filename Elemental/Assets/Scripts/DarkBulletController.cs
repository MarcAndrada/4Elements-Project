using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkBulletController : MonoBehaviour
{

    public GameObject bullets;
    float timer;

    private Rigidbody2D _rb2d;
    public Rigidbody2D rb2d
    {
        get
        {
            _rb2d = _rb2d ?? GetComponent<Rigidbody2D>();
            return _rb2d;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        timer = 3000;
    }

    // Update is called once per frame
    void Update()
    {
        float delta = Time.deltaTime * 1000;

        timer -= delta;
        if (timer <= 0)
        {
            GameObject bullet1 = Instantiate(bullets, transform.position , Quaternion.Euler(0, 0, 0));
            GameObject bullet2 = Instantiate(bullets, transform.position , Quaternion.Euler(0, 0, 45));
            GameObject bullet3 = Instantiate(bullets, transform.position , Quaternion.Euler(0, 0, 90));
            GameObject bullet4 = Instantiate(bullets, transform.position , Quaternion.Euler(0, 0, 135));
            GameObject bullet5 = Instantiate(bullets, transform.position , Quaternion.Euler(0, 0, 180));
            GameObject bullet6 = Instantiate(bullets, transform.position , Quaternion.Euler(0, 0, 225));
            GameObject bullet7 = Instantiate(bullets, transform.position , Quaternion.Euler(0, 0, 270));
            GameObject bullet8 = Instantiate(bullets, transform.position , Quaternion.Euler(0, 0, 315));
            GameObject bullet9 = Instantiate(bullets, transform.position , Quaternion.Euler(0, 0, 360));
            Destroy(gameObject);
        }
    }
    public void setVelocity(Vector2 _velocity)
    {


        rb2d.velocity = _velocity;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Map"))
        {
            Destroy(gameObject);
        }
    }

}