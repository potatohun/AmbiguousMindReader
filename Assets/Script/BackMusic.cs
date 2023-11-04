using UnityEngine;

public class BackMusic : MonoBehaviour
{
    AudioSource backMusic;
    public AudioClip[] clip = new AudioClip[2];

    public void SetMusic(bool rage)
    {
        backMusic = GetComponent<AudioSource>();
        if (rage)
        {
            backMusic.clip = clip[0];
            backMusic.pitch = 1.2f;
        }
        else
        {
            backMusic.clip = clip[1];
            backMusic.pitch = 1.0f;
        }
        backMusic.Play();
    }
}
