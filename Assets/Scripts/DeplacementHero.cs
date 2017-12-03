using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementHero : MonoBehaviour
{

    //vitesse du personnage
    private static float VITESSE_HERO = 2.0f;
    private bool versDroite = true;
    private bool versHaut = true;

    private static float TEMPS_LANCEMENT_BOMBE = 3.0f;
    private float tempsRestant = 0.0f;
    private bool bombeLancee=false;

    //Initialisation du personnage
    Rigidbody2D personnage;

    private Rigidbody2D body;

    //Initialisation de la bombe
    public GameObject bombe;

    //variable pour définir si les touches de déplacements sont actives
    bool keypressedRight = false;
    bool keypressedLeft = false;
    bool keypressedUp = false;
    bool keypressedDown = false;

    private Animator animateur; // reference vers lanimator du perso

    // Use this for initialization
    void Start()
    {
        animateur = this.GetComponent<Animator>(); // va recuperer la reference de lanimator

        personnage = gameObject.GetComponent<Rigidbody2D>();

        body = this.GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {

        //personnage qui va sur la droite si le joueur appuie sur la fleche de droite
        if (Input.GetKeyDown(KeyCode.RightArrow) || keypressedRight)
        {
            keypressedRight = true;
            animateur.SetBool("mHorizontal", true);
            personnage.transform.Translate(Vector3.right * VITESSE_HERO * Time.deltaTime, Space.World);
        }

        //personnage qui s'arrete quand le joueur relache la fleche de droite
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            keypressedRight = false;
            animateur.SetBool("mHorizontal", false);

            personnage.transform.Translate(Vector3.right * 0 * Time.deltaTime, Space.World);
        }

        //personnage qui va sur la gauche si le joueur appuie sur la fleche de gauche
        if (Input.GetKeyDown(KeyCode.LeftArrow) || keypressedLeft)
        {
            keypressedLeft = true;
            animateur.SetBool("mHorizontal", true);

            personnage.transform.Translate(Vector3.left * VITESSE_HERO * Time.deltaTime, Space.World);
        }

        //personnage qui s'arrete quand le joueur relache la fleche de gauche
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            keypressedLeft = false;
            animateur.SetBool("mHorizontal", false);

            personnage.transform.Translate(Vector3.left * 0 * Time.deltaTime, Space.World);
        }

        //personnage qui va en haut si le joueur appuie sur la fleche du haut
        if (Input.GetKeyDown(KeyCode.UpArrow) || keypressedUp)
        {
            keypressedUp = true;
            animateur.SetBool("mHorizontal", false);

            animateur.SetBool("mHaut", true);

            float move = Input.GetAxis("Vertical");

            animateur.SetFloat("speed", Mathf.Abs(move));

            body.velocity = new Vector2(move * VITESSE_HERO, body.velocity.x);

            personnage.transform.Translate(Vector3.up * VITESSE_HERO * Time.deltaTime, Space.World);
        }

        //personnage qui s'arrete quand le joueur relache la fleche du haut
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            keypressedUp = false;
            animateur.SetBool("mHaut", false);

            personnage.transform.Translate(Vector3.up * 0 * Time.deltaTime, Space.World);
        }

        //personnage qui va en bas si le joueur appuie sur la fleche du bas
        if (Input.GetKeyDown(KeyCode.DownArrow) || keypressedDown)
        {
            keypressedDown = true;
            animateur.SetBool("mHorizontal", false);

            animateur.SetBool("mBas", true);
            float move = Input.GetAxis("Vertical");

            animateur.SetFloat("speed", Mathf.Abs(move));

            body.velocity = new Vector2(move * VITESSE_HERO, body.velocity.x);

            personnage.transform.Translate(Vector3.down * VITESSE_HERO * Time.deltaTime, Space.World);
        }

        //personnage qui s'arrete quand le joueur relache la fleche du bas
        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            keypressedDown = false;
            animateur.SetBool("mBas", false);
      
            personnage.transform.Translate(Vector3.down * 0 * Time.deltaTime, Space.World);
        }

        //lorsque le joueur clique sur espace, instantiation de la bombe et lancement du temps restant avant un nouveau lance
        if (Input.GetKeyUp(KeyCode.Space) && bombeLancee==false)
        {
            bombeLancee = true;
            tempsRestant = TEMPS_LANCEMENT_BOMBE;
            Instantiate(bombe, new Vector3(personnage.transform.position.x, personnage.position.y), Quaternion.identity);
            animateur.Play("Bombe");
        }

        //lorsque la bombe est lancee, decrementation du temps
        if (bombeLancee == true)
        {
            tempsRestant -= Time.deltaTime;

            //lorsque letemps est à 0 on remet bombeLancee à false
            if(tempsRestant < 0.0f)
            {
                bombeLancee = false;
            }
        }

    }
    
    void FixedUpdate()

    {
        float move = Input.GetAxis("Horizontal");

        animateur.SetFloat("speed", Mathf.Abs(move));

        body.velocity = new Vector2(move * VITESSE_HERO, body.velocity.y);

        if (move > 0 && !versDroite)

            flip();
        else if (move < 0 && versDroite)
            flip();
       
    }

    private void flip()
    {
        versDroite = !versDroite;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;

        transform.localScale = theScale;

    }
}
