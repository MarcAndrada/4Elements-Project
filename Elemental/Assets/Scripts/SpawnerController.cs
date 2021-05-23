using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class SpawnerController : MonoBehaviour
{
    public GameObject Chaser;
    public GameObject Witch;
    public GameObject Teleporter;
  
    public float timer;
    private float gametimer;
  
    // Start is called before the first frame update
    void Start()
    {
        gametimer = 0;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float delta = Time.deltaTime * 1000;
        gametimer += delta;
        timer += delta;

        if(gametimer <= 30000)
        {


            if (timer >= 10000)
            {
                int toSpawn = Random.Range(1, 7);
                if (toSpawn == 1 || toSpawn == 3 || toSpawn == 6)
                {
                    Instantiate(Chaser, transform);
                }
                else if (toSpawn == 2 || toSpawn == 4)
                {
                    Instantiate(Witch, transform);
                }
                else if (toSpawn == 5 || toSpawn == 7)
                {
                    Instantiate(Teleporter, transform);
                }
                timer = 0;
            }

        }
        else if   (gametimer <= 60000)
            {


                if (timer >= 10000)
                {
                    int toSpawn = Random.Range(1, 7);
                    if (toSpawn == 1 || toSpawn == 3 || toSpawn == 6)
                    {
                        Instantiate(Chaser, transform);
                    Instantiate(Witch, transform);
                }
                    else if (toSpawn == 2 || toSpawn == 4)
                    {
                        Instantiate(Witch, transform);
                        Instantiate(Teleporter, transform);
                }
                    else if (toSpawn == 5 || toSpawn == 7)
                    {
                        Instantiate(Teleporter, transform);
                    }
                    timer = 0;
                }

            }
        else if (gametimer <= 90000)
        {


            if (timer >= 10000)
            {
                int toSpawn = Random.Range(1, 7);
                if (toSpawn == 1 || toSpawn == 3 || toSpawn == 6)
                {
                    Instantiate(Chaser, transform);
                    Instantiate(Witch, transform);
                }
                else if (toSpawn == 2 || toSpawn == 4)
                {
                    Instantiate(Witch, transform);
                    Instantiate(Teleporter, transform);
                    Instantiate(Chaser, transform);
                }
                else if (toSpawn == 5 || toSpawn == 7)
                {
                    Instantiate(Teleporter, transform);
                    Instantiate(Chaser, transform);
                }
                timer = 0;
            }

        }
        else if (gametimer <= 120000)
        {


            if (timer >= 10000)
            {
                int toSpawn = Random.Range(1, 7);
                if (toSpawn == 1 || toSpawn == 3 || toSpawn == 6)
                {
                    Instantiate(Chaser, transform);
                    Instantiate(Chaser, transform);
                    Instantiate(Witch, transform);
                }
                else if (toSpawn == 2 || toSpawn == 4)
                {
                    Instantiate(Witch, transform);
                    Instantiate(Teleporter, transform);
                    Instantiate(Chaser, transform);
                }
                else if (toSpawn == 5 || toSpawn == 7)
                {
                    Instantiate(Teleporter, transform);
                    Instantiate(Chaser, transform);
                    Instantiate(Witch, transform);
                }
                timer = 0;
            }

        }
    }
}


