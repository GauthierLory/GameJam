using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementEnnemies : MonoBehaviour
{

    private Rigidbody2D ennemie;

    private static float VITESSE_ENNEMIE = 3.0f;

    // Use this for initialization
    void Start()
    {
        ennemie = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        ennemie.transform.Translate(Vector3.left * VITESSE_ENNEMIE * Time.deltaTime, Space.World);
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
