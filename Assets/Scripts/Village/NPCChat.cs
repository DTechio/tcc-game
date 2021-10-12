using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCChat : MonoBehaviour
{
    public float TheDistance;
    public GameObject NPC;
    public GameObject ActionText;
    public GameObject subText;
    public GameObject subBox;
    public GameObject mainBlocker;
    public GameObject blockText;
    public GameObject villageExitTrig;
    public static bool crabSlayed = false;

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
                if (DialogueState.stateAxeTake == false && crabSlayed == false)
                {
                    NPC.GetComponent<Animator>().Play("Talk01");
                    subBox.SetActive(true);
                    subText.GetComponent<Text>().text = "Oh, você quer ser um guerreiro!? Haha - Pega aquele machado, tenho uma tarefa para você.";
                    ActionText.GetComponent<Text>().text = "";
                    ActionText.SetActive(false);
                    StartCoroutine(ResetChat());
                }
                if (DialogueState.stateAxeTake == true && crabSlayed == false)
                {
                    NPC.GetComponent<Animator>().Play("Talk01");
                    subBox.SetActive(true);
                    subText.GetComponent<Text>().text = "Esse machado vai lhe ajudar. Tem um caranguejo na praia que está causando estragos, elimine-o se for capaz! Hahaha";
                    ActionText.GetComponent<Text>().text = "";
                    ActionText.SetActive(false);
                    mainBlocker.SetActive(false);
                    blockText.SetActive(false);
                    StartCoroutine(ResetChat());
                }
                if (crabSlayed == true)
                {
                    NPC.GetComponent<Animator>().Play("Talk03");
                    subBox.SetActive(true);
                    subText.GetComponent<Text>().text = "Até que você leva jeito, obrigado pela ajuda. Pegue essa chave para sair da vila, você conseguirá melhores aventuras lá fora.";
                    ActionText.GetComponent<Text>().text = "";
                    ActionText.SetActive(false);
                    mainBlocker.SetActive(false);
                    blockText.SetActive(false);
                    villageExitTrig.SetActive(true);
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
