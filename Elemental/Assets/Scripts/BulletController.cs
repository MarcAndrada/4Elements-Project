﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BulletController : MonoBehaviour
{

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
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void setVelocity(Vector2 _velocity)
    {


        rb2d.velocity = _velocity;

    }
 
}