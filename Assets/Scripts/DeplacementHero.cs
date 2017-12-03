using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementHero : MonoBehaviour {

    //vitesse du personnage
    private static float VITESSE_HERO = 2.0f;
    Rigidbody2D personnage;

    //variable pour définir si les touches de déplacements sont actives
    bool keypressedRight = false;
    bool keypressedLeft = false;
    bool keypressedUp = false;
    bool keypressedDown = false;

    // Use this for initialization
    void Start () {
        personnage = gameObject.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {

        //personnage qui va sur la droite si le joueur appuie sur la fleche de droite
        if (Input.GetKeyDown(KeyCode.RightArrow) || keypressedRight)
        {
            keypressedRight = true;
            personnage.transform.Translate(Vector3.right * VITESSE_HERO * Time.deltaTime, Space.World);
        }

        //personnage qui s'arrete quand le joueur relache la fleche de droite
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            keypressedRight = false;
            personnage.transform.Translate(Vector3.right * 0 * Time.deltaTime, Space.World);
        }

        //personnage qui va sur la gauche si le joueur appuie sur la fleche de gauche
        if (Input.GetKeyDown(KeyCode.LeftArrow) || keypressedLeft)
        {
            keypressedLeft = true;
            personnage.transform.Translate(Vector3.left * VITESSE_HERO * Time.deltaTime, Space.World);
        }

        //personnage qui s'arrete quand le joueur relache la fleche de gauche
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            keypressedLeft = false;
            personnage.transform.Translate(Vector3.left * 0 * Time.deltaTime, Space.World);
        }

        //personnage qui va en haut si le joueur appuie sur la fleche du haut
        if (Input.GetKeyDown(KeyCode.UpArrow) || keypressedUp)
        {
            keypressedUp = true;
            personnage.transform.Translate(Vector3.up * VITESSE_HERO * Time.deltaTime, Space.World);
        }

        //personnage qui s'arrete quand le joueur relache la fleche du haut
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            keypressedUp = false;
            personnage.transform.Translate(Vector3.up * 0 * Time.deltaTime, Space.World);
        }

        //personnage qui va en bas si le joueur appuie sur la fleche du bas
        if (Input.GetKeyDown(KeyCode.DownArrow) || keypressedDown)
        {
            keypressedDown = true;
            personnage.transform.Translate(Vector3.down * VITESSE_HERO * Time.deltaTime, Space.World);
        }

        //personnage qui s'arrete quand le joueur relache la fleche du bas
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            keypressedDown = false;
            personnage.transform.Translate(Vector3.down * 0 * Time.deltaTime, Space.World);
        }
    }
}
