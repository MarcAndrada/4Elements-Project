using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindController : MonoBehaviour
{
    public GameObject Tornado;
    public GameObject EarthWall;
    private GameObject ExistTornado;
    private GameObject Wall;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ExistTornado == null)
        {
            ExistTornado = GameObject.FindGameObjectWithTag("Tornado");
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Fire")
        {
            if (ExistTornado == null)
            {
                Instantiate(Tornado, transform.position, Quaternion.identity);
            }
            
            Destroy(collision.gameObject);

            Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Earth")
        {
            Wall = Instantiate(EarthWall, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(Wall, 2.5f);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }


}
