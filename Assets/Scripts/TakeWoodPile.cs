using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeWoodPile : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionText;
    public GameObject woodPile;

    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }

    void OnMouseOver()
    {
        if (TheDistance <= 5)
        {
            ActionText.GetComponent<Text>().text = "Pegar madeira";
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
                NPCChoice.questComplete = true;
                woodPile.SetActive(false);
                ActionText.SetActive(false);
                this.gameObject.GetComponent<BoxCollider>().enabled = false;
            }
        }
    }

    void OnMouseExit()
    {
        ActionText.GetComponent<Text>().text = "";
        ActionText.SetActive(false);
    }

}
