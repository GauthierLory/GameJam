using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ce script genere les caisses sur les maps aleatoirement avec les items

public class GenerationMaps : MonoBehaviour
{
    //Recuperation de l'image de la caisse
    public GameObject caisse;

    //Initiation des ITEMS
    public GameObject vitesse;
    public GameObject pv;
    public GameObject coeur;
    public GameObject crane;
    public GameObject stopHero;

    // Initialisation du hero
    public GameObject hero;

    //Creation d'un tableau solDepart
    private GameObject[] solDepart;

    //Creation d'un tableau sol
    GameObject[] sol;

    //Creation tableau prenant toutes les caisses présentent
    GameObject[] tagCaisses;


    //Instantation de la fonction Random
    System.Random rnd;
    int suivant;
    int suivant2;

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
            print(suivant);
            if (suivant == 1)
            {
                //Creation des sols
                Instantiate(caisse, new Vector2(sol[i].transform.position.x, sol[i].transform.position.y), Quaternion.identity);
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
        int positionHero = rnd.Next(2);
        //instantiation du héro en fonction du nombre aléatoire
        Instantiate(hero,new Vector2(solDepart[positionHero].transform.position.x, solDepart[positionHero].transform.position.y), Quaternion.identity);
    }

    void Update()
    {


    }
}
