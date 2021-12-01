using UnityEngine.AI;
using UnityEngine;
using System.Collections;
public class MoveCarRaycast : MonoBehaviour
{
	private NavMeshAgent agent;
	public GameObject frontLights;
	public AudioSource startEngine, stopEngine;

	private void Start()
	{
		agent = GetComponent<NavMeshAgent>();
	}
	
	private void Update()
	{


		if (Input.GetMouseButtonDown(0))
		{

			RaycastHit hit;
			// Получаем позицию мыши и преобразуем его в Ray
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			// Создаем луч и указываем что информация попадет в переменную hit
			if (Physics.Raycast(ray, out hit, 100.0f))
			{

				agent.SetDestination(hit.point);
				frontLights.SetActive(true);
				startEngine.Play();
				stopEngine.Stop();

			}

		}
		else if (agent.remainingDistance == 0)
		{
			frontLights.SetActive(false);

		}
		 if (!frontLights.active && startEngine.isPlaying)
		{
			startEngine.Stop();
			stopEngine.Play();
		}


	}


}
