using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    [SerializeField]
    private GameObject _podeInteragirTxt;
    private bool _podeInteragir;
    public LayerMask interactableLayer;

    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward,out hit, 8, interactableLayer))
        {
            _podeInteragirTxt.gameObject.SetActive(true);
            _podeInteragir = true;
        }
        else
        {
            _podeInteragirTxt.gameObject.SetActive(false);
            _podeInteragir = false;
        }

        if (_podeInteragir == true && Input.GetKeyDown(KeyCode.E))
        {
            hit.transform.gameObject.GetComponent<MeshRenderer>().material.color = UnityEngine.Random.ColorHSV();
        }
    }
}
