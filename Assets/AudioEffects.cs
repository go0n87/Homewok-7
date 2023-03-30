using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEffects : MonoBehaviour
{
    public AudioClip audioClip;      

    public void PlaySoundClick()
    {
        GetComponent<AudioSource>().PlayOneShot(audioClip);
    }
}
