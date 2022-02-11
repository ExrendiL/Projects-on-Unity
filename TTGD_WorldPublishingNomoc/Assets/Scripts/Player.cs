using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static int lives_count = 3;
    [SerializeField] private GameObject game_over;
    [SerializeField] private Text counter;
    [SerializeField] private GameObject player;
    [SerializeField] private Animation anim;

    private void Start()
    {
        lives_count = 3;
        anim = GetComponent<Animation>();
        counter.text = lives_count.ToString();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy_bullet" && lives_count != 0)
        {
            anim.Play();
            counter.text = lives_count.ToString();
        }
        else if (lives_count == 0 || lives_count< 0)
        {
            counter.text = lives_count.ToString();
            game_over.SetActive(true);
            Destroy(player);

        }
    }
}
