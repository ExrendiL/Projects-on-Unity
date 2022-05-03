using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRotate : MonoBehaviour
{
    public Transform moon;
    public float earthSpeed = 10f, moonSpeed = 25f;

    private void Update()
    {
        transform.Rotate(Vector3.up *earthSpeed *Time.deltaTime);
        moon.RotateAround(transform.position, Vector3.up, moonSpeed * Time.deltaTime);
    }
}
