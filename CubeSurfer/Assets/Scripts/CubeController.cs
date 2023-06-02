using UnityEngine;

public class CubeController : MonoBehaviour
{
    [SerializeField] private CubeStacking cubeStacking;

    private Vector3 direction = Vector3.back;
    private bool isStack = false;
    private RaycastHit hit;

    void Start()
    {
        cubeStacking = GameObject.FindObjectOfType<CubeStacking>();
    }

    void FixedUpdate()
    {
        SetCubeRaycast();
    }

    private void SetCubeRaycast()
    {
        if(Physics.Raycast(transform.position, direction, out hit, 1f))
        {
            if(!isStack)
            {
                isStack = true;
                cubeStacking.IncreaseCubeStak(gameObject);
                SetDirection();
            }
            if(hit.transform.name == "Obstacle")
            {
                    cubeStacking.DecreaseCube(gameObject);
            }
        }
    }

    private void SetDirection()
    {
        direction = Vector3.forward;
    }
}
