using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    public Canvas CanvasMenu;
    public Canvas CanvasOption;
    public Canvas CanvasNiveau;

    void Awake()
    {
        CanvasOption.enabled = false;
        CanvasNiveau.enabled = false;
    }

    public void OptionsOn()
    {
        CanvasOption.enabled = true;
        CanvasNiveau.enabled = false;
        CanvasMenu.enabled = false;
    }

    public void ReturnOn()
    {
        CanvasOption.enabled = false;
        CanvasNiveau.enabled = false;
        CanvasMenu.enabled = true;
    }

    public void SelectOn()
    {
        CanvasOption.enabled = false;
        CanvasMenu.enabled = false;
        CanvasNiveau.enabled = true;
    }

    public void LoadOn()
    {
        SceneManager.LoadScene(1);
    }

    public void Selectlvl1()
    {
        SceneManager.LoadScene(1);
    }

    public void Selectlvl2()
    {
        SceneManager.LoadScene(2);
    }

    public void Selectlvl3()
    {
        SceneManager.LoadScene(3);
    }

    public void Selectlvl4()
    {
        SceneManager.LoadScene(4);
    }

    public void Selectlvl5()
    {
        SceneManager.LoadScene(5);
    }
}
