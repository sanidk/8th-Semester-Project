using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource intro;
    public AudioSource introloop;
    public AudioSource build;
    public AudioSource main;

    float volume = 0.3f;

    bool isLoopPlayed;
    bool isBuildPlayed;
    bool isBuildStopped;
    bool isMainPlaying;




    // Start is called before the first frame update
    void Start()
    {
        intro.volume = volume;
        introloop.volume = volume;
        build.volume = volume;
        main.volume = volume;

    }

    // Update is called once per frame
    void Update()
    {
        if (!intro.isPlaying && !isLoopPlayed)
        {
            introloop.Play();
            isLoopPlayed = true;
        }

        if (GameManagerLogic.isPlayersReady && !isBuildPlayed)
        {
            introloop.loop = false;
            build.Play();
            isBuildPlayed = true;
            
        }

        if (isBuildPlayed && !build.isPlaying && !isMainPlaying)
        {
            isMainPlaying = true;
            //isBuildStopped = true;
            main.Play();

        }

        


    }
}
