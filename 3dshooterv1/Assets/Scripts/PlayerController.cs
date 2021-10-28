using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float lookspeed = 5f;

    private PlayerMotor motor;

    void Update()
    {
        motor = GetComponent<PlayerMotor> ();
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");

        Vector3 movHor = transform.right*xMov;
        Vector3 movVer = transform.forward * zMov;

        Vector3 velocity = (movHor + movVer).normalized * speed; 
            motor.Move(velocity);

        float yRot = Input.GetAxisRaw("Mouse X");
        Vector3 rotation = new Vector3(0f, yRot, 0f)*lookspeed;
        motor.Rotate(rotation);

        float xRot = Input.GetAxisRaw("Mouse Y");
        Vector3 camRotation = new Vector3(xRot, 0f, 0f) * lookspeed;
        motor.RotateCam (camRotation);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 10f;
            lookspeed = 7f;
        }
        else
        {
            speed = 5f;
            lookspeed = 5f;
        }
    }

}
