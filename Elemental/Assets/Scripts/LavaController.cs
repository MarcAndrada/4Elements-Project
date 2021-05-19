using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaController : MonoBehaviour
{
    private Vector3 MinScale = new Vector3(0, 0, 0);
    private float WaitTime = 6000;
    private float WaitedTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float delta = Time.deltaTime * 1000;
        WaitedTime += delta;

        /* if (WaitedTime >= WaitTime && MinScale.x <= transform.localScale.x && MinScale.y <= transform.localScale.y)
         {
             transform.localScale = new Vector3(transform.localScale.x - 0.005f, transform.localScale.y - 0.005f, transform.localScale.z );
             WaitedTime = 0;

         }

         if (transform.localScale.x < MinScale.x && transform.localScale.y < MinScale.y)
         {
             Destroy(gameObject);
         }
        */
        if (WaitedTime >= WaitTime)
        {
            Destroy(gameObject);
        }

    }
}