using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorOpenGarage : MonoBehaviour
{

    public float TheDistance;
    public GameObject ActionText;
    public GameObject theDoor;
    public AudioSource CreakyDoor;

    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }

    void OnMouseOver()
    {
        if (TheDistance <= 5)
        {
            ActionText.GetComponent<Text>().text = "Abrir Porta";
            ActionText.SetActive(true);
        }
        else
        {
            ActionText.GetComponent<Text>().text = "";
            ActionText.SetActive(false);
        }

        if (Input.GetButtonDown("Action"))
        {
            if (TheDistance <= 5)
            {
                CreakyDoor.Play();
                ActionText.GetComponent<Text>().text = "";
                theDoor.GetComponent<Animator>().enabled = true;
                theDoor.GetComponent<Animator>().Play("GarageDoorOne");
                this.GetComponent<BoxCollider>().enabled = false;
                ActionText.SetActive(false);
            }
        }
    }

    void OnMouseExit()
    {
        ActionText.GetComponent<Text>().text = "";
        ActionText.SetActive(false);
    }
}
