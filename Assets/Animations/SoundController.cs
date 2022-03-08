using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    private VRAnimatorController animatorController;
    private AudioSource footstepSound;

    // Start is called before the first frame update
    void Start()
    {
        footstepSound = GetComponent<AudioSource>();
        animatorController = GetComponent<VRAnimatorController>();

        footstepSound.Play();
    }

    // Update is called once per frame
    void Update()
    {
        footstepSound.volume = Mathf.Clamp(animatorController.velocity, 0, 1);
    }
}
