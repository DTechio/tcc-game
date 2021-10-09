using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AxeTake : MonoBehaviour
{
    public float TheDistance;
    public AudioSource TakeAxeSound;
    public GameObject ActionText;
    public GameObject FakeAxe;
    public GameObject RealAxe;

    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }

    void OnMouseOver()
    {
        if (TheDistance <= 5)
        {
            ActionText.GetComponent<Text>().text = "Pegar machado";
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
                ActionText.GetComponent<Text>().text = "";
                RealAxe.SetActive(true);
                FakeAxe.SetActive(false);
                AxeSwing.holdingAxe = true;
                ActionText.SetActive(false);
                TakeAxeSound.Play();
                DialogueState.stateAxeTake = true;
                Destroy(gameObject);
            }
        }
    }

    void OnMouseExit()
    {
        ActionText.GetComponent<Text>().text = "";
        ActionText.SetActive(false);
    }

}
