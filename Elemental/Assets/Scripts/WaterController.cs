using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    public Vector3 MaxScale;
    public GameObject Steam;
    public GameObject QuicSand;
    public GameObject Bubbles;

    private Vector3 MinScale = new Vector3(0, 0, 0);
    private float WaitTime = 50;
    private float WaitedTime;
    private float DisappearTime = 3000;
    private bool DestroyWater = false;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = MinScale;
    }

    // Update is called once per frame
    void Update()
    {
        float delta = Time.deltaTime * 1000;
        WaitedTime += delta;
        if (WaitedTime >= WaitTime && MaxScale.x >= transform.localScale.x && MaxScale.y >= transform.localScale.y && MaxScale.z >= transform.localScale.z && !DestroyWater)
        {
            transform.localScale = new Vector3(transform.localScale.x + 0.15f, transform.localScale.y + 0.15f, transform.localScale.z + 0.15f);
            WaitedTime = 0;
        }

        if (WaitedTime >= DisappearTime)
        {
            DestroyWater = true;
        }

        if (WaitedTime >= WaitTime && MinScale.x <= transform.localScale.x && MinScale.y <= transform.localScale.y && MinScale.z <= transform.localScale.z && DestroyWater)
        {
            transform.localScale = new Vector3(transform.localScale.x - 0.1f, transform.localScale.y - 0.1f, transform.localScale.z - 0.1f);
            WaitedTime = 0;

        }

        if (transform.localScale.x < MinScale.x && transform.localScale.y < MinScale.y)
        {
            Destroy(gameObject);
        }

    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fire")
        {
            Instantiate(Steam, transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Earth")
        {

            Instantiate(QuicSand, transform.position, Quaternion.identity);

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Wind")
        {
            Instantiate(Bubbles, new Vector3(transform.position.x + Random.Range(-0.35f, 0.35f) , transform.position.y + Random.Range(-0.35f, 0.35f), transform.position.z), Quaternion.identity);
            Destroy(collision.gameObject);
            Destroy(gameObject);

        }
    }
}
