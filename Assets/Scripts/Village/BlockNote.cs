using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockNote : MonoBehaviour
{
    public GameObject blockNote;

    void OnTriggerEnter(Collider other)
    {
        blockNote.SetActive(true);
    }

    void OnTriggerExit(Collider other)
    {
        blockNote.SetActive(false);
    }
}
