using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioSource intro;
    public AudioSource introloop;
    public AudioSource build;
    public AudioSource main;

    bool isLoopPlayed;
    bool isBuildPlayed;
    bool isBuildStopped;




    // Start is called before the first frame update
    void Start()
    {
        
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

        if (isBuildPlayed && !build.isPlaying)
        {
            //isBuildStopped = true;
            main.Play();
        }

        


    }
}
