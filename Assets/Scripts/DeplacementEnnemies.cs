using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementEnnemies : MonoBehaviour
{

    private Rigidbody2D ennemie;

    private static float VITESSE_ENNEMIE = 1.2f;

    private bool versGauche = true;
    private bool versDroite = false;
    private bool versHaut = false;
    private bool versBas = false;
    private bool vertical = false;


    // Use this for initialization
    void Start()
    {
        ennemie = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (versGauche)
        {
            gameObject.transform.Translate(Vector3.left * VITESSE_ENNEMIE * Time.deltaTime, Space.World);
        }
        else if (versDroite)
        {
            gameObject.transform.Translate(Vector3.right * VITESSE_ENNEMIE * Time.deltaTime, Space.World);
        }
        else if (versHaut)
        {
            gameObject.transform.Translate(Vector3.up * VITESSE_ENNEMIE * Time.deltaTime, Space.World);
        }
        else if (versBas)
        {
            gameObject.transform.Translate(Vector3.down * VITESSE_ENNEMIE * Time.deltaTime, Space.World);
        }

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        
        
        if (collider.gameObject.tag == "caisse" || collider.gameObject.tag == "obstacle")
        {
            if(versGauche && !versDroite && !versHaut && !versBas)
            {
                versGauche = false;
                versDroite = true;
            }else if (!versGauche && versDroite && !versHaut && !versBas)
            {
                versDroite = false;
                versHaut = true;
            }
            else if (!versBas && versHaut && !versGauche && !versDroite)
            {
                versHaut = false;
                versBas = true;
            }
            else if (versBas && !versHaut && !versGauche && !versDroite)
            {
                versBas = false;
                versGauche = true;
            }

        }
    }
}
