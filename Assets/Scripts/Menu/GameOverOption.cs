using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverOption : MonoBehaviour
{
    public void RespawnPlayer()
    {
        SceneManager.LoadScene(2);
    }
}
