using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MoveCar : MonoBehaviour {


    public float speed = 10f, rotateSpeed = 50f;
    private Animator anim;

    private Rigidbody rb;

    private void Awake() {

        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void Update() {
        // Получаем данные от пользователя (нажатия на стрелочки или клавиши A и D)
        float moveHorizontal = Input.GetAxis("Horizontal");

        // Получаем данные от пользователя (нажатия на стрелочки или клавиши W и S)
        float moveVertical = Input.GetAxis("Vertical");

        // Вращаем объект без использования физики
        transform.Rotate(Vector3.up * rotateSpeed * moveHorizontal * Time.fixedDeltaTime);

        // Задаем траекторию, основываясь на данных от пользователя
        Vector3 movement = new Vector3(0.0f, 0.0f, moveVertical * speed);

        // Передвигаем объект при помощи функции MovePosition

        // Для создания передвижения относительно вращения используем transform.TransformDirection()
        // В неё передаем направление движения

        if (moveVertical > 0 || moveVertical < 0)
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }


        rb.MovePosition(transform.position + transform.TransformDirection(movement) * Time.fixedDeltaTime);

        
    }

}