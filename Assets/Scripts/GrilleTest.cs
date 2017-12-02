using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrilleTest : MonoBehaviour
{


    // Use this for initialization
    void Start()
    {

        List<GameObject> items = new List<GameObject>(GameObject.FindGameObjectsWithTag("sol"));
        //items.AddRange(new List<GameObject>(GameObject.FindGameObjectsWithTag("sol")));
        //items.AddRange(new List<GameObject>(GameObject.FindGameObjectsWithTag("obstacle")));
        print("Nombre grille : " +items.Count);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
