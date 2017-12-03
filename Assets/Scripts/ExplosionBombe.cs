using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBombe : MonoBehaviour {

    //Initialisation de la vitesse de destruction bombe 
    private static float VITESSE_BOMBE = 2.8f;
    private GameObject bombe;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        //Destruction de la bombe au bout de 3s
        Destroy(this.gameObject, VITESSE_BOMBE);
    }
}
