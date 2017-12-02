using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionsHero : MonoBehaviour {
    //definition des points à gagner
    private static int POINTS_POTION = 20;
    private static int POINTS_ENNEMIS = 60;
    private static int POINTS_COEUR = 1;
    private static int POINTS_CRANE_MORT = 10;
    private static int SCORE_INITIAL = 0;
    private static int SCORE_GAGNANT = 180;
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "potion")
        {

        }
        else if (collider.tag == "ennemi")
        {

        }
    }
}
