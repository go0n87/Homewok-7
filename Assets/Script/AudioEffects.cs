using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEffects : MonoBehaviour
{
    public AudioClip audioClip;
    
    public GameObject  CurrentPanel;
    
    public AudioSource CurrentAudio;    

    private bool clickEvent   = false;    

    void Update()
    {
        if (!CurrentAudio.isPlaying && clickEvent)
        {
            CurrentPanel.SetActive(false);
            clickEvent = false;
        }

    }

    public void PlaySoundClick()
    {
        GetComponent<AudioSource>().PlayOneShot(audioClip);
    }

    public void PlaySoundAndClosePanel()
    {
        GetComponent<AudioSource>().PlayOneShot(audioClip);
        clickEvent = true;
    }
}
