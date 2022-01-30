using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillObstacle : MonoBehaviour
{
    //private ContactPoint contact;
    // Проверяем текущий размер если он больше определенного то удалаем рядом стоящие
    private void OnTriggerEnter(Collider other)
    {
       
        if (other.tag == "FireBall" || other.tag == "Player")
        
        {
            Destroy(gameObject);
            Destroy(other.gameObject);

        }
        
    }

    //если преграда контактирует с другой преградой и их задел триггер то удалять все контактирущие преграды при условии
    //что размер фаербола больше н числа трансформ
    //private void OnCollisionStay(Collision collision)
    //{
    //    foreach (ContactPoint contact in collision.contacts)
    //    {
    //        print(contact.thisCollider.name + " hit " + contact.otherCollider.name);
    //        Destroy(contact.thisCollider);
    //        Destroy(contact.otherCollider);

    //    }
    //}

}
