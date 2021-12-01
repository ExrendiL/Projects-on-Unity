using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class MoveCar : MonoBehaviour {

   
    public float speed = 30f, rotateSpeed = 50f;

  
    public GameObject frontLights, backLights;
   // public AudioSource moveForwardSound, moveBackSound;

    // Переменная что будет ссылаться на Rigidbody компонент
    private Rigidbody rb;

    private void Awake() {
        // Присваиваем значение в переменную rb
        rb = GetComponent<Rigidbody>();
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
        // Также можно передвигать объект через: rb.AddForce(movement * speed);
        // или же через значение velocity
        // Мы используем MovePosition, так как в ней легко указать, что объект
        // будет передвигаться вперед относительно его вращения

        // Для создания передвижения относительно вращения используем transform.TransformDirection()
        // В неё передаем направление движения
        rb.MovePosition(transform.position + transform.TransformDirection(movement) * Time.fixedDeltaTime);


        if (moveVertical > 0 && !frontLights.active)
        {
            frontLights.SetActive(true);
           // moveForwardSound.Play();

        }

        else if (moveVertical == 0 && frontLights.active || backLights.active)
        {
            frontLights.SetActive(false);
            backLights.SetActive(false);
          //  moveForwardSound.Stop();
           // moveBackSound.Stop();
        }
        

        if (moveVertical < 0 && !backLights.active)
        {
           
            backLights.SetActive(true);
        }
        
    }

}