using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwingAudio : MonoBehaviour
{

    private Animator animator;
    public Vector3 previousPos;

    public float velocity;
    private AudioSource swingAudio;
    private Lighsaber lighsaber;
    public GameObject bladeObj;
    public GameObject LightSaberParentObj;
    private MeshRenderer bladeRenderer;
    private Color colorAlpha;
    //private Rigidbody LightSaberRigidBody;
    //private float speed;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        swingAudio = GetComponent<AudioSource>();
        lighsaber = GetComponentInParent<Lighsaber>();
        bladeRenderer = bladeObj.GetComponent<MeshRenderer>();
        //LightSaberRigidBody = LightSaberParentObj.GetComponent<Rigidbody>();
        swingAudio.Play();

    }

    // Update is called once per frame
    void Update()
    {
        //speed = LightSaberRigidBody.velocity.magnitude; //
        //speed = Remap(speed, 0, speed, 0, 1); //

        velocity = ((transform.TransformPoint(Vector3.zero) - previousPos).magnitude) / Time.deltaTime;
        previousPos = transform.TransformPoint(Vector3.zero);

        //animator.SetBool("isMoving", velocity > 0.2f);

        
        swingAudio.volume = Mathf.Clamp(velocity, 0, 1);
        colorAlpha = bladeRenderer.material.color;
        colorAlpha.a = Mathf.Clamp(velocity, 0, 1);
        bladeRenderer.material.color = colorAlpha;

        /*swingAudio.volume = speed;
        colorAlpha = bladeRenderer.material.color;
        colorAlpha.a = speed;
        bladeRenderer.material.color = colorAlpha;*/

    }

    public float Remap(float value, float from1, float to1, float from2, float to2)
    {
        return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }
}
