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

    bool isIntroPlayed;
    bool isBuildPlayed;
    bool isBuildStopped;
    bool isMainPlaying;
    bool isStartBuild;
    bool buildStart;



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
        if (!intro.isPlaying && !isIntroPlayed)
        {
            introloop.Play();
            isIntroPlayed = true;
        }

        if (GameManagerLogic.isPlayersReady)
        {
            introloop.loop = false;
            isStartBuild = true;
            //introloop.isPlaying

        }

        if (!isBuildPlayed && !introloop.isPlaying && isStartBuild)
        {
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
