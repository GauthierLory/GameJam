﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionsBombe : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        print("TRIGGER");
        if (collider.gameObject.tag == "caisse")
        {
            Destroy(collider.gameObject);
        }
    }
}
