using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class MoveBall : MonoBehaviour
{
    private Vector3 mousePressDown;
    private Vector3 mouseRelaease;
   
    private Rigidbody rb;
    
    private bool isShoot;

    private void Start()
    {
       rb = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        mousePressDown = Input.mousePosition;
 
    }

    private void OnMouseUp()
    {
        mouseRelaease = Input.mousePosition;
        Shoot(mousePressDown - mouseRelaease);
    }

    private float forceMult = 10;
    void Shoot(Vector3 Force)
    {
        if (isShoot)
            return;

        rb.AddForce(new Vector3(Force.x, Force.y, Force.y) * forceMult);
        isShoot = true;
    }


}
