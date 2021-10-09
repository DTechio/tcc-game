using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CrabAI : MonoBehaviour
{
    public GameObject theCrab;
    public bool isAttacking = false;

    void OnTriggerEnter(Collider other)
    {
        if (isAttacking == false)
        {
            isAttacking = true; 
            theCrab.GetComponent<Animator>().Play("Armature|Attack_1");
            theCrab.GetComponent<NavigationAI>().enabled = false;
            theCrab.GetComponent<NavMeshAgent>().enabled = false;
            this.GetComponent<MeshCollider>().enabled = false;
            StartCoroutine(TakeHealth());
        }
    }

    void OnTriggerExit(Collider other)
    {
        isAttacking = false;
        theCrab.GetComponent<Animator>().Play("Armature|Walk_Cycle_1");
        theCrab.GetComponent<NavigationAI>().enabled = true;
        theCrab.GetComponent<NavMeshAgent>().enabled = true;
        this.GetComponent<MeshCollider>().enabled = true;
        StopCoroutine(TakeHealth());
    }

    IEnumerator TakeHealth()
    {
        yield return new WaitForSeconds(1.15f);
        HealthMonitor.healthPoints -= 10;
        isAttacking = false;
        theCrab.GetComponent<Animator>().Play("Armature|Walk_Cycle_1");
        theCrab.GetComponent<NavigationAI>().enabled = true;
        theCrab.GetComponent<NavMeshAgent>().enabled = true;
        this.GetComponent<MeshCollider>().enabled = true;
    }
}
