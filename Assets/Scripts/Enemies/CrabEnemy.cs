using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CrabEnemy : MonoBehaviour
{
    public int enemyHealth = 10;
    public GameObject attackObj;

    void DeductPoints(int damageAmount)
    {
        enemyHealth -= damageAmount;
    }

    void Update()
    {
        if (enemyHealth <= 0)
        {
            this.GetComponent<Animator>().Play("Armature|Die");
            this.GetComponent<NavigationAI>().enabled = false;
            this.GetComponent<NavMeshAgent>().enabled = false;
            this.GetComponent<BoxCollider>().enabled = false;
            attackObj.SetActive(false);
            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(5f);
        this.gameObject.SetActive(false);
    }
}
