using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuFunction : MonoBehaviour
{
    public void NewGameButton()
    {
        //Respawn or Normal Game Scene
        SceneManager.LoadScene(3);
    }

    public void LoadButton()
    {
        //SceneManager.LoadScene(#);
    }

    public void OptionsButton()
    {
        //UI for options to be built
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
