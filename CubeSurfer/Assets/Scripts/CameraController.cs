using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform heroTransform;

    private Vector3 offset;
    private Vector3 newPosition;

    [SerializeField] private float lerpValue ;

    void Start()
    {
        offset = transform.position - heroTransform.position;
    }

    
    void LateUpdate()
    {
        SetSoothFollowCamera();
    }

    private void SetSoothFollowCamera()
    {
        newPosition = Vector3.Lerp(transform.position, new Vector3(0f, heroTransform.position.y, heroTransform.position.z)+offset, lerpValue * Time.deltaTime);
        transform.position = newPosition;
    }
}
