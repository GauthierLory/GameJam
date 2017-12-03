using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Ce script genere les caisses sur les maps aleatoirement avec les items

public class GenerationMaps : MonoBehaviour
{
    //Recuperation de l'image de la caisse
    public GameObject caisse;
    //CollisionsHero collisionHero;

    //Initiation des ITEMS
    public GameObject vitesse;
    public GameObject pv;
    public GameObject coeur;
    public GameObject crane;
    public GameObject stopHero;
    public GameObject ennemy;

    // Initialisation du hero
    public GameObject hero;

    //Creation d'un tableau solDepart
    private GameObject[] solDepart;

    //Creation d'un tableau sol
    GameObject[] sol;

    //Creation tableau prenant toutes les caisses présentent
    GameObject[] tagCaisses;

    //Scenes



    //Instantation de la fonction Random
    System.Random rnd;
    int suivant;
    int suivant2;
    int suivantEnnemy;
    private bool estTerminee = false;

    static int stage = 5;

    void Start()
    {
        //Recuperation de tous les gameobjects avec le tag sol
        sol = GameObject.FindGameObjectsWithTag("sol");
        //Recuperation de tous les gameobjects avec le tag solDepart
        solDepart = GameObject.FindGameObjectsWithTag("solDepart");



        rnd = new System.Random();

        //de 0 au nombre de sols
        for (int i = 0; i < sol.Length; i++)
        {

            suivant = rnd.Next(2);
            if (suivant == 1)
            {
                //Creation des sols
                Instantiate(caisse, new Vector2(sol[i].transform.position.x, sol[i].transform.position.y), Quaternion.identity);
                sol[i].layer = 9;
            }

        }

        //Recuperation de tous les gameObjects avec le tag caisse
        tagCaisses = GameObject.FindGameObjectsWithTag("caisse");

        for (int j = 0; j < tagCaisses.Length; j++)
        {
            suivant = rnd.Next(15);
            if (suivant == 5)
            {
                //apparition bonus
                suivant2 = rnd.Next(2);
                switch (suivant2)
                {
                    case 0:
                        //generation item PV
                        Instantiate(pv, new Vector2(tagCaisses[j].transform.position.x, tagCaisses[j].transform.position.y), Quaternion.identity);
                        break;

                    case 1:
                        //generation item vitesse
                        Instantiate(vitesse, new Vector2(tagCaisses[j].transform.position.x, tagCaisses[j].transform.position.y), Quaternion.identity);
                        break;

                    case 2:
                        //generation item coeur
                        Instantiate(coeur, new Vector2(tagCaisses[j].transform.position.x, tagCaisses[j].transform.position.y), Quaternion.identity);
                        break;

                }

            }
            else if (suivant == 6)
            {
                //apparition malus
                suivant2 = rnd.Next(1);
                switch (suivant2)
                {
                    case 0:
                        //generation crane
                        Instantiate(crane, new Vector2(tagCaisses[j].transform.position.x, tagCaisses[j].transform.position.y), Quaternion.identity);
                        break;

                    case 1:
                        //generation stopHero
                        Instantiate(stopHero, new Vector2(tagCaisses[j].transform.position.x, tagCaisses[j].transform.position.y), Quaternion.identity);
                        break;
                }
            }

        }


        //génération aléatoire d'un entier entre 0 et 2
        int positionHero = rnd.Next(3);
        //instantiation du héro en fonction du nombre aléatoire
        Instantiate(hero, new Vector2(solDepart[positionHero].transform.position.x, solDepart[positionHero].transform.position.y), Quaternion.identity);
        InstantiateEnnemy();

    }

    void Update()
    {

        if (CollisionsHero.SCORE_ACTUEL == CollisionsHero.SCORE_GAGNANT)
        {
            GestionStage();

        }
    }

    void InstantiateEnnemy()
    {
        int nbEnnemi = 5;
        sol = GameObject.FindGameObjectsWithTag("sol");
        switch (stage)
        {
            case 1:
                nbEnnemi = 5;
                for (int j = 0; j < sol.Length; j++)
                {
                    if (sol[j].layer != 9 && nbEnnemi > 0)
                    {
                        Instantiate(ennemy, new Vector2(sol[j].transform.position.x, sol[j].transform.position.y), Quaternion.identity);
                        nbEnnemi -= 1;
                    }
                }
                break;
            case 2:
                nbEnnemi = 6;
                for (int j = 0; j < sol.Length; j++)
                {
                    if (sol[j].layer != 9 && nbEnnemi > 0)
                    {
                        Instantiate(ennemy, new Vector2(sol[j].transform.position.x, sol[j].transform.position.y), Quaternion.identity);
                        nbEnnemi -= 1;
                    }
                }
                break;
            case 3:
                nbEnnemi = 7;
                for (int j = 0; j < sol.Length; j++)
                {
                    if (sol[j].layer != 9 && nbEnnemi > 0)
                    {
                        Instantiate(ennemy, new Vector2(sol[j].transform.position.x, sol[j].transform.position.y), Quaternion.identity);
                        nbEnnemi -= 1;
                    }
                }
                break;
            case 4:
                nbEnnemi = 8;
                for (int j = 0; j < sol.Length; j++)
                {
                    if (sol[j].layer != 9 && nbEnnemi > 0)
                    {
                        Instantiate(ennemy, new Vector2(sol[j].transform.position.x, sol[j].transform.position.y), Quaternion.identity);
                        nbEnnemi -= 1;
                    }
                }
                break;
            case 5:
                nbEnnemi = 9;
                for (int j = 0; j < sol.Length; j++)
                {
                    if (sol[j].layer != 9 && nbEnnemi > 0)
                    {
                        Instantiate(ennemy, new Vector2(sol[j].transform.position.x, sol[j].transform.position.y), Quaternion.identity);
                        nbEnnemi -= 1;
                    }
                }
                break;
        }
        

        
    }

    void GestionStage()
    {
        estTerminee = true;
        //stage += stage;

        if (stage == 5 && Application.loadedLevelName == "Level1")
        {
            Application.LoadLevel("level2");
        }
        else if (stage == 5 && Application.loadedLevelName == "level3")
        {
            Application.LoadLevel("level3");
        }
        else if (stage == 5 && Application.loadedLevelName == "level4")
        {
            Application.LoadLevel("level4");
        }

        else if (stage == 5 && Application.loadedLevelName == "Level5")
        {

        }

        else
        {
            Application.LoadLevel(Application.loadedLevel);
        }
    }
}
