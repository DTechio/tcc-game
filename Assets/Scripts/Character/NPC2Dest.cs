using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC2Dest : MonoBehaviour
{
    public int pivotPoint;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "NPC")
        {
            if (pivotPoint == 5)
            {
                pivotPoint = 0;
            }
            if (pivotPoint == 4)
            {
                this.gameObject.transform.position = new Vector3(150, 9, 160);
                pivotPoint = 5;
            }
            if (pivotPoint == 3)
            {
                this.gameObject.transform.position = new Vector3(185, 9, 150);
                pivotPoint = 4;
            }
            if (pivotPoint == 2)
            {
                this.gameObject.transform.position = new Vector3(150, 9, 160);
                pivotPoint = 3;
            }
            if (pivotPoint == 1)
            {
                this.gameObject.transform.position = new Vector3(170, 9, 190);
                pivotPoint = 2;
            }
            if (pivotPoint == 0)
            {
                this.gameObject.transform.position = new Vector3(155, 9, 180);
                pivotPoint = 1;
            }
        }
    }
}
