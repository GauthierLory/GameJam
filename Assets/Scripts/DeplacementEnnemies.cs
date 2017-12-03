using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementEnnemies : MonoBehaviour
{

    public Rigidbody2D ennemie;

    // Use this for initialization
    void Start()
    {
        ennemie = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ennemie.transform.Translate(Vector3.left * 0 * Time.deltaTime, Space.World);
    }
}
