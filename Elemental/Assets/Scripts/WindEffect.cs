using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindEffect : MonoBehaviour
{

    public float speed;
    private Vector3 dir;

    // Start is called before the first frame update
    void Start()
    {

        if (PlayerInput.ShootRight)
        {
            dir = transform.right;
        }
        else if (PlayerInput.ShootLeft)
        { 
            dir = -transform.right;
        }
        else if (PlayerInput.ShootUp)
        {
            dir = transform.up;
        }
        else if (PlayerInput.ShootDown)
        {
            dir = -transform.up;
        }
    }

    // Update is called once per frame
    void FixedUpdate() { 
        transform.position += dir * speed * Time.deltaTime;

    }
}
