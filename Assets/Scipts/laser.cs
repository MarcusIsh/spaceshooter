﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
    [SerializeField]
    private float _speed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //move up at 10 speed,
        transform.Translate(Vector3.up * _speed * Time.deltaTime);

        float yPos = transform.position.y;

        if (yPos > 5.5f)
        {
            Destroy(this.gameObject);
        }
    }
}
