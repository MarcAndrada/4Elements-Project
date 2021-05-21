using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class SpawnerController : MonoBehaviour
{
    public GameObject Chaser;
    public GameObject Witch;
    public GameObject Teleporter;
  
    public float timer;
  
    // Start is called before the first frame update
    void Start()
    {
     
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float delta = Time.deltaTime * 1000;
        timer += delta;
        if (timer >= 5000)
        {
            int toSpawn = Random.Range(1, 7);
                if(toSpawn==1|| toSpawn == 3 || toSpawn == 6)
            {
                Instantiate(Chaser,transform);
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
}


