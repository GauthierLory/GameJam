using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBombe : MonoBehaviour {

    //Initialisation de la vitesse de destruction bombe 
    private static float VITESSE_BOMBE = 2.8f;
    private float tempExplosion=0.0f;
    public GameObject explosion;
    public GameObject explosionFeu;
    private GameObject bombe;

	// Use this for initialization
	void Start () {
        bombe = this.gameObject;
	}
	
	// Update is called once per frame
	void Update () {
        tempExplosion += Time.deltaTime;
        if (tempExplosion >= 2.7f)
        {
            explosionFeu = Instantiate(explosion, new Vector3(bombe.transform.position.x, bombe.transform.position.y), Quaternion.identity);
            Destroy(explosionFeu,0.1f);
        }
        //Destruction de la bombe au bout de 2.8s
        Destroy(this.gameObject, VITESSE_BOMBE);
    }
}
