using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public Canvas CanvasMenu;
    public Canvas CanvasOption;

    void Awake()
    {
        CanvasOption.enabled = false;
    }

    public void OptionsOn()
    {
        CanvasOption.enabled = true;
        CanvasMenu.enabled = false;
    }

    public void ReturnOn()
    {
        CanvasOption.enabled = false;
        CanvasMenu.enabled = true;
    }

    public void LoadOn()
    {
        SceneManager.LoadScene(1);
    }
}
