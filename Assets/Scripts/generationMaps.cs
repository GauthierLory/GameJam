using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ce script genere les caisses sur les maps aleatoirement
public class generationMaps : MonoBehaviour
{
    //Recuperation de l'image de la caisse
    public GameObject caisse;

    //Creation d'un tableau sol
    GameObject[] sol;

    //Instantation de la fonction Random
    System.Random rnd;
    int suivant;

    // Use this for initialization
    void Start()
    {
        //Recuperation de tous les gameobjects avec le tag sol
        sol = GameObject.FindGameObjectsWithTag("sol");
        rnd = new System.Random ();
        //de 0 au nombre de sols
        for (int i = 0; i < sol.Length; i++)
        {
            suivant = rnd.Next(2);
            print(suivant);
            if (suivant == 1)
            {
                //Creation des sols
                Instantiate(caisse, new Vector2(sol[i].transform.position.x, sol[i].transform.position.y), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
