using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Cursor.visible = false;

        transform.position = new Vector3 (Player.transform.position.x, Player.transform.position.y, transform.position.z);
    }
}
