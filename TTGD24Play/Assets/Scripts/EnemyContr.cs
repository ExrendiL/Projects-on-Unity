using UnityEngine;
using UnityEngine.AI;
using System.Collections;


public class EnemyContr : MonoBehaviour
{
	private NavMeshAgent agent1;


	public float randomXMin = -10f, randomXMax = 10f;
	

	private void Start()
	{
		agent1 = GetComponent<NavMeshAgent>();

		StartCoroutine(NewDestination1());
	}

	IEnumerator NewDestination1()
	{
		while (true)
		{

			agent1.SetDestination(
				
				new Vector4(Random.Range(randomXMin, randomXMax), 0)
			);

			yield return new WaitForSeconds(0.2f);
		}
	}

}

