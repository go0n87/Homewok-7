using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource TrackPlayer;

    public AudioClip track1;
    public AudioClip track2;
    public AudioClip track3;

    private int numberOfTrack;

    void Start()
    {
        numberOfTrack = 1;
    }

    void Update()
    {
        if (!TrackPlayer.isPlaying)
        {

            if (numberOfTrack == 1)
            {
                GetComponent<AudioSource>().PlayOneShot(track1);
            }
            else if (numberOfTrack == 2)
            {
                GetComponent<AudioSource>().PlayOneShot(track2);
            }
            else if (numberOfTrack == 3)
            {
                GetComponent<AudioSource>().PlayOneShot(track3);
            }

            numberOfTrack = (numberOfTrack == 3 ? 1 : ++numberOfTrack);

        }
    }
}
