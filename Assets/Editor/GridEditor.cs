using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor; //c'est le package qui va nous permettre d'hériter de la classe Editor

[CustomEditor(typeof(Grid))] //Spécifie que notre classe Editor sera basée sur la classe grid

public class GridEditor : Editor
{

    Grid grid;
    private bool keyPressed = false;

    public void OnEnable()
    { //va activer le script quand on est en mode édition
        grid = (Grid)target;

        SceneView.onSceneGUIDelegate += gridUpdate;

    }

    public void OnDisable()
    { //va desactiver le script quand nous serons en run-time
        SceneView.onSceneGUIDelegate -= gridUpdate;
    }

    public void gridUpdate(SceneView sceneView)
    {

        Event e = Event.current; // récupere l'evenement en cours

        Ray rayon = Camera.current.ScreenPointToRay(
                        new Vector3(e.mousePosition.x, -e.mousePosition.y + Camera.current.pixelHeight, 0.0f)
        );

        Vector3 mousePos = rayon.origin;

        //si on tape sur un bouton et que c'est le bouton ctrl

        if (e.ToString() == "Repaint" && e.control && !keyPressed)
        {
            keyPressed = true;

            GameObject obj;

            //va recuperer la reference de l'objet
            Object prefab = PrefabUtility.GetPrefabParent(Selection.activeObject);

            obj = (GameObject)PrefabUtility.InstantiatePrefab(prefab);

            Vector3 aligned = new Vector3(
                Mathf.Floor(mousePos.x / grid.width) * grid.width + grid.width * .5f,
                Mathf.Floor(mousePos.y / grid.height) * grid.height + grid.height * .5f
                );

            obj.transform.position = aligned;

        }
        else if (e.ToString() == "Repaint" && e.control && keyPressed)
        {
            keyPressed = false;
        }

    }
}
