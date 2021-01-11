using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource AudioSource;

    private float musicVolume_f = 1f;

    // Start is called before the first frame update
    void Start()
    {
        AudioSource.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        AudioSource.volume = musicVolume_f;
    }
    public void updateVolume(float volume)
    {
        musicVolume_f = volume;
    }
}
