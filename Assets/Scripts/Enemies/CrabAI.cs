using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabAI : MonoBehaviour
{
    public GameObject theCrab;

    void OnTriggerEnter(Collider other)
    {
        theCrab.GetComponent<Animator>().Play("Armature|Attack_1");
    }

    void OnTriggerExit(Collider other)
    {
        theCrab.GetComponent<Animator>().Play("Armature|Rest");
    }
}
