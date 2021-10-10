using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawning : MonoBehaviour
{
    void Start()
    {
        HealthMonitor.healthPoints = 300;
        SceneManager.LoadScene(1);
    }
}
