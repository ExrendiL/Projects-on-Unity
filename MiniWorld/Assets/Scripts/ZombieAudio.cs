using System.Collections;
using UnityEngine;

public class ZombieAudio : MonoBehaviour
{
    public AudioClip[] audio;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        StartCoroutine(spawnAudio());
    }

    IEnumerator spawnAudio()
    {
        while (true)
        {
            yield return new WaitForSeconds(8f);
            AudioClip nowAudio = audio[Random.Range(0, audio.Length)];
            audioSource.clip = nowAudio;
            audioSource.Play();
           
        }
    }
}
