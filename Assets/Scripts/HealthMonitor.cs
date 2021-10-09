using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthMonitor : MonoBehaviour
{
    public static int healthPoints = 100;
    public int internalHealth;
    public GameObject healthDisplay;

    void Update()
    {
        internalHealth = healthPoints;
        healthDisplay.GetComponent<Text>().text = "" + healthPoints;
    }
}
