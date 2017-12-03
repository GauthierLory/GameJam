using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionsHero : MonoBehaviour {

    //definition des points à gagner ou à perdre
    private static int POINTS_POTION = 20;
    private static int POINTS_ENNEMIS = 60;
    private static int POINTS_VITESSE_AUGMENTEE = 20;
    private static int POINTS_COEUR = 20;
    private static int POINTS_STOP_HERO = 10;
    private static int POINTS_CRANE_MORT = 10;
    //definition scores
    private static int SCORE_INITIAL = 0;
    private static int SCORE_ACTUEL;
    private static int SCORE_GAGNANT = 180;
    //definition vie
    private static int POINT_VIE = 1;
    private static int VIE_INITIALE = 3;
    private static int VIE_ACTUELLE;

    private Menu gui;


    // Use this for initialization
    void Start () {
        
    }

    // Update is called once per frame
    void Update ()
    {
        
    }

    //ajout ou supression des points, des vies lors de la collision du hero avec les items
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "potion")
        {
            Destroy(collider.gameObject);
            SCORE_ACTUEL += POINTS_POTION;
        }
        else if (collider.tag == "cranemort")
        {
            Destroy(collider.gameObject);
            SCORE_ACTUEL -= POINTS_CRANE_MORT;
        }
        else if (collider.tag == "vitesseaugmentee")
        {
            Destroy(collider.gameObject);
            SCORE_ACTUEL += POINTS_VITESSE_AUGMENTEE;
        }
        else if (collider.tag == "coeur")
        {
            Destroy(collider.gameObject);
            SCORE_ACTUEL += POINTS_COEUR;
            VIE_ACTUELLE += POINT_VIE;
        }
        else if (collider.tag == "stophero")
        {
            Destroy(collider.gameObject);
            SCORE_ACTUEL += POINTS_STOP_HERO;
        }
    }
}
