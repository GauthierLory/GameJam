using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Gui : MonoBehaviour {


    private float xDepart;
    private float yDepart;
    private CollisionsHero perso;
    public Text TexteVie;
    public Text TextLevel;
    public Text TexteScore;
    public Text TexteGagner;
    public Text TexteGameOver;
    public Text TexteRecommencer;
    
    public static Gui instance;

    void Start()
    {
        instance = this;

        TexteVie.text = "Vie : " + CollisionsHero.VIE_ACTUELLE;
        TexteScore.text = "Points : " + CollisionsHero.SCORE_ACTUEL;
        TextLevel.text = "Niveau :99";
        //TexteGameOver.enabled = false;
        //TexteGagner.enabled = false;
        //TexteRecommencer.enabled = false;
    }

    void Update()
    {
        TexteVie.text = "Vie : "+ CollisionsHero.VIE_ACTUELLE;
        TexteScore.text = "Points : " + CollisionsHero.SCORE_ACTUEL;
    }

    public void finPartie(CollisionsHero appelant)
    {
        TexteGameOver.enabled = true;
        TexteRecommencer.enabled = true;
        this.perso = appelant;
        Time.timeScale = 0f;
        if (Input.GetKeyDown(KeyCode.H))
        {
            CollisionsHero.redemarrer();
            SceneManager.LoadScene(0);
            Time.timeScale = 1f;
            TexteGagner.enabled = false;
            TexteRecommencer.enabled = false;
        }

    }

    /*public void winGame()
    {
        TexteGagner.enabled = true;
        TexteRecommencer.enabled = true;
        Time.timeScale = 0f;
        if (Input.GetKeyDown(KeyCode.H))
        {
            CollisionsHero.redemarrer();
            SceneManager.LoadScene(1);
            Time.timeScale = 1f;
            TexteGagner.enabled = false;
            TexteRecommencer.enabled = false;
        }
    }*/
}
