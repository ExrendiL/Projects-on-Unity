using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour {

    private NavMeshAgent agent;

    public Camera cam;

    private void Start() {
        agent = gameObject.GetComponent<NavMeshAgent>();
    }

    private void Update() {
        if(Input.GetMouseButtonDown(0)) {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray, out hit)) {
                agent.SetDestination(hit.point);
            }
        }
    }

}
