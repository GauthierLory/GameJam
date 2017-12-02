using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Custom/Editor")]

public class Grid : MonoBehaviour
{

    public float width = 1.0f;
    public float height = 1.0f;

    public Color color = Color.yellow;

    void OnDrawGizmos()
    { // va nous permettre de dessiner sur la scene en mode edition
        Vector3 pos = Camera.current.transform.position; // va chercher la position de la camera

        Gizmos.color = color; // indique a Gizmos de quelle couleur on va dessiner

        //va tracer 500 lignes en ce centrant sur la position de la camera
        for (float y = pos.y - 250.0f; y < pos.y + 250.0f; y += height)
        {

            Gizmos.DrawLine
            (
                new Vector3(-250.0f, Mathf.Floor(y / height) * height, 0.0f),
                new Vector3(250.0f, Mathf.Floor(y / height) * height, 0.0f)
            );
        }


        for (float x = pos.x - 250.0f; x < pos.x + 250.0f; x += width)
        {

            Gizmos.DrawLine
            (
                new Vector3(Mathf.Floor(x / width) * width, -250.0f + 0.0f),
                new Vector3(Mathf.Floor(x / width) * width, 250.0f + 0.0f)
            );
        }
    }
}
