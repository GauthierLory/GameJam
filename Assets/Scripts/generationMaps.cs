using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generationMaps : MonoBehaviour
{
    public GameObject caisse;
    public GameObject[] sols;
    System.Random rnd;
    int suivant;

    // Use this for initialization
    void Start()
    {
        rnd = new System.Random ();
        for (int i = 0; i < sols.Length; i++)
        {
            suivant = rnd.Next(2);
            print(suivant);
            if (suivant == 1)
            {
                Instantiate(caisse, new Vector2(sols[i].transform.position.x, sols[i].transform.position.y), Quaternion.identity);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
