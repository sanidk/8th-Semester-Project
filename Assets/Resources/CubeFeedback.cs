using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeFeedback : MonoBehaviour
{
    public AudioClip audioFeedback;
    AudioSource audioSource;
    public static int scoreStreak;
    public int scoreStreakV2;
    float previousScorestreak;
    public Color colour;
    //Outline outline;
    bool cubeHit;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //outline = GetComponent<Outline>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!cubeHit)
        {
            switch (scoreStreakV2)
            {
                case 1:
                    audioSource.pitch = 1.2f;
                    audioSource.PlayOneShot(audioFeedback, 0.55f);
                    //outline.OutlineColor = colour;
                    //outline.OutlineWidth = 1;
                    cubeHit = true;
                    break;
                case 2:
                    audioSource.pitch = 1.4f;
                    audioSource.PlayOneShot(audioFeedback, 0.6f);
                    //outline.OutlineColor = colour;
                    //outline.OutlineWidth = 2;
                    cubeHit = true;
                    break;
                case 3:
                    audioSource.pitch = 1.6f;
                    audioSource.PlayOneShot(audioFeedback, 0.65f);
                    //outline.OutlineColor = colour;
                    //outline.OutlineWidth = 3;
                    cubeHit = true;
                    break;
                case 4:
                    audioSource.pitch = 1.8f;
                    audioSource.PlayOneShot(audioFeedback, 0.7f);
                    //outline.OutlineColor = colour;
                    //outline.OutlineWidth = 4;
                    cubeHit = true;
                    break;
                case 5:
                    audioSource.pitch = 2f;
                    audioSource.PlayOneShot(audioFeedback, 0.75f);
                    //outline.OutlineColor = colour;
                    //outline.OutlineWidth = 5;
                    cubeHit = true;
                    break;
                case 6:
                    audioSource.pitch = 2.2f;
                    audioSource.PlayOneShot(audioFeedback, 0.8f);
                    //outline.OutlineColor = colour;
                    //outline.OutlineWidth = 6;
                    cubeHit = true;
                    break;
                case 7:
                    audioSource.pitch = 2.4f;
                    audioSource.PlayOneShot(audioFeedback, 0.85f);
                    //outline.OutlineColor = colour;
                    //outline.OutlineWidth = 7;
                    cubeHit = true;
                    break;
                case 8:
                    audioSource.pitch = 2.6f;
                    audioSource.PlayOneShot(audioFeedback, 0.9f);
                    //outline.OutlineColor = colour;
                    //outline.OutlineWidth = 8;
                    cubeHit = true;
                    break;
                case 9:
                    audioSource.pitch = 2.8f;
                    audioSource.PlayOneShot(audioFeedback, 0.95f);
                    //outline.OutlineColor = colour;
                    //outline.OutlineWidth = 9;
                    cubeHit = true;
                    break;
                case 10:
                    audioSource.pitch = 3.0f;
                    audioSource.PlayOneShot(audioFeedback, 1f);
                    //outline.OutlineColor = colour;
                    //outline.OutlineWidth = 10;
                    cubeHit = true;
                    break;
            }
        }

    }
}

