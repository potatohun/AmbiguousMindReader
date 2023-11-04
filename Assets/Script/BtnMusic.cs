using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnMusic : MonoBehaviour
{
    AudioSource button;

    public AudioClip[] btn = new AudioClip[2];
    public void btnMusic(string str)
    {
        button = GetComponent<AudioSource>();
        if (str == "True")
        {
            button.clip = btn[0];
        }
        else
        {
            button.clip = btn[1];
        }
        button.Play();
    }
}
