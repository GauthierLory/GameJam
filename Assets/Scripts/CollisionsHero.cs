using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionsHero : MonoBehaviour
{

    //definition des points à gagner ou à perdre
    private static int POINTS_POTION = 20;
    private static int POINTS_ENNEMIS = 60;
    private static int POINTS_VITESSE_AUGMENTEE = 20;
    private static int POINTS_COEUR = 20;
    private static int POINTS_STOP_HERO = 10;
    private static int POINTS_CRANE_MORT = 10;
    //definition scores
    private static int SCORE_INITIAL = 0;
    public static int SCORE_ACTUEL;
    public static int SCORE_GAGNANT = 180;
    //definition vie
    public static int POINT_VIE = 1;
    public static int VIE_INITIALE = 3;
    public static int VIE_ACTUELLE;

    private Gui gui;


    // Use this for initialization
    void Start()
    {
        gui = Gui.instance;

        VIE_ACTUELLE = VIE_INITIALE;
    }

    // Update is called once per frame
    void Update()
    {
        if (VIE_INITIALE == 0)
        {

            gui.finPartie(this);
        }
        else if (SCORE_GAGNANT >= 15)
        {
            gui.winGame(this);
        }
    }

    //ajout ou supression des points, des vies lors de la collision du hero avec les items
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "ennemi")

        {

            gui = Gui.instance;
            VIE_ACTUELLE -= 1;


            if (VIE_ACTUELLE <= 0)
            {
                gui.finPartie(this);
            }
            else
            {
                Application.LoadLevel(Application.loadedLevel);
            }

        }


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


    public void redemarrer()
    {
        VIE_INITIALE = 3;
    }
}
