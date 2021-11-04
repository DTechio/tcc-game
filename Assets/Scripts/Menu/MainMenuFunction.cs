using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuFunction : MonoBehaviour
{
    public GameObject optMenu;
    public GameObject loadMenu;

    public void NewGameButton()
    {
        //Respawn or Normal Game Scene
        SceneManager.LoadScene(3);
    }

    public void LoadButton()
    {
        if (loadMenu.activeSelf == false)
        {
            loadMenu.SetActive(true);
            optMenu.SetActive(false);
        }
        else
        {
            loadMenu.SetActive(false);
        }
    }

    public void OptionsButton()
    {
        if (optMenu.activeSelf == false)
        {
            optMenu.SetActive(true);
            loadMenu.SetActive(false);
        }
        else
        {
            optMenu.SetActive(false);
        }
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
