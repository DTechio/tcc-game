using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCChat : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionText;
    public GameObject subText;
    public GameObject subBox;
    public GameObject mainBlocker;
    public GameObject blockText;

    void Update()
    {
        TheDistance = PlayerCasting.DistanceFromTarget;
    }

    void OnMouseOver()
    {
        if (TheDistance <= 5)
        {
            ActionText.GetComponent<Text>().text = "Conversar";
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
                if (DialogueState.stateAxeTake == false)
                {
                    subBox.SetActive(true);
                    subText.GetComponent<Text>().text = "Pega o machado ali, piá!";
                    ActionText.GetComponent<Text>().text = "";
                    ActionText.SetActive(false);
                    StartCoroutine(ResetChat());
                }
                if (DialogueState.stateAxeTake == true)
                {
                    subBox.SetActive(true);
                    subText.GetComponent<Text>().text = "Baita machado né, agora pode cortar árvores e outras cositas más! Tipo os bixo lá, vai matá!";
                    ActionText.GetComponent<Text>().text = "";
                    ActionText.SetActive(false);
                    mainBlocker.SetActive(false);
                    blockText.SetActive(false);
                    StartCoroutine(ResetChat());
                }
            }
        }
    }

    void OnMouseExit()
    {
        ActionText.GetComponent<Text>().text = "";
        ActionText.SetActive(false);
    }

    IEnumerator ResetChat()
    {
        yield return new WaitForSeconds(2.5f);
        subBox.SetActive(false);
        subText.GetComponent<Text>().text = "";
    }
}
