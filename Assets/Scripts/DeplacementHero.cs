using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeplacementHero : MonoBehaviour {

    Rigidbody2D personnage;
    bool keypressed = false;

    // Use this for initialization
    void Start () {
        personnage = gameObject.GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.RightArrow) || keypressed)
        {
            keypressed = true;
            personnage.transform.Translate(Vector3.right * 2.3f * Time.deltaTime, Space.World);
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            keypressed = false;
            personnage.transform.Translate(Vector3.right * 0 * Time.deltaTime, Space.World);
        }
    }
}
