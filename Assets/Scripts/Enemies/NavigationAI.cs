using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavigationAI : MonoBehaviour
{
	public GameObject theDestination;
	NavMeshAgent theAgent;
	public static bool canAttack;
	public GameObject thePlayer;

	void Start()
	{
		theAgent = GetComponent<NavMeshAgent>();
	}


	void Update()
	{
		if (canAttack == true)
		{
			theAgent.SetDestination(thePlayer.transform.position);
		}
		else
		{
			theAgent.SetDestination(theDestination.transform.position);
		}
	}
}
