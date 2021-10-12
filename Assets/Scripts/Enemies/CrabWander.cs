using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabWander : MonoBehaviour
{
    public int xPos;
    public int zPos;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            xPos = Random.Range(6, 40);
            zPos = Random.Range(35, 120);
            this.gameObject.transform.position = new Vector3(xPos, 5, zPos);
            this.gameObject.GetComponent<BoxCollider>().enabled = true;
        }
    }

}
