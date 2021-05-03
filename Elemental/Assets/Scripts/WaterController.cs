using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    public Vector3 MaxScale;
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
            transform.localScale = new Vector3(transform.localScale.x + 0.2f, transform.localScale.y + 0.2f, transform.localScale.z + 0.2f);
            WaitedTime = 0;
        }

        if (WaitedTime >= DisappearTime)
        {
            DestroyWater = true;
        }

        if (WaitedTime >= WaitTime && MinScale.x <= transform.localScale.x && MinScale.y <= transform.localScale.y && MinScale.z <= transform.localScale.z && DestroyWater)
        {
            transform.localScale = new Vector3(transform.localScale.x - 0.2f, transform.localScale.y - 0.2f, transform.localScale.z - 0.2f);
            WaitedTime = 0;

        }

        if (transform.localScale.x < MinScale.x && transform.localScale.y < MinScale.y)
        {
            Destroy(gameObject);
        }

    }
}
