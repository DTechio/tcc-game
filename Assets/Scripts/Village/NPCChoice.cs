using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class NPCChoice : MonoBehaviour
{
    public float TheDistance;
    public GameObject ActionText;
    public GameObject subText;
    public GameObject subBox;
    public GameObject thePlayer;
    public GameObject optButton01;
    public GameObject optButton02;
    public GameObject woodPile;
    public GameObject questCompText;
    public bool takenQuest = false;
    public static bool questComplete = false;

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
                if (takenQuest == false)
                {
                    GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = false;
                    this.transform.LookAt(new Vector3(thePlayer.transform.position.x, this.transform.position.y, thePlayer.transform.position.z));
                    this.GetComponent<Animator>().Play("Talk01");
                    this.GetComponent<NavMeshAgent>().enabled = false;
                    this.GetComponent<NPCAINav>().enabled = false;
                    subBox.SetActive(true);
                    subText.GetComponent<Text>().text = "Olá garoto! Pelo jeito deixaram você sair. Está buscando aventura?";
                    this.gameObject.GetComponent<BoxCollider>().enabled = false;
                    ActionText.GetComponent<Text>().text = "";
                    ActionText.SetActive(false);
                    StartCoroutine(StartSelectConvo());
                }
                if (questComplete == true)
                {
                    questComplete = false;
                    GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = false;
                    this.transform.LookAt(new Vector3(thePlayer.transform.position.x, this.transform.position.y, thePlayer.transform.position.z));
                    this.GetComponent<Animator>().Play("Talk01");
                    this.GetComponent<NavMeshAgent>().enabled = false;
                    this.GetComponent<NPCAINav>().enabled = false;
                    subBox.SetActive(true);
                    subText.GetComponent<Text>().text = "Muito obrigado! Isso será de grande ajuda!";
                    ActionText.GetComponent<Text>().text = "";
                    ActionText.SetActive(false);
                    StartCoroutine(QuestReturned());
                }
            }
        }
    }

    void OnMouseExit()
    {
        ActionText.GetComponent<Text>().text = "";
        ActionText.SetActive(false);
    }

    IEnumerator StartSelectConvo()
    {
        yield return new WaitForSeconds(4f);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        subText.GetComponent<Text>().text = "Então tenho uma aventura para você. Siga a estrada e colete a madeira próxima ao poço. Posso contar com você?";
        optButton01.SetActive(true);
        optButton02.SetActive(true);
    }
    
    IEnumerator QuestReturned()
    {
        yield return new WaitForSeconds(3f);
        questCompText.GetComponent<Animator>().Play("QuestCompletedAnim");
        subBox.SetActive(false);
        this.gameObject.GetComponent<BoxCollider>().enabled = true;
        subText.GetComponent<Text>().text = "";
        this.GetComponent<Animator>().Play("Walk01");
        this.GetComponent<NavMeshAgent>().enabled = true;
        this.GetComponent<NPCAINav>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = true;
    }

    public void YesOption()
    {
        StartCoroutine(StartYes());
    }

    IEnumerator StartYes()
    {
        takenQuest = true;
        optButton01.SetActive(false);
        optButton02.SetActive(false);
        woodPile.SetActive(true);
        subText.GetComponent<Text>().text = "Ótimo! Estarei aguardando aqui.";
        yield return new WaitForSeconds(4.5f);
        subBox.SetActive(false);
        this.gameObject.GetComponent<BoxCollider>().enabled = true;
        subText.GetComponent<Text>().text = "";
        this.GetComponent<Animator>().Play("Walk01");
        this.GetComponent<NavMeshAgent>().enabled = true;
        this.GetComponent<NPCAINav>().enabled = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = true;
    }

    public void NoOption()
    {
        Cursor.visible = false;
        optButton01.SetActive(false);
        optButton02.SetActive(false);
        subBox.SetActive(false);
        this.gameObject.GetComponent<BoxCollider>().enabled = true;
        subText.GetComponent<Text>().text = "";
        this.GetComponent<Animator>().Play("Walk01");
        this.GetComponent<NavMeshAgent>().enabled = true;
        this.GetComponent<NPCAINav>().enabled = true;
        Cursor.lockState = CursorLockMode.Locked;
        GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = true;
    }
}