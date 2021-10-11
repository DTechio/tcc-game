using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverOption : MonoBehaviour
{
    public void RespawnPlayer()
    {
        //Respawn Scene
        SceneManager.LoadScene(3);
    }

    public void MainMenu()
    {
        //Menu Scene
        SceneManager.LoadScene(1);
    }
}
