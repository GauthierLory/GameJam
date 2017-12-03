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

        TexteVie.text = "Vie : 3";
        TexteScore.text = "Points : 0";
        TextLevel.text = "Niveau :99";
        TexteGameOver.enabled = false;
        TexteGagner.enabled = false;
        TexteRecommencer.enabled = false;
    }

    void Update()
    {
        TexteVie.text = "Vie : "+ CollisionsHero.VIE_ACTUELLE;
    }

    public void finPartie(CollisionsHero appelant)
    {
        TexteGameOver.enabled = true;
        TexteRecommencer.enabled = true;
        this.perso = appelant;
        Time.timeScale = 0f;
        if (Input.GetKeyDown(KeyCode.H))
        {
            perso.redemarrer();
            SceneManager.LoadScene(0);
            Time.timeScale = 1f;
            TexteGagner.enabled = false;
            TexteRecommencer.enabled = false;
        }

    }

    public void winGame(CollisionsHero appelant)
    {
        TexteGagner.enabled = true;
        TexteRecommencer.enabled = true;
        this.perso = appelant;
        Time.timeScale = 0f;
        if (Input.GetKeyDown(KeyCode.H))
        {
            perso.redemarrer();
            SceneManager.LoadScene(1);
            Time.timeScale = 1f;
            TexteGagner.enabled = false;
            TexteRecommencer.enabled = false;
        }
    }

    public void updateScore(string points)
    {
        TexteScore.text = points;

    }
}
